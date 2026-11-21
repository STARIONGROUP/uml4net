// -------------------------------------------------------------------------------------------------
// <copyright file="EnumerationXmiLiteralTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Tests
{
    using System;

    using NUnit.Framework;

    using uml4net.xmi.Extensions.EnterpriseArchitect.Structure;

    /// <summary>
    /// Verifies the generated <c>QueryXmiLiteral</c> and <c>TryParseXmiLiteral</c> methods of the enumerations of the
    /// Enterprise Architect extension
    /// </summary>
    [TestFixture]
    public class EnumerationXmiLiteralTestFixture
    {
        [Test]
        public void Verify_that_every_Status_literal_round_trips()
        {
            using (Assert.EnterMultipleScope())
            {
                foreach (Status status in Enum.GetValues(typeof(Status)))
                {
                    var literal = status.QueryXmiLiteral();

                    Assert.That(literal, Is.EqualTo(status.ToString()));
                    Assert.That(StatusExtensions.TryParseXmiLiteral(literal, out var parsed), Is.True);
                    Assert.That(parsed, Is.EqualTo(status));
                }

                Assert.That(StatusExtensions.TryParseXmiLiteral("approved", out var unknown), Is.False, "the literal must match exactly");
                Assert.That(unknown, Is.EqualTo(default(Status)));
                Assert.That(() => ((Status)99).QueryXmiLiteral(), Throws.InstanceOf<ArgumentOutOfRangeException>());
            }
        }

        [Test]
        public void Verify_that_every_ConstraintStatus_literal_round_trips()
        {
            using (Assert.EnterMultipleScope())
            {
                foreach (ConstraintStatus status in Enum.GetValues(typeof(ConstraintStatus)))
                {
                    var literal = status.QueryXmiLiteral();

                    Assert.That(literal, Is.EqualTo(status.ToString()));
                    Assert.That(ConstraintStatusExtensions.TryParseXmiLiteral(literal, out var parsed), Is.True);
                    Assert.That(parsed, Is.EqualTo(status));
                }

                Assert.That(ConstraintStatusExtensions.TryParseXmiLiteral("0", out var unknown), Is.False, "a numeric value is not a literal");
                Assert.That(unknown, Is.EqualTo(default(ConstraintStatus)));
                Assert.That(() => ((ConstraintStatus)99).QueryXmiLiteral(), Throws.InstanceOf<ArgumentOutOfRangeException>());
            }
        }
    }
}
