// -------------------------------------------------------------------------------------------------
// <copyright file="PackageExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Packages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.CommonStructure;

    /// <summary>
    /// The <see cref="PackageExtensions"/> class provides extensions methods for <see cref="IPackage"/>
    /// </summary>
    internal static class PackageExtensions
    {
        /// <summary>
        /// Retrieves a collection of nested <see cref="IPackage"/> elements contained within the specified <paramref name="package"/>.
        /// </summary>
        /// <param name="package">The <see cref="IPackage"/> whose nested packages are to be retrieved.</param>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="IPackage"/> elements representing the nested packages 
        /// within the specified <paramref name="package"/>.
        /// </returns>
        internal static List<IPackage> QueryNestedPackage(this IPackage package)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            return package.PackagedElement.OfType<IPackage>().ToList();
        }

        /// <summary>
        /// Queries the Stereotypes that are owned by the Package.
        /// </summary>
        /// <param name="package">
        /// The subject <see cref="IPackage"/>
        /// </param>
        /// <returns>
        /// The Stereotypes that are owned by the Package.
        /// </returns>
        internal static List<IStereotype> QueryOwnedStereotype(this IPackage package)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            return package.PackagedElement.OfType<IStereotype>().ToList();
        }

        /// <summary>
        /// Queries the packaged elements that are Types.
        /// </summary>
        /// <param name="package">
        /// The subject <see cref="IPackage"/>
        /// </param>
        /// <returns>
        /// The packaged elements that are Types.
        /// </returns>
        internal static List<IType> QueryOwnedType(this IPackage package)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            return package.PackagedElement.OfType<IType>().ToList();
        }

        /// <summary>
        /// Queries whether this Package makes the specified NamedElement visible outside itself.
        /// </summary>
        /// <param name="package">
        /// The subject <see cref="IPackage"/>
        /// </param>
        /// <param name="element">
        /// the <see cref="INamedElement"/> to check
        /// </param>
        /// <returns>
        /// <c>true</c> when the element is visible outside this Package, <c>false</c> otherwise.
        /// </returns>
        /// <remarks>
        /// The metamodel's own OCL for <c>Package::makesVisible</c> (verified against the raw
        /// <c>resources/UML/UML.xmi</c>, not just the uml4net-sage extraction, to rule out an
        /// extraction error) is malformed - the second clause compares an <c>ElementImport</c>'s
        /// <c>importedElement</c> (a NamedElement) directly to <c>VisibilityKind::public</c> (an
        /// enum literal), which can never hold, and the third clause uses
        /// <c>collect(...)->notEmpty()</c> where <c>exists(...)</c> was clearly intended (as written,
        /// it would return true for any public PackageImport regardless of whether the element is
        /// actually a member of the imported package). This implementation instead follows the
        /// operation's own documentation comment ("Elements with no visibility and elements with
        /// public visibility are made visible") and the OCL's evident structural intent: an element
        /// is visible if it is an owned member, or was imported via a public <see cref="IElementImport"/>,
        /// or is a member of a Package imported via a public <see cref="IPackageImport"/>.
        /// </remarks>
        internal static bool QueryMakesVisible(this IPackage package, INamedElement element)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (package.OwnedMember.Contains(element))
            {
                return true;
            }

            if (package.ElementImport.Any(elementImport => elementImport.Visibility == VisibilityKind.Public && Equals(elementImport.ImportedElement, element)))
            {
                return true;
            }

            return package.PackageImport.Any(packageImport => packageImport.Visibility == VisibilityKind.Public && packageImport.ImportedPackage.Member.Contains(element));
        }

        /// <summary>
        /// Queries the PackageableElements that this Package makes visible to importers.
        /// </summary>
        /// <param name="package">
        /// The subject <see cref="IPackage"/>
        /// </param>
        /// <returns>
        /// the PackageableElements that this Package makes visible to importers.
        /// </returns>
        internal static List<IPackageableElement> QueryVisibleMembers(this IPackage package)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            return package.Member
                .OfType<IPackageableElement>()
                .Where(package.QueryMakesVisible)
                .Distinct()
                .ToList();
        }
    }
}
