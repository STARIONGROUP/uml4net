// -------------------------------------------------------------------------------------------------
// <copyright file="DecisionModelNotationReaderTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Tests
{
    using System.IO;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Packages;
    using uml4net.xmi;

    [TestFixture]
    public class DecisionModelNotationReaderTestFixture
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
        public void Verify_that_DMN_XMI_can_be_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "dtc-23-02-13.xmi"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);
                Assert.That(xmiReaderResult.XmiRoot.Documentation.Exporter, Is.EqualTo("MagicDraw Clean XMI Exporter"));
                Assert.That(xmiReaderResult.XmiRoot.Documentation.ExporterVersion, Is.EqualTo("19.0 v9"));
                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(2));

                var model = xmiReaderResult.QueryRoot("_17_0_2_3_ea50349_1435105765209_262546_0") as IModel;

                Assert.That(model.Name, Is.EqualTo("Data"));

                Assert.That(model.NestedPackage.Count, Is.EqualTo(4));
            }
        }
    }
}
