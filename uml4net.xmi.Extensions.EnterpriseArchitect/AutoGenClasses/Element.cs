// -------------------------------------------------------------------------------------------------
// <copyright file="Element.cs" company="Starion Group S.A.">
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
    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;

    /// <summary>
    /// </summary>
    [Class(xmiId: "EAID_82D87274_FF2E_BDC4_BB27_B53181643B13", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class Element : IElement
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcFB13EF_6F86_4b26_8575_254200A6DEBF", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Attributes")]
        public IAttribute Attributes { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst304E53_23CA_4582_AFFB_E75F8D867890", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Code")]
        public ICode Code { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstF28C85_25C8_4727_B3FD_8F5AEA78232C", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElementReference.ExtendedElement")]
        public IXmiElement ExtendedElement { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst480030_0BC2_40fd_8766_854E8C7A5249", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.ExtendedProperties")]
        public IExtendedProperties ExtendedProperties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst9B0CF5_4300_4160_9767_F0AC68C46A6A", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Flags")]
        public IFlags Flags { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst37C619_C146_4dda_A797_3339A455EC44", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Links")]
        public ILinksCollection Links { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst3D94E9_3148_4281_BBE8_DD654F8025B4", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Model")]
        public IModel Model { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8B42627D_1513_65E2_8B19_450CF0AF1923", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamedElement.Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src0190FB_C450_4753_9D96_D753A47A938C", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Operations")]
        public List<IOperation> Operations { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstCA925D_1586_4f1a_BCC3_1339062E56E6", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Packageproperties")]
        public IPackageProperties Packageproperties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src5F83C7_DC08_48bb_A217_C957D9403925", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Paths")]
        public List<IPath> Paths { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstECD2A0_E810_4a8e_B871_CDEB518FEFE6", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Project")]
        public IProject Project { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst836134_24AA_4c56_B6F0_A1F9A6CB3E60", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Properties")]
        public IElementProperties Properties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_BB9E7B06_4FA0_348F_B3D4_B9D203D90797", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IScopedElement.Scope")]
        public string Scope { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstB766CB_26E9_4f63_BC14_997AA16FA576", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Style")]
        public IAppearanceStyle Style { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src50F7AD_5DFF_40c4_B473_232336BF3E8D", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.TemplateParameters")]
        public List<IParameter> TemplateParameters { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst3B33EA_B85C_40d4_90C6_B04628F6286B", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Times")]
        public ITimes Times { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst3FA8D5_D7AE_478c_941B_0723A9E89733", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Xrefs")]
        public IXrefs Xrefs { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
