// -------------------------------------------------------------------------------------------------
// <copyright file="RedefinableElementExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.Deployments;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;

    [TestFixture]
    public class RedefinableElementExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryRedefinedElement_throws_when_argument_is_null()
        {
            IRedefinableElement redefinableElement = null;

            Assert.That(() => RedefinableElementExtensions.QueryRedefinedElement(redefinableElement), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_RedefinedEdge_for_an_ActivityEdge()
        {
            var edge = new ControlFlow { Name = "e" };
            var redefined = new ControlFlow { Name = "redefined" };
            edge.RedefinedEdge.Add(redefined);

            Assert.That(edge.QueryRedefinedElement(), Is.EquivalentTo(new IRedefinableElement[] { redefined }));
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_RedefinedNode_for_an_ActivityNode()
        {
            var node = new OpaqueAction { Name = "n" };
            var redefined = new OpaqueAction { Name = "redefined" };
            node.RedefinedNode.Add(redefined);

            Assert.That(node.QueryRedefinedElement(), Is.EquivalentTo(new IRedefinableElement[] { redefined }));
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_RedefinedConnector_for_a_Connector()
        {
            var connector = new Connector { Name = "c" };
            var redefined = new Connector { Name = "redefined" };
            connector.RedefinedConnector.Add(redefined);

            Assert.That(connector.QueryRedefinedElement(), Is.EquivalentTo(new IRedefinableElement[] { redefined }));
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_ExtendedRegion_for_a_Region()
        {
            var region = new Region { Name = "r" };
            var extended = new Region { Name = "extended" };
            region.ExtendedRegion = extended;

            Assert.That(region.QueryRedefinedElement(), Is.EquivalentTo(new IRedefinableElement[] { extended }));
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_an_empty_list_when_ExtendedRegion_is_null()
        {
            var region = new Region { Name = "r" };

            Assert.That(region.QueryRedefinedElement(), Is.Empty);
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_RedefinedTransition_for_a_Transition()
        {
            var transition = new Transition { Name = "t" };
            var redefined = new Transition { Name = "redefined" };
            transition.RedefinedTransition = redefined;

            Assert.That(transition.QueryRedefinedElement(), Is.EquivalentTo(new IRedefinableElement[] { redefined }));
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_RedefinedVertex_for_a_Vertex()
        {
            var state = new State { Name = "s" };
            var redefined = new State { Name = "redefined" };
            state.RedefinedVertex = redefined;

            Assert.That(state.QueryRedefinedElement(), Is.EquivalentTo(new IRedefinableElement[] { redefined }));
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_RedefinedClassifier_for_a_Classifier()
        {
            var @class = new Class { Name = "C" };
            var redefined = new Class { Name = "redefined" };
            @class.RedefinedClassifier.Add(redefined);

            Assert.That(@class.QueryRedefinedElement(), Is.EquivalentTo(new IRedefinableElement[] { redefined }));
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_RedefinedInterface_for_an_Interface()
        {
            var redefined = new Interface { Name = "Redefined" };
            var redefinedAsClassifier = new Interface { Name = "RedefinedAsClassifier" };
            var @interface = new Interface { Name = "I" };
            @interface.RedefinedInterface.Add(redefined);
            @interface.RedefinedClassifier.Add(redefinedAsClassifier);
            var inBothLists = new Interface { Name = "InBothLists" };
            @interface.RedefinedInterface.Add(inBothLists);
            @interface.RedefinedClassifier.Add(inBothLists);

            Assert.That(@interface.RedefinedElement, Is.EquivalentTo(new IRedefinableElement[] { redefined, redefinedAsClassifier, inBothLists }), "redefinedInterface subsets redefinedClassifier; the union is de-duplicated");
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_RedefinedBehavior_for_a_Behavior()
        {
            var redefined = new Activity { Name = "Redefined" };
            var activity = new Activity { Name = "A" };
            activity.RedefinedBehavior.Add(redefined);

            Assert.That(activity.RedefinedElement, Is.EquivalentTo(new IRedefinableElement[] { redefined }));
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_ExtendedStateMachine_for_a_StateMachine_and_does_not_throw()
        {
            var extended = new StateMachine { Name = "Extended" };
            var stateMachine = new StateMachine { Name = "SM" };
            stateMachine.ExtendedStateMachine.Add(extended);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => stateMachine.RedefinedElement, Throws.Nothing, "extendedStateMachine redefines redefinedBehavior, the redefined property throws when read");
                Assert.That(stateMachine.RedefinedElement, Is.EquivalentTo(new IRedefinableElement[] { extended }));
            }
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_RedefinedPort_for_a_Port()
        {
            var redefinedPort = new Port { Name = "Redefined" };
            var redefinedProperty = new Property { Name = "RedefinedProperty" };
            var port = new Port { Name = "P" };
            port.RedefinedPort.Add(redefinedPort);
            port.RedefinedProperty.Add(redefinedProperty);

            Assert.That(port.RedefinedElement, Is.EquivalentTo(new IRedefinableElement[] { redefinedPort, redefinedProperty }), "redefinedPort subsets redefinedProperty");
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_RedefinedOperation_for_an_Operation()
        {
            var operation = new Operation { Name = "op" };
            var redefined = new Operation { Name = "redefined" };
            operation.RedefinedOperation.Add(redefined);

            Assert.That(operation.QueryRedefinedElement(), Is.EquivalentTo(new IRedefinableElement[] { redefined }));
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_RedefinedProperty_for_a_Property()
        {
            var property = new Property { Name = "p" };
            var redefined = new Property { Name = "redefined" };
            property.RedefinedProperty.Add(redefined);

            Assert.That(property.QueryRedefinedElement(), Is.EquivalentTo(new IRedefinableElement[] { redefined }));
        }

        [Test]
        public void Verify_that_QueryRedefinedElement_returns_ExtendedSignature_for_a_RedefinableTemplateSignature()
        {
            var signature = new RedefinableTemplateSignature();
            var extended = new RedefinableTemplateSignature();
            signature.ExtendedSignature.Add(extended);

            Assert.That(signature.QueryRedefinedElement(), Is.EquivalentTo(new IRedefinableElement[] { extended }));
        }

        [Test]
        public void Verify_that_QueryRedefinitionContext_throws_when_argument_is_null()
        {
            IRedefinableElement redefinableElement = null;

            Assert.That(() => RedefinableElementExtensions.QueryRedefinitionContext(redefinableElement), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryRedefinitionContext_returns_an_empty_list_for_an_unowned_element()
        {
            var operation = new Operation { Name = "op" };

            Assert.That(operation.QueryRedefinitionContext(), Is.Empty);
        }

        [Test]
        public void Verify_that_QueryRedefinitionContext_returns_the_owning_Class_for_an_Operation()
        {
            var @class = new Class { Name = "C" };
            var operation = new Operation { Name = "op" };
            @class.OwnedOperation.Add(operation);

            Assert.That(operation.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { @class }));
        }

        [Test]
        public void Verify_that_QueryRedefinitionContext_returns_the_nesting_Class_for_a_nested_Class()
        {
            var nestingClass = new Class { Name = "Outer" };
            var nestedClass = new Class { Name = "Inner" };
            nestingClass.NestedClassifier.Add(nestedClass);

            Assert.That(nestedClass.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { nestingClass }));
        }

        [Test]
        public void Verify_that_QueryRedefinitionContext_uses_QueryContext_for_a_Behavior()
        {
            var owningClass = new Class { Name = "Owner" };
            var behavior = new Activity { Name = "Activity" };
            owningClass.OwnedBehavior.Add(behavior);

            Assert.That(behavior.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { owningClass }));
        }

        [Test]
        public void Verify_that_QueryRedefinitionContext_returns_the_nesting_Class_for_a_Behavior_owned_as_a_nestedClassifier()
        {
            // Behavior::context is null when nestingClass is set; Class::nestedClassifier provides the nesting Class
            var owningClass = new Class { Name = "Owner" };
            var behavior = new Activity { Name = "Nested" };
            owningClass.NestedClassifier.Add(behavior);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(behavior.Context, Is.Null);
                Assert.That(behavior.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { owningClass }));
            }
        }

        [Test]
        public void Verify_that_QueryRedefinitionContext_returns_the_owner_for_every_property_that_subsets_redefinableElement()
        {
            var @class = new Class { Name = "C" };
            var classAttribute = new Property { Name = "a" };
            var classOperation = new Operation { Name = "op" };
            var connector = new Connector { Name = "con" };
            var signature = new RedefinableTemplateSignature { Name = "sig" };
            @class.OwnedAttribute.Add(classAttribute);
            @class.OwnedOperation.Add(classOperation);
            @class.OwnedConnector.Add(connector);
            @class.OwnedTemplateSignature.Add(signature);

            var dataType = new DataType { Name = "D" };
            var dataTypeAttribute = new Property { Name = "da" };
            var dataTypeOperation = new Operation { Name = "dop" };
            dataType.OwnedAttribute.Add(dataTypeAttribute);
            dataType.OwnedOperation.Add(dataTypeOperation);

            var @interface = new Interface { Name = "I" };
            var interfaceOperation = new Operation { Name = "iop" };
            var interfaceNested = new Class { Name = "InInterface" };
            @interface.OwnedOperation.Add(interfaceOperation);
            @interface.NestedClassifier.Add(interfaceNested);

            var artifact = new Artifact { Name = "Art" };
            var artifactOperation = new Operation { Name = "aop" };
            artifact.OwnedOperation.Add(artifactOperation);

            var association = new Association { Name = "A" };
            var ownedEnd = new Property { Name = "end" };
            association.OwnedEnd.Add(ownedEnd);

            var extension = new Extension { Name = "E" };
            var extensionEnd = new ExtensionEnd { Name = "extension_S" };
            extension.OwnedEnd.Add(extensionEnd);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classAttribute.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { @class }), "Classifier::attribute");
                Assert.That(classOperation.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { @class }), "Class::ownedOperation");
                Assert.That(connector.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { @class }), "StructuredClassifier::ownedConnector");
                Assert.That(signature.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { @class }), "Classifier::ownedTemplateSignature");
                Assert.That(dataTypeAttribute.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { dataType }), "Classifier::attribute of a DataType");
                Assert.That(dataTypeOperation.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { dataType }), "DataType::ownedOperation");
                Assert.That(interfaceOperation.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { @interface }), "Interface::ownedOperation");
                Assert.That(interfaceNested.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { @interface }), "Interface::nestedClassifier");
                Assert.That(artifactOperation.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { artifact }), "Artifact::ownedOperation");
                Assert.That(ownedEnd.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { association }), "Association::ownedEnd");
                Assert.That(() => extensionEnd.QueryRedefinitionContext(), Throws.Nothing, "Extension::ownedEnd redefines Association::ownedEnd");
                Assert.That(extensionEnd.QueryRedefinitionContext(), Is.EquivalentTo(new IClassifier[] { extension }));
            }
        }

        [Test]
        public void Verify_that_QueryRedefinitionContext_is_empty_for_elements_owned_through_a_property_that_provides_no_context()
        {
            var @class = new Class { Name = "C" };
            var reception = new Reception { Name = "r" };
            @class.OwnedReception.Add(reception);

            var activity = new Activity { Name = "A" };
            var node = new OpaqueAction { Name = "node" };
            var edge = new ControlFlow { Name = "edge" };
            activity.Node.Add(node);
            activity.Edge.Add(edge);

            var useCase = new UseCase { Name = "U" };
            var extensionPoint = new ExtensionPoint { Name = "ep" };
            useCase.ExtensionPoint.Add(extensionPoint);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(reception.QueryRedefinitionContext(), Is.Empty, "Class::ownedReception does not subset redefinableElement");
                Assert.That(node.QueryRedefinitionContext(), Is.Empty, "Activity::node");
                Assert.That(edge.QueryRedefinitionContext(), Is.Empty, "Activity::edge");
                Assert.That(extensionPoint.QueryRedefinitionContext(), Is.Empty, "UseCase::extensionPoint");
            }
        }
    }
}
