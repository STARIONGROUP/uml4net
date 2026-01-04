// -------------------------------------------------------------------------------------------------
// <copyright file="SysML2.XmiReaderTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;
    
    using Serilog;

    using uml4net.CommonStructure;
    using uml4net.Extensions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    
    using uml4net.xmi;

    [TestFixture]
    public class SystemsModelingAPIandServicesPIMXmiReaderTestFixture
    {
        private ILoggerFactory loggerFactory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        [Test]
        public void Verify_that_SystemsModelingAPIandServicesPIM_XMI_without_acces_to_Kerml_can_be_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData",
                "SystemsModelingAPIandServicesPIM.xmi"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);
                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(2));

                var model = xmiReaderResult.QueryRoot("_19_0_4_3fa0198_1689000259946_865221_0") as IModel;

                Assert.That(model.XmiId, Is.EqualTo("_19_0_4_3fa0198_1689000259946_865221_0"));
                Assert.That(model.Name, Is.EqualTo("Systems Modeling API and Services PIM"));
            }
        }

        [Test]
        public void Verify_that_SystemsModelingAPIandServicesPIM_XMI_with_acces_to_Kerml_can_be_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SystemsModelingAPIandServicesPIM.xmi"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(4));

                var model = xmiReaderResult.QueryRoot("_19_0_4_3fa0198_1689000259946_865221_0") as IModel;

                Assert.That(model.XmiId, Is.EqualTo("_19_0_4_3fa0198_1689000259946_865221_0"));
                Assert.That(model.Name, Is.EqualTo("Systems Modeling API and Services PIM"));

                var interfaces = model.QueryPackages().SelectMany(x => x.PackagedElement.OfType<IInterface>());

                var data = interfaces.Single(x => x.Name == "Data");

                Assert.That(interfaces.Count(), Is.EqualTo(1));

                var realizations = model.QueryPackages().SelectMany(x => x.PackagedElement.OfType<IRealization>());

                var externalRelationship = model.QueryPackages().SelectMany(x => x.PackagedElement.OfType<IClass>())
                    .Single(x => x.Name == "ExternalRelationship");

                var externalRelationshipInterface = externalRelationship.QueryInterfaces().Single();

                Assert.That(externalRelationshipInterface, Is.EqualTo(data));
            }
        }
    }
}
