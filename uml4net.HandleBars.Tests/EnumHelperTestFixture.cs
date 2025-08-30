// -------------------------------------------------------------------------------------------------
//  <copyright file="EnumHelperTestFixture.cs" company="Starion Group S.A.">
//
//    Copyright (C) 2019-2025 Starion Group S.A.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.HandleBars.Tests
{
    using System;
    using System.Globalization;

    using HandlebarsDotNet;

    using NUnit.Framework;

    using uml4net.HandleBars;

    /// <summary>
    /// Suite of tests for the <see cref="EnumHelper"/> class.
    /// </summary>
    [TestFixture]
    public class EnumHelperTestFixture
    {
        private IHandlebars handlebarsContext;

        [SetUp]
        public void SetUp()
        {
            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;
            EnumHelper.RegisterEnumHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_EnumToString_returns_expected_value()
        {
            var result = EnumHelper.EnumToString(DayOfWeek.Friday);
            Assert.That(result, Is.EqualTo("Friday"));
        }

        [Test]
        public void Verify_helper_converts_enum_to_lowercase()
        {
            var template = "{{ #Enum.ToString this }}";
            var action = this.handlebarsContext.Compile(template);
            var result = action(DayOfWeek.Monday);

            Assert.That(result, Is.EqualTo("monday"));
        }

        [Test]
        public void Verify_helper_throws_when_argument_is_not_enum()
        {
            var template = "{{ #Enum.ToString this }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(5), Throws.TypeOf<HandlebarsException>());
        }

        [Test]
        public void Verify_helper_throws_when_parameter_count_invalid()
        {
            var template = "{{ #Enum.ToString this \"extra\" }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(DayOfWeek.Tuesday), Throws.TypeOf<HandlebarsException>());
        }
    }
}
