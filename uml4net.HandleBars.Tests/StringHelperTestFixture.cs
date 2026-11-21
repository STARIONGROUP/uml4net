// -------------------------------------------------------------------------------------------------
// <copyright file="StringHelperTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.HandleBars.Tests
{
    using System.Globalization;

    using HandlebarsDotNet;

    using NUnit.Framework;

    using uml4net.Extensions;

    [TestFixture]
    public class StringHelperTestFixture
    {
        private IHandlebars handlebarsContext;

        [SetUp]
        public void SetUp()
        {
            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;

            StringHelper.RegisterStringHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_that_CapitalizeFirstLetter_returns_Expected_result()
        {
            var template = "{{ #String.CapitalizeFirstLetter this }}";

            var action = this.handlebarsContext.Compile(template);

            var result = action("starion");

            Assert.That(result, Is.EqualTo("Starion"));
        }

        [Test]
        public void Verify_that_LowerCaseFirstLetter_returns_Expected_result()
        {
            var template = "{{ #String.LowerCaseFirstLetter this }}";

            var action = this.handlebarsContext.Compile(template);

            var result = action("Starion");

            Assert.That(result, Is.EqualTo("starion"));
        }

        [Test]
        public void Verify_that_Length_returns_Expected_result()
        {
            var template = "{{ #String.Length this }}";

            var action = this.handlebarsContext.Compile(template);

            var length = action("Starion");

            Assert.That(length, Is.EqualTo("7"));
        }

        [Test]
        public void Verify_that_EscapeCSharpKeyword_returns_Expected_result()
        {
            var action = this.handlebarsContext.Compile("{{ #String.EscapeCSharpKeyword this }}");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(action("class"), Is.EqualTo("@class"));
                Assert.That(action("ownedComment"), Is.EqualTo("ownedComment"));
                Assert.That(() => action(5), Throws.TypeOf<HandlebarsException>());
                Assert.That(() => this.handlebarsContext.Compile("{{ #String.EscapeCSharpKeyword this this }}")("class"), Throws.TypeOf<HandlebarsException>());
                Assert.That(() => this.handlebarsContext.Compile("{{ #String.EscapeCSharpKeyword }}")("class"), Throws.TypeOf<HandlebarsException>());
            }
        }

        [Test]
        [NonParallelizable]
        public void Verify_that_EscapeCSharpKeyword_escapes_a_registered_keyword()
        {
            var action = this.handlebarsContext.Compile("{{ #String.EscapeCSharpKeyword this }}");

            try
            {
                StringExtensions.RegisterAdditionalCSharpKeywords("var");

                Assert.That(action("var"), Is.EqualTo("@var"));
            }
            finally
            {
                StringExtensions.ClearAdditionalCSharpKeywords();
            }

            Assert.That(action("var"), Is.EqualTo("var"));
        }
    }
}