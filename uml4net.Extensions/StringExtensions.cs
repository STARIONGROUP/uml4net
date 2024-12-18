﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="StringExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
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

    using uml4net.Utils;

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
            Guard.ThrowIfNull(input);

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
        /// Prefixes the input string with another
        /// </summary>
        /// <param name="input">
        /// the string that is to be prefixed
        /// </param>
        /// <param name="prefix">
        /// the subject prefix
        /// </param>
        /// <returns>
        /// the inputs string prefixed with the provided prefix
        /// </returns>
        public static string Prefix(this string input, string prefix)
        {
            return $"{prefix}{input}";
        }

        /// <summary>
        /// Returns the opposite value of a boolean
        /// </summary>
        /// <param name="value">
        /// the subject boolean
        /// </param>
        /// <returns>
        /// true or false
        /// </returns>
        public static bool FlipIt(bool value)
        {
            return !value;
        }

        /// <summary>
        /// Increments the value with 1
        /// </summary>
        /// <param name="value">
        /// the value that is to be incremented
        /// </param>
        /// <returns>
        /// the value incremented with 1
        /// </returns>
        public static int Increment(int value)
        {
            var result = value + 1;
            return result;
        }

        /// <summary>
        /// Increments the value with 1
        /// </summary>
        /// <param name="value">
        /// the value that is to be incremented
        /// </param>
        /// <returns>
        /// the value incremented with 1
        /// </returns>
        public static int Decrement(int value)
        {
            var result = value - 1;
            return result;
        }
    }
}
