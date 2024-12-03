// -------------------------------------------------------------------------------------------------
// <copyright file="ITemplateableElement.cs" company="Starion Group S.A.">
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
    /// A TemplateableElement is an Element that can optionally be defined as a template and bound to other
    /// templates.
    /// </summary>
    [Class(xmiId: "TemplateableElement", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    public partial interface ITemplateableElement : IElement
    {
        /// <summary>
        /// The optional TemplateSignature specifying the formal TemplateParameters for this
        /// TemplateableElement. If a TemplateableElement has a TemplateSignature, then it is a template.
        /// </summary>
        [Property(xmiId: "TemplateableElement-ownedTemplateSignature", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<ITemplateSignature> OwnedTemplateSignature { get; set; }

        /// <summary>
        /// The optional TemplateBindings from this TemplateableElement to one or more templates.
        /// </summary>
        [Property(xmiId: "TemplateableElement-templateBinding", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<ITemplateBinding> TemplateBinding { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
