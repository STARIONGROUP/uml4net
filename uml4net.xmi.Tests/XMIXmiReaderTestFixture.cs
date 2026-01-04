// -------------------------------------------------------------------------------------------------
//  <copyright file="XMIXmiReaderTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.xmi;

    [TestFixture]
    public class XMIXmiReaderTestFixture
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
        public void Verify_that_XMI_XMI_can_be_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(rootPath, "XMI-model.xmi"));

            Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);

            var nsPrefixTag = xmiReaderResult.XmiRoot.Tags.Single(x => x.XmiId == "_org.omg.xmi.nsPrefix");
            Assert.That(nsPrefixTag.Name, Is.EqualTo("org.omg.xmi.nsPrefix"));
            Assert.That(nsPrefixTag.Value, Is.EqualTo("xmi"));
            Assert.That(nsPrefixTag.Element[0], Is.EqualTo("_XMI"));

            var superClassFirstTag = xmiReaderResult.XmiRoot.Tags.Single(x => x.XmiId == "_org.omg.xmi.superClassFirst");
            Assert.That(superClassFirstTag.Name, Is.EqualTo("org.omg.xmi.superClassFirst"));
            Assert.That(superClassFirstTag.Value, Is.EqualTo("true"));
            Assert.That(superClassFirstTag.Element[0], Is.EqualTo("_XMI"));

            var useSchemaExtensionTag = xmiReaderResult.XmiRoot.Tags.Single(x => x.XmiId == "_org.omg.xmi.useSchemaExtension");
            Assert.That(useSchemaExtensionTag.Name, Is.EqualTo("org.omg.xmi.useSchemaExtension"));
            Assert.That(useSchemaExtensionTag.Value, Is.EqualTo("true"));
            Assert.That(useSchemaExtensionTag.Element[0], Is.EqualTo("_XMI"));

            var elementTag = xmiReaderResult.XmiRoot.Tags.Single(x => x.XmiId == "_org.omg.xmi.element");
            Assert.That(elementTag.Name, Is.EqualTo("org.omg.xmi.element"));
            Assert.That(elementTag.Value, Is.EqualTo("true"));
            Assert.That(elementTag.Element[0], Is.EqualTo("_XMI"));

            var attributeTag = xmiReaderResult.XmiRoot.Tags.Single(x => x.XmiId == "_org.omg.xmi.attribute");
            Assert.That(attributeTag.Name, Is.EqualTo("org.omg.xmi.attribute"));
            Assert.That(attributeTag.Value, Is.EqualTo("false"));
            Assert.That(attributeTag.Element[0], Is.EqualTo("_XMI"));

            var schemaTypeTag = xmiReaderResult.XmiRoot.Tags.Single(x => x.XmiId == "_org.omg.xmi.schemaType");
            Assert.That(schemaTypeTag.Name, Is.EqualTo("org.omg.xmi.schemaType"));
            Assert.That(schemaTypeTag.Value, Is.EqualTo("http://www.w3.org/2001/XMLSchema#dateTime"));
            Assert.That(schemaTypeTag.Element[0], Is.EqualTo("_XMI-DateTime"));
        }
    }
}
