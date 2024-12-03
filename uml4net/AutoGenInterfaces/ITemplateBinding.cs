// -------------------------------------------------------------------------------------------------
// <copyright file="ITemplateBinding.cs" company="Starion Group S.A.">
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

namespace uml4net.CommonStructure
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
    /// A TemplateBinding is a DirectedRelationship between a TemplateableElement and a template. A
    /// TemplateBinding specifies the TemplateParameterSubstitutions of actual parameters for the formal
    /// parameters of the template.
    /// </summary>
    [Class(xmiId: "TemplateBinding", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface ITemplateBinding : IDirectedRelationship
    {
        /// <summary>
        /// The TemplateableElement that is bound by this TemplateBinding.
        /// </summary>
        [Property(xmiId: "TemplateBinding-boundElement", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-source")]
        [SubsettedProperty(propertyName: "Element-owner")]
        public ITemplateableElement BoundElement { get; set; }

        /// <summary>
        /// The TemplateParameterSubstitutions owned by this TemplateBinding.
        /// </summary>
        [Property(xmiId: "TemplateBinding-parameterSubstitution", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<ITemplateParameterSubstitution> ParameterSubstitution { get; set; }

        /// <summary>
        /// The TemplateSignature for the template that is the target of this TemplateBinding.
        /// </summary>
        [Property(xmiId: "TemplateBinding-signature", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-target")]
        public ITemplateSignature Signature { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
