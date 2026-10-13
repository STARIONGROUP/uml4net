// -------------------------------------------------------------------------------------------------
// <copyright file="CSharpIdentifierCasing.cs" company="Starion Group S.A.">
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
