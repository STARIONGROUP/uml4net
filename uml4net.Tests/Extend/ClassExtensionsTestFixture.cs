// -------------------------------------------------------------------------------------------------
//  <copyright file="ClassExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.Tests.Extend
{
    using System.Collections.Generic;
    
    using NUnit.Framework;

    using uml4net.Classification;
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
            animal_is_generalization_of_mammal.Specific = mammal;

            var mammal_is_generalization_of_cat = new Generalization();
            mammal_is_generalization_of_cat.General = mammal;
            mammal_is_generalization_of_cat.Specific = cat;

            cat.Generalization.Add(mammal_is_generalization_of_cat);
            animal.Generalization.Add(animal_is_generalization_of_mammal);

            var general = ClassifierExtensions.QueryGeneral(cat);

            Assert.That(general, Is.EquivalentTo(new List<IClass>() { mammal }));
        }

        [Test]
        public void Verify_that_when_Class_is_null_argument_exception_is_thrown()
        {
            Class @class = null;

            Assert.That(() => ClassifierExtensions.QueryGeneral(@class), Throws.ArgumentNullException);
        }
    }
}
