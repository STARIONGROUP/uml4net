// -------------------------------------------------------------------------------------------------
// <copyright file="ClassExtensionsQueryExtensionTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ClassExtensionsQueryExtensionTestFixture
    {
        private Package profile;
        private Class metaclass;
        private Stereotype stereotype;
        private Extension extension;
        private ExtensionEnd extensionEnd;
        private Property baseProperty;

        [SetUp]
        public void SetUp()
        {
            // mirrors the "Abstraction_Derive" Extension in the OMG StandardProfile.xmi:
            // an Extension whose ownedEnd is typed by the Stereotype, and whose other
            // memberEnd (an ownedAttribute of the Stereotype named "base_<Metaclass>") is
            // typed by the extended metaclass.
            this.profile = new Package { Name = "StandardProfile" };

            this.metaclass = new Class { Name = "Abstraction" };
            this.stereotype = new Stereotype { Name = "Derive" };

            this.extensionEnd = new ExtensionEnd { Name = "extension_Derive", Type = this.stereotype };

            this.baseProperty = new Property { Name = "base_Abstraction", Type = this.metaclass };

            this.extension = new Extension { Name = "Abstraction_Derive" };
            this.extension.OwnedEnd.Add(this.extensionEnd);
            this.extension.MemberEnd.Add(this.extensionEnd);
            this.extension.MemberEnd.Add(this.baseProperty);

            this.stereotype.OwnedAttribute.Add(this.baseProperty);

            this.profile.PackagedElement.Add(this.metaclass);
            this.profile.PackagedElement.Add(this.stereotype);
            this.profile.PackagedElement.Add(this.extension);
        }

        [Test]
        public void Verify_that_when_class_is_null_argument_exception_is_thrown()
        {
            Class @class = null;

            Assert.That(() => ClassExtensions.QueryExtension(@class), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_Extension_on_the_stereotype_returns_the_extension()
        {
            Assert.That(this.stereotype.Extension, Is.EquivalentTo(new[] { this.extension }));
        }

        [Test]
        public void Verify_that_Extension_on_the_metaclass_returns_the_extension()
        {
            Assert.That(this.metaclass.Extension, Is.EquivalentTo(new[] { this.extension }));
        }

        [Test]
        public void Verify_that_Extension_on_an_unrelated_class_returns_an_empty_list()
        {
            var unrelated = new Class { Name = "Unrelated" };

            this.profile.PackagedElement.Add(unrelated);

            Assert.That(unrelated.Extension, Is.Empty);
        }

        [Test]
        public void Verify_that_Extension_on_a_class_without_owner_returns_an_empty_list()
        {
            var orphan = new Class { Name = "Orphan" };

            Assert.That(orphan.Extension, Is.Empty);
        }

        [Test]
        public void Verify_that_Extension_is_found_through_a_nested_package()
        {
            var nestedPackage = new Package { Name = "Nested" };

            var nestedMetaclass = new Class { Name = "NestedMetaclass" };
            var nestedStereotype = new Stereotype { Name = "NestedStereotype" };
            var nestedExtensionEnd = new ExtensionEnd { Name = "extension_NestedStereotype", Type = nestedStereotype };
            var nestedBaseProperty = new Property { Name = "base_NestedMetaclass", Type = nestedMetaclass };

            var nestedExtension = new Extension { Name = "NestedMetaclass_NestedStereotype" };
            nestedExtension.OwnedEnd.Add(nestedExtensionEnd);
            nestedExtension.MemberEnd.Add(nestedExtensionEnd);
            nestedExtension.MemberEnd.Add(nestedBaseProperty);

            nestedStereotype.OwnedAttribute.Add(nestedBaseProperty);

            nestedPackage.PackagedElement.Add(nestedMetaclass);
            nestedPackage.PackagedElement.Add(nestedStereotype);
            nestedPackage.PackagedElement.Add(nestedExtension);

            this.profile.PackagedElement.Add(nestedPackage);

            Assert.That(nestedMetaclass.Extension, Is.EquivalentTo(new[] { nestedExtension }));
        }
    }
}
