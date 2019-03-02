// -------------------------------------------------------------------------------------------------
// <copyright file="Component.cs" company="RHEA System S.A.">
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

namespace Uml.StructuredClassifiers
{
    using System.Collections.Generic;
    using Uml.SimpleClassifiers;
    using Uml.Assembler;
    using Uml.Classification;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="Component"/> represents a modular part of a system that encapsulates its contents and whose manifestation is replaceable within its environment.  
    /// </summary>
    public interface Component : Class
    {
        /// <summary>
        /// If true, the <see cref="Component"/> is defined at design-time, but at run-time (or execution-time) an object specified by the <see cref="Component"/> does not exist, that is, the Component is instantiated indirectly, through the instantiation of its realizing <see cref="Classifier"/>s or parts.
        /// </summary>
        bool IsIndirectlyInstantiated { get; set; }

        /// <summary>
        /// The set of <see cref="PackageableElement"/>s that a Component owns. In the namespace of a Component, all model elements that are involved in or related to its definition may be owned or imported explicitly. These may include e.g., Classes, Interfaces, Components, Packages, UseCases, Dependencies (e.g., mappings), and Artifacts.
        /// </summary>
        OwnerList<PackageableElement> PackagedElement { get; set; }

        /// <summary>
        /// The <see cref="Interface"/>s that the <see cref="Component"/> exposes to its environment. These <see cref="Interface"/>s may be Realized by the <see cref="Component"/> or any of its realizingClassifiers, or they may be the <see cref="Interface"/>s that are provided by its public <see cref="Port"/>s.
        /// </summary>
        IEnumerable<Interface> Provided { get; }

        /// <summary>
        /// The set of <see cref="Realization"/>s owned by the <see cref="Component"/>. <see cref="Realization"/>s reference the <see cref="Classifier"/>s of which the <see cref="Component"/> is an abstraction; i.e., that realize its behavior.
        /// </summary>
        OwnerList<ComponentRealization> Realization { get; set; }

        /// <summary>
        /// The <see cref="Interface"/>s that the <see cref="Component"/> requires from other Components in its environment in order to be able to offer its full set of provided functionality. These <see cref="Interface"/>s may be used by the <see cref="Component"/> or any of its realizingClassifiers, or they may be the Interfaces that are required by its public <see cref="Port"/>s.
        /// </summary>
        IEnumerable<Interface> Required { get; }
    }
}