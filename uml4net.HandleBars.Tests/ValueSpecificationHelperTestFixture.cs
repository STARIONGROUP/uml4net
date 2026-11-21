// -------------------------------------------------------------------------------------------------
// <copyright file="ValueSpecificationHelperTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.HandleBars.Tests
{
    using System;
    using System.Globalization;

    using HandlebarsDotNet;

    using NUnit.Framework;

    using uml4net.Values;

    /// <summary>
    /// Suite of tests for the <see cref="ValueSpecificationHelper"/> class.
    /// </summary>
    [TestFixture]
    public class ValueSpecificationHelperTestFixture
    {
        private IHandlebars handlebarsContext;

        [SetUp]
        public void SetUp()
        {
            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;
            ValueSpecificationHelper.RegisterValueSpecificationHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_that_WriteLanguageAndBody_writes_the_expected_result()
        {
            var opaqueExpression = new OpaqueExpression();
            opaqueExpression.Language.Add("OCL");
            opaqueExpression.Body.Add("self.size() > 0");

            var template = "{{ #ValueSpecification.WriteLanguageAndBody this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(opaqueExpression);

            Assert.That(result, Does.StartWith("OCL: self.size() > 0"));
        }

        [Test]
        public void Verify_that_WriteLanguageAndBody_throws_when_context_is_invalid()
        {
            var template = "{{ #ValueSpecification.WriteLanguageAndBody this }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(5), Throws.TypeOf<ArgumentException>());
        }
    }
}
