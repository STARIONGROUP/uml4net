// -------------------------------------------------------------------------------------------------
// <copyright file="ConstraintExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions.Tests
{
    using NUnit.Framework;

    using uml4net.CommonStructure;
    using uml4net.Extensions;
    using uml4net.Values;

    [TestFixture]
    public class ConstraintExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryConstraintBody_returns_the_body_of_the_OpaqueExpression()
        {
            var opaqueExpression = new OpaqueExpression();
            opaqueExpression.Body.Add("  self.isAbstract  ");
            opaqueExpression.Language.Add("OCL");

            var constraint = new Constraint();
            constraint.Specification.Add(opaqueExpression);

            Assert.That(constraint.QueryConstraintBody(), Is.EqualTo("self.isAbstract"));
        }

        [Test]
        public void Verify_that_QueryConstraintBody_joins_the_bodies_and_normalizes_line_endings()
        {
            var opaqueExpression = new OpaqueExpression();
            opaqueExpression.Body.Add("let n : Integer = 1 in\r\n  n > 0");
            opaqueExpression.Body.Add("true\r\n");

            var constraint = new Constraint();
            constraint.Specification.Add(opaqueExpression);

            Assert.That(constraint.QueryConstraintBody(), Is.EqualTo("let n : Integer = 1 in\n  n > 0\ntrue"));
        }

        [Test]
        public void Verify_that_QueryConstraintBody_returns_empty_without_an_OpaqueExpression_body()
        {
            var withoutSpecification = new Constraint();

            var withLiteral = new Constraint();
            withLiteral.Specification.Add(new LiteralBoolean { Value = true });

            var withEmptyOpaqueExpression = new Constraint();
            withEmptyOpaqueExpression.Specification.Add(new OpaqueExpression());

            using (Assert.EnterMultipleScope())
            {
                Assert.That(withoutSpecification.QueryConstraintBody(), Is.Empty);
                Assert.That(withLiteral.QueryConstraintBody(), Is.Empty);
                Assert.That(withEmptyOpaqueExpression.QueryConstraintBody(), Is.Empty);
                Assert.That(() => ConstraintExtensions.QueryConstraintBody(null), Throws.ArgumentNullException);
            }
        }
    }
}
