// -------------------------------------------------------------------------------------------------
//  <copyright file="HtmlReportGeneratorTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Reporting.Tests.Generators
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using Reporting.Drawing;
    using Reporting.Generators;
    using Serilog;

    [TestFixture]
    public class HtmlReportGeneratorTestFixture
    {
        private ILoggerFactory loggerFactory;

        private InheritanceDiagramRenderer inheritanceDiagramRenderer;

        private AssociationDiagramRenderer associationDiagramRenderer;

        private HtmlReportGenerator htmlReportGenerator;

        private FileInfo umlModelFileInfo;

        private FileInfo sysml2ModelFileInfo;

        private FileInfo sysml2PimFileInfo;

        private FileInfo magicDrawFileInfo;

        private FileInfo eAExportFileInfo;

        [SetUp]
        public void SetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });

            this.inheritanceDiagramRenderer = new InheritanceDiagramRenderer(loggerFactory.CreateLogger<InheritanceDiagramRenderer>());
            this.associationDiagramRenderer = new AssociationDiagramRenderer(loggerFactory.CreateLogger<AssociationDiagramRenderer>());

            this.umlModelFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"));
            this.sysml2ModelFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));
            this.sysml2PimFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML2Pim.uml"));
            this.eAExportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "EAExport.xmi"));
            this.magicDrawFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "BallotDefinitionUMLModel.xml"));
        }

        [Test]
        public void Verify_that_the_report_generator_generates_a_report_of_uml()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var reportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "uml-html-report.html"));

            var pathmap = new Dictionary<string, string>();

            Assert.That(() => this.htmlReportGenerator.GenerateReport(this.umlModelFileInfo, this.umlModelFileInfo.Directory, "_0", "UML", true, pathmap, reportFileInfo), Throws.Nothing);
        }

        [Test]
        public void Verify_that_the_report_generator_generates_a_report_of_sysml2()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var reportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "sysml2-html-report.html"));

            var pathmap = new Dictionary<string, string>();
            pathmap.Add("pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml", Path.Combine("TestData", "PrimitiveTypes.xmi"));

            Assert.That(() => this.htmlReportGenerator.GenerateReport(this.sysml2ModelFileInfo, this.umlModelFileInfo.Directory, "_kUROkM9FEe6Zc_le1peNgQ", "sysml", true, pathmap, reportFileInfo), Throws.Nothing);
        }

        [Test]
        public void Verify_that_the_report_generator_generates_a_report_of_sysml2_with_Custom_html()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var reportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "sysml2-html-report.html"));

            var pathmap = new Dictionary<string, string>();
            pathmap.Add("pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml", Path.Combine("TestData", "PrimitiveTypes.xmi"));

            var customHtml = """
                             <div style="text-align: center;">
                             <H1>OMG SysML&#174; Version 2 <a href="https://github.com/Systems-Modeling/SysML-v2-Pilot-Implementation/blob/master/org.omg.sysml/model/SysML_xmi.uml" target="_blank" rel="noopener noreferrer">UML based Meta Model Documentation</a></H1>
                             <H3><a href="https://github.com/Systems-Modeling/SysML-v2-Pilot-Implementation/releases/tag/2025-06" target="_blank" rel="noopener noreferrer">Release 2025-06</a></H3>
                             <p class="small">Powered By <a href="https://www.stariongroup.eu" target="_blank" rel="noopener noreferrer">Starion Group</a>, 2022-2025</p>
                             <div>
                             """;

            Assert.That(() => this.htmlReportGenerator.GenerateReport(this.sysml2ModelFileInfo, this.umlModelFileInfo.Directory, "_kUROkM9FEe6Zc_le1peNgQ", "sysml", true, pathmap, reportFileInfo, customHtml), Throws.Nothing);
        }

        [Test]
        public void Verify_that_the_report_generator_generators_a_report_of_syml2pim()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            Extensions.PropertyExtensions.AddOrOverwriteCSharpTypeMappings(("ISO8601DateTime", "DateTime"));

            var reportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "sysml2-pim-html-report.html"));

            Assert.That(() => this.htmlReportGenerator.GenerateReport(this.sysml2PimFileInfo, this.umlModelFileInfo.Directory, "_19_0_4_3fa0198_1689000259946_865221_0", "Systems Modeling API and Services PIM", true, null, reportFileInfo), Throws.Nothing);
        }

        [Test]
        public void Verify_that_the_report_generator_generators_a_report_of_ea_model()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var reportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "EAExport.html"));

            Assert.That(() => this.htmlReportGenerator.GenerateReport(this.eAExportFileInfo, this.umlModelFileInfo.Directory, "", "EA_Model", true, null, reportFileInfo), Throws.Nothing);
        }

        [Test]
        public void Verify_that_the_report_generator_generators_a_report_of_md_model()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);
            
            var reportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "MDExport.html"));

            Assert.That(() => this.htmlReportGenerator.GenerateReport(this.magicDrawFileInfo, this.umlModelFileInfo.Directory, "", "Data", true, null, reportFileInfo), Throws.Nothing);
        }

        [Test]
        public void Verify_that_generated_html_report_contains_per_class_inheritance_diagrams()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var pathmap = new Dictionary<string, string>();

            var html = this.htmlReportGenerator.GenerateReport(this.umlModelFileInfo, this.umlModelFileInfo.Directory, "_0", "UML", true, pathmap);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(html, Is.Not.Null.And.Not.Empty);
                Assert.That(html, Does.Contain("inheritance-tree-"));
                Assert.That(html, Does.Contain("Inheritance Diagram"));
            }
        }

        [Test]
        public void Verify_that_generated_html_report_of_sysml2_contains_per_class_inheritance_diagrams()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var pathmap = new Dictionary<string, string>();
            pathmap.Add("pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml", Path.Combine("TestData", "PrimitiveTypes.xmi"));

            var html = this.htmlReportGenerator.GenerateReport(this.sysml2ModelFileInfo, this.umlModelFileInfo.Directory, "_kUROkM9FEe6Zc_le1peNgQ", "sysml", true, pathmap);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(html, Is.Not.Null.And.Not.Empty);
                Assert.That(html, Does.Contain("inheritance-tree-"));
                Assert.That(html, Does.Contain("Inheritance Diagram"));
            }
        }

        [Test]
        public void Verify_that_the_report_generator_throws_exception_when_modelpath_or_rootdirectory_are_null()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var reportFileInfo = new FileInfo("some-path");

            
            Assert.That(() => this.htmlReportGenerator.GenerateReport(null, null, "", "Data", true, null, reportFileInfo), Throws.ArgumentNullException);
            Assert.That(() => this.htmlReportGenerator.GenerateReport(this.magicDrawFileInfo, this.umlModelFileInfo.Directory, "", "Data", true, null,null, ""), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_generated_html_contains_collapsible_details_elements()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var pathmap = new Dictionary<string, string>();

            var html = this.htmlReportGenerator.GenerateReport(this.umlModelFileInfo, this.umlModelFileInfo.Directory, "_0", "UML", true, pathmap);

            Assert.That(html, Does.Contain("<details class=\"collapsible-section\""));
            Assert.That(html, Does.Contain("<summary>"));
            Assert.That(html, Does.Contain("</details>"));
        }

        [Test]
        public void Verify_that_generated_html_contains_collapsible_features_properties_and_rules_sections()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var pathmap = new Dictionary<string, string>();

            var html = this.htmlReportGenerator.GenerateReport(this.umlModelFileInfo, this.umlModelFileInfo.Directory, "_0", "UML", true, pathmap);

            Assert.That(html, Does.Contain("<summary><H4>Features</H4></summary>"));
            Assert.That(html, Does.Contain("<summary><H4>Properties</H4></summary>"));
            Assert.That(html, Does.Contain("<summary><H4>Rules</H4></summary>"));
            Assert.That(html, Does.Contain("<summary><H4>Enumeration Literals</H4></summary>"));
            Assert.That(html, Does.Contain("<summary><H3 id=\"InheritanceDiagram\">Inheritance Diagram</H3></summary>"));
        }

        [Test]
        public void Verify_that_class_sections_are_ordered_features_properties_rules()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var pathmap = new Dictionary<string, string>();

            var html = this.htmlReportGenerator.GenerateReport(this.umlModelFileInfo, this.umlModelFileInfo.Directory, "_0", "UML", true, pathmap);

            var classesStart = html.IndexOf("<H2 id=\"Classes\">");
            var interfacesStart = html.IndexOf("<H2 id=\"Interfaces\">");

            Assert.That(classesStart, Is.GreaterThan(-1), "Classes section not found");
            Assert.That(interfacesStart, Is.GreaterThan(-1), "Interfaces section not found");

            var classesSection = html.Substring(classesStart, interfacesStart - classesStart);

            var featuresIndex = classesSection.IndexOf("<summary><H4>Features</H4></summary>");
            var propertiesIndex = classesSection.IndexOf("<summary><H4>Properties</H4></summary>");
            var rulesIndex = classesSection.IndexOf("<summary><H4>Rules</H4></summary>");

            Assert.That(featuresIndex, Is.GreaterThan(-1), "Features section not found in Classes");
            Assert.That(propertiesIndex, Is.GreaterThan(-1), "Properties section not found in Classes");
            Assert.That(rulesIndex, Is.GreaterThan(-1), "Rules section not found in Classes");

            Assert.That(featuresIndex, Is.LessThan(propertiesIndex), "Features should appear before Properties");
            Assert.That(propertiesIndex, Is.LessThan(rulesIndex), "Properties should appear before Rules");
        }

        [Test]
        public void Verify_that_collapsible_sections_are_open_by_default()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var pathmap = new Dictionary<string, string>();

            var html = this.htmlReportGenerator.GenerateReport(this.umlModelFileInfo, this.umlModelFileInfo.Directory, "_0", "UML", true, pathmap);

            var openDetailsCount = Regex.Matches(html, "<details class=\"collapsible-section\" open>").Count;
            var closedDetailsCount = Regex.Matches(html, @"<details class=""collapsible-section"">\s*<summary><H[34][^>]*>(?:Inheritance|Association) Diagram</H[34]>").Count;

            Assert.That(openDetailsCount, Is.GreaterThan(0), "No open collapsible sections found");
            Assert.That(closedDetailsCount, Is.GreaterThan(0), "No inheritance diagram collapsible sections found");
            Assert.That(openDetailsCount + closedDetailsCount, Is.EqualTo(Regex.Matches(html, "<details class=\"collapsible-section\"").Count), "All collapsible sections should be either open or inheritance diagrams");
        }

        [Test]
        public void Verify_that_generated_html_contains_collapsible_section_css()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var pathmap = new Dictionary<string, string>();

            var html = this.htmlReportGenerator.GenerateReport(this.umlModelFileInfo, this.umlModelFileInfo.Directory, "_0", "UML", true, pathmap);

            Assert.That(html, Does.Contain("details.collapsible-section"));
            Assert.That(html, Does.Contain("cursor: pointer"));
        }

        [Test]
        public void Verify_that_QueryReportType_returns_html()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            Assert.That(this.htmlReportGenerator.QueryReportType(), Is.EqualTo("html"));
        }

        [Test]
        public void Verify_that_IsValidReportExtension_validates_correctly()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.inheritanceDiagramRenderer, this.associationDiagramRenderer, this.loggerFactory);

            var validResult = this.htmlReportGenerator.IsValidReportExtension(new FileInfo("report.html"));
            Assert.That(validResult.Item1, Is.True);

            var invalidResult = this.htmlReportGenerator.IsValidReportExtension(new FileInfo("report.pdf"));
            Assert.That(invalidResult.Item1, Is.False);

            Assert.That(() => this.htmlReportGenerator.IsValidReportExtension(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
