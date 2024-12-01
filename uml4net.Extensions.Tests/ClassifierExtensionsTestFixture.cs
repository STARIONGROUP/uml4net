// -------------------------------------------------------------------------------------------------
//  <copyright file="ClassifierExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using xmi.Readers;

    [TestFixture]
    public class ClassifierExtensionsTestFixture
    {
        private ILoggerFactory loggerFactory;

        private XmiReaderResult xmiReaderResult;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
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
        }

        [Test]
        public void Verify_that_QueryAllGeneralClassifiers_returns_expected_result()
        {
            var commonStructuresPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "CommonStructure");

            var dependency = commonStructuresPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Dependency");

            // Dependency -> DirectedRelationship -> Relationship         -> Element
            //               PackageableElement   -> ParameterableElement -> Element
            //                                    -> NamedElement         -> Element

            var classifiers = dependency.QueryAllGeneralClassifiers();

            foreach (var classifier in classifiers)
            {
                Log.Logger.Information(classifier.Name);
            }


            Assert.That(classifiers.Count, Is.EqualTo(7));
        }
    }
}