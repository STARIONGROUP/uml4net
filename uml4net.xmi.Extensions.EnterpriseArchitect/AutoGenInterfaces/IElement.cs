// -------------------------------------------------------------------------------------------------
// <copyright file="IElement.cs" company="Starion Group S.A.">
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
    using System;
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
    [Class(xmiId: "EAID_82D87274_FF2E_BDC4_BB27_B53181643B13", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IElement : IElementReference, IScopedElement, INamedElement, uml4net.CommonStructure.IElement
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src169A19_16E7_40cc_B4F5_304A9694039A", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IPaths> Paths { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src022177_9894_FD6B_8100_AA14F84A9D67", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IFlags> Flags { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcABC002_61B8_84B7_A09C_690662236345", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IExtendedProperties> ExtendedProperties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcEB4F08_CF0C_865B_A6DD_0BD6998A4795", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IXrefs> Xrefs { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src5633FA_CEB0_1407_AE1D_25C10B9F654B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IElementProperties> Properties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src024073_CC9E_3F8B_8105_B55861903707", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IPackageProperties> Packageproperties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src296286_E45E_47a2_A95E_850F51FB28EC", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ILinksCollection> Links { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src0190FB_C450_4753_9D96_D753A47A938C", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IOperations> Operations { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src9E8012_0CF1_807A_84A2_EDD1927A3348", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IProject> Project { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src423E98_7EFC_50D3_B556_5D67372DBB7E", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ITimes> Times { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcE6AF01_AA38_E470_A20E_73170E49ACD1", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IAppearanceStyle> Style { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src219605_045E_4605_ACE3_DEB203358D6F", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ICode> Code { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcFB13EF_6F86_4b26_8575_254200A6DEBF", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IAttributesCollection> Attributes { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcE7F2A0_AFE4_38DD_ACD0_C51ACA4C9A0E", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IModel> Model { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcEF615B_21A6_4929_AA2D_ECB583792236", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ITagsCollection> Tags { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
