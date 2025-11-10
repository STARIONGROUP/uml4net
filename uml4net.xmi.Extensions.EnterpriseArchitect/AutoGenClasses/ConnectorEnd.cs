// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorEnd.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Structure
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
    [Class(xmiId: "EAID_80AD1F93_B9D1_8742_BAEE_4732F4BCF72B", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class ConnectorEnd : IConnectorEnd
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstEF3962_4B00_497a_BBE7_FCF19B763CBA", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Constraints")]
        public IConstraints Constraints { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstFF2578_3AE2_4c11_997D_0158FD3C5A82", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IDocumentedElement.Documentation")]
        public IDocumentation Documentation { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstF28C85_25C8_4727_B3FD_8F5AEA78232C", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElementReference.ExtendedElement")]
        public IXmiElement ExtendedElement { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst4756CD_56B6_4b4f_850C_B8B6E25E12D2", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Model")]
        public IModel Model { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstC7A80C_9DE4_4268_AC64_361EABA632C0", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Modifiers")]
        public IModifiers Modifiers { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst655D69_3157_43d6_A67F_26C7BE73839C", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Role")]
        public IRole Role { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstB40348_50AB_4b8c_9235_DE854F2B8DBD", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Style")]
        public IStyle Style { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src25771C_307D_4f20_A087_D533AE803601", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Tags")]
        public List<ITag> Tags { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst792341_9FB5_4044_9470_BFB3E8B5F5C7", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Type")]
        public IConnectorEndType Type { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst746170_9D4A_4939_98AD_E933E1834FFD", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Xrefs")]
        public IXrefs Xrefs { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
