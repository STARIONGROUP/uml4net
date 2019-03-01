// -------------------------------------------------------------------------------------------------
// <copyright file="Lifeline.cs" company="RHEA System S.A.">
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

namespace Uml.Interactions
{
    using Uml.Assembler;
    using System.Collections.Generic;
    using Uml.CommonStructure;
    using Uml.StructuredClassifiers;
    using Uml.Values;

    /// <summary>
    /// A <see cref="Lifeline"/> represents an individual participant in the Interaction. While parts and structural features may have multiplicity greater than 1, <see cref="Lifeline"/>s represent only one interacting entity.
    /// </summary>
    public interface Lifeline : NamedElement
    {
        /// <summary>
        /// References the <see cref="InteractionFragment"/> s in which this <see cref="Lifeline"/> takes part.
        /// </summary>
        List<InteractionFragment> CoveredBy { get; set; }

        /// <summary>
        /// References the <see cref="Interaction"/> that represents the decomposition.
        /// </summary>
        PartDecomposition DecomposedAs { get; set; }

        /// <summary>
        /// References the <see cref="Interaction"/> enclosing this <see cref="Lifeline"/>.
        /// </summary>
        Interaction Interaction { get; set; }

        /// <summary>
        /// References the <see cref="ConnectableElement"/> within the classifier that contains the enclosing interaction.
        /// </summary>
        ConnectableElement Represents { get; set; }

        /// <summary>
        /// If the referenced <see cref="ConnectableElement"/> is multivalued, then this specifies the specific individual part within that set.
        /// </summary>
        OwnerList<ValueSpecification> Sector { get; set; }
    }
}