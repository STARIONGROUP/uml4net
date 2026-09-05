// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using uml4net.Values;

    [TestFixture]
    public class ParameterExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_parameter_is_null_argument_exception_is_thrown()
        {
            Parameter parameter = null;

            Assert.That(() => ParameterExtensions.QueryDefault(parameter), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_Default_is_null_when_the_parameter_is_not_typed_String()
        {
            var parameter = new Parameter { Type = new PrimitiveType { Name = "Integer" } };
            parameter.DefaultValue.Add(new LiteralString { Value = "abc" });

            Assert.That(parameter.Default, Is.Null);
        }

        [Test]
        public void Verify_that_Default_is_null_when_the_parameter_has_no_type()
        {
            var parameter = new Parameter();
            parameter.DefaultValue.Add(new LiteralString { Value = "abc" });

            Assert.That(parameter.Default, Is.Null);
        }

        [Test]
        public void Verify_that_Default_is_null_when_a_String_typed_parameter_has_no_defaultValue()
        {
            var parameter = new Parameter { Type = new PrimitiveType { Name = "String" } };

            Assert.That(parameter.Default, Is.Null);
        }

        [Test]
        public void Verify_that_Default_returns_the_LiteralString_value_for_a_String_typed_parameter()
        {
            var parameter = new Parameter { Type = new PrimitiveType { Name = "String" } };
            parameter.DefaultValue.Add(new LiteralString { Value = "abc" });

            Assert.That(parameter.Default, Is.EqualTo("abc"));
        }

        [Test]
        public void Verify_that_Default_is_null_for_a_String_typed_parameter_whose_defaultValue_is_not_a_LiteralString_or_StringExpression()
        {
            var parameter = new Parameter { Type = new PrimitiveType { Name = "String" } };
            parameter.DefaultValue.Add(new LiteralInteger { Value = 42 });

            Assert.That(parameter.Default, Is.Null);
        }

        [Test]
        public void Verify_that_Default_concatenates_the_operands_of_a_StringExpression_with_no_subExpressions()
        {
            var parameter = new Parameter { Type = new PrimitiveType { Name = "String" } };

            var stringExpression = new StringExpression();
            stringExpression.Operand.Add(new LiteralString { Value = "foo" });
            stringExpression.Operand.Add(new LiteralString { Value = "bar" });

            parameter.DefaultValue.Add(stringExpression);

            Assert.That(parameter.Default, Is.EqualTo("foobar"));
        }

        [Test]
        public void Verify_that_Default_concatenates_the_subExpressions_of_a_StringExpression_when_present()
        {
            var parameter = new Parameter { Type = new PrimitiveType { Name = "String" } };

            var subExpression1 = new StringExpression();
            subExpression1.Operand.Add(new LiteralString { Value = "foo" });

            var subExpression2 = new StringExpression();
            subExpression2.Operand.Add(new LiteralString { Value = "bar" });

            var stringExpression = new StringExpression();
            stringExpression.SubExpression.Add(subExpression1);
            stringExpression.SubExpression.Add(subExpression2);

            // an operand set alongside sub-expressions must be ignored, per the OCL's if/else
            stringExpression.Operand.Add(new LiteralString { Value = "ignored" });

            parameter.DefaultValue.Add(stringExpression);

            Assert.That(parameter.Default, Is.EqualTo("foobar"));
        }
    }
}
