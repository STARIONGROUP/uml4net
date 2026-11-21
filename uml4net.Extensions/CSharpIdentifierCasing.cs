// -------------------------------------------------------------------------------------------------
// <copyright file="CSharpIdentifierCasing.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions
{
    /// <summary>
    /// The casing of the first letter of a C# identifier that is derived from the name of a model element, see
    /// <see cref="NamedElementExtensions.QueryCSharpIdentifier"/>
    /// </summary>
    public enum CSharpIdentifierCasing
    {
        /// <summary>
        /// The name is used as it is in the model
        /// </summary>
        AsModelled = 0,

        /// <summary>
        /// The first letter of the name is converted to upper case
        /// </summary>
        UpperCaseFirstLetter = 1,

        /// <summary>
        /// The first letter of the name is converted to lower case
        /// </summary>
        LowerCaseFirstLetter = 2
    }
}
