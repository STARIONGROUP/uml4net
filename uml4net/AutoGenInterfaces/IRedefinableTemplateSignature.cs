// -------------------------------------------------------------------------------------------------
// <copyright file="IRedefinableTemplateSignature.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
    /// A RedefinableTemplateSignature supports the addition of formal template parameters in a
    /// specialization of a template classifier.
    /// </summary>
    [Class(xmiId: "RedefinableTemplateSignature", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IRedefinableTemplateSignature : IRedefinableElement, ITemplateSignature
    {
        /// <summary>
        /// The Classifier that owns this RedefinableTemplateSignature.
        /// </summary>
        [Property(xmiId: "RedefinableTemplateSignature-classifier", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinitionContext")]
        [RedefinedProperty(propertyName: "TemplateSignature-template")]
        public new IClassifier Classifier { get; set; }

        /// <summary>
        /// The signatures extended by this RedefinableTemplateSignature.
        /// </summary>
        [Property(xmiId: "RedefinableTemplateSignature-extendedSignature", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        public List<IRedefinableTemplateSignature> ExtendedSignature { get; set; }

        /// <summary>
        /// The formal template parameters of the extended signatures.
        /// </summary>
        [Property(xmiId: "RedefinableTemplateSignature-inheritedParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "TemplateSignature-parameter")]
        public IReadOnlyList<ITemplateParameter> InheritedParameter { get; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
