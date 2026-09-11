// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierHelperTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.HandleBars.Tests
{
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using HandlebarsDotNet;
    using HandlebarsDotNet.Helpers;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Suite of tests for the <see cref="ClassifierHelper"/> class
    /// </summary>
    [TestFixture]
    public class ClassifierHelperTestFixture
    {
        private IHandlebars handlebarsContext;

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

            this.xmiReaderResult = reader.Read(Path.Combine(rootPath, "UML.xmi"));

            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;

            HandlebarsHelpers.Register(this.handlebarsContext);
            ClassifierHelper.RegisterClassifierHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_that_QueryContainers_returns_expected_result()
        {
            var template = "{{#each (Classifier.QueryContainers this) as | container |}}{{ container.Name }};{{/each}}";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var valuesPackage = root.NestedPackage.Single(x => x.Name == "Values");
            var opaqueExpression = valuesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "OpaqueExpression");

            var result = action(opaqueExpression);

            Assert.That(result, Does.Contain("Abstraction;"));
        }

        [Test]
        public void Verify_that_QueryContainers_throws_when_context_is_invalid()
        {
            var template = "{{#each (Classifier.QueryContainers this) as | container |}}{{ container.Name }};{{/each}}";

            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(5), Throws.ArgumentException);
        }
    }
}
