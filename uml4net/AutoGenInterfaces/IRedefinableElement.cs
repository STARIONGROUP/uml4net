// -------------------------------------------------------------------------------------------------
// <copyright file="IRedefinableElement.cs" company="Starion Group S.A.">
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

    using uml4net.Utils;

    /// <summary>
    /// A RedefinableElement is an element that, when defined in the context of a Classifier, can be
    /// redefined more specifically or differently in the context of another Classifier that specializes
    /// (directly or indirectly) the context Classifier.
    /// </summary>
    [Class(xmiId: "RedefinableElement", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IRedefinableElement : INamedElement
    {
        /// <summary>
        /// Indicates whether it is possible to further redefine a RedefinableElement. If the value is true,
        /// then it is not possible to further redefine the RedefinableElement.
        /// </summary>
        [Property(xmiId: "RedefinableElement-isLeaf", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsLeaf { get; set; }

        /// <summary>
        /// The RedefinableElement that is being redefined by this element.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinedElement", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        public List<IRedefinableElement> RedefinedElement { get; }

        /// <summary>
        /// The contexts that this element may be redefined from.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinitionContext", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        public List<IClassifier> RedefinitionContext { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
