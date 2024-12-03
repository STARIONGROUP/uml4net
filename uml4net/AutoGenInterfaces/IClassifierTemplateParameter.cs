// -------------------------------------------------------------------------------------------------
// <copyright file="IClassifierTemplateParameter.cs" company="Starion Group S.A.">
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
    /// A ClassifierTemplateParameter exposes a Classifier as a formal template parameter.
    /// </summary>
    [Class(xmiId: "ClassifierTemplateParameter", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IClassifierTemplateParameter : ITemplateParameter
    {
        /// <summary>
        /// Constrains the required relationship between an actual parameter and the parameteredElement for this
        /// formal parameter.
        /// </summary>
        [Property(xmiId: "ClassifierTemplateParameter-allowSubstitutable", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "true")]
        public bool AllowSubstitutable { get; set; }

        /// <summary>
        /// The classifiers that constrain the argument that can be used for the parameter. If the
        /// allowSubstitutable attribute is true, then any Classifier that is compatible with this constraining
        /// Classifier can be substituted; otherwise, it must be either this Classifier or one of its
        /// specializations. If this property is empty, there are no constraints on the Classifier that can be
        /// used as an argument.
        /// </summary>
        [Property(xmiId: "ClassifierTemplateParameter-constrainingClassifier", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IClassifier> ConstrainingClassifier { get; set; }

        /// <summary>
        /// The Classifier exposed by this ClassifierTemplateParameter.
        /// </summary>
        [Property(xmiId: "ClassifierTemplateParameter-parameteredElement", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "TemplateParameter-parameteredElement")]
        public new IClassifier ParameteredElement { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
