// -------------------------------------------------------------------------------------------------
//  <copyright file="MagicDrawModelEclipseExportWithPathMapTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.SimpleClassifiers;
    using uml4net.xmi;

    [TestFixture]
    public class MagicDrawModelEclipseExportWithPathMapTestFixture
    {
        private ILoggerFactory loggerFactory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        [Test]
        public void Verify_that_UML_MagicDrawExportToEclipseModel_With_PrimitiveTypes_in_PathMap_XMI_can_be_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.UseStrictReading = false;
                    x.LocalReferenceBasePath = rootPath;
                    x.PathMaps = new Dictionary<string, string>
                    {
                        ["pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml"] =
                            Path.Combine("TestData", "PrimitiveTypes.xmi")
                    };
                })
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData",
                "GH142_Eclipse_export.uml"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);

                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(2));

                var rootPackage = xmiReaderResult.QueryRoot("eee_1045467100313_135436_1");

                Assert.That(rootPackage.Name, Is.EqualTo("Model"));
                Assert.That(rootPackage.PackageImport.Count, Is.EqualTo(2));
                Assert.That(rootPackage.PackagedElement.Count, Is.EqualTo(2));

                var primitiveTypes = xmiReaderResult.Packages.Single(x => x.Name == "PrimitiveTypes");

                var booleanPrimitiveType = primitiveTypes.PackagedElement.OfType<IPrimitiveType>()
                    .Single(x => x.XmiId == "Boolean");

                Assert.That(booleanPrimitiveType.Name, Is.EqualTo("Boolean"));

                var comment = booleanPrimitiveType.OwnedComment.Single();

                Assert.That(comment.AnnotatedElement, Contains.Item(booleanPrimitiveType));
            }
        }
    }
}
