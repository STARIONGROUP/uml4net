// -------------------------------------------------------------------------------------------------
// <copyright file="SysML2.XmiReaderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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
    public class SysML2XmiReaderTestFixture
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
        public void Verify_that_SysML_XMI_can_be_read()
        {
            var reader = XmiReaderBuilder.Create()
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));

            Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(1));

            var model = xmiReaderResult.Root as IModel;

            Assert.That(model.XmiId, Is.EqualTo("_kUROkM9FEe6Zc_le1peNgQ"));
            Assert.That(model.Name, Is.EqualTo("sysml"));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Verify_that_SysML_XMI_pathmap_references_can_be_read(bool usingSettings)
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                    x.PathMaps = usingSettings ? new Dictionary<string, string> { ["pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml"] = Path.Combine("TestData", "PrimitiveTypes.xmi") } : [])
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));

            var model = xmiReaderResult.Root as IModel;

            var sysmlTypClass = model.PackagedElement.OfType<IClass>().FirstOrDefault(x => x.Name == "Type");
            var isAbstractProperty = sysmlTypClass?.OwnedAttribute.FirstOrDefault(x => x.Name == "isAbstract");

            Assert.Multiple(() =>
            {
                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(usingSettings ? 2 : 1));

                Assert.That(model.XmiId, Is.EqualTo("_kUROkM9FEe6Zc_le1peNgQ"));
                Assert.That(model.Name, Is.EqualTo("sysml"));

                Assert.That(sysmlTypClass, Is.Not.Null);
                Assert.That(isAbstractProperty, Is.Not.Null);
                Assert.That(isAbstractProperty.Type, usingSettings ? Is.Not.Null : Is.Null);
            });
        }
    }
}
