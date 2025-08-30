// -------------------------------------------------------------------------------------------------
//  <copyright file="NamedElementHelperTestFixture.cs" company="Starion Group S.A.">
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
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Suite of tests for the <see cref="NamedElementHelper"/> class.
    /// </summary>
    [TestFixture]
    public class NamedElementHelperTestFixture
    {
        private IHandlebars handlebarsContext;

        [SetUp]
        public void SetUp()
        {
            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;
            NamedElementHelper.RegisterNamedElementHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_that_WriteNameSpace_returns_expected_namespace()
        {
            var root = new Package { Name = "root" };
            var sub = new Package { Name = "sub" };
            var cls = new Class { Name = "MyClass" };
            root.PackagedElement.Add(sub);
            sub.PackagedElement.Add(cls);

            var template = "{{ #NamedElement.WriteNameSpace this }}";
            var action = this.handlebarsContext.Compile(template);
            var result = action(cls);

            Assert.That(result, Is.EqualTo("sub"));
        }

        [Test]
        public void Verify_that_WriteNameSpace_throws_when_context_is_invalid()
        {
            var template = "{{ #NamedElement.WriteNameSpace this }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(5), Throws.TypeOf<ArgumentException>());
        }
    }
}
