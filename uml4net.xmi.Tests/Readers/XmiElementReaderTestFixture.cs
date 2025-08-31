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
            public TestReader() : base(new XmiElementCache(), NullLoggerFactory.Instance) { }
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
