// -------------------------------------------------------------------------------------------------
// <copyright file="ClassExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.StructuredClassifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;

    /// <summary>
    /// The <see cref="ClassExtensions"/> class provides extensions methods for <see cref="IClass"/>
    /// </summary>
    internal static class ClassExtensions
    {
        /// <summary>
        /// Queries whether this property is used when the Class is acting as a metaclass. It references the Extensions that
        /// specify additional properties of the metaclass. The property is derived from the Extensions whose
        /// memberEnds are typed by the Class.
        /// </summary>
        /// <param name="class">
        /// The subject <see cref="IClass"/>
        /// </param>
        /// <returns>
        /// This property is used when the Class is acting as a metaclass. It references the Extensions that
        /// specify additional properties of the metaclass. The property is derived from the Extensions whose
        /// memberEnds are typed by the Class.
        /// </returns>
        internal static List<IExtension> QueryExtension(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            IElement rootElement = @class;

            while (rootElement.Owner != null)
            {
                rootElement = rootElement.Owner;
            }

            var extensions = new List<IExtension>();

            if (rootElement is IPackage rootPackage)
            {
                CollectExtensions(rootPackage, extensions);
            }

            return extensions.Where(x => x.MemberEnd.Any(memberEnd => ReferenceEquals(QueryMemberEndType(memberEnd), @class))).ToList();
        }

        /// <summary>
        /// Queries the <see cref="IType"/> that types the <paramref name="property"/>, honoring the fact that
        /// <see cref="IExtensionEnd"/> redefines (and hides) <see cref="ITypedElement.Type"/>.
        /// </summary>
        /// <param name="property">
        /// The <see cref="IProperty"/> for which the type is queried.
        /// </param>
        /// <returns>
        /// The <see cref="IType"/> that types the <paramref name="property"/>.
        /// </returns>
        private static IType QueryMemberEndType(IProperty property)
        {
            return property is IExtensionEnd extensionEnd ? extensionEnd.Type : property.Type;
        }

        /// <summary>
        /// Recursively collects the <see cref="IExtension"/> elements that are packaged, directly or via nested
        /// packages, within the specified <paramref name="package"/>.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> to search.
        /// </param>
        /// <param name="extensions">
        /// The <see cref="List{T}"/> of <see cref="IExtension"/> to which any found <see cref="IExtension"/> is added.
        /// </param>
        private static void CollectExtensions(IPackage package, List<IExtension> extensions)
        {
            foreach (var packagedElement in package.PackagedElement)
            {
                switch (packagedElement)
                {
                    case IExtension extension:
                        extensions.Add(extension);
                        break;
                    case IPackage nestedPackage:
                        CollectExtensions(nestedPackage, extensions);
                        break;
                }
            }
        }

        /// <summary>
        /// Retrieves the list of immediate superclasses for the specified class, based on its generalizations.
        /// </summary>
        /// <param name="class">
        /// The <see cref="IClass"/> instance whose superclasses are being queried.
        /// </param>
        /// <returns>
        /// A list of <see cref="IClass"/> objects representing the immediate superclasses of the specified class. 
        /// If no superclasses are defined, returns an empty list.
        /// </returns>
        internal static List<IClass> QuerySuperClass(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            return @class.Generalization.Select(x => x.General).OfType<IClass>().ToList();
        }
    }
}
