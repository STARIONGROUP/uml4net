// -------------------------------------------------------------------------------------------------
// <copyright file="ExtensionExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using uml4net.Values;

    [TestFixture]
    public class ExtensionExtensionsTestFixture
    {
        private Class metaclass;
        private Stereotype stereotype;
        private ExtensionEnd extensionEnd;
        private Property baseProperty;
        private Extension extension;

        [SetUp]
        public void SetUp()
        {
            // mirrors the "Abstraction_Derive" Extension in the OMG StandardProfile.xmi
            this.metaclass = new Class { Name = "Abstraction" };
            this.stereotype = new Stereotype { Name = "Derive" };

            this.extensionEnd = new ExtensionEnd { Name = "extension_Derive", Type = this.stereotype };
            this.baseProperty = new Property { Name = "base_Abstraction", Type = this.metaclass };

            this.extension = new Extension { Name = "Abstraction_Derive" };
            this.extension.OwnedEnd.Add(this.extensionEnd);
            this.extension.MemberEnd.Add(this.extensionEnd);
            this.extension.MemberEnd.Add(this.baseProperty);
        }

        [Test]
        public void Verify_that_when_extension_is_null_argument_null_exception_is_thrown()
        {
            Extension extension = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => ExtensionExtensions.QueryIsRequired(extension), Throws.ArgumentNullException);
                Assert.That(() => ExtensionExtensions.QueryMetaclass(extension), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_Metaclass_returns_the_class_typed_by_the_non_owned_memberEnd()
        {
            Assert.That(this.extension.Metaclass, Is.SameAs(this.metaclass));
        }

        [Test]
        public void Verify_that_IsRequired_is_false_when_the_ownedEnd_lower_is_0()
        {
            // set explicitly rather than relying on ExtensionEnd's default Lower - see GH-270,
            // which tracks that the default currently (incorrectly) resolves to 1, not the
            // spec-redefined default of 0
            this.extensionEnd.LowerValue.Add(new LiteralInteger { Value = 0 });

            Assert.That(this.extension.IsRequired, Is.False);
        }

        [Test]
        public void Verify_that_IsRequired_is_true_when_the_ownedEnd_lower_is_1()
        {
            this.extensionEnd.LowerValue.Add(new LiteralInteger { Value = 1 });

            Assert.That(this.extension.IsRequired, Is.True);
        }

        [Test]
        public void Verify_that_IsRequired_is_false_when_there_is_no_ownedEnd()
        {
            var orphan = new Extension { Name = "Orphan" };

            Assert.That(orphan.IsRequired, Is.False);
        }

        [Test]
        public void Verify_that_Metaclass_is_null_when_there_is_no_non_owned_memberEnd()
        {
            var orphan = new Extension { Name = "Orphan" };
            orphan.OwnedEnd.Add(this.extensionEnd);
            orphan.MemberEnd.Add(this.extensionEnd);

            Assert.That(orphan.Metaclass, Is.Null);
        }
    }
}
