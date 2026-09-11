// -------------------------------------------------------------------------------------------------
// <copyright file="ValueSpecificationHelperTestFixture.cs" company="Starion Group S.A.">
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
