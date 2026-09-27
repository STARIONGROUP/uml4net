// -------------------------------------------------------------------------------------------------
// <copyright file="ElementExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using NUnit.Framework;

    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;

    [TestFixture]
    public class ElementExtensionsTestFixture
    {
        [Test]
        public void QueryOwner_ReturnsPossessor()
        {
            var owner = new Class();
            var property = new Property { Possessor = owner };

            var result = property.QueryOwner();

            Assert.That(result, Is.EqualTo(owner));
        }

        [Test]
        public void QueryOwner_ThrowsArgumentNullException_WhenElementIsNull()
        {
            Assert.That(() => ElementExtensions.QueryOwner(null), Throws.ArgumentNullException);
        }

        [Test]
        public void QueryOwnedElement_ReturnsEmptyList_WhenNothingIsOwned()
        {
            var comment = new Comment();

            Assert.That(comment.OwnedElement, Is.Empty);
        }

        [Test]
        public void QueryOwnedElement_ReturnsValuesFromGenuinelyBackedCompositeProperties()
        {
            var property = new Property();
            var nameExpression = new StringExpression();
            var comment = new Comment();

            property.NameExpression.Add(nameExpression);
            property.OwnedComment.Add(comment);

            Assert.That(property.OwnedElement, Is.EquivalentTo(new IElement[] { nameExpression, comment }));
        }

        [Test]
        public void QueryOwnedElement_ExcludesElements_OnlyReachableThroughAPropertyShadowedByARealMoreGeneralProperty()
        {
            // Activity.StructuredNode subsets both Activity.Group and Activity.Node, which are themselves real,
            // non-derived composite properties - so StructuredNode is shadowed and must not be double-counted.
            var activity = new Activity();
            var topLevelNode = new StructuredActivityNode();
            var onlyReachableViaStructuredNode = new StructuredActivityNode();

            activity.Group.Add(topLevelNode);
            activity.StructuredNode.Add(onlyReachableViaStructuredNode);

            Assert.That(activity.OwnedElement, Does.Contain(topLevelNode));
            Assert.That(activity.OwnedElement, Does.Not.Contain(onlyReachableViaStructuredNode));
        }

        [Test]
        public void Verify_that_QueryAllInstancesInModel_covers_the_own_containment_tree_and_every_cached_element()
        {
            var cache = new XmiElementCache();

            var first = new Package { XmiId = "first" };
            var firstClass = new Class { XmiId = "firstClass" };
            first.PackagedElement.Add(firstClass);

            var second = new Package { XmiId = "second" };
            var secondClass = new Class { XmiId = "secondClass" };
            second.PackagedElement.Add(secondClass);

            foreach (var element in new IXmiElement[] { first, firstClass, second, secondClass })
            {
                cache.TryAdd(element);
            }

            // created in code after the read: not in the cache, but owned by an element that is
            var addedInCode = new Class { XmiId = "addedInCode" };
            second.PackagedElement.Add(addedInCode);

            var builtInCode = new Package { XmiId = "builtInCode" };
            var builtInCodeClass = new Class { XmiId = "builtInCodeClass" };
            builtInCode.PackagedElement.Add(builtInCodeClass);

            var model = new IElement[] { first, firstClass, second, secondClass, addedInCode };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(firstClass.QueryAllInstancesInModel(), Is.EquivalentTo(model));
                Assert.That(firstClass.QueryAllInstancesInModel(), Is.Unique);
                Assert.That(firstClass.QueryAllInstancesInModel().Take(2), Is.EquivalentTo(new IElement[] { first, firstClass }), "the own containment tree comes first");
                Assert.That(addedInCode.QueryAllInstancesInModel(), Is.EquivalentTo(model), "the cache of the nearest owner is used");
                Assert.That(builtInCodeClass.QueryAllInstancesInModel(), Is.EquivalentTo(new IElement[] { builtInCode, builtInCodeClass }), "without a cache, the own containment tree");
                Assert.That(() => ElementExtensions.QueryAllInstancesInModel(null).ToList(), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_derivations_using_allInstances_find_elements_of_another_root()
        {
            var cache = new XmiElementCache();

            // NamedElement::clientDependency
            var components = new Package { XmiId = "components" };
            var client = new Class { XmiId = "client" };
            components.PackagedElement.Add(client);

            var traces = new Package { XmiId = "traces" };
            var dependency = new Dependency { XmiId = "dependency" };
            dependency.Client.Add(client);
            traces.PackagedElement.Add(dependency);

            // ConnectableElement::end
            var parts = new Class { XmiId = "parts" };
            var part = new Property { XmiId = "part" };
            parts.OwnedAttribute.Add(part);

            var assembly = new Class { XmiId = "assembly" };
            var connector = new Connector { XmiId = "connector" };
            var connectorEnd = new ConnectorEnd { XmiId = "connectorEnd", Role = part };
            connector.End.Add(connectorEnd);
            assembly.OwnedConnector.Add(connector);

            // Class::extension
            var metamodel = new Package { XmiId = "metamodel" };
            var metaclass = new Class { XmiId = "metaclass" };
            metamodel.PackagedElement.Add(metaclass);

            var profile = new Profile { XmiId = "profile" };
            var stereotype = new Stereotype { XmiId = "stereotype" };
            var baseProperty = new Property { XmiId = "base", Type = metaclass };
            stereotype.OwnedAttribute.Add(baseProperty);
            var extension = new Extension { XmiId = "extension" };
            extension.MemberEnd.Add(baseProperty);
            profile.PackagedElement.Add(stereotype);
            profile.PackagedElement.Add(extension);

            // Vertex::incoming and Vertex::outgoing: a Transition of a StateMachine that extends the one of its Vertices
            var stateMachine = new StateMachine { XmiId = "stateMachine" };
            var region = new Region { XmiId = "region" };
            stateMachine.Region.Add(region);
            var source = new State { XmiId = "source" };
            var target = new State { XmiId = "target" };
            region.Subvertex.Add(source);
            region.Subvertex.Add(target);

            var extendingStateMachine = new StateMachine { XmiId = "extendingStateMachine" };
            extendingStateMachine.ExtendedStateMachine.Add(stateMachine);
            var extendingRegion = new Region { XmiId = "extendingRegion" };
            extendingStateMachine.Region.Add(extendingRegion);
            var transition = new Transition { XmiId = "transition", Source = source, Target = target };
            extendingRegion.Transition.Add(transition);

            foreach (var root in new IElement[] { components, traces, parts, assembly, metamodel, profile, stateMachine, extendingStateMachine })
            {
                cache.TryAdd(root);
            }

            using (Assert.EnterMultipleScope())
            {
                Assert.That(client.ClientDependency, Is.EqualTo(new[] { dependency }));
                Assert.That(part.End, Is.EqualTo(new[] { connectorEnd }));
                Assert.That(metaclass.Extension, Is.EqualTo(new[] { extension }));
                Assert.That(source.Outgoing, Is.EqualTo(new[] { transition }));
                Assert.That(target.Incoming, Is.EqualTo(new[] { transition }));
            }
        }
    }
}
