// -------------------------------------------------------------------------------------------------
//  <copyright file="StringExtensions.cs" company="Starion Group S.A.">
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
    }
}
