// -------------------------------------------------------------------------------------------------
// <copyright file="SysML2.XmiReaderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
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
    using uml4net.StructuredClassifiers;
    using uml4net.Packages;
    using uml4net.xmi;
    using Serilog;
    using System.Collections.Generic;

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

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SystemsModelingAPIandServicesPIM.xmi"));

            Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(2));

            var model = xmiReaderResult.Root as IModel;

            Assert.That(model.XmiId, Is.EqualTo("_19_0_4_3fa0198_1689000259946_865221_0"));
            Assert.That(model.Name, Is.EqualTo("Systems Modeling API and Services PIM"));
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

            Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(4));

            var model = xmiReaderResult.Root as IModel;

            Assert.That(model.XmiId, Is.EqualTo("_19_0_4_3fa0198_1689000259946_865221_0"));
            Assert.That(model.Name, Is.EqualTo("Systems Modeling API and Services PIM"));
        }
    }
}
