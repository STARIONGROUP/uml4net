// -------------------------------------------------------------------------------------------------
//  <copyright file="EnterpriseArchitectModelTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Packages;
    using uml4net.xmi;

    [TestFixture]
    public class EnterpriseArchitectModelTestFixture
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
        public void Verify_that_EnterpriseArchitect_XMI_can_be_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult =
                reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "EAExport.xmi"));

            using (Assert.EnterMultipleScope())
            {

                Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);
                Assert.That(xmiReaderResult.XmiRoot.Documentation.Exporter, Is.EqualTo("Enterprise Architect"));
                Assert.That(xmiReaderResult.XmiRoot.Documentation.ExporterVersion, Is.EqualTo("6.5"));
                Assert.That(xmiReaderResult.XmiRoot.Documentation.ExporterID, Is.EqualTo("1704"));
                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(2));

                var model = xmiReaderResult.QueryRoot(null, "EA_Model") as IModel;

                Assert.That(model.Name, Is.EqualTo("EA_Model"));
                Assert.That(model.NestedPackage.Count, Is.EqualTo(1));
            }
        }
    }
}
