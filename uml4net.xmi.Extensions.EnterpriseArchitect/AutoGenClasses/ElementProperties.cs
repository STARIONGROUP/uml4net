// -------------------------------------------------------------------------------------------------
// <copyright file="ElementProperties.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_B0F7E3F3_032E_000D_8270_F4E00131652E", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class ElementProperties : IElementProperties
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_92CBE5A3_FEC4_6705_AF7C_CA1E59AFDB30", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [Implements(implementation: "IElementProperties.Documentation")]
        public string Documentation { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8D2D9220_8EF8_3FD4_8C89_5F3579D77526", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [Implements(implementation: "IElementProperties.IsSpecification")]
        public bool IsSpecification { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_84CF5F45_4E1B_6DB0_821D_913DD5D4C16E", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [Implements(implementation: "IElementProperties.NType")]
        public int NType { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_BB9E7B06_4FA0_348F_B3D4_B9D203D90797", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [Implements(implementation: "IScopedElement.Scope")]
        public string Scope { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8E0EF71A_5224_DB89_8F76_86D07833872B", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [Implements(implementation: "IElementProperties.Stereotype")]
        public string Stereotype { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_9C77F8E1_87D7_2B27_BF43_F50012DD21A5", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [Implements(implementation: "IElementProperties.SType")]
        public string SType { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
