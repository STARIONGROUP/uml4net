// -------------------------------------------------------------------------------------------------
//  <copyright file="InheritanceDiagramRendererTestFixture.cs" company="Starion Group S.A.">
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
    public class InheritanceDiagramRendererTestFixture
    {
        private ILoggerFactory loggerFactory;

        private InheritanceDiagramRenderer inheritanceDiagramRenderer;

        private FileInfo umlModelFileInfo;

        private FileInfo sysml2ModelFileInfo;

        private FileInfo sysml2PimFileInfo;

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

            this.inheritanceDiagramRenderer = new InheritanceDiagramRenderer(loggerFactory.CreateLogger<InheritanceDiagramRenderer>());

            this.umlModelFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"));
            this.sysml2ModelFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));
            this.sysml2PimFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML2Pim.uml"));
        }

        [Test]
        public void Verify_that_SVG_inheritance_diagram_can_be_created_For_UML()
        {
            var xmiReaderResult = this.LoadModel("UML.xmi");

            var svg = this.inheritanceDiagramRenderer.SvgRender(xmiReaderResult, "_0", "UML");

            Log.Logger.Information(svg);

            Assert.That(svg, Is.Not.Empty);
        }

        [Test]
        public void Verify_that_SVG_inheritance_diagram_can_be_rendered_to_stream_for_UML()
        {
            var xmiReaderResult = this.LoadModel("UML.xmi");

            using var stream = new MemoryStream();
            this.inheritanceDiagramRenderer.SvgRender(xmiReaderResult, "_0", "UML", stream);

            Assert.That(stream.Length, Is.GreaterThan(0));
        }

        [Test]
        public void Verify_that_SvgRenderForClass_returns_svg_with_highlighted_target_class()
        {
            var xmiReaderResult = this.LoadModel("UML.xmi");

            var payload = HandlebarsPayloadFactory.CreateHandlebarsPayload(xmiReaderResult, "_0", "UML");

            var targetClass = payload.Classes.First(c => c.Name == "Behavior");

            var svg = this.inheritanceDiagramRenderer.SvgRenderForClass(targetClass, payload);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(svg, Is.Not.Null.And.Not.Empty);
                Assert.That(svg, Does.Contain("<svg"));
                Assert.That(svg, Does.Contain($"id=\"inheritance-tree-{targetClass.XmiId}\""));
                Assert.That(svg, Does.Contain(targetClass.Name));
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_returns_svg_for_leaf_class_with_no_descendants()
        {
            var xmiReaderResult = this.LoadModel("UML.xmi");

            var payload = HandlebarsPayloadFactory.CreateHandlebarsPayload(xmiReaderResult, "_0", "UML");

            var targetClass = payload.Classes.First(c => c.Name == "FunctionBehavior");

            var svg = this.inheritanceDiagramRenderer.SvgRenderForClass(targetClass, payload);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(svg, Is.Not.Null.And.Not.Empty);
                Assert.That(svg, Does.Contain("<svg"));
                Assert.That(svg, Does.Contain(targetClass.Name));
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_returns_svg_for_root_class_with_no_ancestors()
        {
            var xmiReaderResult = this.LoadModel("UML.xmi");

            var payload = HandlebarsPayloadFactory.CreateHandlebarsPayload(xmiReaderResult, "_0", "UML");

            var targetClass = payload.Classes.First(c => c.Name == "Element");

            var svg = this.inheritanceDiagramRenderer.SvgRenderForClass(targetClass, payload);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(svg, Is.Not.Null.And.Not.Empty);
                Assert.That(svg, Does.Contain("<svg"));
                Assert.That(svg, Does.Contain("Element"));
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
