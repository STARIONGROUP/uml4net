// -------------------------------------------------------------------------------------------------
// <copyright file="NamedElementExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.CommonStructure
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="NamedElementExtensions"/> class provides extensions methods for <see cref="INamedElement"/>
    /// </summary>
    internal static class NamedElementExtensions
    {
        /// <summary>
        /// Queries the Dependencies that reference this NamedElement as a client.
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <returns>
        /// the Dependencies that reference this NamedElement as a client.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<IDependency> QueryClientDependency(this INamedElement namedElement)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries A collection of NamedElements identifiable within the Namespace, either by being owned or by being
        /// introduced by importing or inheritance.
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <returns>
        /// A collection of NamedElements identifiable within the Namespace, either by being owned or by being
        /// introduced by importing or inheritance.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<INamedElement> QueryMember(this INamedElement namedElement)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries the fully qualified name of the <see cref="INamedElement"/>
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <returns>
        /// a string that represents the fully qualified name following the pattern N1::N2::x where N1 and N2 are container
        /// Namespaces and x is the subject <see cref="INamedElement"/>
        /// </returns>
        /// <remarks>
        /// As a Namespace is itself a NamedElement, the fully qualified name of a NamedElement may include multiple
        /// Namespace names, such as N1::N2::x
        /// </remarks>
        internal static string QueryQualifiedName(this INamedElement namedElement)
        {
            if (namedElement == null)
            {
                throw new ArgumentNullException(nameof(namedElement));
            }

            if (string.IsNullOrEmpty(namedElement.Name))
            {
                return string.Empty;
            }

            var result = namedElement.Name;

            var owner = namedElement.Owner;

            while (owner != null)
            {
                if (owner is INamespace @namespace)
                {
                    result = $"{@namespace.Name}::{result}";
                }

                owner = owner.Owner;
            }

            return result;
        }

        /// <summary>
        /// Queries the <see cref="INamespace"/> that owns the <see cref="INamedElement"/>
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <returns>
        /// The <see cref="INamespace"/> that owns the <see cref="INamedElement"/>
        /// </returns>
        internal static INamespace QueryNamespace(this INamedElement namedElement)
        {
            if (namedElement == null)
            {
                throw new ArgumentNullException(nameof(namedElement));
            }

            if (namedElement.Owner == null)
            {
                return null;
            }

            var owner = namedElement.Owner;

            while (owner is not INamespace)
            {
                owner = owner.Owner;
            }

            return owner as INamespace;
        }

        /// <summary>
        /// Queries A collection of NamedElements owned by the Namespace.
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <returns>
        /// A collection of NamedElements owned by the Namespace.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static IContainerList<INamedElement> QueryOwnedMember(this INamedElement namedElement)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }
    }
}
