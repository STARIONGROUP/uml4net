// -------------------------------------------------------------------------------------------------
//  <copyright file="StringHelperTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
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
    using System.Globalization;

    using HandlebarsDotNet;

    using NUnit.Framework;

    [TestFixture]
    public class StringHelperTestFixture
    {
        private IHandlebars handlebarsContenxt;

        [SetUp]
        public void SetUp()
        {
            this.handlebarsContenxt = Handlebars.Create();
            this.handlebarsContenxt.Configuration.FormatProvider = CultureInfo.InvariantCulture;

            StringHelper.RegisterStringHelper(this.handlebarsContenxt);
        }

        [Test]
        public void Verify_that_CapitalizeFirstLetter_returns_Expected_result()
        {
            var template = "{{ #String.CapitalizeFirstLetter this }}";

            var action = this.handlebarsContenxt.Compile(template);

            var result = action("starion");

            Assert.That(result, Is.EqualTo("Starion"));
        }

        [Test]
        public void Verify_that_LowerCaseFirstLetter_returns_Expected_result()
        {
            var template = "{{ #String.LowerCaseFirstLetter this }}";

            var action = this.handlebarsContenxt.Compile(template);

            var result = action("Starion");

            Assert.That(result, Is.EqualTo("starion"));
        }

        [Test]
        public void Verify_that_Length_returns_Expected_result()
        {
            var template = "{{ #String.Length this }}";

            var action = this.handlebarsContenxt.Compile(template);

            var length = action("Starion");

            Assert.That(length, Is.EqualTo("7"));
        }
    }
}