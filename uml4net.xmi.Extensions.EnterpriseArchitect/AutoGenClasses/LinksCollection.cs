// -------------------------------------------------------------------------------------------------
// <copyright file="LinksCollection.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_10315761_90A5_4510_9E09_A1BAF2E57137", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class LinksCollection : ILinksCollection
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcC87A37_7100_4360_B75E_CCA9B591076A", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Abstraction")]
        public List<IAbstraction> Abstraction { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src2794E4_E960_447a_A950_065B0BF699CA", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Aggregation")]
        public List<IAggregation> Aggregation { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcECEA59_6A04_403b_8E82_09EF23BDA1DD", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Association")]
        public List<IAssociation> Association { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src10B0FC_977C_46a6_8A0D_F548095B8526", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Dependency")]
        public List<IDependency> Dependency { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src297E45_68BF_40e4_8686_F85EB6092677", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Generalization")]
        public List<IGeneralization> Generalization { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcD57C83_8F6B_46d7_BB69_BD3460C8A307", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Nesting")]
        public List<INesting> Nesting { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src651CB9_65AD_4e09_B0EA_2BB5E0A40F1D", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.NoteLink")]
        public List<INoteLink> NoteLink { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7F468F_F87A_4661_BCE7_737B6A6C7413", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Realisation")]
        public List<IRealisation> Realisation { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcA73D13_C0FB_445f_892D_AE9C6FF1BD6A", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.TemplateBinding")]
        public List<ITemplateBinding> TemplateBinding { get; set; } = new();
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
