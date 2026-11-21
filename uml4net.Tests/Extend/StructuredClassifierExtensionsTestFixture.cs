// -------------------------------------------------------------------------------------------------
// <copyright file="StructuredClassifierExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class StructuredClassifierExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryPart_throws_when_structuredClassifier_is_null()
        {
            IStructuredClassifier structuredClassifier = null;

            Assert.That(() => StructuredClassifierExtensions.QueryPart(structuredClassifier), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryPart_returns_only_composite_owned_attributes()
        {
            var @class = new Class { Name = "C" };
            var composite = new Property { Name = "part", Aggregation = AggregationKind.Composite };
            var nonComposite = new Property { Name = "notPart", Aggregation = AggregationKind.None };
            @class.OwnedAttribute.Add(composite);
            @class.OwnedAttribute.Add(nonComposite);

            Assert.That(@class.QueryPart(), Is.EquivalentTo(new IProperty[] { composite }));
        }

        [Test]
        public void Verify_that_QueryRole_throws_when_structuredClassifier_is_null()
        {
            IStructuredClassifier structuredClassifier = null;

            Assert.That(() => StructuredClassifierExtensions.QueryRole(structuredClassifier), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryRole_returns_OwnedAttribute_for_a_Class()
        {
            var @class = new Class { Name = "C" };
            var attribute = new Property { Name = "attr" };
            @class.OwnedAttribute.Add(attribute);

            Assert.That(@class.QueryRole(), Is.EquivalentTo(new IConnectableElement[] { attribute }));
        }

        [Test]
        public void Verify_that_QueryRole_includes_CollaborationRole_for_a_Collaboration()
        {
            var collaboration = new Collaboration { Name = "Coll" };
            var attribute = new Property { Name = "attr" };
            var role = new Property { Name = "role" };
            collaboration.OwnedAttribute.Add(attribute);
            collaboration.CollaborationRole.Add(role);

            Assert.That(collaboration.QueryRole(), Is.EquivalentTo(new IConnectableElement[] { attribute, role }));
        }
    }
}
