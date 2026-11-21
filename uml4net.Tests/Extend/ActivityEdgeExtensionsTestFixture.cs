// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityEdgeExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.Actions;
    using uml4net.Activities;

    [TestFixture]
    public class ActivityEdgeExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_activityEdge_is_null_argument_null_exception_is_thrown()
        {
            ControlFlow activityEdge = null;

            Assert.That(() => ActivityEdgeExtensions.QueryInGroup(activityEdge), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryInGroup_returns_empty_list_when_edge_is_in_no_group()
        {
            var edge = new ControlFlow { Name = "Edge" };

            Assert.That(edge.InGroup, Is.Empty);
        }

        [Test]
        public void Verify_that_QueryInGroup_returns_the_ActivityPartitions_the_edge_is_in()
        {
            var partition1 = new ActivityPartition { Name = "Partition1" };
            var partition2 = new ActivityPartition { Name = "Partition2" };

            var edge = new ControlFlow { Name = "Edge" };
            edge.InPartition.Add(partition1);
            edge.InPartition.Add(partition2);

            Assert.That(edge.InGroup, Is.EquivalentTo(new IActivityGroup[] { partition1, partition2 }));
        }

        [Test]
        public void Verify_that_QueryInGroup_returns_the_StructuredActivityNode_the_edge_is_in()
        {
            var structuredActivityNode = new StructuredActivityNode { Name = "SAN" };

            var edge = new ControlFlow { Name = "Edge", InStructuredNode = structuredActivityNode };

            Assert.That(edge.InGroup, Is.EquivalentTo(new IActivityGroup[] { structuredActivityNode }));
        }

        [Test]
        public void Verify_that_QueryInGroup_combines_ActivityPartitions_and_StructuredActivityNode()
        {
            var partition = new ActivityPartition { Name = "Partition" };
            var structuredActivityNode = new StructuredActivityNode { Name = "SAN" };

            var edge = new ControlFlow { Name = "Edge", InStructuredNode = structuredActivityNode };
            edge.InPartition.Add(partition);

            Assert.That(edge.InGroup, Is.EquivalentTo(new IActivityGroup[] { partition, structuredActivityNode }));
        }

        [Test]
        public void Verify_that_QueryInGroup_finds_the_StructuredActivityNode_through_the_owner_when_inStructuredNode_is_not_set()
        {
            // the reader does not populate ActivityEdge::inStructuredNode, which subsets owner
            var structuredActivityNode = new StructuredActivityNode { Name = "SAN" };
            var edge = new ControlFlow { Name = "Edge" };
            structuredActivityNode.Edge.Add(edge);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(edge.InStructuredNode, Is.SameAs(structuredActivityNode), "the containment sets the owner end");
                Assert.That(edge.InGroup, Is.EquivalentTo(new IActivityGroup[] { structuredActivityNode }));
            }
        }
    }
}
