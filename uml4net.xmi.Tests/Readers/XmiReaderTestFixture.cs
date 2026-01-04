// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiReaderTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
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
    using System.IO;
    using Extender;
    using Microsoft.Extensions.Logging.Abstractions;

    using Moq;

    using NUnit.Framework;

    using uml4net.xmi.Settings;
    using uml4net.xmi.Readers;
    using uml4net.xmi.ReferenceResolver;

    [TestFixture]
    public class XmiReaderTestFixture
    {
        private Mock<IAssembler> assembler;

        private Mock<IXmiElementCache> xmiElementCache;

        private Mock<IXmiElementReaderFacade> xmiElementReaderFacade;

        private Mock<IExternalReferenceResolver> externalReferenceResolver;

        private Mock<IXmiReaderScope> xmiReaderScope;

        private Mock<IExtenderReaderRegistry> extenderReaderRegistry;

        private XmiReader xmiReader;

        private NameSpaceResolver nameSpaceResolver;

        [SetUp]
        public void SetUp()
        {
            this.assembler = new Mock<IAssembler>();
            this.xmiElementCache = new Mock<IXmiElementCache>();
            this.xmiElementReaderFacade = new Mock<IXmiElementReaderFacade>();
            this.externalReferenceResolver = new Mock<IExternalReferenceResolver>();
            this.extenderReaderRegistry = new Mock<IExtenderReaderRegistry>();

            this.xmiReaderScope = new Mock<IXmiReaderScope>();
            this.nameSpaceResolver = new NameSpaceResolver();

            this.xmiReader = new XmiReader(this.assembler.Object,
                this.xmiElementCache.Object,
                this.xmiElementReaderFacade.Object,
                NullLoggerFactory.Instance,
                this.externalReferenceResolver.Object, xmiReaderScope.Object, new DefaultSettings(), this.nameSpaceResolver, this.extenderReaderRegistry.Object);
        }

        [Test]
        public void Verify_that_when_file_uri_invalid_exception_is_thrown()
        {
            string fileUri = null;
            Assert.That(() => this.xmiReader.Read(fileUri), Throws.ArgumentException);

            fileUri = "";
            Assert.That(() => this.xmiReader.Read(fileUri), Throws.ArgumentException);

            fileUri = "Z:\\this\\file\\does\\not\\exist.xmi";
            Assert.That(() => this.xmiReader.Read(fileUri), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_when_input_stream_invalid_exception_is_thrown()
        {
            Stream inputStream = null;
            string documentName = null;

            Assert.That(() => this.xmiReader.Read(inputStream, documentName), Throws.ArgumentNullException);

            inputStream = new MemoryStream();
            Assert.That(() => this.xmiReader.Read(inputStream, documentName), Throws.ArgumentException);
        }
    }
}
