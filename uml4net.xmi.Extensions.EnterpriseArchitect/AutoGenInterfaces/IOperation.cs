// -------------------------------------------------------------------------------------------------
// <copyright file="IOperation.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_BCC181A8_5A4A_BF36_B823_D804FCF18AEA", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IOperation : INamedElement, IScopedElement, IDocumentedElement, IElementReference, uml4net.CommonStructure.IElement
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7383AB_CC81_460a_B2A7_ECDCB713554F", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IParametersCollection> Parameters { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7CC3B5_842A_4CEF_89BB_626B2F8A6DC5", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IStyle> Style { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcE2928D_20E7_AB24_A133_8AEF626AA658", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IXrefs> Xrefs { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src874EE4_EE0F_CBF1_819F_75248B65176C", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ITypeElement> Type { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcC4FE37_7709_8AFB_B613_6F5DFB33C18C", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IStereotypeDefinition> Stereotype { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcB26D9A_9628_001F_B7E5_9DA6565F0338", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IStyle> Styleex { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcAE30EC_D933_6804_A6E5_956AC537A188", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ICode> Code { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcF7DA64_729F_95F3_82DE_A3F9E785FAC9", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IModel> Model { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcF869B8_77B0_B827_8901_88C315314CAB", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IBehaviour> Behaviour { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src0B7A84_B6A5_E500_82C0_8436217830FB", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IOperationProperties> Properties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src06CE26_9739_E0EB_83E0_937932D99CDA", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ITagsCollection> Tags { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
