// -------------------------------------------------------------------------------------------------
//  <copyright file="GeneralizationHelperTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.HandleBars.Tests
{
    using System;
    using System.IO;
    using System.Globalization;
    using System.Linq;

    using HandlebarsDotNet;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class GeneralizationHelperTestFixture
    {
        private IHandlebars handlebarsContenxt;

        private ILoggerFactory loggerFactory;

        private XmiReaderResult xmiReaderResult;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder => { builder.AddSerilog(); });
        }

        [SetUp]
        public void SetUp()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            this.xmiReaderResult = reader.Read(Path.Combine(rootPath, "SystemsModelingAPIandServicesPIM.xmi"));

            this.handlebarsContenxt = Handlebars.Create();
            this.handlebarsContenxt.Configuration.FormatProvider = CultureInfo.InvariantCulture;

            GeneralizationHelper.RegisterGeneralizationHelper(this.handlebarsContenxt);
        }

        [Test]
        public void Verify_that_expected_interface_implementation_is_written_as_expected()
        {
            var template = "{{ #Generalization.Interfaces this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_19_0_4_3fa0198_1689000259946_865221_0", name: "Systems Modeling API and Services PIM");

            var apiModelPackage = root.NestedPackage.Single(x => x.Name == "API_Model");

            var project = apiModelPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Project");

            var interfaces = handlebarsTemplate(project);

            Assert.That(interfaces, Is.EqualTo(": IRecord"));
        }

        [Test]
        public void Verify_that_expected_interface_implementation_throws_exception_when_not_provided_with_class()
        {
            var template = "{{ #Generalization.Interfaces this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_19_0_4_3fa0198_1689000259946_865221_0", name: "Systems Modeling API and Services PIM");

            var apiModelPackage = root.NestedPackage.Single(x => x.Name == "API_Model");

            var project = apiModelPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Project");
            var property = project.OwnedAttribute.First();

            Assert.That(() => handlebarsTemplate(property), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_expected_interface_implementation_and_interfaces_are_written_as_expected()
        {
            var template = "{{ #Generalization.InterfaceImplementationAndInterfaces this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_19_0_4_3fa0198_1689000259946_865221_0", name: "Systems Modeling API and Services PIM");

            var apiModelPackage = root.NestedPackage.Single(x => x.Name == "API_Model");

            var project = apiModelPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Project");

            var interfaces = handlebarsTemplate(project);

            Assert.That(interfaces, Is.EqualTo(": IRecord"));
        }

        [Test]
        public void Verify_that_expected_interface_implementation_and_interfaces_throws_exception_when_not_provided_with_class()
        {
            var template = "{{ #Generalization.InterfaceImplementationAndInterfaces this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_19_0_4_3fa0198_1689000259946_865221_0", name: "Systems Modeling API and Services PIM");

            var apiModelPackage = root.NestedPackage.Single(x => x.Name == "API_Model");

            var project = apiModelPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Project");
            var property = project.OwnedAttribute.First();

            Assert.That(() => handlebarsTemplate(property), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_expected_class_implementation_is_written_as_expected()
        {
            var template = "{{ #Generalization.Classes this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_19_0_4_3fa0198_1689000259946_865221_0", name: "Systems Modeling API and Services PIM");

            var apiModelPackage = root.NestedPackage.Single(x => x.Name == "API_Model");

            var project = apiModelPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Project");

            var classes = handlebarsTemplate(project);

            Assert.That(classes, Is.EqualTo(": IProject"));
        }

        [Test]
        public void Verify_that_expected_class_implementation_throws_exception_when_not_provided_with_class()
        {
            var template = "{{ #Generalization.Classes this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_19_0_4_3fa0198_1689000259946_865221_0", name: "Systems Modeling API and Services PIM");

            var apiModelPackage = root.NestedPackage.Single(x => x.Name == "API_Model");

            var project = apiModelPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Project");
            var property = project.OwnedAttribute.First();

            Assert.That(() => handlebarsTemplate(property), Throws.TypeOf<ArgumentException>());
        }
    }
}
