// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterBuilderTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Tests.Writers
{
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.xmi;
    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;

    [TestFixture]
    public class XmiWriterBuilderTestFixture
    {
        private ILoggerFactory loggerFactory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();
        }

        [SetUp]
        public void SetUp()
        {
            this.loggerFactory = LoggerFactory.Create(builder => builder.AddSerilog());
        }

        [Test]
        public void Verify_that_Build_returns_an_XmiWriter()
        {
            using var writer = XmiWriterBuilder.Create()
                .WithLogger(this.loggerFactory)
                .Build();

            Assert.That(writer, Is.InstanceOf<IXmiWriter>());
        }

        [Test]
        public void Verify_that_UsingSettings_delegate_configures_the_settings()
        {
            var scope = XmiWriterBuilder.Create()
                .UsingSettings(x => x.ExternalReferenceResolution = ExternalReferenceResolutionKind.Include)
                .WithLogger(this.loggerFactory);

            using var writer = scope.Build();

            Assert.That(writer, Is.InstanceOf<IXmiWriter>());
        }

        [Test]
        public void Verify_that_UsingSettings_instance_configures_the_settings()
        {
            var settings = new DefaultWriterSettings
            {
                Indent = false
            };

            using var writer = XmiWriterBuilder.Create()
                .UsingSettings(settings)
                .WithLogger(this.loggerFactory)
                .Build();

            Assert.That(writer, Is.InstanceOf<IXmiWriter>());
        }

        [Test]
        public void Verify_that_scope_can_be_disposed()
        {
            var scope = XmiWriterBuilder.Create().WithLogger(this.loggerFactory);
            var writer = scope.Build();

            Assert.That(() => scope.Dispose(), Throws.Nothing);
        }

        [Test]
        public void Verify_that_disposing_the_writer_disposes_the_scope()
        {
            var writer = XmiWriterBuilder.Create()
                .WithLogger(this.loggerFactory)
                .Build();

            Assert.That(() => writer.Dispose(), Throws.Nothing);
        }
    }
}
