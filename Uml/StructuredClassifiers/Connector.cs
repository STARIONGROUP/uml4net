// -------------------------------------------------------------------------------------------------
// <copyright file="Connector.cs" company="RHEA System S.A.">
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
    using Uml.CommonStructure;
    using Uml.Assembler;
    using Uml.Classification;
    using Uml.CommonBehavior;

    /// <summary>
    /// A <see cref="Connector"/> specifies links that enables communication between two or more instances. In contrast to <see cref="Association"/>s, which specify links between any instance of the associated <see cref="Classifier"/>s, <see cref="Connector"/>s specify links between instances playing the connected parts only.
    /// </summary>
    public interface Connector : Feature
    {
        /// <summary>
        /// The set of <see cref="Behavior"/>s that specify the valid interaction patterns across the <see cref="Connector"/>.
        /// </summary>
        List<Behavior> Contract { get; set; }

        /// <summary>
        /// A <see cref="Connector"/> has at least two <see cref="ConnectorEnd"/>s, each representing the participation of instances of the <see cref="Classifier"/>s typing the <see cref="ConnectableElement"/>s attached to the end. The set of <see cref="ConnectorEnd"/>s is ordered. 
        /// </summary>
        OwnerList<ConnectorEnd> End { get; set; }

        /// <summary>
        /// Indicates the kind of <see cref="Connector"/>. This is derived: a <see cref="Connector"/> with one or more ends connected to a <see cref="Port"/> which is not on a Part and which is not a behavior port is a delegation; otherwise it is an assembly.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        ConnectorKind Kind { get; }

        /// <summary>
        /// A <see cref="Connector"/> may be redefined when its containing <see cref="Classifier"/> is specialized. The redefining <see cref="Connector"/> may have a type that specializes the type of the redefined <see cref="Connector"/>. The types of the <see cref="ConnectorEnd"/>s of the redefining <see cref="Connector"/> may specialize the types of the <see cref="ConnectorEnd"/>s of the redefined <see cref="Connector"/>. The properties of the <see cref="ConnectorEnd"/>s of the redefining <see cref="Connector"/> may be replaced.
        /// </summary>
        List<Connector> RedefinedConnector { get; set; }

        /// <summary>
        /// An optional <see cref="Association"/> that classifies links corresponding to this <see cref="Connector"/>.
        /// </summary>
        Association Type { get; set; }
    }
}