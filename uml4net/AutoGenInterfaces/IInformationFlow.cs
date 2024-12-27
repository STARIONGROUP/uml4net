// -------------------------------------------------------------------------------------------------
// <copyright file="IInformationFlow.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.InformationFlows
{
    using System.CodeDom.Compiler;
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.InformationFlows;
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Values;

    /// <summary>
    /// InformationFlows describe circulation of information through a system in a general manner. They do
    /// not specify the nature of the information, mechanisms by which it is conveyed, sequences of exchange
    /// or any control conditions. During more detailed modeling, representation and realization links may
    /// be added to specify which model elements implement an InformationFlow and to show how information is
    /// conveyed.  InformationFlows require some kind of “information channel” for unidirectional
    /// transmission of information items from sources to targets.  They specify the information channel’s
    /// realizations, if any, and identify the information that flows along them.  Information moving along
    /// the information channel may be represented by abstract InformationItems and by concrete Classifiers.
    /// </summary>
    [Class(xmiId: "InformationFlow", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IInformationFlow : IDirectedRelationship, IPackageableElement
    {
        /// <summary>
        /// Specifies the information items that may circulate on this information flow.
        /// </summary>
        [Property(xmiId: "InformationFlow-conveyed", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IClassifier> Conveyed { get; set; }

        /// <summary>
        /// Defines from which source the conveyed InformationItems are initiated.
        /// </summary>
        [Property(xmiId: "InformationFlow-informationSource", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-source")]
        public List<INamedElement> InformationSource { get; set; }

        /// <summary>
        /// Defines to which target the conveyed InformationItems are directed.
        /// </summary>
        [Property(xmiId: "InformationFlow-informationTarget", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-target")]
        public List<INamedElement> InformationTarget { get; set; }

        /// <summary>
        /// Determines which Relationship will realize the specified flow.
        /// </summary>
        [Property(xmiId: "InformationFlow-realization", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IRelationship> Realization { get; set; }

        /// <summary>
        /// Determines which ActivityEdges will realize the specified flow.
        /// </summary>
        [Property(xmiId: "InformationFlow-realizingActivityEdge", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IActivityEdge> RealizingActivityEdge { get; set; }

        /// <summary>
        /// Determines which Connectors will realize the specified flow.
        /// </summary>
        [Property(xmiId: "InformationFlow-realizingConnector", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IConnector> RealizingConnector { get; set; }

        /// <summary>
        /// Determines which Messages will realize the specified flow.
        /// </summary>
        [Property(xmiId: "InformationFlow-realizingMessage", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IMessage> RealizingMessage { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
