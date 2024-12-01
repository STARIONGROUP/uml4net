// -------------------------------------------------------------------------------------------------
// <copyright file="IGeneralization.cs" company="Starion Group S.A.">
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
    /// A Generalization is a taxonomic relationship between a more general Classifier and a more specific
    /// Classifier. Each instance of the specific Classifier is also an instance of the general Classifier.
    /// The specific Classifier inherits the features of the more general Classifier. A Generalization is
    /// owned by the specific Classifier.
    /// </summary>
    [Class(xmiId: "Generalization", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IGeneralization : IDirectedRelationship
    {
        /// <summary>
        /// The general classifier in the Generalization relationship.
        /// </summary>
        [Property(xmiId: "Generalization-general", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-target")]
        public IClassifier General { get; set; }

        /// <summary>
        /// Represents a set of instances of Generalization.  A Generalization may appear in many
        /// GeneralizationSets.
        /// </summary>
        [Property(xmiId: "Generalization-generalizationSet", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IGeneralizationSet> GeneralizationSet { get; set; }

        /// <summary>
        /// Indicates whether the specific Classifier can be used wherever the general Classifier can be used.
        /// If true, the execution traces of the specific Classifier shall be a superset of the execution traces
        /// of the general Classifier. If false, there is no such constraint on execution traces. If unset, the
        /// modeler has not stated whether there is such a constraint or not.
        /// </summary>
        [Property(xmiId: "Generalization-isSubstitutable", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "true")]
        public bool IsSubstitutable { get; set; }

        /// <summary>
        /// The specializing Classifier in the Generalization relationship.
        /// </summary>
        [Property(xmiId: "Generalization-specific", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-source")]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IClassifier Specific { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------