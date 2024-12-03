// -------------------------------------------------------------------------------------------------
// <copyright file="NamedElementExtensions.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
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
    
    using uml4net.Utils;

    /// <summary>
    /// The <see cref="NamedElementExtensions"/> class provides extensions methods for <see cref="INamedElement"/>
    /// </summary>
    public static class NamedElementExtensions
    {
        public static List<IDependency> QueryClientDependency(this INamedElement namedElement)
        {
            throw new NotImplementedException();
        }

        public static List<INamedElement> QueryMember(this INamedElement namedElement)
        {
            throw new NotImplementedException();
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
        public static string QueryQualifiedName(this INamedElement namedElement)
        {
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
        public static INamespace QueryNamespace(this INamedElement namedElement)
        {
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


        public static IContainerList<INamedElement> QueryOwnedMember(this INamedElement namedElement)
        {
            throw new NotImplementedException();
        }
    }
}
