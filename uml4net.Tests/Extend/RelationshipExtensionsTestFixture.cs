// -------------------------------------------------------------------------------------------------
// <copyright file="RelationshipExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.InformationFlows;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;

    [TestFixture]
    public class RelationshipExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_Generalization_QueryRelatedElement_return_expected_result()
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
            mammal.Generalization.Add(animal_is_generalization_of_mammal);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(animal_is_generalization_of_mammal.RelatedElement, Is.EquivalentTo([animal, mammal]));
                Assert.That(mammal_is_generalization_of_cat.RelatedElement, Is.EquivalentTo([mammal, cat]));
            }
        }

        [Test]
        public void Verify_that_RelatedElement_of_a_DirectedRelationship_is_the_union_of_Source_and_Target()
        {
            var classA = new Class { Name = "A" };
            var classB = new Class { Name = "B" };

            var dependency = new Dependency();
            dependency.Client.Add(classA);
            dependency.Supplier.Add(classB);
            dependency.Supplier.Add(classA);

            Assert.That(dependency.RelatedElement, Is.EquivalentTo([classA, classB]), "an element that is both source and target is expected once");
        }

        [Test]
        public void Verify_that_RelatedElement_of_an_Association_with_class_owned_ends_is_its_EndType()
        {
            var classA = new Class { Name = "A" };
            var classB = new Class { Name = "B" };

            var endTypedByB = new Property { Name = "b", Type = classB };
            var endTypedByA = new Property { Name = "a", Type = classA };
            classA.OwnedAttribute.Add(endTypedByB);
            classB.OwnedAttribute.Add(endTypedByA);

            var association = new Association();
            association.MemberEnd.Add(endTypedByA);
            association.MemberEnd.Add(endTypedByB);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(association.OwnedEnd, Is.Empty);
                Assert.That(association.RelatedElement, Is.EquivalentTo([classA, classB]));
            }
        }

        [Test]
        public void Verify_that_RelatedElement_of_an_Extension_is_the_metaclass_and_the_stereotype()
        {
            var metaclass = new Class { Name = "Class" };
            var stereotype = new Stereotype { Name = "Stereotype" };

            var metaclassEnd = new Property { Name = "base_Class", Type = metaclass };
            var extensionEnd = new ExtensionEnd { Name = "extension_Stereotype", Type = stereotype };

            var extension = new Extension();
            extension.OwnedEnd.Add(extensionEnd);
            extension.MemberEnd.Add(metaclassEnd);
            extension.MemberEnd.Add(extensionEnd);

            Assert.That(extension.RelatedElement, Is.EquivalentTo(new IElement[] { metaclass, stereotype }));
        }

        [Test]
        public void Verify_that_RelatedElement_Source_and_Target_do_not_throw_for_any_relationship()
        {
            var relationships = new IRelationship[]
            {
                new Abstraction(), new Association(), new AssociationClass(), new CommunicationPath(), new ComponentRealization(),
                new Dependency(), new Deployment(), new ElementImport(), new uml4net.UseCases.Extend(), new Extension(),
                new Generalization(), new Include(), new InformationFlow(), new InterfaceRealization(), new Manifestation(),
                new PackageImport(), new PackageMerge(), new ProfileApplication(), new ProtocolConformance(), new Realization(),
                new Substitution(), new TemplateBinding(), new Usage()
            };

            using (Assert.EnterMultipleScope())
            {
                foreach (var relationship in relationships)
                {
                    Assert.That(relationship.RelatedElement, Is.Empty, relationship.GetType().Name);

                    if (relationship is IDirectedRelationship directedRelationship)
                    {
                        Assert.That(directedRelationship.Source, Is.Empty, relationship.GetType().Name);
                        Assert.That(directedRelationship.Target, Is.Empty, relationship.GetType().Name);
                    }
                }
            }
        }

        [Test]
        public void Verify_that_when_relationship_is_null_exception_is_thrown()
        {
            Assert.That(() => RelationshipExtensions.QueryRelatedElement(null), Throws.ArgumentNullException);
        }
    }
}
