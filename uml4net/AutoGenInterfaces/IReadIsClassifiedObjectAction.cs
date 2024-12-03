// -------------------------------------------------------------------------------------------------
// <copyright file="IReadIsClassifiedObjectAction.cs" company="Starion Group S.A.">
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
    /// A ReadIsClassifiedObjectAction is an Action that determines whether an object is classified by a
    /// given Classifier.
    /// </summary>
    [Class(xmiId: "ReadIsClassifiedObjectAction", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IReadIsClassifiedObjectAction : IAction
    {
        /// <summary>
        /// The Classifier against which the classification of the input object is tested.
        /// </summary>
        [Property(xmiId: "ReadIsClassifiedObjectAction-classifier", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IClassifier Classifier { get; set; }

        /// <summary>
        /// Indicates whether the input object must be directly classified by the given Classifier or whether it
        /// may also be an instance of a specialization of the given Classifier.
        /// </summary>
        [Property(xmiId: "ReadIsClassifiedObjectAction-isDirect", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsDirect { get; set; }

        /// <summary>
        /// The InputPin that holds the object whose classification is to be tested.
        /// </summary>
        [Property(xmiId: "ReadIsClassifiedObjectAction-object", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Action-input")]
        public IContainerList<IInputPin> Object { get; set; }

        /// <summary>
        /// The OutputPin that holds the Boolean result of the test.
        /// </summary>
        [Property(xmiId: "ReadIsClassifiedObjectAction-result", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Action-output")]
        public IContainerList<IOutputPin> Result { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
