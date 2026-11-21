// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorEndExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    public class ConnectorEndExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_connectorEnd_is_null_argument_exception_is_thrown()
        {
            ConnectorEnd connectorEnd = null;

            Assert.That(() => ConnectorEndExtensions.QueryDefiningEnd(connectorEnd), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_DefiningEnd_returns_null_when_the_connectorEnd_has_no_owning_connector()
        {
            var connectorEnd = new ConnectorEnd { Role = new Property { Name = "part1" } };

            Assert.That(connectorEnd.DefiningEnd, Is.Null);
        }

        [Test]
        public void Verify_that_DefiningEnd_returns_null_when_the_owning_connector_has_no_type()
        {
            var connector = new Connector();

            var end1 = new ConnectorEnd { Role = new Property { Name = "part1" } };
            var end2 = new ConnectorEnd { Role = new Property { Name = "part2" } };

            connector.End.Add(end1);
            connector.End.Add(end2);

            Assert.That(end1.DefiningEnd, Is.Null);
        }

        [Test]
        public void Verify_that_DefiningEnd_returns_the_memberEnd_at_the_matching_position()
        {
            var connector = new Connector();

            var end1 = new ConnectorEnd { Role = new Property { Name = "part1" } };
            var end2 = new ConnectorEnd { Role = new Property { Name = "part2" } };

            connector.End.Add(end1);
            connector.End.Add(end2);

            var memberEnd1 = new Property { Name = "associationEnd1" };
            var memberEnd2 = new Property { Name = "associationEnd2" };

            connector.Type = new Association
            {
                Name = "AssociationType",
                MemberEnd = { memberEnd1, memberEnd2 }
            };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(end1.DefiningEnd, Is.SameAs(memberEnd1));
                Assert.That(end2.DefiningEnd, Is.SameAs(memberEnd2));
            }
        }
    }
}
