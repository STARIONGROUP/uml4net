// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityGroupExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using NUnit.Framework;

    using uml4net.Actions;
    using uml4net.Activities;

    [TestFixture]
    public class ActivityGroupExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_activityGroup_is_null_argument_null_exception_is_thrown()
        {
            ActivityPartition activityGroup = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => ActivityGroupExtensions.QueryContainedEdge(activityGroup), Throws.ArgumentNullException);
                Assert.That(() => ActivityGroupExtensions.QueryContainedNode(activityGroup), Throws.ArgumentNullException);
                Assert.That(() => ActivityGroupExtensions.QuerySubgroup(activityGroup), Throws.ArgumentNullException);
                Assert.That(() => ActivityGroupExtensions.QuerySuperGroup(activityGroup), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_ActivityPartition_contributes_edge_node_subgroup_and_superGroup()
        {
            var parent = new ActivityPartition { Name = "Parent" };
            var child = new ActivityPartition { Name = "Child", SuperPartition = parent };
            parent.Subpartition.Add(child);

            var edge = new ControlFlow { Name = "Edge" };
            var node = new InitialNode { Name = "Node" };
            parent.Edge.Add(edge);
            parent.Node.Add(node);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(parent.ContainedEdge, Is.EquivalentTo(new[] { edge }));
                Assert.That(parent.ContainedNode, Is.EquivalentTo(new[] { node }));
                Assert.That(parent.Subgroup.ToList(), Is.EquivalentTo(new[] { child }));
                Assert.That(child.SuperGroup, Is.SameAs(parent));
                Assert.That(parent.SuperGroup, Is.Null);
                Assert.That(child.Subgroup, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_InterruptibleActivityRegion_contributes_node_but_not_edge_subgroup_or_superGroup()
        {
            var region = new InterruptibleActivityRegion { Name = "Region" };

            var node = new ActivityFinalNode { Name = "Node" };
            region.Node.Add(node);

            var interruptingEdge = new ControlFlow { Name = "InterruptingEdge" };
            region.InterruptingEdge.Add(interruptingEdge);

            using (Assert.EnterMultipleScope())
            {
                // interruptingEdge does not subset containedEdge per the UML 2.5.1 metamodel
                Assert.That(region.ContainedEdge, Is.Empty);
                Assert.That(region.ContainedNode, Is.EquivalentTo(new[] { node }));
                Assert.That(region.Subgroup, Is.Empty);
                Assert.That(region.SuperGroup, Is.Null);
            }
        }

        [Test]
        public void Verify_that_StructuredActivityNode_contributes_edge_and_node_but_not_subgroup_or_superGroup()
        {
            var structuredActivityNode = new StructuredActivityNode { Name = "SAN" };

            var edge = new ControlFlow { Name = "Edge" };
            var node = new InitialNode { Name = "Node" };
            structuredActivityNode.Edge.Add(edge);
            structuredActivityNode.Node.Add(node);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(structuredActivityNode.ContainedEdge, Is.EquivalentTo(new[] { edge }));
                Assert.That(structuredActivityNode.ContainedNode, Is.EquivalentTo(new[] { node }));
                Assert.That(structuredActivityNode.Subgroup, Is.Empty);
                Assert.That(structuredActivityNode.SuperGroup, Is.Null);
            }
        }
    }
}
