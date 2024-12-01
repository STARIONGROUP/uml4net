// -------------------------------------------------------------------------------------------------
// <copyright file="IBehavioralFeature.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
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
    /// A BehavioralFeature is a feature of a Classifier that specifies an aspect of the behavior of its
    /// instances.  A BehavioralFeature is implemented (realized) by a Behavior. A BehavioralFeature
    /// specifies that a Classifier will respond to a designated request by invoking its implementing
    /// method.
    /// </summary>
    [Class(xmiId: "BehavioralFeature", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    public partial interface IBehavioralFeature : IFeature, INamespace
    {
        /// <summary>
        /// Specifies the semantics of concurrent calls to the same passive instance (i.e., an instance
        /// originating from a Class with isActive being false). Active instances control access to their own
        /// BehavioralFeatures.
        /// </summary>
        [Property(xmiId: "BehavioralFeature-concurrency", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "sequential")]
        public CallConcurrencyKind Concurrency { get; set; }

        /// <summary>
        /// If true, then the BehavioralFeature does not have an implementation, and one must be supplied by a
        /// more specific Classifier. If false, the BehavioralFeature must have an implementation in the
        /// Classifier or one must be inherited.
        /// </summary>
        [Property(xmiId: "BehavioralFeature-isAbstract", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsAbstract { get; set; }

        /// <summary>
        /// A Behavior that implements the BehavioralFeature. There may be at most one Behavior for a particular
        /// pairing of a Classifier (as owner of the Behavior) and a BehavioralFeature (as specification of the
        /// Behavior).
        /// </summary>
        [Property(xmiId: "BehavioralFeature-method", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IBehavior> Method { get; set; }

        /// <summary>
        /// The ordered set of formal Parameters of this BehavioralFeature.
        /// </summary>
        [Property(xmiId: "BehavioralFeature-ownedParameter", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IParameter> OwnedParameter { get; set; }

        /// <summary>
        /// The ParameterSets owned by this BehavioralFeature.
        /// </summary>
        [Property(xmiId: "BehavioralFeature-ownedParameterSet", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IParameterSet> OwnedParameterSet { get; set; }

        /// <summary>
        /// The Types representing exceptions that may be raised during an invocation of this BehavioralFeature.
        /// </summary>
        [Property(xmiId: "BehavioralFeature-raisedException", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IType> RaisedException { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------