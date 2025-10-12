// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtendedElementExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Tests.Extensions
{
    using System;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Extensions;
    using uml4net.xmi.Extensions.EntrepriseArchitect.Structure;

    using Association = StructuredClassifiers.Association;
    using Attribute = EntrepriseArchitect.Structure.Attribute;
    using Connector = EntrepriseArchitect.Structure.Connector;
    using ConnectorEnd = EntrepriseArchitect.Structure.ConnectorEnd;

    [TestFixture]
    public class ExtendedElementExtensionsTestFixture
    {
        [Test]
        public void Verify_that_hwen_null_throws_exception()
        {
            Assert.That(() => ExtendedElementExtensions.QueryDocumentationFromExtensions(null), Throws.ArgumentNullException);
        }

        [Test]
        public void QueryDocumentationFromExtensions_ReturnsDocumentationFromExtendedElements()
        {
            var classElement = new Class();
            var extensionElement = new Element();
            extensionElement.Properties.Add(new ElementProperties { Documentation = "From properties" });
            var attributeExtension = new Attribute();
            attributeExtension.Documentation.Add(new Documentation { Value = "From documentation" });

            classElement.Extensions.Add(extensionElement);
            classElement.Extensions.Add(attributeExtension);

            var documentation = classElement.QueryDocumentationFromExtensions();

            Assert.That(documentation, Is.EqualTo($"From properties{Environment.NewLine}From documentation"));
        }

        [Test]
        public void QueryDocumentationFromExtensions_ReturnsDocumentationFromAssociationConnector()
        {
            var property = new Property { XmiId = "src123" };
            var association = new Association();
            property.Association = association;

            var connectorEnd = new ConnectorEnd();
            connectorEnd.Documentation.Add(new Documentation { Value = "Connector doc" });
            var connector = new Connector();
            connector.Source.Add(connectorEnd);

            association.Extensions.Add(connector);

            var documentation = property.QueryDocumentationFromExtensions();

            Assert.That(documentation, Is.EqualTo("Connector doc"));
        }
    }
}
