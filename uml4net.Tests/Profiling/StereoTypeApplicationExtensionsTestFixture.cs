// -------------------------------------------------------------------------------------------------
// <copyright file="StereoTypeApplicationExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests.Profiling
{
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.Profiling;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class StereoTypeApplicationExtensionsTestFixture
    {
        private XmiElementCache cache;

        private Class @class;

        private StereoTypeApplication resolved;

        private StereoTypeApplication unresolved;

        [SetUp]
        public void SetUp()
        {
            this.cache = new XmiElementCache();
            this.@class = new Class { XmiId = "class", DocumentName = "test", Cache = this.cache };

            var block = new Stereotype { Name = "Block" };
            var isEncapsulated = new Property { Name = "isEncapsulated" };
            block.OwnedAttribute.Add(isEncapsulated);

            this.resolved = new StereoTypeApplication
            {
                XmiId = "resolved",
                StereoTypeName = "BlockAsRead",
                Stereotype = block,
                TaggedValues = { new TaggedValue { Name = "isEncapsulatedAsRead", Property = isEncapsulated, Values = { true } } }
            };

            this.unresolved = new StereoTypeApplication
            {
                XmiId = "unresolved",
                StereoTypeName = "Marker",
                TaggedValues = { new TaggedValue { Name = "note", RawValues = { "kept" } } }
            };

            this.cache.AddStereoTypeApplication(this.@class, this.resolved);
            this.cache.AddStereoTypeApplication(this.@class, this.unresolved);
        }

        [Test]
        public void Verify_that_the_stereotype_applications_of_an_element_are_queried()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.@class.QueryStereoTypeApplications(), Is.EqualTo(new[] { this.resolved, this.unresolved }));
                Assert.That(new Class { XmiId = "other", Cache = this.cache }.QueryStereoTypeApplications(), Is.Empty);
                Assert.That(new Class { XmiId = "withoutCache" }.QueryStereoTypeApplications(), Is.Empty);
                Assert.That(() => ((IXmiElement)null).QueryStereoTypeApplications(), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_an_application_is_queried_by_the_name_of_its_stereotype()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.@class.QueryStereoTypeApplication("Block"), Is.SameAs(this.resolved), "the name of the resolved stereotype");
                Assert.That(this.@class.QueryStereoTypeApplication("BlockAsRead"), Is.Null);
                Assert.That(this.@class.QueryStereoTypeApplication("Marker"), Is.SameAs(this.unresolved), "the name that was read, when the stereotype is not resolved");
                Assert.That(() => this.@class.QueryStereoTypeApplication(null), Throws.ArgumentException);
            }
        }

        [Test]
        public void Verify_that_a_tagged_value_is_queried_by_the_name_of_its_property()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.resolved.QueryTaggedValue("isEncapsulated")?.Values, Is.EqualTo(new object[] { true }), "the name of the resolved property");
                Assert.That(this.unresolved.QueryTaggedValue("note")?.RawValues, Is.EqualTo(new[] { "kept" }), "the name that was read, when the property is not resolved");
                Assert.That(this.unresolved.QueryTaggedValue("missing"), Is.Null);
                Assert.That(() => ((StereoTypeApplication)null).QueryTaggedValue("note"), Throws.ArgumentNullException);
                Assert.That(() => this.unresolved.QueryTaggedValue(string.Empty), Throws.ArgumentException);
            }
        }
    }
}
