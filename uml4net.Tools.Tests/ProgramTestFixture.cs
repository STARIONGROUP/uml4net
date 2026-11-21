// -------------------------------------------------------------------------------------------------
// <copyright file="ProgramTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tools.Tests
{
    using System.IO;
    using System.Threading.Tasks;
    using NUnit.Framework;

    using uml4net.Tools;

    [TestFixture]
    public class ProgramTestFixture
    {
        private string inputModel;

        [SetUp]
        public void Setup()
        {
            this.inputModel = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi");
        }

        [Test]
        [TestCase("html-report")]
        [TestCase( "excel-report")]
        [TestCase("inspect")]
        public async Task Verify_that_console_app_can_generate_reports(string reportKind)
        {
            var args = new[]
            {
                reportKind,
                "--no-logo",
                "--log-level", "Warning",
                "--input-model", this.inputModel,
                "--root-package-xmi-id", "_0",
                "--root-package-name", "UML"
            };

            var exitCode = await Program.Main(args);

            Assert.That(exitCode, Is.EqualTo(0));
        }
    }
}
