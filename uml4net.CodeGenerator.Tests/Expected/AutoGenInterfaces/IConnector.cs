// -------------------------------------------------------------------------------------------------
// <copyright file="IConnector.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.StructuredClassifiers
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
    /// A Connector specifies links that enables communication between two or more instances. In contrast to
    /// Associations, which specify links between any instance of the associated Classifiers, Connectors
    /// specify links between instances playing the connected parts only.
    /// </summary>
    [Class(xmiId: "Connector", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IConnector : IFeature
    {
        /// <summary>
        /// The set of Behaviors that specify the valid interaction patterns across the Connector.
        /// </summary>
        [Property(xmiId: "Connector-contract", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IBehavior> Contract { get; set; }

        /// <summary>
        /// A Connector has at least two ConnectorEnds, each representing the participation of instances of the
        /// Classifiers typing the ConnectableElements attached to the end. The set of ConnectorEnds is ordered.
        /// </summary>
        [Property(xmiId: "Connector-end", aggregation: AggregationKind.Composite, lowerValue: 2, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IConnectorEnd> End { get; set; }

        /// <summary>
        /// Indicates the kind of Connector. This is derived: a Connector with one or more ends connected to a
        /// Port which is not on a Part and which is not a behavior port is a delegation; otherwise it is an
        /// assembly.
        /// </summary>
        [Property(xmiId: "Connector-kind", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public ConnectorKind Kind { get; }

        /// <summary>
        /// A Connector may be redefined when its containing Classifier is specialized. The redefining Connector
        /// may have a type that specializes the type of the redefined Connector. The types of the ConnectorEnds
        /// of the redefining Connector may specialize the types of the ConnectorEnds of the redefined
        /// Connector. The properties of the ConnectorEnds of the redefining Connector may be replaced.
        /// </summary>
        [Property(xmiId: "Connector-redefinedConnector", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        public List<IConnector> RedefinedConnector { get; set; }

        /// <summary>
        /// An optional Association that classifies links corresponding to this Connector.
        /// </summary>
        [Property(xmiId: "Connector-type", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IAssociation Type { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
