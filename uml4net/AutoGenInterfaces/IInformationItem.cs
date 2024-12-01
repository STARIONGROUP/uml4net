// -------------------------------------------------------------------------------------------------
// <copyright file="IInformationItem.cs" company="Starion Group S.A.">
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

namespace uml4net.InformationFlows
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
    /// InformationItems represent many kinds of information that can flow from sources to targets in very
    /// abstract ways.  They represent the kinds of information that may move within a system, but do not
    /// elaborate details of the transferred information.  Details of transferred information are the
    /// province of other Classifiers that may ultimately define InformationItems.  Consequently,
    /// InformationItems cannot be instantiated and do not themselves have features, generalizations, or
    /// associations. An important use of InformationItems is to represent information during early design
    /// stages, possibly before the detailed modeling decisions that will ultimately define them have been
    /// made. Another purpose of InformationItems is to abstract portions of complex models in less precise,
    /// but perhaps more general and communicable, ways.
    /// </summary>
    [Class(xmiId: "InformationItem", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IInformationItem : IClassifier
    {
        /// <summary>
        /// Determines the classifiers that will specify the structure and nature of the information. An
        /// information item represents all its represented classifiers.
        /// </summary>
        [Property(xmiId: "InformationItem-represented", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IClassifier> Represented { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------