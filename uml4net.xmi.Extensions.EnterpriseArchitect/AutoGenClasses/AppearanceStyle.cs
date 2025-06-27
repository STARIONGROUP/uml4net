﻿// -------------------------------------------------------------------------------------------------
// <copyright file="AppearanceStyle.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_AF38C410_6082_A233_AF3A_A1B511006BA3", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4ne.extension", "latest")]
    public partial class AppearanceStyle : XmiElement, IAppearanceStyle
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
        [Property(xmiId: "EAID_9257C6A2_BAE6_D06A_B4A1_A4A18CD3035A", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAppearanceStyle.Appearance")]
        public string Appearance { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8B2175AE_70FD_7AD7_8F91_B2438AD2CCD4", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAppearanceStyle.ObjectStyle")]
        public string ObjectStyle { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_B3FA93E1_5876_0E6D_82D5_D50989ABDB2C", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAppearanceStyle.Styleex")]
        public string Styleex { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
