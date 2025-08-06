// -------------------------------------------------------------------------------------------------
// <copyright file="IConnector.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EntrepriseArchitect.Structure
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
    /// </summary>
    [Class(xmiId: "EAID_AC4AB105_BB28_F334_9B5A_11B7E91D68BE", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IConnector : INamedElement, IDocumentedElement, IElementReference, uml4net.CommonStructure.IElement
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7B1C55_D1B1_4245_BCA4_E1AD2FEA033B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IModifiers> Modifiers { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcCDB14F_9286_7431_9FFC_165542344C6F", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IParameterSubstitutions> ParameterSubstitutions { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7ADDA0_DEB6_3D69_8184_60DA602C9139", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ITagsCollection> Tags { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src8F5DE8_C432_0C66_BD49_BFE407F59D4F", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IConnectorAppearance> Appearance { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src774A2E_6750_862F_AF88_ABCD8460AEAF", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IConnectorEnd> Target { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcE3A113_7D16_6765_8C32_5ACE0D30F0FE", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IXrefs> Xrefs { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcF568CB_7031_8742_B7C5_6EAB0B3F10A1", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IConnectorProperties> Properties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src6DD9D6_A0C0_3455_A4A2_F6B697D4A086", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IConnectorEnd> Source { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src874E62_E32F_C2F1_97A0_F5AA5EC8D5FC", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IModel> Model { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcE5F922_3930_166D_9D38_3B87457062DE", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IConnectorExtendedProperties> ExtendedProperties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src5DF87A_9163_FF34_9E70_26446DA1889B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ILabels> Labels { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcD5D1DA_C2B2_7D99_8F85_0A8833D27C3B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IStyle> Style { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
