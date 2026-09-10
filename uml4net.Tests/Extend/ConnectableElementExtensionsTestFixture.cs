// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectableElementExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ConnectableElementExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_connectableElement_is_null_argument_exception_is_thrown()
        {
            Property connectableElement = null;

            Assert.That(() => ConnectableElementExtensions.QueryEnd(connectableElement), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_End_is_empty_when_the_connectableElement_is_attached_to_no_connector()
        {
            var part = new Property { Name = "part" };

            Assert.That(part.End, Is.Empty);
        }

        [Test]
        public void Verify_that_End_finds_the_ConnectorEnds_whose_role_is_the_connectableElement()
        {
            var package = new Package { Name = "Package" };
            var owningClass = new Class { Name = "Owner" };
            package.PackagedElement.Add(owningClass);

            var part1 = new Property { Name = "part1" };
            var part2 = new Property { Name = "part2" };
            owningClass.OwnedAttribute.Add(part1);
            owningClass.OwnedAttribute.Add(part2);

            var connector = new Connector { Name = "Connector" };
            owningClass.OwnedConnector.Add(connector);

            var end1 = new ConnectorEnd { Role = part1 };
            var end2 = new ConnectorEnd { Role = part2 };
            connector.End.Add(end1);
            connector.End.Add(end2);

            Assert.That(part1.End, Is.EquivalentTo(new[] { end1 }));
        }

        [Test]
        public void Verify_that_End_does_not_return_ConnectorEnds_attached_to_a_different_connectableElement()
        {
            var package = new Package { Name = "Package" };
            var owningClass = new Class { Name = "Owner" };
            package.PackagedElement.Add(owningClass);

            var part1 = new Property { Name = "part1" };
            var part2 = new Property { Name = "part2" };
            owningClass.OwnedAttribute.Add(part1);
            owningClass.OwnedAttribute.Add(part2);

            var connector = new Connector { Name = "Connector" };
            owningClass.OwnedConnector.Add(connector);

            var end1 = new ConnectorEnd { Role = part1 };
            connector.End.Add(end1);

            Assert.That(part2.End, Is.Empty);
        }

        [Test]
        public void Verify_that_End_finds_ConnectorEnds_owned_by_a_sibling_classifier_reachable_from_the_same_root()
        {
            var package = new Package { Name = "Package" };

            var partOwner = new Class { Name = "PartOwner" };
            package.PackagedElement.Add(partOwner);

            var part = new Property { Name = "part" };
            partOwner.OwnedAttribute.Add(part);

            var connectorOwner = new Class { Name = "ConnectorOwner" };
            package.PackagedElement.Add(connectorOwner);

            var connector = new Connector { Name = "Connector" };
            connectorOwner.OwnedConnector.Add(connector);

            var end = new ConnectorEnd { Role = part };
            connector.End.Add(end);

            Assert.That(part.End, Is.EquivalentTo(new[] { end }));
        }
    }
}
