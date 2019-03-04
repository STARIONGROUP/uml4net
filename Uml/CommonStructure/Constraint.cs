// -------------------------------------------------------------------------------------------------
// <copyright file="Constraint.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.Attributes;
    using System.Collections.Generic;
    using Uml.Values;

    /// <summary>
    /// A <see cref="Constraint"/> is a condition or restriction expressed in natural language text or in a machine readable language for the purpose of declaring some of the semantics of an <see cref="Element"/> or set of <see cref="Element"/>s.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false)]
    public interface Constraint : PackageableElement
    {
        /// <summary>
        /// The ordered set of Elements referenced by this <see cref="Constraint"/>.
        /// </summary>
        List<Element> ConstrainedElement { get; set; }

        /// <summary>
        /// Specifies the Namespace that owns the Constraint.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="NamedElement.Namespace"/>
        /// </remarks>
        Namespace Context { get; set; }

        /// <summary>
        /// A condition that must be true when evaluated in order for the <see cref="Constraint"/> to be satisfied.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="Element.OwnedElement"/>
        /// </remarks>
        OwnerList<ValueSpecification> Specification { get; set; }
    }
}