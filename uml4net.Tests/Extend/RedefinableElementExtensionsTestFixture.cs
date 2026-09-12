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
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;

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
        public void Verify_that_QueryRedefinitionContext_returns_an_empty_list_for_a_Behavior_directly_owned_as_a_nestedClassifier()
        {
            var owningClass = new Class { Name = "Owner" };
            var behavior = new Activity { Name = "Nested" };
            owningClass.NestedClassifier.Add(behavior);

            Assert.That(behavior.QueryRedefinitionContext(), Is.Empty);
        }
    }
}
