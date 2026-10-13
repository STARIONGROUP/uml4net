// -------------------------------------------------------------------------------------------------
// <copyright file="NamedElementExtensions.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2026 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
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
    using System.Text;

    using uml4net.CommonStructure;

    /// <summary>
    /// Extension methods for <see cref="INamedElement"/> interface
    /// </summary>
    public static class NamedElementExtensions
    {
        /// <summary>
        /// Query the CSharp namespace of a <see cref="INamedElement"/>
        /// </summary>
        /// <param name="namedElement">
        /// The <see cref="INamedElement"/>
        /// </param>
        /// <returns>
        /// The CSharp compliant namespace
        /// </returns>
        public static string QueryNamespace(this INamedElement namedElement)
        {
            if (string.IsNullOrEmpty(namedElement?.QualifiedName))
            {
                return string.Empty;
            }

            var parts = namedElement.QualifiedName.Split(["::"], StringSplitOptions.None);

            var sb = new StringBuilder();

            for (var i = 0; i < parts.Length; i++)
            {
                if (sb.Length > 0)
                {
                    sb.Append('.');
                }

                sb.Append(parts[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Queries the C# identifier for the <see cref="INamedElement"/>: its name, with the requested casing of the
        /// first letter, escaped when the result is a reserved keyword of C# or a word that has been registered with
        /// <see cref="StringExtensions.RegisterAdditionalCSharpKeywords"/>
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <param name="casing">
        /// The <see cref="CSharpIdentifierCasing"/> of the first letter of the identifier
        /// </param>
        /// <returns>
        /// The name of the <paramref name="namedElement"/> with the requested <paramref name="casing"/>, prefixed
        /// with <c>@</c> when that is a reserved keyword of C# (see <see cref="StringExtensions.EscapeCSharpKeyword"/>)
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the <paramref name="namedElement"/> has no name. <c>NamedElement::name</c> is optional in UML,
        /// but an identifier cannot be derived from an element without a name.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="casing"/> is not a value of the <see cref="CSharpIdentifierCasing"/>
        /// enumeration
        /// </exception>
        /// <remarks>
        /// Only the first letter is changed and only keywords are escaped. A name that holds characters that are not
        /// allowed in a C# identifier, such as a space or an operator symbol, is returned with those characters.
        /// </remarks>
        public static string QueryCSharpIdentifier(this INamedElement namedElement, CSharpIdentifierCasing casing = CSharpIdentifierCasing.AsModelled)
        {
            if (namedElement == null)
            {
                throw new ArgumentNullException(nameof(namedElement));
            }

            if (string.IsNullOrWhiteSpace(namedElement.Name))
            {
                throw new InvalidOperationException($"The {namedElement.GetType().Name} with xmi:id '{namedElement.XmiId}' has no name, a C# identifier cannot be derived from it");
            }

            string identifier;

            switch (casing)
            {
                case CSharpIdentifierCasing.UpperCaseFirstLetter:
                    identifier = namedElement.Name.CapitalizeFirstLetter();
                    break;
                case CSharpIdentifierCasing.LowerCaseFirstLetter:
                    identifier = namedElement.Name.LowerCaseFirstLetter();
                    break;
                case CSharpIdentifierCasing.AsModelled:
                    identifier = namedElement.Name;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(casing), casing, "The casing is not a value of the CSharpIdentifierCasing enumeration");
            }

            return identifier.EscapeCSharpKeyword();
        }
    }
}
