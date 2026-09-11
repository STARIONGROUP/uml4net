// -------------------------------------------------------------------------------------------------
// <copyright file="IEnumerableHelperTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Globalization;

    using HandlebarsDotNet;
    using HandlebarsDotNet.Helpers;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="IEnumerableHelper"/> class.
    /// </summary>
    [TestFixture]
    public class IEnumerableHelperTestFixture
    {
        private IHandlebars handlebarsContext;

        [SetUp]
        public void SetUp()
        {
            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;
            HandlebarsHelpers.Register(this.handlebarsContext);
            IEnumerableHelper.RegisterEnumerableHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_that_IsEmpty_returns_true_for_an_empty_list()
        {
            var template = "{{#if (IEnumerable.IsEmpty list)}}empty{{else}}not-empty{{/if}}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(new { list = new List<object>() });

            Assert.That(result, Is.EqualTo("empty"));
        }

        [Test]
        public void Verify_that_IsEmpty_returns_false_for_a_non_empty_list()
        {
            var template = "{{#if (IEnumerable.IsEmpty list)}}empty{{else}}not-empty{{/if}}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(new { list = new List<object> { "a" } });

            Assert.That(result, Is.EqualTo("not-empty"));
        }

        [Test]
        public void Verify_that_IsEmpty_returns_false_when_the_value_is_not_an_IEnumerable_of_object()
        {
            var template = "{{#if (IEnumerable.IsEmpty list)}}empty{{else}}not-empty{{/if}}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(new { list = 5 });

            Assert.That(result, Is.EqualTo("not-empty"));
        }
    }
}
