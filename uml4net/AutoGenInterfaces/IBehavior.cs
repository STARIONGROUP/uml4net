// -------------------------------------------------------------------------------------------------
// <copyright file="IBehavior.cs" company="Starion Group S.A.">
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

namespace uml4net.CommonBehavior
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
    /// Behavior is a specification of how its context BehavioredClassifier changes state over time. This
    /// specification may be either a definition of possible behavior execution or emergent behavior, or a
    /// selective illustration of an interesting subset of possible executions. The latter form is typically
    /// used for capturing examples, such as a trace of a particular execution.
    /// </summary>
    [Class(xmiId: "Behavior", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IBehavior : IClass
    {
        /// <summary>
        /// The BehavioredClassifier that is the context for the execution of the Behavior. A Behavior that is
        /// directly owned as a nestedClassifier does not have a context. Otherwise, to determine the context of
        /// a Behavior, find the first BehavioredClassifier reached by following the chain of owner
        /// relationships from the Behavior, if any. If there is such a BehavioredClassifier, then it is the
        /// context, unless it is itself a Behavior with a non-empty context, in which case that is also the
        /// context for the original Behavior. For example, following this algorithm, the context of an entry
        /// Behavior in a StateMachine is the BehavioredClassifier that owns the StateMachine. The features of
        /// the context BehavioredClassifier as well as the Elements visible to the context Classifier are
        /// visible to the Behavior.
        /// </summary>
        [Property(xmiId: "Behavior-context", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinitionContext")]
        public IBehavioredClassifier Context { get; }

        /// <summary>
        /// Tells whether the Behavior can be invoked while it is still executing from a previous invocation.
        /// </summary>
        [Property(xmiId: "Behavior-isReentrant", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "true")]
        public bool IsReentrant { get; set; }

        /// <summary>
        /// References a list of Parameters to the Behavior which describes the order and type of arguments that
        /// can be given when the Behavior is invoked and of the values which will be returned when the Behavior
        /// completes its execution.
        /// </summary>
        [Property(xmiId: "Behavior-ownedParameter", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IParameter> OwnedParameter { get; set; }

        /// <summary>
        /// The ParameterSets owned by this Behavior.
        /// </summary>
        [Property(xmiId: "Behavior-ownedParameterSet", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IParameterSet> OwnedParameterSet { get; set; }

        /// <summary>
        /// An optional set of Constraints specifying what is fulfilled after the execution of the Behavior is
        /// completed, if its precondition was fulfilled before its invocation.
        /// </summary>
        [Property(xmiId: "Behavior-postcondition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedRule")]
        public IContainerList<IConstraint> Postcondition { get; set; }

        /// <summary>
        /// An optional set of Constraints specifying what must be fulfilled before the Behavior is invoked.
        /// </summary>
        [Property(xmiId: "Behavior-precondition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedRule")]
        public IContainerList<IConstraint> Precondition { get; set; }

        /// <summary>
        /// Designates a BehavioralFeature that the Behavior implements. The BehavioralFeature must be owned by
        /// the BehavioredClassifier that owns the Behavior or be inherited by it. The Parameters of the
        /// BehavioralFeature and the implementing Behavior must match. A Behavior does not need to have a
        /// specification, in which case it either is the classifierBehavior of a BehavioredClassifier or it can
        /// only be invoked by another Behavior of the Classifier.
        /// </summary>
        [Property(xmiId: "Behavior-specification", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IBehavioralFeature Specification { get; set; }

        /// <summary>
        /// References the Behavior that this Behavior redefines. A subtype of Behavior may redefine any other
        /// subtype of Behavior. If the Behavior implements a BehavioralFeature, it replaces the redefined
        /// Behavior. If the Behavior is a classifierBehavior, it extends the redefined Behavior.
        /// </summary>
        [Property(xmiId: "Behavior-redefinedBehavior", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-redefinedClassifier")]
        public List<IBehavior> RedefinedBehavior { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
