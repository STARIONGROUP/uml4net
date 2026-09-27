// -------------------------------------------------------------------------------------------------
// <copyright file="OptionalValueTypesTestFixture.cs" company="Starion Group S.A.">
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
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;

    /// <summary>
    /// Verifies the initial values of the optional [0..1] value-typed properties: null when the metamodel has no default,
    /// the metamodel default otherwise
    /// </summary>
    [TestFixture]
    public class OptionalValueTypesTestFixture
    {
        [Test]
        public void Verify_that_optional_value_typed_properties_start_with_the_metamodel_default_or_no_value()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Property().Visibility, Is.Null, "NamedElement::visibility [0..1] has no default");
                Assert.That(new Constraint().Visibility, Is.EqualTo(VisibilityKind.Public), "PackageableElement::visibility [0..1] = public");
                Assert.That(new Class().Visibility, Is.EqualTo(VisibilityKind.Public));
                Assert.That(new Parameter().Effect, Is.Null, "Parameter::effect [0..1] has no default");
                Assert.That(new Generalization().IsSubstitutable, Is.True, "Generalization::isSubstitutable [0..1] = true");
                Assert.That(new TimeConstraint().FirstEvent, Is.True, "TimeConstraint::firstEvent [0..1] = true");
                Assert.That(new Operation().Lower, Is.Null, "Operation::lower is null without a return parameter");
                Assert.That(new ExtensionEnd().Lower, Is.EqualTo(0), "ExtensionEnd::lower redefines the [1..1] MultiplicityElement::lower and stays an int");
            }
        }

        [Test]
        public void Verify_that_an_optional_value_can_be_cleared()
        {
            var @class = new Class { Visibility = VisibilityKind.Private };
            var generalization = new Generalization { IsSubstitutable = false };

            @class.Visibility = null;
            generalization.IsSubstitutable = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@class.Visibility, Is.Null);
                Assert.That(((INamedElement)@class).Visibility, Is.Null, "PackageableElement::visibility redefines NamedElement::visibility");
                Assert.That(generalization.IsSubstitutable, Is.Null);
            }
        }
    }
}
