// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWriteContextTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Writers;

    [TestFixture]
    public class XmiWriteContextTestFixture
    {
        [Test]
        public void Verify_that_constructor_throws_when_arguments_are_null()
        {
            Assert.That(() => new XmiWriteContext(null, []), Throws.ArgumentNullException);
            Assert.That(() => new XmiWriteContext("UML.xmi", null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_DocumentName_is_set()
        {
            var context = new XmiWriteContext("UML.xmi", []);

            Assert.That(context.DocumentName, Is.EqualTo("UML.xmi"));
        }

        [Test]
        public void Verify_that_IsLocal_returns_expected_result()
        {
            var localClass = new Class { XmiId = "Class-1", DocumentName = "UML.xmi" };
            var externalClass = new Class { XmiId = "Class-2", DocumentName = "PrimitiveTypes.xmi" };

            var context = new XmiWriteContext("UML.xmi", [localClass.FullyQualifiedIdentifier]);

            Assert.That(context.IsLocal(localClass), Is.True);
            Assert.That(context.IsLocal(externalClass), Is.False);
        }

        [Test]
        public void Verify_that_IsLocal_supports_empty_document_name()
        {
            var localClass = new Class { XmiId = "Class-1" };

            var context = new XmiWriteContext("UML.xmi", [localClass.FullyQualifiedIdentifier]);

            Assert.That(context.IsLocal(localClass), Is.True);
        }

        [Test]
        public void Verify_that_IsLocal_throws_when_element_is_null()
        {
            var context = new XmiWriteContext("UML.xmi", []);

            Assert.That(() => context.IsLocal(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryHref_returns_expected_result()
        {
            var externalClass = new Class { XmiId = "Boolean", DocumentName = "PrimitiveTypes.xmi" };

            var context = new XmiWriteContext("UML.xmi", []);

            Assert.That(context.QueryHref(externalClass), Is.EqualTo("PrimitiveTypes.xmi#Boolean"));
        }

        [Test]
        public void Verify_that_QueryHref_throws_when_element_is_null()
        {
            var context = new XmiWriteContext("UML.xmi", []);

            Assert.That(() => context.QueryHref(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_without_Canonical_XMI_the_identifiers_are_those_that_were_read()
        {
            var @class = new Class { XmiId = "c", XmiGuid = "guid", DocumentName = "a.xmi" };
            var context = new XmiWriteContext("a.xmi", [@class.FullyQualifiedIdentifier]);

            context.BeginCanonicalObject(@class, "uml:Class", "C");
            context.EndCanonicalObject();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(context.IsCanonical, Is.False);
                Assert.That(context.IsRecording, Is.False);
                Assert.That(context.QueryXmiId(@class), Is.EqualTo("c"));
                Assert.That(context.QueryXmiUuid(@class), Is.EqualTo("guid"));
                Assert.That(context.QueryXmiUuid(new Class { XmiId = "d" }), Is.Null, "no xmi:uuid is made up");
                Assert.That(() => context.QueryXmiId(null), Throws.ArgumentNullException);
                Assert.That(() => context.QueryXmiUuid(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_the_canonical_identifiers_are_derived_from_the_recorded_objects()
        {
            var package = new Package { XmiId = "p1", DocumentName = "a.xmi", Name = "P" };
            var first = new Class { XmiId = "c1", DocumentName = "a.xmi", Name = "C" };
            var second = new Class { XmiId = "c2", DocumentName = "a.xmi", Name = "C" };
            var context = new XmiWriteContext("a.xmi", [package.FullyQualifiedIdentifier, first.FullyQualifiedIdentifier, second.FullyQualifiedIdentifier], true);

            context.StartRecording();
            context.BeginCanonicalObject(package, "uml:Package", package.Name);
            context.BeginCanonicalObject(first, "packagedElement", first.Name);
            context.EndCanonicalObject();
            context.BeginCanonicalObject(second, "packagedElement", second.Name);
            context.EndCanonicalObject();
            context.EndCanonicalObject();
            context.EndCanonicalObject();

            Assert.That(context.QueryXmiId(first), Is.EqualTo("c1"), "before the derivation, the identifier that was read");

            context.DeriveCanonicalIdentifiers();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(context.IsCanonical, Is.True);
                Assert.That(context.IsRecording, Is.False);
                Assert.That(context.QueryXmiId(package), Is.EqualTo("P"));
                Assert.That(context.QueryXmiId(first), Is.EqualTo("P-C"));
                Assert.That(context.QueryXmiId(second), Is.EqualTo("P-C_2"), "a duplicate name is numbered from 2");
                Assert.That(context.QueryXmiIdByReadIdentifier("c2"), Is.EqualTo("P-C_2"));
                Assert.That(context.QueryXmiIdByReadIdentifier("unknown"), Is.EqualTo("unknown"));
                Assert.That(context.QueryXmiIdByReadIdentifier(null), Is.Null);
                Assert.That(context.QueryXmiUuid(first), Is.EqualTo("a.xmi#c1"), "the document and the xmi:id that was read");
                Assert.That(context.QueryCanonicalXmiUuid("given", "c1"), Is.EqualTo("given"));
                Assert.That(context.QueryCanonicalXmiUuid(null, null), Is.Null);
            }
        }

        [Test]
        public void Verify_that_the_values_of_a_property_that_is_not_ordered_are_ordered_canonically()
        {
            var nestedB = new Class { XmiId = "n2", XmiGuid = "b", DocumentName = "a.xmi" };
            var nestedA = new Class { XmiId = "n1", XmiGuid = "a", DocumentName = "a.xmi" };
            var externalZ = new Class { XmiId = "z", DocumentName = "z.xmi" };
            var externalY = new Class { XmiId = "y", DocumentName = "y.xmi" };
            var context = new XmiWriteContext("a.xmi", [nestedA.FullyQualifiedIdentifier, nestedB.FullyQualifiedIdentifier], true);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(context.QueryCanonicalOrder(new[] { externalZ, nestedB, externalY, nestedA }, true), Is.EqualTo(new[] { nestedA, nestedB, externalY, externalZ }),
                    "B.5.3: the nested elements by xmi:uuid, then the href links by href");
                Assert.That(context.QueryCanonicalOrder(new[] { nestedA, nestedB }, false), Is.EqualTo(new[] { nestedA, nestedB }), "the xmi:idref links by identifier");
                Assert.That(() => context.QueryCanonicalOrder<Class>(null, true), Throws.ArgumentNullException);
            }
        }
    }
}
