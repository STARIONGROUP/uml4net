// -------------------------------------------------------------------------------------------------
// <copyright file="NamespaceExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Values;

    [TestFixture]
    public class NamespaceExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryOwnedMember_throws_when_namespace_is_null()
        {
            Package @namespace = null;

            Assert.That(() => NamespaceExtensions.QueryOwnedMember(@namespace), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryOwnedMember_always_includes_OwnedRule()
        {
            var package = new Package { Name = "P" };
            var rule = new Constraint { Name = "Rule" };
            package.OwnedRule.Add(rule);

            Assert.That(package.OwnedMember, Does.Contain(rule));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_PackagedElement_for_a_Package()
        {
            var package = new Package { Name = "P" };
            var nested = new Class { Name = "Nested" };
            package.PackagedElement.Add(nested);

            Assert.That(package.OwnedMember, Does.Contain(nested));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_Variable_for_an_Activity()
        {
            var activity = new Activity { Name = "A" };
            var variable = new Variable { Name = "v" };
            activity.Variable.Add(variable);

            Assert.That(activity.OwnedMember, Does.Contain(variable));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_the_Artifact_specific_collections()
        {
            var artifact = new Artifact { Name = "Art" };
            var nestedArtifact = new Artifact { Name = "Nested" };
            var attribute = new Property { Name = "attr" };
            var operation = new Operation { Name = "op" };
            artifact.NestedArtifact.Add(nestedArtifact);
            artifact.OwnedAttribute.Add(attribute);
            artifact.OwnedOperation.Add(operation);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(artifact.OwnedMember, Does.Contain(nestedArtifact));
                Assert.That(artifact.OwnedMember, Does.Contain(attribute));
                Assert.That(artifact.OwnedMember, Does.Contain(operation));
            }
        }

        [Test]
        public void Verify_that_QueryOwnedMember_uses_Extension_OwnedEnd_when_the_association_is_an_Extension()
        {
            var extension = new Extension { Name = "E" };
            var end = new ExtensionEnd { Name = "end" };
            extension.OwnedEnd.Add(end);

            Assert.That(extension.OwnedMember, Does.Contain(end));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_uses_Association_OwnedEnd_for_a_plain_Association()
        {
            var association = new Association { Name = "A" };
            var end = new Property { Name = "end" };
            association.OwnedEnd.Add(end);

            Assert.That(association.OwnedMember, Does.Contain(end));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_the_Behavior_specific_collections()
        {
            var behavior = new OpaqueBehavior { Name = "B" };
            var parameter = new Parameter { Name = "p" };
            var parameterSet = new ParameterSet { Name = "ps" };
            behavior.OwnedParameter.Add(parameter);
            behavior.OwnedParameterSet.Add(parameterSet);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(behavior.OwnedMember, Does.Contain(parameter));
                Assert.That(behavior.OwnedMember, Does.Contain(parameterSet));
            }
        }

        [Test]
        public void Verify_that_QueryOwnedMember_uses_Operation_OwnedParameter_when_the_feature_is_an_Operation()
        {
            var operation = new Operation { Name = "op" };
            var parameter = new Parameter { Name = "p" };
            operation.OwnedParameter.Add(parameter);

            Assert.That(operation.OwnedMember, Does.Contain(parameter));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_uses_BehavioralFeature_OwnedParameter_for_a_Reception()
        {
            var reception = new Reception { Name = "r" };
            var parameter = new Parameter { Name = "p" };
            reception.OwnedParameter.Add(parameter);

            Assert.That(reception.OwnedMember, Does.Contain(parameter));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_the_Class_specific_collections_and_does_not_throw_via_StructuredClassifier()
        {
            var @class = new Class { Name = "C" };
            var nestedClassifier = new Class { Name = "Nested" };
            var attribute = new Property { Name = "attr" };
            var operation = new Operation { Name = "op" };
            var reception = new Reception { Name = "rec" };
            var connector = new Connector { Name = "conn" };
            var behavior = new OpaqueBehavior { Name = "beh" };
            var useCase = new UseCase { Name = "uc" };
            @class.NestedClassifier.Add(nestedClassifier);
            @class.OwnedAttribute.Add(attribute);
            @class.OwnedOperation.Add(operation);
            @class.OwnedReception.Add(reception);
            @class.OwnedConnector.Add(connector);
            @class.OwnedBehavior.Add(behavior);
            @class.OwnedUseCase.Add(useCase);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@class.OwnedMember, Does.Contain(nestedClassifier));
                Assert.That(@class.OwnedMember, Does.Contain(attribute));
                Assert.That(@class.OwnedMember, Does.Contain(operation));
                Assert.That(@class.OwnedMember, Does.Contain(reception));
                Assert.That(@class.OwnedMember, Does.Contain(connector));
                Assert.That(@class.OwnedMember, Does.Contain(behavior));
                Assert.That(@class.OwnedMember, Does.Contain(useCase));
            }
        }

        [Test]
        public void Verify_that_QueryOwnedMember_uses_StructuredClassifier_OwnedAttribute_for_a_Collaboration()
        {
            var collaboration = new Collaboration { Name = "Collab" };
            var attribute = new Property { Name = "attr" };
            var connector = new Connector { Name = "conn" };
            collaboration.OwnedAttribute.Add(attribute);
            collaboration.OwnedConnector.Add(connector);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(collaboration.OwnedMember, Does.Contain(attribute));
                Assert.That(collaboration.OwnedMember, Does.Contain(connector));
            }
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_PackagedElement_for_a_Component()
        {
            var component = new Component { Name = "Comp" };
            var packagedElement = new Class { Name = "pe" };
            component.PackagedElement.Add(packagedElement);

            Assert.That(component.OwnedMember, Does.Contain(packagedElement));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_the_DataType_specific_collections()
        {
            var dataType = new DataType { Name = "DT" };
            var attribute = new Property { Name = "attr" };
            var operation = new Operation { Name = "op" };
            dataType.OwnedAttribute.Add(attribute);
            dataType.OwnedOperation.Add(operation);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(dataType.OwnedMember, Does.Contain(attribute));
                Assert.That(dataType.OwnedMember, Does.Contain(operation));
            }
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_OwnedLiteral_for_an_Enumeration()
        {
            var enumeration = new Enumeration { Name = "E" };
            var literal = new EnumerationLiteral { Name = "L" };
            enumeration.OwnedLiteral.Add(literal);

            Assert.That(enumeration.OwnedMember, Does.Contain(literal));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_the_Interaction_specific_collections()
        {
            var interaction = new Interaction { Name = "I" };
            var gate = new Gate { Name = "gate" };
            var lifeline = new Lifeline { Name = "lifeline" };
            var message = new Message { Name = "message" };
            interaction.FormalGate.Add(gate);
            interaction.Lifeline.Add(lifeline);
            interaction.Message.Add(message);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(interaction.OwnedMember, Does.Contain(gate));
                Assert.That(interaction.OwnedMember, Does.Contain(lifeline));
                Assert.That(interaction.OwnedMember, Does.Contain(message));
            }
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_the_Interface_specific_collections()
        {
            var @interface = new Interface { Name = "I" };
            var nestedClassifier = new Class { Name = "Nested" };
            var attribute = new Property { Name = "attr" };
            var operation = new Operation { Name = "op" };
            var reception = new Reception { Name = "rec" };
            var protocol = new ProtocolStateMachine { Name = "psm" };
            @interface.NestedClassifier.Add(nestedClassifier);
            @interface.OwnedAttribute.Add(attribute);
            @interface.OwnedOperation.Add(operation);
            @interface.OwnedReception.Add(reception);
            @interface.Protocol.Add(protocol);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@interface.OwnedMember, Does.Contain(nestedClassifier));
                Assert.That(@interface.OwnedMember, Does.Contain(attribute));
                Assert.That(@interface.OwnedMember, Does.Contain(operation));
                Assert.That(@interface.OwnedMember, Does.Contain(reception));
                Assert.That(@interface.OwnedMember, Does.Contain(protocol));
            }
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_NestedNode_for_a_Node()
        {
            var node = new Node { Name = "N" };
            var nestedNode = new Node { Name = "Nested" };
            node.NestedNode.Add(nestedNode);

            Assert.That(node.OwnedMember, Does.Contain(nestedNode));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_the_Region_specific_collections()
        {
            var region = new Region { Name = "R" };
            var vertex = new State { Name = "s" };
            var transition = new Transition { Name = "t" };
            region.Subvertex.Add(vertex);
            region.Transition.Add(transition);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(region.OwnedMember, Does.Contain(vertex));
                Assert.That(region.OwnedMember, Does.Contain(transition));
            }
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_OwnedAttribute_for_a_Signal()
        {
            var signal = new Signal { Name = "S" };
            var attribute = new Property { Name = "attr" };
            signal.OwnedAttribute.Add(attribute);

            Assert.That(signal.OwnedMember, Does.Contain(attribute));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_the_State_specific_collections()
        {
            var state = new State { Name = "S" };
            var connection = new ConnectionPointReference { Name = "conn" };
            var connectionPoint = new Pseudostate { Name = "cp" };
            var region = new Region { Name = "r" };
            state.Connection.Add(connection);
            state.ConnectionPoint.Add(connectionPoint);
            state.Region.Add(region);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(state.OwnedMember, Does.Contain(connection));
                Assert.That(state.OwnedMember, Does.Contain(connectionPoint));
                Assert.That(state.OwnedMember, Does.Contain(region));
            }
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_the_StateMachine_specific_collections()
        {
            var stateMachine = new StateMachine { Name = "SM" };
            var connectionPoint = new Pseudostate { Name = "cp" };
            var region = new Region { Name = "r" };
            stateMachine.ConnectionPoint.Add(connectionPoint);
            stateMachine.Region.Add(region);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(stateMachine.OwnedMember, Does.Contain(connectionPoint));
                Assert.That(stateMachine.OwnedMember, Does.Contain(region));
            }
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_Variable_for_a_StructuredActivityNode()
        {
            var structuredActivityNode = new StructuredActivityNode { Name = "SAN" };
            var variable = new Variable { Name = "v" };
            structuredActivityNode.Variable.Add(variable);

            Assert.That(structuredActivityNode.OwnedMember, Does.Contain(variable));
        }

        [Test]
        public void Verify_that_QueryOwnedMember_includes_the_UseCase_specific_collections()
        {
            var useCase = new UseCase { Name = "UC" };
            var extend = new Extend { Name = "ext" };
            var extensionPoint = new ExtensionPoint { Name = "ep" };
            var include = new Include { Name = "inc" };
            useCase.Extend.Add(extend);
            useCase.ExtensionPoint.Add(extensionPoint);
            useCase.Include.Add(include);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(useCase.OwnedMember, Does.Contain(extend));
                Assert.That(useCase.OwnedMember, Does.Contain(extensionPoint));
                Assert.That(useCase.OwnedMember, Does.Contain(include));
            }
        }

        [Test]
        public void Verify_that_QueryGetNamesOfMember_throws_when_an_argument_is_null()
        {
            var package = new Package { Name = "P" };
            var @class = new Class { Name = "C" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => NamespaceExtensions.QueryGetNamesOfMember(null, @class), Throws.ArgumentNullException);
                Assert.That(() => NamespaceExtensions.QueryGetNamesOfMember(package, null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryGetNamesOfMember_returns_the_own_name_for_an_owned_member()
        {
            var package = new Package { Name = "P" };
            var @class = new Class { Name = "C" };
            package.PackagedElement.Add(@class);

            Assert.That(package.QueryGetNamesOfMember(@class), Is.EquivalentTo(new[] { "C" }));
        }

        [Test]
        public void Verify_that_QueryGetNamesOfMember_returns_the_imported_element_name_when_imported_without_an_alias()
        {
            var package = new Package { Name = "P" };
            var importedElement = new Class { Name = "Imported" };
            var elementImport = new ElementImport { ImportedElement = importedElement };
            package.ElementImport.Add(elementImport);

            Assert.That(package.QueryGetNamesOfMember(importedElement), Is.EquivalentTo(new[] { "Imported" }));
        }

        [Test]
        public void Verify_that_QueryGetNamesOfMember_returns_the_alias_when_imported_with_an_alias()
        {
            var package = new Package { Name = "P" };
            var importedElement = new Class { Name = "Imported" };
            var elementImport = new ElementImport { Alias = "Aliased", ImportedElement = importedElement };
            package.ElementImport.Add(elementImport);

            Assert.That(package.QueryGetNamesOfMember(importedElement), Is.EquivalentTo(new[] { "Aliased" }));
        }

        [Test]
        public void Verify_that_QueryGetNamesOfMember_returns_an_empty_list_when_the_element_is_neither_owned_nor_imported()
        {
            var package = new Package { Name = "P" };
            var unrelated = new Class { Name = "Unrelated" };

            Assert.That(package.QueryGetNamesOfMember(unrelated), Is.Empty);
        }

        [Test]
        public void Verify_that_QueryExcludeCollisions_and_QueryImportMembers_throw_when_an_argument_is_null()
        {
            var package = new Package { Name = "P" };
            var imps = new List<IPackageableElement>();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => NamespaceExtensions.QueryExcludeCollisions(null, imps), Throws.ArgumentNullException);
                Assert.That(() => NamespaceExtensions.QueryExcludeCollisions(package, null), Throws.ArgumentNullException);
                Assert.That(() => NamespaceExtensions.QueryImportMembers(null, imps), Throws.ArgumentNullException);
                Assert.That(() => NamespaceExtensions.QueryImportMembers(package, null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryExcludeCollisions_keeps_candidates_that_do_not_collide()
        {
            var package = new Package { Name = "P" };
            var classCandidate = new Class { Name = "Same" };
            var signalCandidate = new Signal { Name = "Same" };

            var result = package.QueryExcludeCollisions(new IPackageableElement[] { classCandidate, signalCandidate });

            Assert.That(result, Is.EquivalentTo(new IPackageableElement[] { classCandidate, signalCandidate }));
        }

        [Test]
        public void Verify_that_QueryExcludeCollisions_excludes_candidates_that_collide_with_each_other()
        {
            // Real callers (Namespace.ImportedMember) always pass candidates that are themselves the
            // ImportedElement of one of this Namespace's own ElementImports - getNamesOfMember only
            // resolves a real name for a candidate that is registered that way (or already owned),
            // so the two candidates need their own ElementImports here to be comparable at all.
            var package = new Package { Name = "P" };
            var classCandidate1 = new Class { Name = "Original1" };
            var classCandidate2 = new Class { Name = "Original2" };
            package.ElementImport.Add(new ElementImport { ImportedElement = classCandidate1, Alias = "Same" });
            package.ElementImport.Add(new ElementImport { ImportedElement = classCandidate2, Alias = "Same" });

            var result = package.QueryExcludeCollisions(new IPackageableElement[] { classCandidate1, classCandidate2 });

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Verify_that_QueryImportMembers_excludes_a_candidate_that_collides_with_an_owned_member()
        {
            var package = new Package { Name = "P" };
            var ownedMember = new Class { Name = "Same" };
            package.PackagedElement.Add(ownedMember);

            var candidate = new Class { Name = "Original" };
            package.ElementImport.Add(new ElementImport { ImportedElement = candidate, Alias = "Same" });

            var result = package.QueryImportMembers(new IPackageableElement[] { candidate });

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Verify_that_QueryImportMembers_keeps_a_candidate_distinguishable_from_everything()
        {
            var package = new Package { Name = "P" };
            var ownedMember = new Class { Name = "Owned" };
            package.PackagedElement.Add(ownedMember);

            var candidate = new Class { Name = "Distinct" };
            package.ElementImport.Add(new ElementImport { ImportedElement = candidate });

            var result = package.QueryImportMembers(new IPackageableElement[] { candidate });

            Assert.That(result, Is.EquivalentTo(new IPackageableElement[] { candidate }));
        }

        [Test]
        public void Verify_that_QueryImportedMember_throws_when_namespace_is_null()
        {
            Package @namespace = null;

            Assert.That(() => NamespaceExtensions.QueryImportedMember(@namespace), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryImportedMember_includes_an_element_imported_via_ElementImport()
        {
            var package = new Package { Name = "P" };
            var importedElement = new Class { Name = "Imported" };
            package.ElementImport.Add(new ElementImport { ImportedElement = importedElement });

            Assert.That(package.ImportedMember, Is.EquivalentTo(new IPackageableElement[] { importedElement }));
        }

        [Test]
        public void Verify_that_QueryImportedMember_excludes_an_element_that_collides_with_an_owned_member()
        {
            var package = new Package { Name = "P" };
            var ownedMember = new Class { Name = "Same" };
            package.PackagedElement.Add(ownedMember);

            var importedElement = new Class { Name = "Original" };
            package.ElementImport.Add(new ElementImport { ImportedElement = importedElement, Alias = "Same" });

            Assert.That(package.ImportedMember, Is.Empty);
        }

        [Test]
        public void Verify_that_QueryMember_throws_when_namespace_is_null()
        {
            Package @namespace = null;

            Assert.That(() => NamespaceExtensions.QueryMember(@namespace), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryMember_is_the_union_of_OwnedMember_and_ImportedMember()
        {
            var package = new Package { Name = "P" };
            var ownedMember = new Class { Name = "Owned" };
            package.PackagedElement.Add(ownedMember);

            var importedElement = new Class { Name = "Imported" };
            package.ElementImport.Add(new ElementImport { ImportedElement = importedElement });

            Assert.That(package.Member, Is.EquivalentTo(new INamedElement[] { ownedMember, importedElement }));
        }
    }
}
