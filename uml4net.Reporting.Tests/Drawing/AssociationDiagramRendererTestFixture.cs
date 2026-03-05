// -------------------------------------------------------------------------------------------------
//  <copyright file="AssociationDiagramRendererTestFixture.cs" company="Starion Group S.A.">
//
//    Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.Reporting.Tests.Drawing
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Reporting.Drawing;
    using uml4net.Reporting.Payload;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class AssociationDiagramRendererTestFixture
    {
        private ILoggerFactory loggerFactory;

        private AssociationDiagramRenderer associationDiagramRenderer;

        [SetUp]
        public void SetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });

            this.associationDiagramRenderer = new AssociationDiagramRenderer(loggerFactory.CreateLogger<AssociationDiagramRenderer>());
        }

        [Test]
        public void Verify_that_SvgRenderForClass_returns_svg_for_class_with_associations()
        {
            var xmiReaderResult = this.LoadModel("UML.xmi");

            var payload = HandlebarsPayloadFactory.CreateHandlebarsPayload(xmiReaderResult, "_0", "UML");

            var targetClass = payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, payload);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(svg, Is.Not.Null.And.Not.Empty);
                Assert.That(svg, Does.Contain("<svg"));
                Assert.That(svg, Does.Contain($"id=\"association-diagram-{targetClass.XmiId}\""));
                Assert.That(svg, Does.Contain(targetClass.Name));
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_returns_svg_containing_multiplicity()
        {
            var xmiReaderResult = this.LoadModel("UML.xmi");

            var payload = HandlebarsPayloadFactory.CreateHandlebarsPayload(xmiReaderResult, "_0", "UML");

            var targetClass = payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, payload);

            Assert.That(svg, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void Verify_that_SvgRenderForClass_returns_empty_for_class_with_no_associations()
        {
            var xmiReaderResult = this.LoadModel("UML.xmi");

            var payload = HandlebarsPayloadFactory.CreateHandlebarsPayload(xmiReaderResult, "_0", "UML");

            var targetClass = payload.Classes.FirstOrDefault(c =>
                !c.OwnedAttribute.Any(p => p.Type is IClass tc && payload.Classes.Contains(tc))
                && !payload.Classes.Any(other => other != c && other.OwnedAttribute.Any(p => p.Type == c)));

            if (targetClass != null)
            {
                var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, payload);

                Assert.That(svg, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_returns_svg_for_behavior_class()
        {
            var xmiReaderResult = this.LoadModel("UML.xmi");

            var payload = HandlebarsPayloadFactory.CreateHandlebarsPayload(xmiReaderResult, "_0", "UML");

            var targetClass = payload.Classes.First(c => c.Name == "Behavior");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, payload);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(svg, Is.Not.Null.And.Not.Empty);
                Assert.That(svg, Does.Contain("<svg"));
                Assert.That(svg, Does.Contain("Behavior"));
            }
        }

        /// <summary>
        /// loads a UML model and returns an <see cref="XmiReaderResult"/>
        /// </summary>
        /// <param name="name">
        /// the name of the Uml model, e.g. UML.xmi
        /// </param>
        /// <returns>
        /// The <see cref="XmiReaderResult"/> that contains the content of a UML model
        /// </returns>
        private XmiReaderResult LoadModel(string name)
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var pathMaps = new Dictionary<string, string>
            {
                ["pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml"] =
                    Path.Combine(rootPath, "PrimitiveTypes.xmi")
            };

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = rootPath;
                    x.PathMaps = pathMaps;
                })
                .WithLogger(loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData",
                name));

            return xmiReaderResult;
        }
    }
}
