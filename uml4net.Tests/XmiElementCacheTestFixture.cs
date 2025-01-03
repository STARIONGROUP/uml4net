// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiElementCacheTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
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

namespace uml4net.Tests
{
    using System.Collections.Generic;
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

            Assert.Multiple(() =>
            {
                Assert.That(this.cache.TryGetValue("test#class", out var value), Is.True);
                Assert.That(value, Is.EqualTo(@class));
            });


            Assert.That(() => this.cache.TryGetValue("", out var nothing), Throws.ArgumentException);

            Assert.That(this.cache.TryGetValue("abc", out var element), Is.False);
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
