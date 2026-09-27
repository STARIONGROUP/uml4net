// -------------------------------------------------------------------------------------------------
// <copyright file="ActionExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Interactions;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ActionExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_action_is_null_argument_exception_is_thrown()
        {
            CallOperationAction action = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => ActionExtensions.QueryContext(action), Throws.ArgumentNullException);
                Assert.That(() => ActionExtensions.QueryInput(action), Throws.ArgumentNullException);
                Assert.That(() => ActionExtensions.QueryOutput(action), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_Context_returns_null_when_the_action_has_neither_an_Activity_nor_a_containing_StructuredActivityNode()
        {
            var action = new CallOperationAction();

            Assert.That(action.Context, Is.Null);
        }

        [Test]
        public void Verify_that_Context_is_resolved_through_the_directly_containing_Activity()
        {
            var owningClass = new Class { Name = "Owner" };
            var activity = new Activity { Name = "Activity" };
            owningClass.OwnedBehavior.Add(activity);

            var action = new CallOperationAction { Activity = activity };

            Assert.That(action.Context, Is.SameAs(owningClass));
        }

        [Test]
        public void Verify_that_Context_is_resolved_through_a_containing_StructuredActivityNode()
        {
            var owningClass = new Class { Name = "Owner" };
            var activity = new Activity { Name = "Activity" };
            owningClass.OwnedBehavior.Add(activity);

            var structuredActivityNode = new StructuredActivityNode { Activity = activity };

            var action = new CallOperationAction { InStructuredNode = structuredActivityNode };

            Assert.That(action.Context, Is.SameAs(owningClass));
        }

        [Test]
        public void Verify_that_Context_is_the_containing_Behavior_itself_when_that_Behavior_has_no_context()
        {
            var activity = new Activity { Name = "Standalone" };
            var action = new CallOperationAction { Activity = activity };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(activity.Context, Is.Null);
                Assert.That(action.Context, Is.SameAs(activity), "if behavior.context = null then behavior");
            }
        }

        [Test]
        public void Verify_that_Context_is_resolved_through_the_owner_when_the_owner_ends_are_not_set()
        {
            // the reader does not populate ActivityNode::activity and ActivityNode::inStructuredNode, which subset owner
            var owningClass = new Class { Name = "Owner" };
            var activity = new Activity { Name = "Activity" };
            owningClass.OwnedBehavior.Add(activity);

            var outerNode = new StructuredActivityNode { Name = "outer" };
            var innerNode = new LoopNode { Name = "inner" };
            var nestedAction = new CallOperationAction { Name = "nested" };
            var directAction = new OpaqueAction { Name = "direct" };

            activity.StructuredNode.Add(outerNode);
            outerNode.Node.Add(innerNode);
            innerNode.Node.Add(nestedAction);
            activity.Node.Add(directAction);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(nestedAction.InStructuredNode, Is.SameAs(innerNode), "the containment sets the owner end");
                Assert.That(nestedAction.QueryContainingBehavior(), Is.SameAs(activity), "through two levels of StructuredActivityNodes");
                Assert.That(nestedAction.Context, Is.SameAs(owningClass));
                Assert.That(innerNode.Context, Is.SameAs(owningClass));
                Assert.That(outerNode.Context, Is.SameAs(owningClass));
                Assert.That(directAction.Context, Is.SameAs(owningClass));
            }
        }

        [Test]
        public void Verify_that_Context_of_an_Action_owned_by_an_Interaction_is_resolved_through_the_Interaction()
        {
            var owningClass = new Class { Name = "Owner" };
            var interaction = new Interaction { Name = "Interaction" };
            owningClass.OwnedBehavior.Add(interaction);

            var action = new OpaqueAction { Name = "action" };
            interaction.Action.Add(action);

            var standaloneInteraction = new Interaction { Name = "Standalone" };
            var standaloneAction = new OpaqueAction { Name = "standaloneAction" };
            standaloneInteraction.Action.Add(standaloneAction);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(action.QueryContainingBehavior(), Is.SameAs(interaction));
                Assert.That(action.Context, Is.SameAs(owningClass));
                Assert.That(standaloneAction.Context, Is.SameAs(standaloneInteraction));
            }
        }

        [Test]
        public void Verify_that_QueryContainingBehavior_throws_for_null_and_is_null_for_an_action_without_a_Behavior()
        {
            CallOperationAction nullAction = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => ActionExtensions.QueryContainingBehavior(nullAction), Throws.ArgumentNullException);
                Assert.That(new CallOperationAction().QueryContainingBehavior(), Is.Null);
            }
        }

        [Test]
        public void Verify_that_Input_unions_the_pins_of_every_subsetting_property()
        {
            var argument = new InputPin { Name = "argument" };
            var target = new InputPin { Name = "target" };

            var action = new CallOperationAction();
            action.Argument.Add(argument);
            action.Target.Add(target);

            Assert.That(action.Input, Is.EquivalentTo(new[] { argument, target }));
        }

        [Test]
        public void Verify_that_Input_includes_the_pins_of_a_property_that_redefines_a_subsetting_property()
        {
            // SendObjectAction::request redefines InvocationAction::argument
            var request = new InputPin { Name = "request" };
            var target = new InputPin { Name = "target" };

            var sendObjectAction = new SendObjectAction();
            sendObjectAction.Request.Add(request);
            sendObjectAction.Target.Add(target);

            // LoopNode::loopVariableInput redefines StructuredActivityNode::structuredNodeInput
            var loopVariableInput = new InputPin { Name = "loopVariableInput" };

            var loopNode = new LoopNode();
            loopNode.LoopVariableInput.Add(loopVariableInput);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(sendObjectAction.Input, Is.EquivalentTo(new[] { request, target }));
                Assert.That(loopNode.Input, Is.EquivalentTo(new[] { loopVariableInput }));
            }
        }

        [Test]
        public void Verify_that_Output_includes_the_pins_of_a_property_that_redefines_a_subsetting_property()
        {
            // LoopNode::result and ConditionalNode::result redefine StructuredActivityNode::structuredNodeOutput
            var loopResult = new OutputPin { Name = "loopResult" };
            var conditionalResult = new OutputPin { Name = "conditionalResult" };
            var structuredNodeOutput = new OutputPin { Name = "structuredNodeOutput" };

            var loopNode = new LoopNode();
            loopNode.Result.Add(loopResult);

            var conditionalNode = new ConditionalNode();
            conditionalNode.Result.Add(conditionalResult);

            var structuredActivityNode = new StructuredActivityNode();
            structuredActivityNode.StructuredNodeOutput.Add(structuredNodeOutput);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(loopNode.Output, Is.EquivalentTo(new[] { loopResult }));
                Assert.That(conditionalNode.Output, Is.EquivalentTo(new[] { conditionalResult }));
                Assert.That(structuredActivityNode.Output, Is.EquivalentTo(new[] { structuredNodeOutput }));
            }
        }

        [Test]
        public void Verify_that_Input_and_Output_union_every_subsetting_property_of_an_action_with_several()
        {
            var first = new InputPin { Name = "first" };
            var second = new InputPin { Name = "second" };
            var result = new OutputPin { Name = "result" };

            var testIdentityAction = new TestIdentityAction();
            testIdentityAction.First.Add(first);
            testIdentityAction.Second.Add(second);
            testIdentityAction.Result.Add(result);

            var @object = new InputPin { Name = "object" };
            var value = new InputPin { Name = "value" };
            var insertAt = new InputPin { Name = "insertAt" };
            var writeResult = new OutputPin { Name = "result" };

            var addStructuralFeatureValueAction = new AddStructuralFeatureValueAction();
            addStructuralFeatureValueAction.Object.Add(@object);
            addStructuralFeatureValueAction.Value.Add(value);
            addStructuralFeatureValueAction.InsertAt.Add(insertAt);
            addStructuralFeatureValueAction.Result.Add(writeResult);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(testIdentityAction.Input, Is.EquivalentTo(new[] { first, second }));
                Assert.That(testIdentityAction.Output, Is.EquivalentTo(new[] { result }));
                Assert.That(addStructuralFeatureValueAction.Input, Is.EquivalentTo(new[] { @object, value, insertAt }), "the pins of StructuralFeatureAction, WriteStructuralFeatureAction and AddStructuralFeatureValueAction");
                Assert.That(addStructuralFeatureValueAction.Output, Is.EquivalentTo(new[] { writeResult }));
            }
        }

        [Test]
        public void Verify_that_Input_and_Output_can_be_read_for_every_concrete_Action()
        {
            var actions = new IAction[]
            {
                new AcceptCallAction(), new AcceptEventAction(), new AddStructuralFeatureValueAction(), new AddVariableValueAction(),
                new BroadcastSignalAction(), new CallBehaviorAction(), new CallOperationAction(), new ClearAssociationAction(),
                new ClearStructuralFeatureAction(), new ClearVariableAction(), new ConditionalNode(), new CreateLinkAction(),
                new CreateLinkObjectAction(), new CreateObjectAction(), new DestroyLinkAction(), new DestroyObjectAction(),
                new ExpansionRegion(), new LoopNode(), new OpaqueAction(), new RaiseExceptionAction(), new ReadExtentAction(),
                new ReadIsClassifiedObjectAction(), new ReadLinkAction(), new ReadLinkObjectEndAction(),
                new ReadLinkObjectEndQualifierAction(), new ReadSelfAction(), new ReadStructuralFeatureAction(),
                new ReadVariableAction(), new ReclassifyObjectAction(), new ReduceAction(), new RemoveStructuralFeatureValueAction(),
                new RemoveVariableValueAction(), new ReplyAction(), new SendObjectAction(), new SendSignalAction(), new SequenceNode(),
                new StartClassifierBehaviorAction(), new StartObjectBehaviorAction(), new StructuredActivityNode(),
                new TestIdentityAction(), new UnmarshallAction(), new ValueSpecificationAction()
            };

            using (Assert.EnterMultipleScope())
            {
                foreach (var action in actions)
                {
                    Assert.That(() => action.Input, Throws.Nothing, action.GetType().Name);
                    Assert.That(() => action.Output, Throws.Nothing, action.GetType().Name);
                    Assert.That(action.Input, Is.Empty, action.GetType().Name);
                    Assert.That(action.Output, Is.Empty, action.GetType().Name);
                }
            }
        }

        [Test]
        public void Verify_that_Input_is_empty_when_no_subsetting_property_has_pins()
        {
            var action = new CallOperationAction();

            Assert.That(action.Input, Is.Empty);
        }

        [Test]
        public void Verify_that_Output_unions_the_pins_of_every_subsetting_property()
        {
            var result = new OutputPin { Name = "result" };

            var action = new CallOperationAction();
            action.Result.Add(result);

            Assert.That(action.Output, Is.EquivalentTo(new[] { result }));
        }
    }
}
