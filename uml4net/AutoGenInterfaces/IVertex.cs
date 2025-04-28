// -------------------------------------------------------------------------------------------------
// <copyright file="IVertex.cs" company="Starion Group S.A.">
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

namespace uml4net.StateMachines
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
    /// A Vertex is an abstraction of a node in a StateMachine graph. It can be the source or destination of
    /// any number of Transitions.
    /// </summary>
    [Class(xmiId: "Vertex", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IVertex : INamedElement, IRedefinableElement
    {
        /// <summary>
        /// The Region that contains this Vertex.
        /// </summary>
        [Property(xmiId: "Vertex-container", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IRegion Container { get; set; }

        /// <summary>
        /// Specifies the Transitions entering this Vertex.
        /// </summary>
        [Property(xmiId: "Vertex-incoming", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<ITransition> Incoming { get; }

        /// <summary>
        /// Specifies the Transitions departing from this Vertex.
        /// </summary>
        [Property(xmiId: "Vertex-outgoing", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<ITransition> Outgoing { get; }

        /// <summary>
        /// References the Classifier in which context this element may be redefined.
        /// </summary>
        [Property(xmiId: "State-redefinitionContext", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedProperty(propertyName: "RedefinableElement-redefinitionContext")]
        public new IClassifier RedefinitionContext { get; }

        /// <summary>
        /// The Vertex of which this Vertex is a redefinition.
        /// </summary>
        [Property(xmiId: "State-redefinedState", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        public IVertex RedefinedVertex { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
