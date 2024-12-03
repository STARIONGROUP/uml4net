// -------------------------------------------------------------------------------------------------
// <copyright file="IConnectorEnd.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
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

    using uml4net.Utils;

    /// <summary>
    /// A ConnectorEnd is an endpoint of a Connector, which attaches the Connector to a ConnectableElement.
    /// </summary>
    [Class(xmiId: "ConnectorEnd", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IConnectorEnd : IMultiplicityElement
    {
        /// <summary>
        /// A derived property referencing the corresponding end on the Association which types the Connector
        /// owing this ConnectorEnd, if any. It is derived by selecting the end at the same place in the
        /// ordering of Association ends as this ConnectorEnd.
        /// </summary>
        [Property(xmiId: "ConnectorEnd-definingEnd", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IProperty DefiningEnd { get; }

        /// <summary>
        /// Indicates the role of the internal structure of a Classifier with the Port to which the ConnectorEnd
        /// is attached.
        /// </summary>
        [Property(xmiId: "ConnectorEnd-partWithPort", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IProperty PartWithPort { get; set; }

        /// <summary>
        /// The ConnectableElement attached at this ConnectorEnd. When an instance of the containing Classifier
        /// is created, a link may (depending on the multiplicities) be created to an instance of the Classifier
        /// that types this ConnectableElement.
        /// </summary>
        [Property(xmiId: "ConnectorEnd-role", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IConnectableElement Role { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
