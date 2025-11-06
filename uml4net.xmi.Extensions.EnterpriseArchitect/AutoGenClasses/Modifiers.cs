// -------------------------------------------------------------------------------------------------
// <copyright file="Modifiers.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_9A77EDA5_7281_7710_8D8D_052718193203", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class Modifiers : IModifiers
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_B0D62129_1FFA_BDF1_A367_1E184A6DEABF", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IModifiers.Changeable")]
        public string Changeable { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_98BBF0FD_A0B3_A1DF_BF69_01795076F956", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IModifiers.IsLeaf")]
        public bool IsLeaf { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8369BBC3_8058_9EB2_9DC1_A1A5F1F4229E", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IModifiers.IsNavigable")]
        public bool IsNavigable { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_BA967E6C_951B_FBC2_A730_BB533A38A97E", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IModifiers.IsOrdered")]
        public bool IsOrdered { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_ADB7BE3F_29E0_AE19_ABC0_6CF8DA7F53FD", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IModifiers.IsRoot")]
        public bool IsRoot { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
