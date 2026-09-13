// -------------------------------------------------------------------------------------------------
// <copyright file="VisibilityKind.cs" company="Starion Group S.A.">
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.CommonStructure
{
    using System;

    /// <summary>
    /// VisibilityKind is an enumeration type that defines literals to determine the visibility of Elements
    /// in a model.
    /// </summary>
    public enum VisibilityKind
    {
        /// <summary>
        /// A Named Element with public visibility is visible to all elements that can access the contents of
        /// the Namespace that owns it.
        /// </summary>
        Public,

        /// <summary>
        /// A NamedElement with private visibility is only visible inside the Namespace that owns it.
        /// </summary>
        Private,

        /// <summary>
        /// A NamedElement with protected visibility is visible to Elements that have a generalization
        /// relationship to the Namespace that owns it.
        /// </summary>
        Protected,

        /// <summary>
        /// A NamedElement with package visibility is visible to all Elements within the nearest enclosing
        /// Package (given that other owning Elements have proper visibility). Outside the nearest enclosing
        /// Package, a NamedElement marked as having package visibility is not visible.  Only NamedElements that
        /// are not owned by Packages can be marked as having package visibility.
        /// </summary>
        Package
    }

    /// <summary>
    /// Extension methods for the <see cref="VisibilityKind"/> enumeration
    /// </summary>
    public static class VisibilityKindExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="VisibilityKind"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this VisibilityKind value)
        {
            return value switch
            {
                VisibilityKind.Public => "public",
                VisibilityKind.Private => "private",
                VisibilityKind.Protected => "protected",
                VisibilityKind.Package => "package",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of VisibilityKind")
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
