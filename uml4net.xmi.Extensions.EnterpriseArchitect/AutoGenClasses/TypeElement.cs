﻿// -------------------------------------------------------------------------------------------------
// <copyright file="TypeElement.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_9DC8F21C_64BB_1226_A3B8_9B797DD51D70", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class TypeElement : XmiElement, ITypeElement
    {
        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        public IContainerList<IComment> OwnedComment { get; set; }

        /// <summary>
        /// The Elements owned by this Element.
        /// </summary>
        public IContainerList<CommonStructure.IElement> OwnedElement { get; }

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        public CommonStructure.IElement Owner { get; }

        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public CommonStructure.IElement Possessor { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_A12A8C04_2847_1F58_A063_CC2A401CB048", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITypeElement.Concurrency")]
        public string Concurrency { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_9FF673C9_185B_3C59_B5B1_3913756102A1", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITypeElement.Const")]
        public bool Const { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_B3511E2F_5959_345B_B4A2_E74AE44A221A", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITypeElement.IsAbstract")]
        public bool IsAbstract { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8DFB0B4B_7B49_5854_AD96_B31C195760CE", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITypeElement.IsQuery")]
        public bool IsQuery { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_AB58EE7B_619F_45A5_9F44_62E501D49FF1", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITypeElement.Pure")]
        public int Pure { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_B041338B_B6D8_5FEB_9315_74106F314976", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITypeElement.Returnarray")]
        public int Returnarray { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_92DD8BF5_8B0E_75E6_9B3C_1194C94D2F36", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITypeElement.Static")]
        public bool Static { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_A260F4AF_3835_2365_8C46_B8A33ED6ACB7", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITypeElement.Stereotype")]
        public string Stereotype { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_BF684C24_FCF0_739A_ADA5_2E16C142CA3E", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITypeElement.Synchronised")]
        public int Synchronised { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_B16B2E86_5757_1401_A90C_9AA3A4F48615", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITypeElement.Type")]
        public string Type { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
