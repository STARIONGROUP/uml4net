// -------------------------------------------------------------------------------------------------
//  <copyright file="DirectedRelationshipExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
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
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class DirectedRelationshipExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_Generalization_Source_and_Target_return_expected_result()
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

            using (Assert.EnterMultipleScope())
            {
                Assert.That(animal_is_generalization_of_mammal.Source, Is.EquivalentTo([mammal]));
                Assert.That(animal_is_generalization_of_mammal.Target, Is.EquivalentTo([animal]));
            }
        }

        [Test]
        public void Verify_that_when_QuerySource_or_QueryTarget_is_called_with_null_argument_exception_is_thrown()
        {
            IDirectedRelationship directedRelationship = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => DirectedRelationshipExtensions.QuerySource(directedRelationship), Throws.ArgumentNullException);
                Assert.That(() => DirectedRelationshipExtensions.QueryTarget(directedRelationship), Throws.ArgumentNullException);
            }
        }
    }
}
