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
    using NUnit.Framework;

    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonStructure;
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
    }
}
