// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
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
    
    using uml4net.POCO.Packages;

    [TestFixture]
    public class XmiReaderTestFixture
    {
        private ILoggerFactory loggerFactory;

        [SetUp]
        public void SetUp()
        {
            this.loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        }

        [Test]
        public void Verify_that_UML_PrimitiveTypes__XMI_can_be_read()
        {
            var reader = new XmiReader(this.loggerFactory);

            var packages = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "PrimitiveTypes.xmi.xml"));

            Assert.That(packages.Count(), Is.EqualTo(1));

            var package = packages.First();

            Assert.That(package.XmiId, Is.EqualTo("_0"));
            Assert.That(package.Name, Is.EqualTo("PrimitiveTypes"));
        }

        [Test]
        public void Verify_that_UML_XMI_can_be_read()
        {
            var reader = new XmiReader(this.loggerFactory);

            var packages = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi.xml"));

            Assert.That(packages.Count(), Is.EqualTo(1));

            var package = packages.First();

            Assert.That(package.XmiId, Is.EqualTo("_0"));
            Assert.That(package.Name, Is.EqualTo("UML"));

            Assert.That(package.PackageImport.Count, Is.EqualTo(15));

            var packageImport = package.PackageImport.First();
            Assert.That(packageImport.XmiId, Is.EqualTo("_packageImport.0"));
        }

        
    }
}
