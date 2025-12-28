// -------------------------------------------------------------------------------------------------
//  <copyright file="InheritanceDiagramRendererTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Reporting.Tests.Drawing
{
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;
    using Reporting.Generators;
    using Serilog;
    using System.Collections.Generic;
    using System.IO;
    using uml4net.Reporting.Drawing;
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
