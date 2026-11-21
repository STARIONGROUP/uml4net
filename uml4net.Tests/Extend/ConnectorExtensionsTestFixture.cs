// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ConnectorExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_connector_is_null_argument_exception_is_thrown()
        {
            Connector connector = null;

            Assert.That(() => ConnectorExtensions.QueryKind(connector), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_a_connector_between_two_parts_properties_is_an_assembly()
        {
            var connector = new Connector();

            var end1 = new ConnectorEnd { Role = new Property { Name = "part1" } };
            var end2 = new ConnectorEnd { Role = new Property { Name = "part2" } };

            connector.End.Add(end1);
            connector.End.Add(end2);

            Assert.That(connector.Kind, Is.EqualTo(ConnectorKind.Assembly));
        }

        [Test]
        public void Verify_that_a_connector_to_a_non_behavior_port_of_the_owning_classifier_is_a_delegation()
        {
            var connector = new Connector();

            var outerPort = new Port { Name = "outerPort", IsBehavior = false };

            var end1 = new ConnectorEnd { Role = outerPort };
            var end2 = new ConnectorEnd { Role = new Property { Name = "part1" } };

            connector.End.Add(end1);
            connector.End.Add(end2);

            Assert.That(connector.Kind, Is.EqualTo(ConnectorKind.Delegation));
        }

        [Test]
        public void Verify_that_a_connector_to_a_behavior_port_of_the_owning_classifier_is_an_assembly()
        {
            // per the OCL, "not role.isBehavior" is required for delegation - a behavior Port does not qualify,
            // even though it is a Port directly on the owning classifier (partWithPort is empty).
            var connector = new Connector();

            var behaviorPort = new Port { Name = "behaviorPort", IsBehavior = true };

            var end1 = new ConnectorEnd { Role = behaviorPort };
            var end2 = new ConnectorEnd { Role = new Property { Name = "part1" } };

            connector.End.Add(end1);
            connector.End.Add(end2);

            Assert.That(connector.Kind, Is.EqualTo(ConnectorKind.Assembly));
        }

        [Test]
        public void Verify_that_a_connector_to_a_port_on_an_internal_part_is_an_assembly()
        {
            // the Port role is attached via partWithPort (an internal Part), not directly on the owning classifier,
            // so it does not qualify for delegation even though it is a non-behavior Port.
            var connector = new Connector();

            var innerPort = new Port { Name = "innerPort", IsBehavior = false };

            var end1 = new ConnectorEnd { Role = innerPort, PartWithPort = new Property { Name = "internalPart" } };
            var end2 = new ConnectorEnd { Role = new Property { Name = "part1" } };

            connector.End.Add(end1);
            connector.End.Add(end2);

            Assert.That(connector.Kind, Is.EqualTo(ConnectorKind.Assembly));
        }
    }
}
