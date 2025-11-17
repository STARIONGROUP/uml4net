// -------------------------------------------------------------------------------------------------
//  <copyright file="EnterpriseArchitectExtenderReaderTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Tests.Extender
{
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Extender;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Extensions;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Structure;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Structure.Readers;

    using Path = System.IO.Path;

    [TestFixture]
    public class EnterpriseArchitectExtenderReaderTestFixture
    {
        private ILoggerFactory loggerFactory;

        [Test]
        public void VerifyCanReadEnterpriseArchitectExtension()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithExtender<EnterpriseArchitectExtenderReader>()
                .WithExtensionContentReaderFacade<ExtensionContentReaderFacade>()
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "EAExport.xmi"));

            var element = xmiReaderResult.Packages[0].NestedPackage[0].PackagedElement.Single(x => x is Class { Name: "Element" })as Class;
            var attribute = element!.OwnedAttribute[0];
            var secondAttribute = element!.OwnedAttribute[1];
            var operation = element!.OwnedOperation[0];
            var operationParameter = operation.OwnedParameter[0];
            var returnParameter = operation.OwnedParameter.Single(x => x.Direction == ParameterDirectionKind.Return);
            var associationParameters = element!.OwnedAttribute.Where(x => x.Association != null);
            var elementWithTags = xmiReaderResult.Packages[0].NestedPackage[0].NestedPackage[0].PackagedElement.Single(x => x is Class { Name: "ClassWithTaggedValues" })as Class;
            var extensionElement = xmiReaderResult.XmiRoot.Extensions.SelectMany(x => x.Content).OfType<Element>().Single(x => x.ExtendedElement == elementWithTags);
            var tags = extensionElement.Tags;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(attribute.OwnedComment.Single().Body, Is.EqualTo("An documentation for an attribute"));
                Assert.That(element.OwnedComment.Single().Body, Is.EqualTo("An Enterprise Architect documentation"));
                Assert.That(secondAttribute.OwnedComment.Single().Body, Is.EqualTo("A note from EA"));
                Assert.That(operation.OwnedComment.Single().Body, Is.EqualTo("The operation also have documentation"));
                Assert.That(operationParameter.OwnedComment.Single().Body, Is.EqualTo("The parameter documentation"));
                Assert.That(returnParameter.OwnedComment.Single().Body, Is.EqualTo("Return value"));
                Assert.That(attribute.IsID, Is.True);
                Assert.That(secondAttribute.IsID, Is.False);

                foreach (var associationParameter in associationParameters)
                {
                    Assert.That(associationParameter.OwnedComment.Single().Body, Is.EqualTo($"A doc for {associationParameter.Name}"));
                }

                Assert.That(tags, Has.Count.EqualTo(2));
                Assert.That(tags[0].Name, Is.EqualTo("EAUML::PackageRef"));
                Assert.That(tags[0].Value, Is.EqualTo("{A059C88E-4BDF-46ec-9651-03CBB56A4410}"));
                Assert.That(tags[1].Name, Is.EqualTo("SearchName"));
                Assert.That(tags[1].Value, Is.EqualTo("Extended"));
                Assert.That(element.QueryAppliedStereotypes(), Has.Count.EqualTo(1));
            }
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder => { builder.AddSerilog(); });
        }
    }
}
