// -------------------------------------------------------------------------------------------------
//  <copyright file="StringExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    using uml4net.Extensions;

    [TestFixture]
    public class StringExtensionsTestFixture
    {
        [Test]
        public void Verify_that_SplitToLines_splits_based_on_maximum_length()
        {
            var input = "Lorem ipsum dolor sit amet";
            var result = input.SplitToLines(11).ToList();
            Assert.That(result, Is.EqualTo(new[] { "Lorem ipsum", "dolor sit", "amet" }));
        }

        [Test]
        public void Verify_that_SplitToLines_replaces_new_lines_and_handles_null()
        {
            var input = "foo\r\nbar baz";
            var result = input.SplitToLines(5).ToList();
            Assert.That(result, Is.EqualTo(new[] { "foo", "bar", "baz" }));
        }

        [Test]
        public void Verify_that_CapitalizeFirstLetter_capitalizes_string()
        {
            var result = "uml4net".CapitalizeFirstLetter();
            Assert.That(result, Is.EqualTo("Uml4net"));
        }

        [Test]
        public void Verify_that_CapitalizeFirstLetter_throws_when_input_is_null_or_empty()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => StringExtensions.CapitalizeFirstLetter(null), Throws.TypeOf<ArgumentException>());
                Assert.That(() => string.Empty.CapitalizeFirstLetter(), Throws.TypeOf<ArgumentException>());
            }
        }

        [Test]
        public void Verify_that_LowerCaseFirstLetter_lowercases_string()
        {
            var result = "Uml4net".LowerCaseFirstLetter();
            Assert.That(result, Is.EqualTo("uml4net"));
        }

        [Test]
        public void Verify_that_LowerCaseFirstLetter_throws_when_input_is_null_or_empty()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => StringExtensions.LowerCaseFirstLetter(null), Throws.TypeOf<ArgumentException>());
                Assert.That(() => string.Empty.LowerCaseFirstLetter(), Throws.TypeOf<ArgumentException>());
            }
        }
    }
}
