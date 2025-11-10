// -------------------------------------------------------------------------------------------------
// <copyright file="IAttribute.cs" company="Starion Group S.A.">
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
    using System.CodeDom.Compiler;
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.InformationFlows;
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Values;

    /// <summary>
    /// </summary>
    [Class(xmiId: "EAID_870CACC6_A17B_C6C3_AD64_F76B06048FCB", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IAttribute : IElementReference, IScopedElement, IDocumentedElement, INamedElement
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst18973D_9FFB_4af6_9FC1_6214F62FC406", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IOptions Options { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstFD6776_7C0B_4023_9F8E_A43008113E57", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainmentDefinition Containment { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst239E18_49CF_4e3a_ABF1_32EAB43D2FF3", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IStereotypeDefinition Stereotype { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst23704B_6B6C_4a6c_A676_4879EF9C6E7F", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IStyle Styleex { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst96BF2D_F404_4fbc_A06E_4A217145AC51", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IAttributeProperties Properties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstF13CE3_4C56_16B1_A3C5_75926914505A", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IInitial Initial { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstC50028_FA8E_4ac9_B43A_A5F8A20AF4BD", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public ICoords Coords { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst64F67E_63E8_4cf6_B4A4_D678790C9B0E", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IModel Model { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstE3645F_70B8_459b_8526_A38F040DB3FA", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IStyle Style { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst8FAF9C_3FA3_4a43_934E_D2B9E1A9D3A1", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IBounds Bounds { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstB2DC6F_9356_49e2_8CF3_560D015D209F", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IXrefs Xrefs { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src603E99_0A6E_4b6a_B758_36DBCAA244EA", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<ITag> Tags { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
