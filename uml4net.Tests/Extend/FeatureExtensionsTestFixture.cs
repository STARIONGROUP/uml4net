// -------------------------------------------------------------------------------------------------
// <copyright file="FeatureExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class FeatureExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryFeaturingClassifier_throws_when_feature_is_null()
        {
            IFeature feature = null;

            Assert.That(() => FeatureExtensions.QueryFeaturingClassifier(feature), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryFeaturingClassifier_returns_the_owning_Class_for_an_owned_attribute()
        {
            var @class = new Class { Name = "C" };
            var attribute = new Property { Name = "attr" };
            @class.OwnedAttribute.Add(attribute);

            Assert.That(attribute.QueryFeaturingClassifier(), Is.EqualTo(@class));
        }

        [Test]
        public void Verify_that_QueryFeaturingClassifier_returns_the_owning_Class_for_an_owned_operation()
        {
            var @class = new Class { Name = "C" };
            var operation = new Operation { Name = "op" };
            @class.OwnedOperation.Add(operation);

            Assert.That(operation.QueryFeaturingClassifier(), Is.EqualTo(@class));
        }

        [Test]
        public void Verify_that_QueryFeaturingClassifier_returns_the_owning_Interface_for_an_owned_reception()
        {
            var @interface = new Interface { Name = "I" };
            var reception = new Reception { Name = "rec" };
            @interface.OwnedReception.Add(reception);

            Assert.That(reception.QueryFeaturingClassifier(), Is.EqualTo(@interface));
        }

        [Test]
        public void Verify_that_QueryFeaturingClassifier_returns_the_owning_Association_for_an_owned_end()
        {
            var association = new Association { Name = "A" };
            var end = new Property { Name = "end" };
            association.OwnedEnd.Add(end);

            Assert.That(end.QueryFeaturingClassifier(), Is.EqualTo(association));
        }

        [Test]
        public void Verify_that_QueryFeaturingClassifier_returns_null_for_an_unowned_feature()
        {
            var operation = new Operation { Name = "op" };

            Assert.That(operation.QueryFeaturingClassifier(), Is.Null);
        }
    }
}
