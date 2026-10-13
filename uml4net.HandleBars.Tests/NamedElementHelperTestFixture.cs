// -------------------------------------------------------------------------------------------------
// <copyright file="NamedElementHelperTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Extensions;
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

        [Test]
        public void Verify_that_WriteCSharpIdentifier_writes_the_name_with_the_requested_casing()
        {
            var asModelled = this.handlebarsContext.Compile("{{ #NamedElement.WriteCSharpIdentifier this }}");
            var upperCase = this.handlebarsContext.Compile("{{ #NamedElement.WriteCSharpIdentifier this \"UpperCaseFirstLetter\" }}");
            var lowerCase = this.handlebarsContext.Compile("{{ #NamedElement.WriteCSharpIdentifier this \"lowercasefirstletter\" }}");

            var @class = new Class { Name = "class" };
            var @event = new Class { Name = "Event" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(asModelled(@class), Is.EqualTo("@class"));
                Assert.That(upperCase(@class), Is.EqualTo("Class"));
                Assert.That(asModelled(@event), Is.EqualTo("Event"));
                Assert.That(lowerCase(@event), Is.EqualTo("@event"), "the casing argument is not case-sensitive");

                Assert.That(() => asModelled("not an element"), Throws.TypeOf<ArgumentException>());
                Assert.That(() => asModelled(new Class()), Throws.InvalidOperationException, "an element without a name");
                Assert.That(() => this.handlebarsContext.Compile("{{ #NamedElement.WriteCSharpIdentifier this \"Shouting\" }}")(@class), Throws.TypeOf<ArgumentException>());
                Assert.That(() => this.handlebarsContext.Compile("{{ #NamedElement.WriteCSharpIdentifier }}")(@class), Throws.TypeOf<HandlebarsException>());
                Assert.That(() => this.handlebarsContext.Compile("{{ #NamedElement.WriteCSharpIdentifier this \"AsModelled\" \"x\" }}")(@class), Throws.TypeOf<HandlebarsException>());
                Assert.That(this.handlebarsContext.Compile("{{ #NamedElement.WriteCSharpIdentifier this \"AsModelled\" }}")(@class), Is.EqualTo("@class"));
            }
        }

        [Test]
        public void Verify_that_WriteCSharpIdentifier_rejects_a_casing_that_is_not_one_of_the_three_names()
        {
            var @class = new Class { Name = "class" };

            var withCasing = this.handlebarsContext.Compile("{{ #NamedElement.WriteCSharpIdentifier this.Element this.Casing }}");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => withCasing(new { Element = @class, Casing = "1" }), Throws.TypeOf<ArgumentException>(), "the number of a value");
                Assert.That(() => withCasing(new { Element = @class, Casing = "7" }), Throws.TypeOf<ArgumentException>(), "a number that is not a value");
                Assert.That(() => withCasing(new { Element = @class, Casing = "AsModelled,UpperCaseFirstLetter" }), Throws.TypeOf<ArgumentException>(), "a list of names");
                Assert.That(() => withCasing(new { Element = @class, Casing = string.Empty }), Throws.TypeOf<ArgumentException>());
                Assert.That(() => withCasing(new { Element = @class, Casing = 5 }), Throws.TypeOf<ArgumentException>(), "not a string");

                Assert.That(withCasing(new { Element = @class, Casing = "UpperCaseFirstLetter" }), Is.EqualTo("Class"));
            }
        }

        [Test]
        [NonParallelizable]
        public void Verify_that_WriteCSharpIdentifier_escapes_a_registered_keyword()
        {
            var action = this.handlebarsContext.Compile("{{ #NamedElement.WriteCSharpIdentifier this }}");
            var value = new Class { Name = "value" };

            try
            {
                StringExtensions.RegisterAdditionalCSharpKeywords("value");

                Assert.That(action(value), Is.EqualTo("@value"));
            }
            finally
            {
                StringExtensions.ClearAdditionalCSharpKeywords();
            }

            Assert.That(action(value), Is.EqualTo("value"));
        }
    }
}
