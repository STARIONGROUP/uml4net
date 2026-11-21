// -------------------------------------------------------------------------------------------------
// <copyright file="EnumerationLiteralExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
