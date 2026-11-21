// -------------------------------------------------------------------------------------------------
// <copyright file="BooleanHelperTestFixture.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// Suite of tests for the <see cref="BooleanHelper"/> class
    /// </summary>
    [TestFixture]
    public class BooleanHelperTestFixture
    {
        private IHandlebars handlebarsContext;

        [SetUp]
        public void SetUp()
        {
            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;

            BooleanHelper.RegisterBooleanHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_that_ToLowerCase_returns_expected_result()
        {
            var template = "{{ #Boolean.ToLowerCase this }}";

            var action = this.handlebarsContext.Compile(template);

            var trueResult = action(true);

            Assert.That(trueResult, Is.EqualTo("true"));

            var falseResult = action(false);

            Assert.That(falseResult, Is.EqualTo("false"));

        }
    }
}
