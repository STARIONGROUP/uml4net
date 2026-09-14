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

namespace uml4net.Tests
{
    using System;

    using NUnit.Framework;

    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Interactions;
    using uml4net.StateMachines;

    /// <summary>
    /// Verifies the generated <c>QueryXmiLiteral</c> extension methods, which map a C# enumeration member to the
    /// name of the literal as defined in the UML 2.5.1 metamodel
    /// </summary>
    [TestFixture]
    public class EnumerationXmiLiteralTestFixture
    {
        [Test]
        public void Verify_that_QueryXmiLiteral_returns_the_literal_name_as_defined_in_the_metamodel()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(ObjectNodeOrderingKind.LIFO.QueryXmiLiteral(), Is.EqualTo("LIFO"), "literals in capitals keep their capitals");
                Assert.That(ObjectNodeOrderingKind.FIFO.QueryXmiLiteral(), Is.EqualTo("FIFO"));
                Assert.That(ObjectNodeOrderingKind.Unordered.QueryXmiLiteral(), Is.EqualTo("unordered"));
                Assert.That(VisibilityKind.Public.QueryXmiLiteral(), Is.EqualTo("public"));
                Assert.That(VisibilityKind.Package.QueryXmiLiteral(), Is.EqualTo("package"));
                Assert.That(AggregationKind.Composite.QueryXmiLiteral(), Is.EqualTo("composite"));
                Assert.That(ParameterDirectionKind.Return.QueryXmiLiteral(), Is.EqualTo("return"));
                Assert.That(MessageSort.AsynchCall.QueryXmiLiteral(), Is.EqualTo("asynchCall"), "camel case literals keep their inner capitals");
                Assert.That(MessageSort.CreateMessage.QueryXmiLiteral(), Is.EqualTo("createMessage"));
                Assert.That(PseudostateKind.DeepHistory.QueryXmiLiteral(), Is.EqualTo("deepHistory"));
                Assert.That(TransitionKind.External.QueryXmiLiteral(), Is.EqualTo("external"));
            }
        }

        [Test]
        public void Verify_that_QueryXmiLiteral_throws_for_a_value_that_is_not_a_literal()
        {
            Assert.That(() => ((VisibilityKind)99).QueryXmiLiteral(), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Verify_that_TryParseXmiLiteral_maps_the_literal_name_of_the_metamodel_to_the_value()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(VisibilityKindExtensions.TryParseXmiLiteral("private", out var visibility), Is.True);
                Assert.That(visibility, Is.EqualTo(VisibilityKind.Private));
                Assert.That(ObjectNodeOrderingKindExtensions.TryParseXmiLiteral("LIFO", out var ordering), Is.True);
                Assert.That(ordering, Is.EqualTo(ObjectNodeOrderingKind.LIFO));
                Assert.That(MessageSortExtensions.TryParseXmiLiteral("asynchCall", out var messageSort), Is.True);
                Assert.That(messageSort, Is.EqualTo(MessageSort.AsynchCall));
                Assert.That(PseudostateKindExtensions.TryParseXmiLiteral("deepHistory", out var pseudostateKind), Is.True);
                Assert.That(pseudostateKind, Is.EqualTo(PseudostateKind.DeepHistory));
                Assert.That(AggregationKindExtensions.TryParseXmiLiteral("composite", out var aggregation), Is.True);
                Assert.That(aggregation, Is.EqualTo(AggregationKind.Composite));
            }
        }

        [TestCase("7", TestName = "numeric value")]
        [TestCase("PRIVATE", TestName = "upper case")]
        [TestCase("Private", TestName = "C# member name")]
        [TestCase(" private", TestName = "leading whitespace")]
        [TestCase("", TestName = "empty")]
        [TestCase(null, TestName = "null")]
        public void Verify_that_TryParseXmiLiteral_rejects_what_is_not_the_name_of_a_literal(string literal)
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(VisibilityKindExtensions.TryParseXmiLiteral(literal, out var visibility), Is.False);
                Assert.That(visibility, Is.EqualTo(default(VisibilityKind)));
            }
        }

        [Test]
        public void Verify_that_QueryXmiLiteral_and_TryParseXmiLiteral_round_trip_every_literal()
        {
            using (Assert.EnterMultipleScope())
            {
                foreach (var value in (VisibilityKind[])Enum.GetValues(typeof(VisibilityKind)))
                {
                    Assert.That(VisibilityKindExtensions.TryParseXmiLiteral(value.QueryXmiLiteral(), out var parsed), Is.True, value.ToString());
                    Assert.That(parsed, Is.EqualTo(value));
                }

                foreach (var value in (ParameterEffectKind[])Enum.GetValues(typeof(ParameterEffectKind)))
                {
                    Assert.That(ParameterEffectKindExtensions.TryParseXmiLiteral(value.QueryXmiLiteral(), out var parsed), Is.True, value.ToString());
                    Assert.That(parsed, Is.EqualTo(value));
                }
            }
        }
    }
}
