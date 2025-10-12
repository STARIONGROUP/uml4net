// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiRootReaderTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Tests.Readers
{
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
            this.xmiReaderSettings = new DefaultSettings();
            this.nameSpaceResolver = new NameSpaceResolver();

            this.xmiRootReader = new XmiRootReader(this.xmiElementCache.Object, this.xmiElementReaderFacade.Object, this.xmiReaderSettings, this.nameSpaceResolver, NullLoggerFactory.Instance);
        }

        [Test]
        public void Verify_that_XmlReader_is_null_argumentException_is_thrown()
        {
            Assert.That(() => this.xmiRootReader.Read(null, "", "", new XmiRoot()), Throws.ArgumentNullException);
        }
    }
}
