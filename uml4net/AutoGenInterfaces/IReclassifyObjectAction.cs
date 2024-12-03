// -------------------------------------------------------------------------------------------------
// <copyright file="IReclassifyObjectAction.cs" company="Starion Group S.A.">
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

namespace uml4net.Actions
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
    /// A ReclassifyObjectAction is an Action that changes the Classifiers that classify an object.
    /// </summary>
    [Class(xmiId: "ReclassifyObjectAction", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IReclassifyObjectAction : IAction
    {
        /// <summary>
        /// Specifies whether existing Classifiers should be removed before adding the new Classifiers.
        /// </summary>
        [Property(xmiId: "ReclassifyObjectAction-isReplaceAll", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsReplaceAll { get; set; }

        /// <summary>
        /// A set of Classifiers to be added to the Classifiers of the given object.
        /// </summary>
        [Property(xmiId: "ReclassifyObjectAction-newClassifier", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IClassifier> NewClassifier { get; set; }

        /// <summary>
        /// The InputPin that holds the object to be reclassified.
        /// </summary>
        [Property(xmiId: "ReclassifyObjectAction-object", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Action-input")]
        public IContainerList<IInputPin> Object { get; set; }

        /// <summary>
        /// A set of Classifiers to be removed from the Classifiers of the given object.
        /// </summary>
        [Property(xmiId: "ReclassifyObjectAction-oldClassifier", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IClassifier> OldClassifier { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
