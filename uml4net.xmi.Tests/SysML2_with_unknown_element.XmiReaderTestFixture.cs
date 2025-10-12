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
    using System;
    using System.IO;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Moq;

    using uml4net.Packages;
    using uml4net.xmi;

    [TestFixture]
    public class SysML2_with_unknown_elementXmiReaderTestFixture
    {
        private Mock<ILoggerFactory> loggerFactory;
        private Mock<ILogger<object>> genericLogger;

        [SetUp]
        public void SetUp()
        {
            this.genericLogger = new Mock<ILogger<object>>();
            this.loggerFactory = new Mock<ILoggerFactory>();

            this.loggerFactory
                .Setup(factory => factory.CreateLogger(It.IsAny<string>()))
                .Returns((string categoryName) => this.genericLogger.Object);
        }

        [Test]
        public void Verify_that_SysML_with_unknown_element_UML_cannot_be_read_by_default()
        {
            var reader = XmiReaderBuilder.Create()
                .WithLogger(this.loggerFactory.Object)
                .Build();

            Assert.That(
                () => reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData",
                    "SysML_with_unknown_element.uml")), Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public void Verify_that_SysML_with_unknown_element_UML_can_be_read_using_not_strict_reading_setting()
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.UseStrictReading = false)
                .WithLogger(this.loggerFactory.Object)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData",
                "SysML_with_unknown_element.uml"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);
                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(1));

                var model = xmiReaderResult.QueryRoot("_kUROkM9FEe6Zc_le1peNgQ") as IModel;

                Assert.That(model.XmiId, Is.EqualTo("_kUROkM9FEe6Zc_le1peNgQ"));
                Assert.That(model.Name, Is.EqualTo("sysml"));
            }
        }
    }
}
