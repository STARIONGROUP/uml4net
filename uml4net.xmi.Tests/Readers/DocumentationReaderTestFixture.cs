// -------------------------------------------------------------------------------------------------
//  <copyright file="DocumentationReaderTestFixture.cs" company="Starion Group S.A.">
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
    using System;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    [TestFixture]
    public class DocumentationReaderTestFixture
    {
        private IXmiReaderSettings xmiReaderSettings;

        private NameSpaceResolver nameSpaceResolver;

        private DocumentationReader documentationReader;

        [SetUp]
        public void SetUp()
        {
            this.xmiReaderSettings = new DefaultSettings();
            this.nameSpaceResolver = new NameSpaceResolver();

            this.documentationReader = new DocumentationReader(this.xmiReaderSettings, this.nameSpaceResolver,NullLoggerFactory.Instance);
        }

        [Test]
        public void Verify_that_null_arguments_throws_exception()
        {
            Assert.That(() => this.documentationReader.Read(null, ""), Throws.TypeOf<ArgumentNullException>() );
        }
    }
}
