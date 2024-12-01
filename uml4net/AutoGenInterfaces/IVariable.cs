// -------------------------------------------------------------------------------------------------
// <copyright file="IVariable.cs" company="Starion Group S.A.">
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

namespace uml4net.Activities
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
    /// A Variable is a ConnectableElement that may store values during the execution of an Activity.
    /// Reading and writing the values of a Variable provides an alternative means for passing data than the
    /// use of ObjectFlows. A Variable may be owned directly by an Activity, in which case it is accessible
    /// from anywhere within that activity, or it may be owned by a StructuredActivityNode, in which case it
    /// is only accessible within that node.
    /// </summary>
    [Class(xmiId: "Variable", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IVariable : IConnectableElement, IMultiplicityElement
    {
        /// <summary>
        /// An Activity that owns the Variable.
        /// </summary>
        [Property(xmiId: "Variable-activityScope", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IActivity ActivityScope { get; set; }

        /// <summary>
        /// A StructuredActivityNode that owns the Variable.
        /// </summary>
        [Property(xmiId: "Variable-scope", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IStructuredActivityNode Scope { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------