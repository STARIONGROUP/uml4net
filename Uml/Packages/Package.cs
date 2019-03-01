// -------------------------------------------------------------------------------------------------
// <copyright file="Package.cs" company="RHEA System S.A.">
//   Copyright (c) 2018-2019 RHEA System S.A.
//
//   This file is part of uml-sharp
//
//   uml-sharp is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   uml-sharp is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with uml-sharp. If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.Packages
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.CommonStructure;

    /// <summary>
    /// A package can have one or more profile applications to indicate which profiles have been applied. Because a profile is a package, it is possible to apply a profile not only to packages, but also to profiles.
    /// Package specializes TemplateableElement and PackageableElement specializes ParameterableElement to specify that a package can be used as a template and a PackageableElement as a template parameter.
    /// A package is used to group elements, and provides a namespace for the grouped elements.
    /// </summary>
    public interface Package : PackageableElement, TemplateableElement, Namespace
    {
        /// <summary>
        /// Provides an identifier for the package that can be used for many purposes. A URI is the universally unique identification of the package following the IETF URI specification, RFC 2396 http://www.ietf.org/rfc/rfc2396.txt and it must comply with those syntax rules.
        /// </summary>
        string Uri { get; set; }

        /// <summary>
        /// References the packaged elements that are <see cref="Package"/>s.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<Package> NestedPackage { get; }

        /// <summary>
        /// References the <see cref="Package"/> that owns this <see cref="Package"/>.
        /// </summary>
        Package NestingPackage { get; set; }

        /// <summary>
        /// References the <see cref="Stereotype"/>s that are owned by the <see cref="Package"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<Stereotype> OwnedEnumerable { get; }

        /// <summary>
        /// References the packaged elements that are Types.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<Type> OwnedType { get; }

        /// <summary>
        /// References the <see cref="PackageMerge"/>s that are owned by this <see cref="Package"/>.
        /// </summary>
        OwnerList<PackageMerge> PackageMerge { get; set; }

        /// <summary>
        /// Specifies the packageable elements that are owned by this <see cref="Package"/>.
        /// </summary>
        OwnerList<PackageableElement> PackageableElement { get; set; }

        /// <summary>
        /// References the <see cref="ProfileApplication"/>s that indicate which profiles have been applied to the <see cref="Package"/>.
        /// </summary>
        OwnerList<ProfileApplication> ProfileApplication { get; set; }
    }
}