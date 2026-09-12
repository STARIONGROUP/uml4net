// -------------------------------------------------------------------------------------------------
// <copyright file="FeatureExtensionsTestFixture.cs" company="Starion Group S.A.">
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
