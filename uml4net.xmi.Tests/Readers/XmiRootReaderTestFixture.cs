// -------------------------------------------------------------------------------------------------
// <copyright file="XmiRootReaderTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Tests.Readers
{
    using Extender;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    using Moq;
    using NUnit.Framework;

    using Serilog;

    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;
    using Xmi;

    [TestFixture]
    public class XmiRootReaderTestFixture
    {
        private Mock<IXmiElementCache> xmiElementCache;

        private Mock<IXmiElementReaderFacade> xmiElementReaderFacade;

        private Mock<IExtenderReaderRegistry> extenderReaderRegistry;

        private IXmiReaderSettings xmiReaderSettings;

        private NameSpaceResolver nameSpaceResolver;

        private XmiRootReader xmiRootReader;

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

        [SetUp]
        public void SetUp()
        {
            this.xmiElementCache = new Mock<IXmiElementCache>();
            this.xmiElementReaderFacade = new Mock<IXmiElementReaderFacade>();
            this.extenderReaderRegistry = new Mock<IExtenderReaderRegistry>();

            this.xmiReaderSettings = new DefaultSettings();
            this.nameSpaceResolver = new NameSpaceResolver();

            this.xmiRootReader = new XmiRootReader(this.xmiElementCache.Object, this.xmiElementReaderFacade.Object, this.xmiReaderSettings, this.nameSpaceResolver, this.extenderReaderRegistry.Object,NullLoggerFactory.Instance);
        }

        [Test]
        public void Verify_that_XmlReader_is_null_argumentException_is_thrown()
        {
            Assert.That(() => this.xmiRootReader.Read(null, "", "", new XmiRoot()), Throws.ArgumentNullException);
        }
    }
}
