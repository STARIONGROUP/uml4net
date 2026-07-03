// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterBuilderTestFixture.cs" company="Starion Group S.A.">
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
