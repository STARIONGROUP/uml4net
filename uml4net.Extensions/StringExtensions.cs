// -------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Extension methods for <see cref="string"/> 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// splits a string into multiple lines
        /// </summary>
        /// <param name="input">
        /// the subject input string
        /// </param>
        /// <param name="maximumLineLength">
        /// the maximum length of a line
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{String}"/>
        /// </returns>
        public static IEnumerable<string> SplitToLines(this string input, int maximumLineLength = 100)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return SplitToLinesIterator(input, maximumLineLength);
        }

        /// <summary>
        /// splits a string into multiple lines
        /// </summary>
        /// <param name="input">
        /// the subject input string
        /// </param>
        /// <param name="maximumLineLength">
        /// the maximum length of a line
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{String}"/>
        /// </returns>
        private static IEnumerable<string> SplitToLinesIterator(string input, int maximumLineLength = 100)
        {
            input = input.Replace("\r\n", " ").Trim();

            var words = input.Split(' ');
            var line = words[0];

            foreach (var word in words.Skip(1))
            {
                var test = $"{line} {word}";
                if (test.Length > maximumLineLength)
                {
                    yield return line;
                    line = word;
                }
                else
                {
                    line = test;
                }
            }

            yield return line.Trim();
        }

        /// <summary>
        /// Capitalize the first letter of a string
        /// </summary>
        /// <param name="input">
        /// The subject input string
        /// </param>
        /// <returns>
        /// Returns a string where the first character is converted to uppercase
        /// </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("string can't be empty!");
            }

            return string.Concat(input[0].ToString(CultureInfo.InvariantCulture).ToUpper(CultureInfo.InvariantCulture), input.Substring(1));
        }

        /// <summary>
        /// Lower case the first letter of a string
        /// </summary>
        /// <param name="input">
        /// The subject input string
        /// </param>
        /// <returns>
        /// Returns a string where the first character is converted to lowercase
        /// </returns>
        public static string LowerCaseFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("string can't be empty!");
            }

            return string.Concat(input[0].ToString(CultureInfo.InvariantCulture).ToLower(CultureInfo.InvariantCulture), input.Substring(1));
        }

        /// <summary>
        /// The reserved keywords of C#. A reserved keyword cannot be used as an identifier unless it is prefixed
        /// with <c>@</c>.
        /// </summary>
        /// <remarks>
        /// The contextual keywords of C#, such as <c>var</c>, <c>value</c> and <c>record</c>, are not part of this
        /// set: they only have a meaning in a specific context and are legal identifiers.
        /// </remarks>
        private static readonly HashSet<string> ReservedCSharpKeywords = new HashSet<string>(StringComparer.Ordinal)
        {
            "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const",
            "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern",
            "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface",
            "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override",
            "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short",
            "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof",
            "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
        };

        /// <summary>
        /// Queries the reserved keywords of C#
        /// </summary>
        /// <returns>
        /// The reserved keywords of C#, in alphabetical order. The contextual keywords are not included.
        /// </returns>
        public static IReadOnlyList<string> QueryCSharpKeywords()
        {
            return ReservedCSharpKeywords.OrderBy(x => x, StringComparer.Ordinal).ToList().AsReadOnly();
        }

        /// <summary>
        /// Queries whether the string is a reserved keyword of C#
        /// </summary>
        /// <param name="input">
        /// The subject input string
        /// </param>
        /// <returns>
        /// true when the <paramref name="input"/> is a reserved keyword of C#, false otherwise. The comparison is
        /// case-sensitive: <c>class</c> is a keyword, <c>Class</c> is not. A contextual keyword such as <c>var</c>
        /// is not a reserved keyword.
        /// </returns>
        public static bool QueryIsCSharpKeyword(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return ReservedCSharpKeywords.Contains(input);
        }

        /// <summary>
        /// Escapes the string when it is a reserved keyword of C#, so that it can be used as an identifier
        /// </summary>
        /// <param name="input">
        /// The subject input string
        /// </param>
        /// <returns>
        /// The <paramref name="input"/> prefixed with <c>@</c> when it is a reserved keyword of C#
        /// (see <see cref="QueryIsCSharpKeyword"/>), the unchanged <paramref name="input"/> otherwise
        /// </returns>
        public static string EscapeCSharpKeyword(this string input)
        {
            return input.QueryIsCSharpKeyword() ? $"@{input}" : input;
        }
    }
}
