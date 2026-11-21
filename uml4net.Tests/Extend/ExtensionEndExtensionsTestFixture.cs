// -------------------------------------------------------------------------------------------------
// <copyright file="ExtensionEndExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using System;

    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.Values;

    [TestFixture]
    public class ExtensionEndExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_extensionEnd_is_null_argument_null_exception_is_thrown()
        {
            ExtensionEnd extensionEnd = null;

            Assert.That(() => ExtensionEndExtensions.QueryLower(extensionEnd), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_Lower_defaults_to_0_when_no_lowerValue_is_set()
        {
            // ExtensionEnd redefines the default MultiplicityElement lower bound (which is 1 when
            // empty) to 0 - see OMG UML 2.5.1 clause 12.4.2.6
            var extensionEnd = new ExtensionEnd();

            Assert.That(extensionEnd.Lower, Is.EqualTo(0));
        }

        [Test]
        public void Verify_that_Lower_returns_the_explicit_lowerValue_when_set()
        {
            var extensionEnd = new ExtensionEnd();
            extensionEnd.LowerValue.Add(new LiteralInteger { Value = 1 });

            Assert.That(extensionEnd.Lower, Is.EqualTo(1));
        }

        [Test]
        public void Verify_that_Lower_is_the_default_0_when_lowerValue_is_not_a_literal_integer()
        {
            // integerValue() is null for a ValueSpecification that is not a LiteralInteger
            var withLiteralString = new ExtensionEnd();
            withLiteralString.LowerValue.Add(new LiteralString { Value = "not-an-integer" });

            var withOpaqueExpression = new ExtensionEnd();
            withOpaqueExpression.LowerValue.Add(new OpaqueExpression { Body = { "n" } });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => withLiteralString.Lower, Throws.Nothing);
                Assert.That(withLiteralString.Lower, Is.EqualTo(0));
                Assert.That(withOpaqueExpression.Lower, Is.EqualTo(0));
            }
        }
    }
}
