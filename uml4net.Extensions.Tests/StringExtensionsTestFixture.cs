// -------------------------------------------------------------------------------------------------
// <copyright file="StringExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
        public void Verify_that_SplitToLines_throws_exception_when_input_is_null()
        {
            string input = null;

            Assert.That(() => StringExtensions.SplitToLines(input, 5), Throws.ArgumentNullException);
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

        [Test]
        public void Verify_that_QueryIsCSharpKeyword_recognizes_the_reserved_keywords()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That("class".QueryIsCSharpKeyword(), Is.True);
                Assert.That("in".QueryIsCSharpKeyword(), Is.True);
                Assert.That("true".QueryIsCSharpKeyword(), Is.True);
                Assert.That("Class".QueryIsCSharpKeyword(), Is.False, "the comparison is case-sensitive");
                Assert.That("var".QueryIsCSharpKeyword(), Is.False, "a contextual keyword is a legal identifier");
                Assert.That("type".QueryIsCSharpKeyword(), Is.False);
                Assert.That(string.Empty.QueryIsCSharpKeyword(), Is.False);
                Assert.That(() => StringExtensions.QueryIsCSharpKeyword(null), Throws.ArgumentNullException);

                Assert.That(StringExtensions.QueryCSharpKeywords(), Has.Count.EqualTo(77));
                Assert.That(StringExtensions.QueryCSharpKeywords(), Is.Ordered.Using((IComparer<string>)StringComparer.Ordinal));
                Assert.That(StringExtensions.QueryCSharpKeywords().All(x => x.QueryIsCSharpKeyword()), Is.True);
            }
        }

        [Test]
        public void Verify_that_EscapeCSharpKeyword_prefixes_a_reserved_keyword()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That("class".EscapeCSharpKeyword(), Is.EqualTo("@class"));
                Assert.That("event".EscapeCSharpKeyword(), Is.EqualTo("@event"));
                Assert.That("Class".EscapeCSharpKeyword(), Is.EqualTo("Class"));
                Assert.That("ownedComment".EscapeCSharpKeyword(), Is.EqualTo("ownedComment"));
                Assert.That("var".EscapeCSharpKeyword(), Is.EqualTo("var"));
                Assert.That("@class".EscapeCSharpKeyword(), Is.EqualTo("@class"), "a string that is already escaped is not escaped again");
                Assert.That("class ".EscapeCSharpKeyword(), Is.EqualTo("class "), "the string is not trimmed");
                Assert.That(string.Empty.EscapeCSharpKeyword(), Is.Empty);
                Assert.That(() => StringExtensions.EscapeCSharpKeyword(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        [NonParallelizable]
        public void Verify_that_RegisterAdditionalCSharpKeywords_extends_the_reserved_keywords()
        {
            try
            {
                StringExtensions.RegisterAdditionalCSharpKeywords("var", "value");
                StringExtensions.RegisterAdditionalCSharpKeywords("value", "class", "record");

                using (Assert.EnterMultipleScope())
                {
                    Assert.That("var".QueryIsCSharpKeyword(), Is.True);
                    Assert.That("value".QueryIsCSharpKeyword(), Is.True);
                    Assert.That("Var".QueryIsCSharpKeyword(), Is.False, "the comparison is case-sensitive");
                    Assert.That("class".QueryIsCSharpKeyword(), Is.True);

                    Assert.That("var".EscapeCSharpKeyword(), Is.EqualTo("@var"));
                    Assert.That("value".EscapeCSharpKeyword(), Is.EqualTo("@value"));
                    Assert.That("Value".EscapeCSharpKeyword(), Is.EqualTo("Value"));

                    Assert.That(StringExtensions.QueryAdditionalCSharpKeywords(), Is.EqualTo(new[] { "record", "value", "var" }),
                        "a reserved keyword of C# and a word that is registered twice are ignored");
                    Assert.That(StringExtensions.QueryCSharpKeywords(), Has.Count.EqualTo(77));
                }
            }
            finally
            {
                StringExtensions.ClearAdditionalCSharpKeywords();
            }

            using (Assert.EnterMultipleScope())
            {
                Assert.That(StringExtensions.QueryAdditionalCSharpKeywords(), Is.Empty);
                Assert.That("var".QueryIsCSharpKeyword(), Is.False);
                Assert.That("value".EscapeCSharpKeyword(), Is.EqualTo("value"));
            }
        }

        [Test]
        [NonParallelizable]
        public void Verify_that_RegisterAdditionalCSharpKeywords_rejects_invalid_keywords()
        {
            try
            {
                using (Assert.EnterMultipleScope())
                {
                    Assert.That(() => StringExtensions.RegisterAdditionalCSharpKeywords(null), Throws.ArgumentNullException);
                    Assert.That(() => StringExtensions.RegisterAdditionalCSharpKeywords("var", null), Throws.ArgumentException);
                    Assert.That(() => StringExtensions.RegisterAdditionalCSharpKeywords("var", string.Empty), Throws.ArgumentException);
                    Assert.That(() => StringExtensions.RegisterAdditionalCSharpKeywords("var", " "), Throws.ArgumentException);
                    Assert.That(() => StringExtensions.RegisterAdditionalCSharpKeywords("var", " value"), Throws.ArgumentException, "a word that starts with white space never equals a name");
                    Assert.That(() => StringExtensions.RegisterAdditionalCSharpKeywords("var", "value "), Throws.ArgumentException);
                    Assert.That(() => StringExtensions.RegisterAdditionalCSharpKeywords("var", "@value"), Throws.ArgumentException);

                    Assert.That(StringExtensions.QueryAdditionalCSharpKeywords(), Is.Empty, "nothing is registered when one of the keywords is invalid");
                    Assert.That(() => StringExtensions.RegisterAdditionalCSharpKeywords(), Throws.Nothing);
                }
            }
            finally
            {
                StringExtensions.ClearAdditionalCSharpKeywords();
            }
        }

        [Test]
        [NonParallelizable]
        public void Verify_that_the_keyword_queries_return_a_read_only_snapshot()
        {
            try
            {
                StringExtensions.RegisterAdditionalCSharpKeywords("var");

                var snapshot = StringExtensions.QueryAdditionalCSharpKeywords();

                StringExtensions.RegisterAdditionalCSharpKeywords("value");
                StringExtensions.ClearAdditionalCSharpKeywords();

                using (Assert.EnterMultipleScope())
                {
                    Assert.That(snapshot, Is.EqualTo(new[] { "var" }), "a later registration or clear does not change a list that was returned before");
                    Assert.That(() => ((IList<string>)snapshot).Add("x"), Throws.TypeOf<NotSupportedException>());
                    Assert.That(() => ((IList<string>)StringExtensions.QueryCSharpKeywords()).Add("x"), Throws.TypeOf<NotSupportedException>());
                    Assert.That(StringExtensions.QueryCSharpKeywords(), Has.Count.EqualTo(77));
                }
            }
            finally
            {
                StringExtensions.ClearAdditionalCSharpKeywords();
            }
        }

        [Test]
        [NonParallelizable]
        public void Verify_that_the_additional_keywords_can_be_registered_and_queried_from_several_threads()
        {
            const int threads = 8;
            const int wordsPerThread = 200;

            try
            {
                var tasks = Enumerable.Range(0, threads).Select(thread => Task.Run(() =>
                {
                    for (var i = 0; i < wordsPerThread; i++)
                    {
                        var word = $"word_{thread}_{i}";

                        StringExtensions.RegisterAdditionalCSharpKeywords(word);

                        if (!word.QueryIsCSharpKeyword() || !"class".QueryIsCSharpKeyword() || "Class".QueryIsCSharpKeyword())
                        {
                            throw new InvalidOperationException($"{word} is not found after it has been registered");
                        }
                    }
                })).ToArray();

                Assert.That(() => Task.WaitAll(tasks), Throws.Nothing);
                Assert.That(StringExtensions.QueryAdditionalCSharpKeywords(), Has.Count.EqualTo(threads * wordsPerThread), "no registration is lost");
            }
            finally
            {
                StringExtensions.ClearAdditionalCSharpKeywords();
            }
        }
    }
}
