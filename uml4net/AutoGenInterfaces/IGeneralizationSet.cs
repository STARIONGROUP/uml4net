// -------------------------------------------------------------------------------------------------
// <copyright file="IGeneralizationSet.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
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
    /// A GeneralizationSet is a PackageableElement whose instances represent sets of Generalization
    /// relationships.
    /// </summary>
    [Class(xmiId: "GeneralizationSet", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IGeneralizationSet : IPackageableElement
    {
        /// <summary>
        /// Designates the instances of Generalization that are members of this GeneralizationSet.
        /// </summary>
        [Property(xmiId: "GeneralizationSet-generalization", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IGeneralization> Generalization { get; set; }

        /// <summary>
        /// Indicates (via the associated Generalizations) whether or not the set of specific Classifiers are
        /// covering for a particular general classifier. When isCovering is true, every instance of a
        /// particular general Classifier is also an instance of at least one of its specific Classifiers for
        /// the GeneralizationSet. When isCovering is false, there are one or more instances of the particular
        /// general Classifier that are not instances of at least one of its specific Classifiers defined for
        /// the GeneralizationSet.
        /// </summary>
        [Property(xmiId: "GeneralizationSet-isCovering", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsCovering { get; set; }

        /// <summary>
        /// Indicates whether or not the set of specific Classifiers in a Generalization relationship have
        /// instance in common. If isDisjoint is true, the specific Classifiers for a particular
        /// GeneralizationSet have no members in common; that is, their intersection is empty. If isDisjoint is
        /// false, the specific Classifiers in a particular GeneralizationSet have one or more members in
        /// common; that is, their intersection is not empty.
        /// </summary>
        [Property(xmiId: "GeneralizationSet-isDisjoint", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsDisjoint { get; set; }

        /// <summary>
        /// Designates the Classifier that is defined as the power type for the associated GeneralizationSet, if
        /// there is one.
        /// </summary>
        [Property(xmiId: "GeneralizationSet-powertype", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IClassifier Powertype { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
