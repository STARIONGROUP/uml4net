// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiElementReaderTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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
    using System.Xml;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net;
    using uml4net.Values;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class XmiElementReaderTestFixture
    {
        private class TestReader : XmiElementReader<IXmiElement>
        {
            public TestReader() : base(new XmiElementCache(), NullLoggerFactory.Instance)
            {

            }
            public override IXmiElement Read(XmlReader xmlReader, string documentName, string namespaceUri) => throw new System.NotImplementedException();

            public void InvokeCollect(XmlReader xmlReader, IXmiElement element, string name) => CollectSingleValueReferencePropertyIdentifier(xmlReader, element, name);

            public bool InvokeTryCollect(XmlReader xmlReader, IXmiElement element, string name) => TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, element, name);

        }

        [Test]
        public void CollectSingleValueReferencePropertyIdentifier_StoresHref()
        {
            var reader = new TestReader();
            var element = new LiteralBoolean();
            using var xr = XmlReader.Create(new System.IO.StringReader("<type href='refId'/>"), new XmlReaderSettings());
            xr.MoveToContent();
            reader.InvokeCollect(xr, element, "type");
            Assert.That(element.SingleValueReferencePropertyIdentifiers["type"], Is.EqualTo("refId"));
        }

        [Test]
        public void TryCollectMultiValueReferencePropertyIdentifiers_StoresValues()
        {
            var reader = new TestReader();
            var element = new LiteralBoolean();
            using var xr = XmlReader.Create(new System.IO.StringReader("<ref href='id1'/>"), new XmlReaderSettings());
            xr.MoveToContent();
            var result = reader.InvokeTryCollect(xr, element, "ref");
            Assert.That(result, Is.True);
            Assert.That(element.MultiValueReferencePropertyIdentifiers["ref"], Has.Member("id1"));
        }
    }
}
