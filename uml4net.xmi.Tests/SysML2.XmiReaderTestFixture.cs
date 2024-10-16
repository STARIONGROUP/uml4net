﻿// -------------------------------------------------------------------------------------------------
// <copyright file="SysML2.XmiReaderTestFixture.cs" company="Starion Group S.A.">
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

    public class SysML2XmiReaderTestFixture
    {
        private ILoggerFactory loggerFactory;

        [SetUp]
        public void SetUp()
        {
            this.loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        }

        [Test]
        public void Verify_that_SysML_XMI_can_be_read()
        {
            var reader = new XmiReader(this.loggerFactory);

            var packages = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));

            Assert.That(packages.Count(), Is.EqualTo(1));

            var model = packages.First() as IModel;

            Assert.That(model.XmiId, Is.EqualTo("_kUROkM9FEe6Zc_le1peNgQ"));
            Assert.That(model.Name, Is.EqualTo("sysml"));
        }
    }
}