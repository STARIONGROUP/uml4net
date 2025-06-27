// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorAppearance.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_A5066505_F183_3250_8F99_8C05F5C538A2", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class ConnectorAppearance : XmiElement, IConnectorAppearance
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
        [Property(xmiId: "EAID_888C4FC6_792E_6E52_B798_AF587726AF7F", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorAppearance.HeadStyle")]
        public int HeadStyle { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_B9427A0B_30AB_1CCE_AD79_5E467FC7DBAF", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorAppearance.Linecolor")]
        public int Linecolor { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_BF5428A7_C57B_B077_B03C_B598DAFB4E8D", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorAppearance.Linemode")]
        public int Linemode { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8F6BE956_22D8_5710_94C2_08D623872415", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorAppearance.LineStyle")]
        public int LineStyle { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_BA15F662_B057_A733_931B_214B3558F7E2", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorAppearance.Linewidth")]
        public int Linewidth { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_842F2461_4204_6461_BF4D_1EC415AAAC08", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorAppearance.Seqno")]
        public int Seqno { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
