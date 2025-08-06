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

namespace uml4net.xmi.Extensions.EntrepriseArchitect.Structure
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
    public partial interface IAttribute : IElementReference, IScopedElement, IDocumentedElement, INamedElement, uml4net.CommonStructure.IElement
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src2223C2_328E_D21A_AA28_25C32DDB7C78", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IStyle> Style { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src5343FE_0640_DCEC_A1E0_DBCC78516780", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IXrefs> Xrefs { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcF13CE3_4C56_16B1_A3C5_75926914505A", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IInitial> Initial { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7154C4_58F7_56F0_997B_A2123073BF5B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ICoords> Coords { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7AE473_6DC4_D407_A4E2_401F485BB6D3", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IStyle> Styleex { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src5BD6D4_9D95_079E_8E70_16C1A31B6BCD", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IBounds> Bounds { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src4ABB13_BEEC_A416_8920_41997B4B1E32", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IContainmentDefinition> Containment { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcC44E53_7D93_D092_9C34_3C5EA96D2454", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IModel> Model { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src70555F_7980_C993_8F9C_CDC6D00833EA", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IOptions> Options { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src22B637_569D_3426_820B_AF6DB0AC932A", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ITagsCollection> Tags { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src73DF29_17CC_1481_9634_1BC51E69191E", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IAttributeProperties> Properties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src1141E6_ECDD_A8D7_8E57_3333297C8C72", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IStereotypeDefinition> Stereotype { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
