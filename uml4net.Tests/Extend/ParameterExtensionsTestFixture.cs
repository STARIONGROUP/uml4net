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
        public void Verify_that_Default_is_null_when_there_is_no_defaultValue()
        {
            var parameter = new Parameter();

            Assert.That(parameter.Default, Is.Null);
        }

        [Test]
        public void Verify_that_Default_is_null_when_the_defaultValue_is_not_a_LiteralSpecification()
        {
            var parameter = new Parameter();
            parameter.DefaultValue.Add(new InstanceValue());

            Assert.That(parameter.Default, Is.Null);
        }

        [Test]
        public void Verify_that_Default_stringifies_a_LiteralBoolean()
        {
            var parameter = new Parameter();
            parameter.DefaultValue.Add(new LiteralBoolean { Value = true });

            Assert.That(parameter.Default, Is.EqualTo("True"));
        }

        [Test]
        public void Verify_that_Default_stringifies_a_LiteralInteger()
        {
            var parameter = new Parameter();
            parameter.DefaultValue.Add(new LiteralInteger { Value = 42 });

            Assert.That(parameter.Default, Is.EqualTo("42"));
        }

        [Test]
        public void Verify_that_Default_stringifies_a_LiteralReal()
        {
            var parameter = new Parameter();
            parameter.DefaultValue.Add(new LiteralReal { Value = 3.14 });

            Assert.That(parameter.Default, Is.EqualTo("3.14"));
        }

        [Test]
        public void Verify_that_Default_returns_a_LiteralString_value_verbatim()
        {
            var parameter = new Parameter();
            parameter.DefaultValue.Add(new LiteralString { Value = "abc" });

            Assert.That(parameter.Default, Is.EqualTo("abc"));
        }

        [Test]
        public void Verify_that_Default_returns_a_LiteralUnlimitedNatural_value_verbatim()
        {
            var parameter = new Parameter();
            parameter.DefaultValue.Add(new LiteralUnlimitedNatural { Value = "*" });

            Assert.That(parameter.Default, Is.EqualTo("*"));
        }

        [Test]
        public void Verify_that_Default_is_null_for_a_LiteralNull()
        {
            var parameter = new Parameter();
            parameter.DefaultValue.Add(new LiteralNull());

            Assert.That(parameter.Default, Is.Null);
        }
    }
}
