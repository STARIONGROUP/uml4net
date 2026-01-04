// -------------------------------------------------------------------------------------------------
// <copyright file="IElement.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Structure
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
    [Class(xmiId: "EAID_82D87274_FF2E_BDC4_BB27_B53181643B13", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IElement : IElementReference, IScopedElement, INamedElement
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst3FA8D5_D7AE_478c_941B_0723A9E89733", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IXrefs Xrefs { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst3B33EA_B85C_40d4_90C6_B04628F6286B", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public ITimes Times { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst3D94E9_3148_4281_BBE8_DD654F8025B4", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IModel Model { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstECD2A0_E810_4a8e_B871_CDEB518FEFE6", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IProject Project { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst836134_24AA_4c56_B6F0_A1F9A6CB3E60", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IElementProperties Properties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst304E53_23CA_4582_AFFB_E75F8D867890", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public ICode Code { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst9B0CF5_4300_4160_9767_F0AC68C46A6A", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IFlags Flags { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstB766CB_26E9_4f63_BC14_997AA16FA576", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IAppearanceStyle Style { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstCA925D_1586_4f1a_BCC3_1339062E56E6", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IPackageProperties Packageproperties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst480030_0BC2_40fd_8766_854E8C7A5249", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IExtendedProperties ExtendedProperties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src5F83C7_DC08_48bb_A217_C957D9403925", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IPath> Paths { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcD6C61F_DECE_464f_A46E_D99E60EE87E1", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<ILink> Links { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcF0988F_3B4F_4db7_890E_F96F32C4DC24", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<ITag> Tags { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src0190FB_C450_4753_9D96_D753A47A938C", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IOperation> Operations { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcFB13EF_6F86_4b26_8575_254200A6DEBF", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IAttribute> Attributes { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src50F7AD_5DFF_40c4_B473_232336BF3E8D", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IParameter> TemplateParameters { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
