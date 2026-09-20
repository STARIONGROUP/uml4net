// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityNodeExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    [TestFixture]
    public class ActivityNodeExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_activityNode_is_null_argument_null_exception_is_thrown()
        {
            InitialNode activityNode = null;

            Assert.That(() => ActivityNodeExtensions.QueryInGroup(activityNode), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryInGroup_returns_empty_list_when_node_is_in_no_group()
        {
            var node = new InitialNode { Name = "Node" };

            Assert.That(node.InGroup, Is.Empty);
        }

        [Test]
        public void Verify_that_QueryInGroup_returns_the_ActivityPartitions_the_node_is_in()
        {
            var partition1 = new ActivityPartition { Name = "Partition1" };
            var partition2 = new ActivityPartition { Name = "Partition2" };

            var node = new InitialNode { Name = "Node" };
            node.InPartition.Add(partition1);
            node.InPartition.Add(partition2);

            Assert.That(node.InGroup, Is.EquivalentTo(new IActivityGroup[] { partition1, partition2 }));
        }

        [Test]
        public void Verify_that_QueryInGroup_returns_the_StructuredActivityNode_the_node_is_in()
        {
            var structuredActivityNode = new StructuredActivityNode { Name = "SAN" };

            var node = new InitialNode { Name = "Node", InStructuredNode = structuredActivityNode };

            Assert.That(node.InGroup, Is.EquivalentTo(new IActivityGroup[] { structuredActivityNode }));
        }

        [Test]
        public void Verify_that_QueryInGroup_combines_ActivityPartitions_and_StructuredActivityNode()
        {
            var partition = new ActivityPartition { Name = "Partition" };
            var structuredActivityNode = new StructuredActivityNode { Name = "SAN" };

            var node = new InitialNode { Name = "Node", InStructuredNode = structuredActivityNode };
            node.InPartition.Add(partition);

            Assert.That(node.InGroup, Is.EquivalentTo(new IActivityGroup[] { partition, structuredActivityNode }));
        }

        [Test]
        public void Verify_that_QueryInGroup_returns_the_InterruptibleActivityRegions_the_node_is_in()
        {
            var region = new InterruptibleActivityRegion { Name = "Region" };
            var otherRegion = new InterruptibleActivityRegion { Name = "OtherRegion" };

            var node = new InitialNode { Name = "Node" };
            node.InInterruptibleRegion.Add(region);
            node.InInterruptibleRegion.Add(otherRegion);

            Assert.That(node.InGroup, Is.EquivalentTo(new IActivityGroup[] { region, otherRegion }), "inInterruptibleRegion subsets inGroup");
        }

        [Test]
        public void Verify_that_QueryInGroup_combines_all_three_subsetting_properties()
        {
            var partition = new ActivityPartition { Name = "Partition" };
            var region = new InterruptibleActivityRegion { Name = "Region" };
            var structuredActivityNode = new StructuredActivityNode { Name = "SAN" };

            var node = new InitialNode { Name = "Node", InStructuredNode = structuredActivityNode };
            node.InPartition.Add(partition);
            node.InInterruptibleRegion.Add(region);

            Assert.That(node.InGroup, Is.EquivalentTo(new IActivityGroup[] { partition, region, structuredActivityNode }));
        }

        [Test]
        public void Verify_that_QueryInGroup_finds_the_StructuredActivityNode_through_the_owner_when_inStructuredNode_is_not_set()
        {
            // the reader does not populate ActivityNode::inStructuredNode, which subsets owner
            var structuredActivityNode = new StructuredActivityNode { Name = "SAN" };
            var node = new InitialNode { Name = "Node" };
            structuredActivityNode.Node.Add(node);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(node.InStructuredNode, Is.Null, "the owner end is not set");
                Assert.That(node.InGroup, Is.EquivalentTo(new IActivityGroup[] { structuredActivityNode }));
            }
        }
    }
}
