﻿// -------------------------------------------------------------------------------------------------
// <copyright file="PackageProperties.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_973CFC61_FBD4_5D0D_9143_3D8B4EDA8441", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class PackageProperties : XmiElement, IPackageProperties
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
        [Property(xmiId: "EAID_A29671D6_4561_E126_92EA_76947FBB7235", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IPackageProperties.Tpos")]
        public int Tpos { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_952D4DC0_E8FA_2CD2_91AD_ADA8F434530E", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IPackageProperties.Version")]
        public string Version { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
