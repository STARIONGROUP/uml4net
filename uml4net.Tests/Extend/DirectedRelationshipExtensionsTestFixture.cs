// -------------------------------------------------------------------------------------------------
// <copyright file="DirectedRelationshipExtensionsTestFixture.cs" company="Starion Group S.A.">
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
        public void Verify_that_Source_and_Target_of_a_Dependency_are_its_clients_and_suppliers()
        {
            var client = new Class { Name = "Client" };
            var supplierA = new Class { Name = "SupplierA" };
            var supplierB = new Class { Name = "SupplierB" };

            foreach (var dependency in new IDependency[] { new Dependency(), new Abstraction(), new Realization(), new Usage() })
            {
                dependency.Client.Add(client);
                dependency.Supplier.Add(supplierA);
                dependency.Supplier.Add(supplierB);

                using (Assert.EnterMultipleScope())
                {
                    Assert.That(dependency.Source, Is.EquivalentTo([client]), dependency.GetType().Name);
                    Assert.That(dependency.Target, Is.EquivalentTo([supplierA, supplierB]), dependency.GetType().Name);
                }
            }
        }

        [Test]
        public void Verify_that_Source_and_Target_of_Dependency_specializations_include_their_own_subsetting_properties()
        {
            var component = new Component { Name = "Component" };
            var realizingClassifier = new Class { Name = "Realizing" };
            var componentRealization = new ComponentRealization { Abstraction = component };
            componentRealization.RealizingClassifier.Add(realizingClassifier);
            componentRealization.Client.Add(realizingClassifier);

            var @interface = new Interface { Name = "Interface" };
            var implementingClassifier = new Class { Name = "Implementing" };
            var interfaceRealization = new InterfaceRealization { Contract = @interface, ImplementingClassifier = implementingClassifier };

            var contract = new Class { Name = "Contract" };
            var substitutingClassifier = new Class { Name = "Substituting" };
            var substitution = new Substitution { Contract = contract, SubstitutingClassifier = substitutingClassifier };

            var node = new Node { Name = "Node" };
            var artifact = new Artifact { Name = "Artifact" };
            var deployment = new Deployment { Location = node };
            deployment.DeployedArtifact.Add(artifact);

            var utilizedElement = new Class { Name = "Utilized" };
            var manifestation = new Manifestation { UtilizedElement = utilizedElement };
            manifestation.Client.Add(artifact);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(componentRealization.Source, Is.EquivalentTo([realizingClassifier]), "a classifier in both client and realizingClassifier is expected once");
                Assert.That(componentRealization.Target, Is.EquivalentTo([component]));
                Assert.That(interfaceRealization.Source, Is.EquivalentTo([implementingClassifier]));
                Assert.That(interfaceRealization.Target, Is.EquivalentTo([@interface]));
                Assert.That(substitution.Source, Is.EquivalentTo([substitutingClassifier]));
                Assert.That(substitution.Target, Is.EquivalentTo([contract]));
                Assert.That(deployment.Source, Is.EquivalentTo([node]));
                Assert.That(deployment.Target, Is.EquivalentTo([artifact]));
                Assert.That(manifestation.Source, Is.EquivalentTo([artifact]));
                Assert.That(manifestation.Target, Is.EquivalentTo([utilizedElement]));
            }
        }

        [Test]
        public void Verify_that_Source_and_Target_of_the_other_directed_relationships_are_their_subsetting_properties()
        {
            var importingPackage = new Package { Name = "Importing" };
            var importedClass = new Class { Name = "Imported" };
            var importedPackage = new Package { Name = "ImportedPackage" };
            var elementImport = new ElementImport { ImportingNamespace = importingPackage, ImportedElement = importedClass };
            var packageImport = new PackageImport { ImportingNamespace = importingPackage, ImportedPackage = importedPackage };
            var packageMerge = new PackageMerge { ReceivingPackage = importingPackage, MergedPackage = importedPackage };

            var profile = new Profile { Name = "Profile" };
            var profileApplication = new ProfileApplication { ApplyingPackage = importingPackage, AppliedProfile = profile };

            var generalMachine = new ProtocolStateMachine { Name = "General" };
            var specificMachine = new ProtocolStateMachine { Name = "Specific" };
            var protocolConformance = new ProtocolConformance { SpecificMachine = specificMachine, GeneralMachine = generalMachine };

            var boundClass = new Class { Name = "Bound" };
            var signature = new TemplateSignature();
            var templateBinding = new TemplateBinding { BoundElement = boundClass, Signature = signature };

            var informationSource = new Class { Name = "InformationSource" };
            var informationTarget = new Class { Name = "InformationTarget" };
            var informationFlow = new InformationFlow();
            informationFlow.InformationSource.Add(informationSource);
            informationFlow.InformationTarget.Add(informationTarget);

            var extendingCase = new UseCase { Name = "Extending" };
            var extendedCase = new UseCase { Name = "Extended" };
            var extend = new uml4net.UseCases.Extend { Extension = extendingCase, ExtendedCase = extendedCase };
            var include = new Include { IncludingCase = extendingCase, Addition = extendedCase };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(elementImport.Source, Is.EquivalentTo([importingPackage]));
                Assert.That(elementImport.Target, Is.EquivalentTo([importedClass]));
                Assert.That(packageImport.Source, Is.EquivalentTo([importingPackage]));
                Assert.That(packageImport.Target, Is.EquivalentTo([importedPackage]));
                Assert.That(packageMerge.Source, Is.EquivalentTo([importingPackage]));
                Assert.That(packageMerge.Target, Is.EquivalentTo([importedPackage]));
                Assert.That(profileApplication.Source, Is.EquivalentTo([importingPackage]));
                Assert.That(profileApplication.Target, Is.EquivalentTo([profile]));
                Assert.That(protocolConformance.Source, Is.EquivalentTo([specificMachine]));
                Assert.That(protocolConformance.Target, Is.EquivalentTo([generalMachine]));
                Assert.That(templateBinding.Source, Is.EquivalentTo([boundClass]));
                Assert.That(templateBinding.Target, Is.EquivalentTo([signature]));
                Assert.That(informationFlow.Source, Is.EquivalentTo([informationSource]));
                Assert.That(informationFlow.Target, Is.EquivalentTo([informationTarget]));
                Assert.That(extend.Source, Is.EquivalentTo([extendingCase]));
                Assert.That(extend.Target, Is.EquivalentTo([extendedCase]));
                Assert.That(include.Source, Is.EquivalentTo([extendingCase]));
                Assert.That(include.Target, Is.EquivalentTo([extendedCase]));
            }
        }

        [Test]
        public void Verify_that_Source_falls_back_to_the_owner_when_the_owner_subsetting_end_is_not_set()
        {
            // the reader does not populate ends that subset Element::owner (they are not serialized), the owner is known
            // through the containment though
            var general = new Class { Name = "General" };
            var specific = new Class { Name = "Specific" };
            var generalization = new Generalization { General = general };
            specific.Generalization.Add(generalization);

            var importingPackage = new Package { Name = "Importing" };
            var importedPackage = new Package { Name = "Imported" };
            var packageImport = new PackageImport { ImportedPackage = importedPackage };
            var elementImport = new ElementImport { ImportedElement = importedPackage };
            var packageMerge = new PackageMerge { MergedPackage = importedPackage };
            var profileApplication = new ProfileApplication { AppliedProfile = new Profile() };
            importingPackage.PackageImport.Add(packageImport);
            importingPackage.ElementImport.Add(elementImport);
            importingPackage.PackageMerge.Add(packageMerge);
            importingPackage.ProfileApplication.Add(profileApplication);

            var implementingClassifier = new Class { Name = "Implementing" };
            var interfaceRealization = new InterfaceRealization { Contract = new Interface() };
            implementingClassifier.InterfaceRealization.Add(interfaceRealization);

            var substitutingClassifier = new Class { Name = "Substituting" };
            var substitution = new Substitution { Contract = new Class() };
            substitutingClassifier.Substitution.Add(substitution);

            var component = new Component { Name = "Component" };
            var componentRealization = new ComponentRealization();
            componentRealization.RealizingClassifier.Add(implementingClassifier);
            component.Realization.Add(componentRealization);

            var node = new Node { Name = "Node" };
            var deployment = new Deployment();
            node.Deployment.Add(deployment);

            var specificMachine = new ProtocolStateMachine { Name = "Specific" };
            var protocolConformance = new ProtocolConformance { GeneralMachine = new ProtocolStateMachine() };
            specificMachine.Conformance.Add(protocolConformance);

            var boundClass = new Class { Name = "Bound" };
            var templateBinding = new TemplateBinding { Signature = new TemplateSignature() };
            boundClass.TemplateBinding.Add(templateBinding);

            var useCase = new UseCase { Name = "UseCase" };
            var extend = new uml4net.UseCases.Extend { ExtendedCase = new UseCase() };
            var include = new Include { Addition = new UseCase() };
            useCase.Extend.Add(extend);
            useCase.Include.Add(include);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(generalization.Specific, Is.Null);
                Assert.That(generalization.Source, Is.EquivalentTo([specific]));
                Assert.That(packageImport.Source, Is.EquivalentTo([importingPackage]));
                Assert.That(elementImport.Source, Is.EquivalentTo([importingPackage]));
                Assert.That(packageMerge.Source, Is.EquivalentTo([importingPackage]));
                Assert.That(profileApplication.Source, Is.EquivalentTo([importingPackage]));
                Assert.That(interfaceRealization.Source, Is.EquivalentTo([implementingClassifier]));
                Assert.That(substitution.Source, Is.EquivalentTo([substitutingClassifier]));
                Assert.That(componentRealization.Target, Is.EquivalentTo([component]));
                Assert.That(deployment.Source, Is.EquivalentTo([node]));
                Assert.That(protocolConformance.Source, Is.EquivalentTo([specificMachine]));
                Assert.That(templateBinding.Source, Is.EquivalentTo([boundClass]));
                Assert.That(extend.Source, Is.EquivalentTo([useCase]));
                Assert.That(include.Source, Is.EquivalentTo([useCase]));
            }
        }

        [Test]
        public void Verify_that_unset_subsetting_properties_are_not_returned_as_null()
        {
            var generalization = new Generalization();
            var elementImport = new ElementImport();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(generalization.Source, Is.Empty);
                Assert.That(generalization.Target, Is.Empty);
                Assert.That(elementImport.Source, Is.Empty);
                Assert.That(elementImport.Target, Is.Empty);
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
