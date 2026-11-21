// -------------------------------------------------------------------------------------------------
// <copyright file="CSharpKeywordsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CodeGenerator.Tests
{
    using System;
    using System.Linq;

    using Microsoft.CodeAnalysis.CSharp;

    using NUnit.Framework;

    using uml4net.Extensions;

    /// <summary>
    /// Verifies the list of reserved C# keywords of <see cref="StringExtensions"/> against the C# compiler. The
    /// uml4net.Extensions library does not reference the compiler, this test project does.
    /// </summary>
    [TestFixture]
    public class CSharpKeywordsTestFixture
    {
        [Test]
        public void Verify_that_the_reserved_keywords_are_those_of_the_CSharp_compiler()
        {
            // the compiler also reserves four undocumented keywords that start with two underscores (__arglist,
            // __makeref, __reftype and __refvalue); a model element is not expected to have such a name
            var compilerKeywords = SyntaxFacts.GetReservedKeywordKinds()
                .Select(SyntaxFacts.GetText)
                .Where(x => !x.StartsWith("__", StringComparison.Ordinal))
                .OrderBy(x => x, StringComparer.Ordinal)
                .ToList();

            Assert.That(StringExtensions.QueryCSharpKeywords(), Is.EqualTo(compilerKeywords));
        }

        [Test]
        public void Verify_that_a_contextual_keyword_is_not_a_reserved_keyword()
        {
            var contextualKeywords = SyntaxFacts.GetContextualKeywordKinds().Select(SyntaxFacts.GetText).ToList();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(contextualKeywords, Does.Contain("partial"));
                Assert.That(contextualKeywords.Where(x => x.QueryIsCSharpKeyword()), Is.Empty);
            }
        }
    }
}
