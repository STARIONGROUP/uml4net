// -------------------------------------------------------------------------------------------------
// <copyright file="XmiElementReaderTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests.Readers
{
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net;
    using uml4net.Values;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

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

            public bool InvokeTryCollectComposite(XmlReader xmlReader, IXmiElement element, string name, int containedCount) => TryCollectCompositeReferencePropertyIdentifier(xmlReader, element, name, containedCount);

        }

        [Test]
        public void TryCollectCompositeReferencePropertyIdentifier_DoesNotMoveTheReaderForADefinition()
        {
            var reader = new TestReader();
            var element = new LiteralBoolean();
            using var xr = XmlReader.Create(new System.IO.StringReader("<ownedRule xmlns:xmi='http://www.omg.org/spec/XMI/20131001' xmi:id='c1' xmi:type='uml:Constraint'><body/></ownedRule>"), new XmlReaderSettings());
            xr.MoveToContent();

            var result = reader.InvokeTryCollectComposite(xr, element, "ownedRule", 0);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.False);
                Assert.That(xr.LocalName, Is.EqualTo("ownedRule"));
                Assert.That(xr.GetAttribute("xmi:id"), Is.EqualTo("c1"));
                Assert.That(element.CompositeReferencePropertyIdentifiers, Is.Empty);
                Assert.That(() => reader.InvokeTryCollectComposite(xr, element, "specification", 0), Throws.InvalidOperationException);
                Assert.That(() => reader.InvokeTryCollectComposite(null, element, "ownedRule", 0), Throws.ArgumentNullException);
                Assert.That(() => reader.InvokeTryCollectComposite(xr, null, "ownedRule", 0), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void TryCollectCompositeReferencePropertyIdentifier_StoresTheIdRefWithItsPosition()
        {
            var reader = new TestReader();
            var element = new LiteralBoolean();

            foreach (var (idRef, containedCount) in new[] { ("c2", 1), ("c3", 2) })
            {
                using var xr = XmlReader.Create(new System.IO.StringReader($"<ownedRule xmlns:xmi='http://www.omg.org/spec/XMI/20131001' xmi:idref='{idRef}'/>"), new XmlReaderSettings());
                xr.MoveToContent();

                Assert.That(reader.InvokeTryCollectComposite(xr, element, "ownedRule", containedCount), Is.True);
            }

            var compositeReferences = element.CompositeReferencePropertyIdentifiers["ownedRule"];

            using (Assert.EnterMultipleScope())
            {
                Assert.That(compositeReferences.Select(x => x.Identifier), Is.EqualTo(new[] { "c2", "c3" }));
                Assert.That(compositeReferences.Select(x => x.Position), Is.EqualTo(new[] { 1, 3 }));
                Assert.That(element.UnresolvedReferences, Is.Empty);
            }
        }

        [Test]
        public void TryCollectCompositeReferencePropertyIdentifier_StoresAndPreservesTheHref()
        {
            var reader = new TestReader();
            var element = new LiteralBoolean();
            using var xr = XmlReader.Create(new System.IO.StringReader("<ownedRule href='doc2.xml#c4'/>"), new XmlReaderSettings());
            xr.MoveToContent();

            var result = reader.InvokeTryCollectComposite(xr, element, "ownedRule", 0);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.True);
                Assert.That(element.CompositeReferencePropertyIdentifiers["ownedRule"].Single().Identifier, Is.EqualTo("doc2.xml#c4"));
                Assert.That(element.UnresolvedReferences.Single().Identifier, Is.EqualTo("doc2.xml#c4"));
                Assert.That(element.UnresolvedReferences.Single().ContentRawXmi, Does.Contain("ownedRule"));
            }
        }

        private class NonStrictTestReader : XmiElementReader<IXmiElement>
        {
            public NonStrictTestReader() : base(new XmiElementCache(), null, new DefaultSettings { UseStrictReading = false }, null, null, NullLoggerFactory.Instance)
            {
            }

            public override IXmiElement Read(XmlReader xmlReader, string documentName, string namespaceUri) => throw new System.NotImplementedException();

            public void InvokeCollect(XmlReader xmlReader, IXmiElement element, string name) => CollectSingleValueReferencePropertyIdentifier(xmlReader, element, name);
        }

        [Test]
        public void CollectSingleValueReferencePropertyIdentifier_ThrowsForARepeatedReferenceWhenNoSettingsAreAvailable()
        {
            var reader = new TestReader();
            var element = new LiteralBoolean { XmiId = "lb", XmiType = "uml:LiteralBoolean" };
            using var xr = XmlReader.Create(new System.IO.StringReader("<root><type xmi:idref='first' xmlns:xmi='http://www.omg.org/spec/XMI/20131001'/><type href='other.xmi#second' xmlns:xmi='http://www.omg.org/spec/XMI/20131001'/></root>"), new XmlReaderSettings());
            xr.MoveToContent();
            xr.Read();
            reader.InvokeCollect(xr, element, "type");
            xr.Read();

            var exception = Assert.Throws<XmiReadException>(() => reader.InvokeCollect(xr, element, "type"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(exception.Message, Does.StartWith("The single-valued reference is given more than once, [first] is kept and [other.xmi#second] is ignored: uml:LiteralBoolean [lb] property [type] at line:position 1:"));
                Assert.That(element.SingleValueReferencePropertyIdentifiers["type"], Is.EqualTo("first"));
                Assert.That(element.UnresolvedReferences, Is.Empty, "the ignored href is not preserved either");
            }
        }

        [Test]
        public void CollectSingleValueReferencePropertyIdentifier_KeepsTheFirstOfARepeatedReferenceInNonStrictMode()
        {
            var reader = new NonStrictTestReader();
            var element = new LiteralBoolean { XmiId = "lb", XmiType = "uml:LiteralBoolean" };
            using var xr = XmlReader.Create(new System.IO.StringReader("<root><type xmi:idref='first' xmlns:xmi='http://www.omg.org/spec/XMI/20131001'/><type xmi:idref='second' xmlns:xmi='http://www.omg.org/spec/XMI/20131001'/></root>"), new XmlReaderSettings());
            xr.MoveToContent();
            xr.Read();
            reader.InvokeCollect(xr, element, "type");
            xr.Read();

            Assert.That(() => reader.InvokeCollect(xr, element, "type"), Throws.Nothing);
            Assert.That(element.SingleValueReferencePropertyIdentifiers["type"], Is.EqualTo("first"));
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

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.True);
                Assert.That(element.MultiValueReferencePropertyIdentifiers["ref"], Has.Member("id1"));
            }
        }

        [Test]
        public void CollectSingleValueReferencePropertyIdentifier_PreservesTheReferenceElementOfAnHref()
        {
            var reader = new TestReader();
            var element = new LiteralBoolean();
            using var xr = XmlReader.Create(new System.IO.StringReader("<appliedProfile xmlns:xmi='http://www.omg.org/spec/XMI/20131001' xmi:type='uml:Profile' href='http://www.sparxsystems.com/profiles/EAUML/1.0#8C9E6706-8'/>"), new XmlReaderSettings());
            xr.MoveToContent();
            reader.InvokeCollect(xr, element, "appliedProfile");

            var unresolvedReference = element.UnresolvedReferences.Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(unresolvedReference.PropertyName, Is.EqualTo("appliedProfile"));
                Assert.That(unresolvedReference.Identifier, Is.EqualTo("http://www.sparxsystems.com/profiles/EAUML/1.0#8C9E6706-8"));
                Assert.That(unresolvedReference.ContentRawXmi, Does.Contain("appliedProfile"));
                Assert.That(unresolvedReference.ContentRawXmi, Does.Contain("href=\"http://www.sparxsystems.com/profiles/EAUML/1.0#8C9E6706-8\""));
                Assert.That(unresolvedReference.ContentRawXmi, Does.Contain("uml:Profile"),
                    "the xmi:type of the reference element is expected to be preserved as part of the raw XMI");
            }
        }

        [Test]
        public void CollectSingleValueReferencePropertyIdentifier_DoesNotPreserveTheReferenceElementOfAnIdRef()
        {
            var reader = new TestReader();
            var element = new LiteralBoolean();
            using var xr = XmlReader.Create(new System.IO.StringReader("<type xmlns:xmi='http://www.omg.org/spec/XMI/20131001' xmi:idref='refId'/>"), new XmlReaderSettings());
            xr.MoveToContent();
            reader.InvokeCollect(xr, element, "type");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(element.SingleValueReferencePropertyIdentifiers["type"], Is.EqualTo("refId"));
                Assert.That(element.UnresolvedReferences, Is.Empty,
                    "an xmi:idref is a reference within the same document and does not depend on a document that may be unavailable");
            }
        }

        [Test]
        public void TryCollectMultiValueReferencePropertyIdentifiers_PreservesTheReferenceElementOfEachHref()
        {
            var reader = new TestReader();
            var element = new LiteralBoolean();

            using (var xr = XmlReader.Create(new System.IO.StringReader("<ref href='other.xmi#id1'/>"), new XmlReaderSettings()))
            {
                xr.MoveToContent();
                reader.InvokeTryCollect(xr, element, "ref");
            }

            using (var xr = XmlReader.Create(new System.IO.StringReader("<ref href='other.xmi#id2'/>"), new XmlReaderSettings()))
            {
                xr.MoveToContent();
                reader.InvokeTryCollect(xr, element, "ref");
            }

            using (Assert.EnterMultipleScope())
            {
                Assert.That(element.UnresolvedReferences.Select(x => x.Identifier),
                    Is.EqualTo(new[] { "other.xmi#id1", "other.xmi#id2" }));
                Assert.That(element.UnresolvedReferences.Select(x => x.PropertyName), Is.All.EqualTo("ref"));
            }
        }

        [Test]
        public void TryCollectMultiValueReferencePropertyIdentifiers_DoesNotPreserveTheReferenceElementOfAnIdRef()
        {
            var reader = new TestReader();
            var element = new LiteralBoolean();
            using var xr = XmlReader.Create(new System.IO.StringReader("<ref xmlns:xmi='http://www.omg.org/spec/XMI/20131001' xmi:idref='id1'/>"), new XmlReaderSettings());
            xr.MoveToContent();
            var result = reader.InvokeTryCollect(xr, element, "ref");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.True);
                Assert.That(element.UnresolvedReferences, Is.Empty);
            }
        }
    }
}
