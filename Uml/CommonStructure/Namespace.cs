// -------------------------------------------------------------------------------------------------
// <copyright file="Namespace.cs" company="RHEA System S.A.">
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

namespace Uml.CommonStructure
{
    using System.Collections.Generic;
    using Uml.Assembler;

    /// <summary>
    /// A <see cref="Namespace"/> is an <see cref="Element"/> in a model that owns and/or imports a set of <see cref="NamedElement"/>s that can be identified by name.
    /// </summary>
    public interface Namespace : NamedElement
    {
        /// <summary>
        /// References the ElementImports owned by the Namespace.
        /// </summary>
        OwnerList<ElementImport> ElementImport { get; set; }

        /// <summary>
        /// References the <see cref="PackageableElement"/>s that are members of this <see cref="Namespace"/> as a result of either <see cref="PackageImport"/>s or <see cref="ElementImport"/>s.
        /// </summary>
        IEnumerable<PackageableElement> ImportedMember { get; set; }

        /// <summary>
        /// A collection of <see cref="NamedElement"/>s identifiable within the <see cref="Namespace"/>, either by being owned or by being introduced by importing or inheritance.
        /// </summary>
        /// <remarks>
        /// Derived Property.
        /// </remarks>
        IEnumerable<NamedElement> Member { get; }

        /// <summary>
        /// A collection of <see cref="NamedElement"/>s owned by the <see cref="Namespace"/>.
        /// </summary>
        /// <remarks>
        /// Derived Property.
        /// </remarks>
        IEnumerable<NamedElement> OwnedMember { get; }

        /// <summary>
        /// Specifies a set of <see cref="Constraint"/>s owned by this <see cref="Namespace"/>.
        /// </summary>
        OwnerList<Constraint> OwnedRule { get; set; }

        /// <summary>
        /// References the <see cref="PackageImport"/>s owned by the <see cref="Namespace"/>.
        /// </summary>
        OwnerList<PackageImport> PackageImport { get; set; }
    }
}