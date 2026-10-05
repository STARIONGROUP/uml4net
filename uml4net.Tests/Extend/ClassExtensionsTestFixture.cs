// -------------------------------------------------------------------------------------------------
// <copyright file="ClassExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ClassExtensionsTestFixture
    {
        [Test]
        public void Verify_that_the_SuperClass_of_a_class_returns_the_expected_result()
        {
            var animal = new Class { Name = "Animal" };
            var mammal = new Class { Name = "Mammal" };
            var cat = new Class { Name = "Cat" };

            var animal_is_generalization_of_mammal = new Generalization();
            animal_is_generalization_of_mammal.General = animal;

            var mammal_is_generalization_of_cat = new Generalization();
            mammal_is_generalization_of_cat.General = mammal;

            cat.Generalization.Add(mammal_is_generalization_of_cat);
            mammal.Generalization.Add(animal_is_generalization_of_mammal);

            var superClasses = cat.SuperClass;

            Assert.That(superClasses, Is.EquivalentTo(new List<IClass>() { mammal }));
        }

        [Test]
        public void Verify_that_SuperClass_contains_no_duplicates_and_no_null()
        {
            // superClass = self.general()->select(oclIsKindOf(Class))->collect(oclAsType(Class))->asSet()
            var animal = new Class { Name = "Animal" };
            var named = new Interface { Name = "Named" };
            var cat = new Class { Name = "Cat" };

            cat.Generalization.Add(new Generalization { General = animal });
            cat.Generalization.Add(new Generalization { General = animal });
            cat.Generalization.Add(new Generalization());
            cat.Generalization.Add(new Generalization { General = named });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(cat.SuperClass, Is.EqualTo(new List<IClass> { animal }), "two generalizations to the same general give one super class, one without a general gives none");
                Assert.That(((IClassifier)cat).General, Is.EqualTo(new List<IClassifier> { animal, named }), "IClassifier.General keeps every parent, superClass selects the Classes (#494)");
                Assert.That(cat.QueryGeneral(), Is.EqualTo(new List<IClassifier> { animal, named }), "general() itself keeps the Interface; superClass selects the Classes");
            }
        }

        [Test]
        public void Verify_that_General_of_an_AssociationClass_contains_a_general_Association()
        {
            // an AssociationClass may specialize a plain Association (Classifier::maySpecializeType); general = parents()
            // keeps it while superClass, which redefines general, selects the Classes only (#494)
            var associationClass = new AssociationClass { Name = "AC" };
            var association = new Association { Name = "A" };
            var @class = new Class { Name = "C" };

            associationClass.Generalization.Add(new Generalization { General = association });
            associationClass.Generalization.Add(new Generalization { General = @class });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(((IClassifier)associationClass).General, Is.EquivalentTo(new IClassifier[] { association, @class }));
                Assert.That(((IAssociation)associationClass).General, Is.EquivalentTo(new IClassifier[] { association, @class }));
                Assert.That(associationClass.SuperClass, Is.EquivalentTo(new IClass[] { @class }));
            }
        }

        [Test]
        public void Verify_that_General_of_a_classifier_contains_no_duplicates_and_no_null()
        {
            // general = parents() = generalization.general->asSet()
            var first = new Interface { Name = "First" };
            var second = new Interface { Name = "Second" };
            var @interface = new Interface { Name = "I" };

            @interface.Generalization.Add(new Generalization { General = first });
            @interface.Generalization.Add(new Generalization());
            @interface.Generalization.Add(new Generalization { General = second });
            @interface.Generalization.Add(new Generalization { General = first });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@interface.General, Is.EqualTo(new List<IClassifier> { first, second }));
                Assert.That(@interface.General, Has.None.Null);
                Assert.That(() => ClassifierExtensions.QueryGeneral(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_when_relationship_is_null_exception_is_thrown()
        {
            Assert.That(() => ClassExtensions.QuerySuperClass(null), Throws.ArgumentNullException);
        }
    }
}
