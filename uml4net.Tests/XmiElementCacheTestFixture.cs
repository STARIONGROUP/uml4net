// -------------------------------------------------------------------------------------------------
// <copyright file="XmiElementCacheTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;
    using SimpleClassifiers;
    using StructuredClassifiers;

    [TestFixture]
    public class XmiElementCacheTestFixture
    {
        private XmiElementCache cache;

        [SetUp]
        public void SetUp()
        {
            this.cache = new XmiElementCache();
        }

        [Test]
        public void Verify_that_TryAdd_and_TryGetValue_returns_expected_result()
        {
            Assert.That(() => this.cache.TryAdd(null), Throws.ArgumentNullException);

            var @class = new Class
            {
                XmiId = "class",
                DocumentName = "test"
            };

            Assert.That(this.cache.TryAdd(@class), Is.True);

            Assert.That(this.cache.TryAdd(@class), Is.False);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.cache.TryGetValue("test#class", out var value), Is.True);
                Assert.That(value, Is.EqualTo(@class));
            }

            Assert.That(() => this.cache.TryGetValue("", out var nothing), Throws.ArgumentException);
            Assert.That(this.cache.TryGetValue("abc", out var element), Is.False);
        }

        [Test]
        public void Verify_that_an_XPointer_uuid_key_locates_the_first_element_of_the_document_with_that_uuid()
        {
            var first = new Class { XmiId = "first", DocumentName = "Co.xmi", XmiGuid = "DCE:emp-3" };
            var twin = new Class { XmiId = "twin", DocumentName = "Co.xmi", XmiGuid = "DCE:emp-3" };
            var noId = new Class { DocumentName = "Co.xmi", XmiGuid = "DCE:no-id" };
            var otherDocument = new Class { XmiId = "other", DocumentName = "Other.xmi", XmiGuid = "DCE:emp-3" };

            this.cache.TryAdd(first);
            this.cache.TryAdd(twin);
            this.cache.TryAdd(noId);
            this.cache.TryAdd(otherDocument);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.cache.TryGetValue("Co.xmi#xpointer((//*[@xmi:uuid='DCE:emp-3'])[1])", out var byUuid), Is.True);
                Assert.That(byUuid, Is.SameAs(first), "the first element with the uuid, per the [1] of the XPointer");
                Assert.That(this.cache.TryGetValue("Co.xmi#xpointer((//*[@xmi:uuid=\"DCE:no-id\"])[1])", out var byUuidNoId), Is.True, "double quotes are accepted");
                Assert.That(byUuidNoId, Is.SameAs(noId), "an element without xmi:id is reachable by uuid");
                Assert.That(this.cache.TryGetValue("Other.xmi#xpointer((//*[@xmi:uuid='DCE:emp-3'])[1])", out var inOther), Is.True);
                Assert.That(inOther, Is.SameAs(otherDocument), "uuids are looked up per document");
                Assert.That(this.cache.TryGetValue("Co.xmi#xpointer((//*[@xmi:uuid='unknown'])[1])", out _), Is.False);
                Assert.That(this.cache.TryGetValue("Co.xmi#DCE:emp-3", out _), Is.False, "a uuid is not an xmi:id");
                Assert.That(this.cache.TryGetValue("Co.xmi#first", out var byId), Is.True, "lookup by xmi:id is unaffected");
                Assert.That(byId, Is.SameAs(first));
            }

            this.cache.Clear();

            Assert.That(this.cache.TryGetValue("Co.xmi#xpointer((//*[@xmi:uuid='DCE:emp-3'])[1])", out _), Is.False, "Clear empties the uuid index as well");
        }

        [TestCase("xpointer((//*[@xmi:uuid='DCE:1234'])[1])", "DCE:1234")]
        [TestCase("xpointer((//*[@xmi:uuid=\"a b\"])[1])", "a b")]
        public void Verify_that_TryParseXPointerUuid_extracts_the_uuid(string fragment, string expectedUuid)
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(XmiElementCache.TryParseXPointerUuid(fragment, out var uuid), Is.True);
                Assert.That(uuid, Is.EqualTo(expectedUuid));
            }
        }

        [TestCase("emp_2", TestName = "bare name")]
        [TestCase("xpointer((//*[@xmi:uuid='v'])[2])", TestName = "not the first")]
        [TestCase("xpointer(descendent(1,Operation,xmi:label,op1))", TestName = "another XPointer scheme")]
        [TestCase("xpointer((//*[@xmi:label='v'])[1])", TestName = "label instead of uuid")]
        [TestCase("", TestName = "empty")]
        [TestCase(null, TestName = "null")]
        public void Verify_that_TryParseXPointerUuid_rejects_other_fragments(string fragment)
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(XmiElementCache.TryParseXPointerUuid(fragment, out var uuid), Is.False);
                Assert.That(uuid, Is.Null);
            }
        }

        [Test]
        public void Verify_that_elements_without_xmi_id_are_all_added_under_distinct_keys()
        {
            var first = new Class { Name = "first", DocumentName = "test" };
            var second = new Class { Name = "second", DocumentName = "test" };
            var third = new Class { Name = "third" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.cache.TryAdd(first), Is.True);
                Assert.That(this.cache.TryAdd(second), Is.True, "a second element without xmi:id from the same document is not a duplicate");
                Assert.That(this.cache.TryAdd(third), Is.True);
                Assert.That(this.cache.TryAdd(first), Is.True, "an element without xmi:id cannot be recognised as already present");

                Assert.That(this.cache.Count, Is.EqualTo(4));
                Assert.That(this.cache.Values, Is.SupersetOf(new[] { first, second, third }));
                Assert.That(this.cache.Keys, Is.Unique);
                Assert.That(this.cache.Keys, Has.All.Contains("<anonymous:"));
                Assert.That(this.cache.TryGetValue("test#", out _), Is.False, "the shared document identifier of elements without xmi:id is not a key");
                Assert.That(first.Cache, Is.SameAs(this.cache));
            }

            this.cache.Clear();
            this.cache.TryAdd(first);

            Assert.That(this.cache.Keys.Single(), Is.EqualTo("test#<anonymous:1>"), "the anonymous counter restarts after Clear");
        }

        [Test]
        public void Verify_that_enumerator_keys_and_values_count_and_clear_return_expected_results()
        {
            var @class = new Class
            {
                XmiId = "class",
                DocumentName = "test"
            };

            var @type = new PrimitiveType
            {
                XmiId = "type",
                DocumentName = "test"
            };

            this.cache.TryAdd(@class);
            this.cache.TryAdd(@type);

            foreach (var kvp in this.cache)
            {
                Assert.That(kvp.Key, Is.EqualTo(kvp.Value.FullyQualifiedIdentifier));                
            }

            Assert.That(this.cache.Values.Count, Is.EqualTo(2));
            Assert.That(this.cache.Values, Is.EquivalentTo(new List<IXmiElement> {@class, @type} ));

            Assert.That(this.cache.Keys.Count, Is.EqualTo(2));
            Assert.That(this.cache.Keys, Is.EquivalentTo(new List<string> { @class.FullyQualifiedIdentifier, @type.FullyQualifiedIdentifier }));

            Assert.That(this.cache.Count, Is.EqualTo(2));

            Assert.That(() => this.cache.Clear(), Throws.Nothing);

            Assert.That(this.cache.Count, Is.EqualTo(0));
        }
    }
}
