// -------------------------------------------------------------------------------------------------
// <copyright file="IEnumerableHelperTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
