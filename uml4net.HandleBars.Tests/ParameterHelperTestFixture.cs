// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterHelperTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.HandleBars.Tests
{
    using System;
    using System.Globalization;

    using HandlebarsDotNet;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.SimpleClassifiers;

    /// <summary>
    /// Suite of tests for the <see cref="ParameterHelper"/> class.
    /// </summary>
    [TestFixture]
    public class ParameterHelperTestFixture
    {
        private IHandlebars handlebarsContext;

        [SetUp]
        public void SetUp()
        {
            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;
            ParameterHelper.RegisterParameterHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_that_WriteTypeAndName_writes_void_when_type_is_null()
        {
            var parameter = new Parameter { Name = "count", Direction = ParameterDirectionKind.In };

            var template = "{{ #Parameter.WriteTypeAndName this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(parameter);

            Assert.That(result, Is.EqualTo("In void"));
        }

        [Test]
        public void Verify_that_WriteTypeAndName_writes_the_type_and_name_for_a_non_return_parameter()
        {
            var type = new PrimitiveType { Name = "Integer", XmiId = "Integer" };
            var parameter = new Parameter { Name = "count", Direction = ParameterDirectionKind.In, Type = type };

            var template = "{{ #Parameter.WriteTypeAndName this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(parameter);

            Assert.That(result, Is.EqualTo("In <a href=#Integer>Integer</a> count [1..1]"));
        }

        [Test]
        public void Verify_that_WriteTypeAndName_omits_the_name_for_a_return_parameter()
        {
            var type = new PrimitiveType { Name = "Integer", XmiId = "Integer" };
            var parameter = new Parameter { Name = "result", Direction = ParameterDirectionKind.Return, Type = type };

            var template = "{{ #Parameter.WriteTypeAndName this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(parameter);

            Assert.That(result, Is.EqualTo("Return <a href=#Integer>Integer</a> [1..1]"));
        }

        [Test]
        public void Verify_that_WriteTypeAndName_throws_when_argument_is_not_a_parameter()
        {
            var template = "{{ #Parameter.WriteTypeAndName this }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(5), Throws.TypeOf<ArgumentException>());
        }
    }
}
