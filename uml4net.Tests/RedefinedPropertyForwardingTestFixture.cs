// -------------------------------------------------------------------------------------------------
// <copyright file="RedefinedPropertyForwardingTestFixture.cs" company="Starion Group S.A.">
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
    using System;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Tests that reading (and, where safe, writing) a redefined property through a base interface
    /// forwards to the redefining property instead of throwing, per the fix for GH-232.
    /// </summary>
    [TestFixture]
    public class RedefinedPropertyForwardingTestFixture
    {
        [Test]
        public void Verify_that_a_value_typed_redefined_property_is_readable_and_writable_through_the_base_interface()
        {
            var @class = new Class { IsAbstract = true };

            IClassifier classifier = @class;

            Assert.That(classifier.IsAbstract, Is.True);

            classifier.IsAbstract = false;

            Assert.That(@class.IsAbstract, Is.False);
        }

        [Test]
        public void Verify_that_an_enum_typed_redefined_property_is_readable_and_writable_through_the_base_interface()
        {
            var @class = new Class { Visibility = VisibilityKind.Public };

            INamedElement namedElement = @class;

            Assert.That(namedElement.Visibility, Is.EqualTo(VisibilityKind.Public));

            namedElement.Visibility = VisibilityKind.Private;

            Assert.That(@class.Visibility, Is.EqualTo(VisibilityKind.Private));
        }

        [Test]
        public void Verify_that_a_narrower_collection_element_type_is_readable_through_the_base_interface()
        {
            var parent = new Class { Name = "Parent" };
            var child = new Class { Name = "Child" };
            child.Generalization.Add(new Generalization { General = parent });

            IClassifier classifier = child;

            Assert.That(classifier.General, Is.EquivalentTo(new IClassifier[] { parent }));
        }

        [Test]
        public void Verify_that_a_narrower_scalar_type_is_readable_through_the_base_interface()
        {
            var stereotype = new Stereotype { Name = "MyStereotype" };
            var extensionEnd = new ExtensionEnd { Type = stereotype };

            ITypedElement typedElement = extensionEnd;

            Assert.That(typedElement.Type, Is.SameAs(stereotype));
        }

        [Test]
        public void Verify_that_setting_a_narrower_scalar_type_through_the_base_interface_with_a_compatible_value_succeeds()
        {
            var stereotype = new Stereotype { Name = "MyStereotype" };
            var extensionEnd = new ExtensionEnd();

            ITypedElement typedElement = extensionEnd;

            typedElement.Type = stereotype;

            Assert.That(extensionEnd.Type, Is.SameAs(stereotype));
        }

        [Test]
        public void Verify_that_setting_a_narrower_scalar_type_through_the_base_interface_with_an_incompatible_value_throws()
        {
            var extensionEnd = new ExtensionEnd();
            var incompatibleType = new PrimitiveType { Name = "Integer" };

            ITypedElement typedElement = extensionEnd;

            Assert.That(() => typedElement.Type = incompatibleType, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void Verify_that_a_composite_collection_with_a_narrower_element_type_still_throws_through_the_base_interface()
        {
            var @class = new Class();

            ITemplateableElement templateableElement = @class;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => templateableElement.OwnedTemplateSignature, Throws.InvalidOperationException);
                Assert.That(() => templateableElement.OwnedTemplateSignature = null, Throws.InvalidOperationException);
            }
        }
    }
}
