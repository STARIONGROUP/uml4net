// -------------------------------------------------------------------------------------------------
// <copyright file="AttributeProperties.cs" company="Starion Group S.A.">
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
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;

    /// <summary>
    /// </summary>
    [Class(xmiId: "EAID_84011D7B_493E_CCC3_85C0_76F44DA4535E", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class AttributeProperties : IAttributeProperties
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_9CF2D82B_6F7E_8BBE_B4B3_92CC59B651C5", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttributeProperties.Changeability")]
        public string Changeability { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_912B5D98_1122_02AC_951B_C2A0F39F80ED", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttributeProperties.Collection")]
        public bool Collection { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_9DFFE3D0_20E9_0247_AE98_6D60571F4EA1", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttributeProperties.Derived")]
        public int Derived { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_81C10435_DDE2_36F0_9B04_7D86B39C1F0E", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttributeProperties.Duplicates")]
        public int Duplicates { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_B7FF1EE7_E2D6_42D3_86E5_AC0BBF660152", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttributeProperties.Length")]
        public int Length { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_A4E0B7D0_AD79_5402_A1AF_032EA06C961D", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttributeProperties.Precision")]
        public int Precision { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_846E874D_51C8_DCA8_9701_22240E62DD0C", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttributeProperties.Static")]
        public int Static { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_9C45849C_8E96_4578_A6BE_4FFD9EBCB9AF", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttributeProperties.Type")]
        public string Type { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
