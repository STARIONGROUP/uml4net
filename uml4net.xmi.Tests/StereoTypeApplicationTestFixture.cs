// -------------------------------------------------------------------------------------------------
//  <copyright file="StereoTypeApplicationTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests
{
    using System.IO;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.xmi;

    [TestFixture]
    public class StereoTypeApplicationTestFixture
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
        public void Verify_that_UML_MagicDraw_BallotDefinition__XMI_can_be_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = rootPath;
                    x.UseStrictReading = true;
                })
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData",
                "BallotDefinition UML Model - without xmi extensions.xml"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);
                Assert.That(xmiReaderResult.XmiRoot.Documentation.Exporter, Is.EqualTo("MagicDraw UML"));
                Assert.That(xmiReaderResult.XmiRoot.Documentation.ExporterVersion, Is.EqualTo("19.0 v9"));
                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(2));

                var rootPackage = xmiReaderResult.QueryRoot("eee_1045467100313_135436_1");

                Assert.That(rootPackage.Name, Is.EqualTo("Data"));
                Assert.That(rootPackage.PackagedElement.Count, Is.EqualTo(3));

                Assert.That(xmiReaderResult.XmiRoot.StereoTypeApplications.Count, Is.EqualTo(91));

                var stereoTypeApplication = xmiReaderResult.XmiRoot.StereoTypeApplications[1];

                Assert.That(stereoTypeApplication.ProfileName, Is.EqualTo("MagicDraw_Profile"));
                Assert.That(stereoTypeApplication.StereoTypeName, Is.EqualTo("DiagramInfo"));
                Assert.That(stereoTypeApplication.XmiId, Is.EqualTo("_17_0_2_4_78e0236_1389366179332_904249_2289"));
                Assert.That(stereoTypeApplication.MetaClass, Is.EqualTo("Diagram"));
                Assert.That(stereoTypeApplication.ElementIdentifier, Is.EqualTo("_17_0_2_4_78e0236_1389366179320_546130_2278"));

                stereoTypeApplication.Attributes.TryGetValue("Author", out var author);
                Assert.That(author, Is.EqualTo("s.dana"));

                stereoTypeApplication.Attributes.TryGetValue("Creation_date", out var creationDate);
                Assert.That(creationDate, Is.EqualTo("1/10/14 10:02 AM"));

                stereoTypeApplication.Attributes.TryGetValue("Last_modified_by", out var lastModifiedBy);
                Assert.That(lastModifiedBy, Is.EqualTo("pro"));

                stereoTypeApplication.Attributes.TryGetValue("Modification_date", out var modificationDate);
                Assert.That(modificationDate, Is.EqualTo("9/14/22 9:07 AM"));
            }
        }
    }
}
