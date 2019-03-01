// -------------------------------------------------------------------------------------------------
// <copyright file="InformationFlow.cs" company="RHEA System S.A.">
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

namespace Uml.InformationFlows
{
    using System.Collections.Generic;
    using Uml.Activities;
    using Uml.Classification;
    using Uml.CommonStructure;
    using Uml.Interactions;
    using Uml.StructuredClassifiers;

    /// <summary>
    /// InformationFlows describe circulation of information through a system in a general manner. They do not specify the nature of the information, mechanisms by which it is conveyed, sequences of exchange or any control conditions. During more detailed modeling, representation and realization links may be added to specify which model elements implement an InformationFlow and to show how information is conveyed.  InformationFlows require some kind of “information channel” for unidirectional transmission of information items from sources to targets.  They specify the information channel’s realizations, if any, and identify the information that flows along them.  Information moving along the information channel may be represented by abstract InformationItems and by concrete Classifiers.
    /// </summary>
    public interface InformationFlow : DirectedRelationship, PackageableElement
    {
        /// <summary>
        /// Specifies the information items that may circulate on this information flow.
        /// </summary>
        List<Classifier> Conveyed { get; set; }

        /// <summary>
        /// Defines from which source the conveyed <see cref="InformationItem"/>s are initiated.
        /// </summary>
        List<NamedElement> InformationSource { get; set; }

        /// <summary>
        /// Defines to which target the conveyed <see cref="InformationItem"/>s are directed.
        /// </summary>
        List<NamedElement> InformationTarget { get; set; }

        /// <summary>
        /// Determines which <see cref="Relationship"/> will realize the specified flow.
        /// </summary>
        List<Relationship> Realization { get; set; }

        /// <summary>
        /// Determines which <see cref="ActivityEdge"/>s will realize the specified flow.
        /// </summary>
        List<ActivityEdge> RealizingActivityEdge { get; set; }

        /// <summary>
        /// Determines which <see cref="Connector"/>s will realize the specified flow.
        /// </summary>
        List<Connector> RealizingConnector { get; set; }

        /// <summary>
        /// Determines which <see cref="Message"/>s will realize the specified flow.
        /// </summary>
        List<Message> RealizingMessage { get; set; }
    }
}