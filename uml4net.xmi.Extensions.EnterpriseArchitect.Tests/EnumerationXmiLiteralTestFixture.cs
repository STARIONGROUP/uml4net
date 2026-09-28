// -------------------------------------------------------------------------------------------------
// <copyright file="EnumerationXmiLiteralTestFixture.cs" company="Starion Group S.A.">
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
