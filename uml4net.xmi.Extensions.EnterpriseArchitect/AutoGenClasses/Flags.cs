// -------------------------------------------------------------------------------------------------
// <copyright file="Flags.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
    using System.Linq;

    using uml4net.Decorators;
    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;

    /// <summary>
    /// </summary>
    [Class(xmiId: "EAID_A92FB636_A554_4539_81E0_5C253B991EA3", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class Flags : IFlags
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_936DF712_A32F_C3AD_8CAC_FEF51007D9B4", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [Implements(implementation: "IFlags.Batchsave")]
        public int Batchsave { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8802DD6D_3AA1_74C7_8FE4_9174445E39FC", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [Implements(implementation: "IFlags.Iscontrolled")]
        public int Iscontrolled { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_9F8B7E58_BCE4_24E6_9D3A_DD9761219FE3", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [Implements(implementation: "IFlags.Isprotected")]
        public int Isprotected { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_913C2666_AC91_E177_86E4_4F4CEEA159A5", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [Implements(implementation: "IFlags.Logxml")]
        public int Logxml { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8EF00D68_BC85_B9B8_BC96_A120EF05D78F", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [Implements(implementation: "IFlags.Usedtd")]
        public int Usedtd { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
