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
    public partial interface IConnector : INamedElement, IDocumentedElement, IElementReference
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstBBBDCD_35B8_462e_8BC1_1E7CB013F15D", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IXrefs Xrefs { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst34DB56_A55A_4f71_B5C8_4DFD808B7441", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IConnectorEnd Source { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstB77511_776D_4dbe_9623_8D8F599773A4", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IStyle Style { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst3FA940_576A_4809_A957_97CE8C6B8F8D", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IConnectorExtendedProperties ExtendedProperties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstD41937_ECB3_41a9_A42A_814F918636B8", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IModifiers Modifiers { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst10D7C3_1BBD_40e2_8710_A97306CEE72D", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IConnectorProperties Properties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst94CB9A_FF08_4edc_9E53_9A79961A621A", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IConnectorEnd Target { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst395808_6C1E_4345_BDF9_64CDF5F0B3BF", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public ILabels Labels { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstF9B423_30F0_45c0_8505_F52A4A619D04", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IConnectorAppearance Appearance { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstF39F74_071D_4fa7_B762_4DD4A2F4036E", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IModel Model { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src3D420D_48BC_47a5_8470_94A1A668ADA2", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<ITag> Tags { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcCDB14F_9286_7431_9FFC_165542344C6F", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IParameterSubstitution> ParameterSubstitutions { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
