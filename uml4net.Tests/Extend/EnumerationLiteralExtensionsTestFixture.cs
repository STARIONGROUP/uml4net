// -------------------------------------------------------------------------------------------------
// <copyright file="EnumerationLiteralExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.SimpleClassifiers;

    [TestFixture]
    public class EnumerationLiteralExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_enumerationLiteral_is_null_argument_exception_is_thrown()
        {
            EnumerationLiteral enumerationLiteral = null;

            Assert.That(() => EnumerationLiteralExtensions.QueryClassifier(enumerationLiteral), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_Classifier_returns_the_owning_Enumeration()
        {
            var enumeration = new Enumeration { Name = "Color" };
            var enumerationLiteral = new EnumerationLiteral { Name = "Red", Enumeration = enumeration };

            Assert.That(enumerationLiteral.Classifier, Is.SameAs(enumeration));
        }
    }
}
