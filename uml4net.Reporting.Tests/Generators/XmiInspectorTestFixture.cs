// -------------------------------------------------------------------------------------------------
// <copyright file="XmiInspectorTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Reporting.Tests.Generators
{
    using System;
    using System.IO;

    using Microsoft.Extensions.Logging;
    
    using NUnit.Framework;
    
    using Serilog;
    
    using uml4net.Reporting.Generators;

    [TestFixture]
    public class XmiInspectorTestFixture
    {
        private ILoggerFactory loggerFactory;

        private XmiInspector xmiInspector;

        private FileInfo umlModelFileInfo;

        private FileInfo sysml2ModelFileInfo;

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

            this.umlModelFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"));
            this.sysml2ModelFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));
        }

        [Test]
        public void Verify_that_the_report_generator_generates_a_report_of_uml()
        {
            this.xmiInspector = new XmiInspector(this.loggerFactory);

            Assert.That(() =>
            {
                var result = this.xmiInspector.Inspect(this.umlModelFileInfo);
                Console.WriteLine(result);

            }, Throws.Nothing);
        }

        [Test]
        public void Verify_that_the_report_generator_generates_a_report_of_sysml2()
        {
            this.xmiInspector = new XmiInspector(this.loggerFactory);

            Assert.That(() =>
            {
                var result = this.xmiInspector.Inspect(this.sysml2ModelFileInfo);
                Console.WriteLine(result);

            }, Throws.Nothing);
        }

        [Test]
        public void Verify_that_elements_without_attributes_are_omitted_from_the_report()
        {
            var xmi = """
                      <?xml version="1.0" encoding="utf-8"?>
                      <root>
                        <withAttributes id="1" name="foo" />
                        <withoutAttributes />
                      </root>
                      """;

            var inputFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "attribute-less-inspection-input.xmi"));
            File.WriteAllText(inputFileInfo.FullName, xmi);

            this.xmiInspector = new XmiInspector(this.loggerFactory);

            var result = this.xmiInspector.Inspect(inputFileInfo);

            using (Assert.EnterMultipleScope())
            {
                // elements that carry attributes are reported as "element: attr attr"
                Assert.That(result, Is.EqualTo("withAttributes: id name"));

                // the attribute-less "root" and "withoutAttributes" elements are intentionally omitted
                Assert.That(result, Does.Not.Contain("withoutAttributes"));
                Assert.That(result, Does.Not.Contain("root"));
            }
        }
    }
}