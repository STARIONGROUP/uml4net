// -------------------------------------------------------------------------------------------------
// <copyright file="VertexExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.StateMachines;

    [TestFixture]
    public class VertexExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_vertex_is_null_argument_null_exception_is_thrown()
        {
            State vertex = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => VertexExtensions.QueryIncoming(vertex), Throws.ArgumentNullException);
                Assert.That(() => VertexExtensions.QueryOutgoing(vertex), Throws.ArgumentNullException);
                Assert.That(() => VertexExtensions.QueryRedefinitionContext(vertex), Throws.ArgumentNullException);
                Assert.That(() => VertexExtensions.QueryContainingStateMachine(vertex), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_a_vertex_without_container_or_pseudostate_kind_has_no_containing_stateMachine()
        {
            var orphan = new State { Name = "Orphan" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(VertexExtensions.QueryContainingStateMachine(orphan), Is.Null);
                Assert.That(orphan.RedefinitionContext, Is.Null);
                Assert.That(orphan.Incoming, Is.Empty);
                Assert.That(orphan.Outgoing, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_Incoming_and_Outgoing_and_RedefinitionContext_are_resolved_for_a_top_level_region()
        {
            var stateMachine = new StateMachine { Name = "SM" };
            var region = new Region { Name = "R", StateMachine = stateMachine };
            stateMachine.Region.Add(region);

            var source = new State { Name = "Source", Container = region };
            var target = new State { Name = "Target", Container = region };
            region.Subvertex.Add(source);
            region.Subvertex.Add(target);

            var transition = new Transition { Name = "T", Source = source, Target = target };
            region.Transition.Add(transition);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(source.Outgoing, Is.EquivalentTo(new[] { transition }));
                Assert.That(source.Incoming, Is.Empty);
                Assert.That(target.Incoming, Is.EquivalentTo(new[] { transition }));
                Assert.That(target.Outgoing, Is.Empty);
                Assert.That(source.RedefinitionContext, Is.SameAs(stateMachine));
                Assert.That(target.RedefinitionContext, Is.SameAs(stateMachine));
            }
        }

        [Test]
        public void Verify_that_Incoming_and_Outgoing_are_resolved_through_a_nested_composite_State_region()
        {
            var stateMachine = new StateMachine { Name = "SM" };
            var topRegion = new Region { Name = "TopRegion", StateMachine = stateMachine };
            stateMachine.Region.Add(topRegion);

            var compositeState = new State { Name = "Composite", Container = topRegion };
            topRegion.Subvertex.Add(compositeState);

            var nestedRegion = new Region { Name = "NestedRegion", State = compositeState };
            compositeState.Region.Add(nestedRegion);

            var source = new State { Name = "NestedSource", Container = nestedRegion };
            var target = new State { Name = "NestedTarget", Container = nestedRegion };
            nestedRegion.Subvertex.Add(source);
            nestedRegion.Subvertex.Add(target);

            var transition = new Transition { Name = "NestedTransition", Source = source, Target = target };
            nestedRegion.Transition.Add(transition);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(source.Outgoing, Is.EquivalentTo(new[] { transition }));
                Assert.That(target.Incoming, Is.EquivalentTo(new[] { transition }));
                Assert.That(source.RedefinitionContext, Is.SameAs(stateMachine));
            }
        }

        [Test]
        public void Verify_that_Incoming_and_Outgoing_are_resolved_for_entry_and_exit_points_owned_by_a_composite_State()
        {
            var stateMachine = new StateMachine { Name = "SM" };
            var topRegion = new Region { Name = "TopRegion", StateMachine = stateMachine };
            stateMachine.Region.Add(topRegion);

            var before = new State { Name = "Before", Container = topRegion };
            var compositeState = new State { Name = "Composite", Container = topRegion };
            var after = new State { Name = "After", Container = topRegion };
            topRegion.Subvertex.Add(before);
            topRegion.Subvertex.Add(compositeState);
            topRegion.Subvertex.Add(after);

            // State::connectionPoint: Pseudostate::state is set, container and stateMachine are not
            var entryPoint = new Pseudostate { Name = "entry", Kind = PseudostateKind.EntryPoint, State = compositeState };
            var exitPoint = new Pseudostate { Name = "exit", Kind = PseudostateKind.ExitPoint, State = compositeState };
            compositeState.ConnectionPoint.Add(entryPoint);
            compositeState.ConnectionPoint.Add(exitPoint);

            var enter = new Transition { Name = "enter", Source = before, Target = entryPoint };
            var leave = new Transition { Name = "leave", Source = exitPoint, Target = after };
            topRegion.Transition.Add(enter);
            topRegion.Transition.Add(leave);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(entryPoint.Incoming, Is.EquivalentTo(new[] { enter }), "the transition that enters the entry point lives in the region of the enclosing StateMachine");
                Assert.That(entryPoint.Outgoing, Is.Empty);
                Assert.That(exitPoint.Outgoing, Is.EquivalentTo(new[] { leave }));
                Assert.That(exitPoint.Incoming, Is.Empty);
                Assert.That(entryPoint.QueryContainingStateMachine(), Is.SameAs(stateMachine));
                Assert.That(exitPoint.RedefinitionContext, Is.SameAs(stateMachine));
            }
        }

        [Test]
        public void Verify_that_Incoming_and_Outgoing_are_resolved_through_the_owner_when_the_owner_ends_are_not_set()
        {
            // the reader does not populate Vertex::container, Region::stateMachine, Region::state, Pseudostate::state,
            // Pseudostate::stateMachine and ConnectionPointReference::state, which all subset owner
            var stateMachine = new StateMachine { Name = "SM" };
            var topRegion = new Region { Name = "TopRegion" };
            stateMachine.Region.Add(topRegion);

            var machineEntryPoint = new Pseudostate { Name = "machineEntry", Kind = PseudostateKind.EntryPoint };
            stateMachine.ConnectionPoint.Add(machineEntryPoint);

            var compositeState = new State { Name = "Composite" };
            var submachineState = new State { Name = "Submachine" };
            topRegion.Subvertex.Add(compositeState);
            topRegion.Subvertex.Add(submachineState);

            var stateEntryPoint = new Pseudostate { Name = "stateEntry", Kind = PseudostateKind.EntryPoint };
            compositeState.ConnectionPoint.Add(stateEntryPoint);

            var connectionPointReference = new ConnectionPointReference { Name = "reference" };
            submachineState.Connection.Add(connectionPointReference);

            var nestedRegion = new Region { Name = "NestedRegion" };
            compositeState.Region.Add(nestedRegion);
            var nested = new State { Name = "Nested" };
            nestedRegion.Subvertex.Add(nested);

            var toStateEntry = new Transition { Name = "toStateEntry", Source = machineEntryPoint, Target = stateEntryPoint };
            var toReference = new Transition { Name = "toReference", Source = compositeState, Target = connectionPointReference };
            var toNested = new Transition { Name = "toNested", Source = stateEntryPoint, Target = nested };
            topRegion.Transition.Add(toStateEntry);
            topRegion.Transition.Add(toReference);
            nestedRegion.Transition.Add(toNested);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(nested.Container, Is.Null, "the owner end is not set");
                Assert.That(machineEntryPoint.Outgoing, Is.EquivalentTo(new[] { toStateEntry }));
                Assert.That(stateEntryPoint.Incoming, Is.EquivalentTo(new[] { toStateEntry }));
                Assert.That(stateEntryPoint.Outgoing, Is.EquivalentTo(new[] { toNested }), "a transition owned by the nested region");
                Assert.That(connectionPointReference.Incoming, Is.EquivalentTo(new[] { toReference }));
                Assert.That(compositeState.Outgoing, Is.EquivalentTo(new[] { toReference }));
                Assert.That(nested.Incoming, Is.EquivalentTo(new[] { toNested }));
                Assert.That(nested.QueryContainingStateMachine(), Is.SameAs(stateMachine));
                Assert.That(nestedRegion.QueryContainingStateMachine(), Is.SameAs(stateMachine));
                Assert.That(connectionPointReference.RedefinitionContext, Is.SameAs(stateMachine));
            }
        }

        [Test]
        public void Verify_that_containingStateMachine_is_resolved_for_an_entryPoint_pseudostate_without_a_container()
        {
            var stateMachine = new StateMachine { Name = "SM" };

            var entryPoint = new Pseudostate { Name = "Entry", Kind = PseudostateKind.EntryPoint, StateMachine = stateMachine };

            Assert.That(entryPoint.RedefinitionContext, Is.SameAs(stateMachine));
        }

        [Test]
        public void Verify_that_containingStateMachine_is_resolved_for_a_connectionPointReference_through_its_state()
        {
            var stateMachine = new StateMachine { Name = "SM" };
            var region = new Region { Name = "R", StateMachine = stateMachine };
            stateMachine.Region.Add(region);

            var submachineState = new State { Name = "Submachine", Container = region };
            region.Subvertex.Add(submachineState);

            var connectionPointReference = new ConnectionPointReference { Name = "CPR", State = submachineState };

            Assert.That(connectionPointReference.RedefinitionContext, Is.SameAs(stateMachine));
        }
    }
}
