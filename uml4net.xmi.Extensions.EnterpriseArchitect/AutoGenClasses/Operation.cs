// -------------------------------------------------------------------------------------------------
// <copyright file="Operation.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_BCC181A8_5A4A_BF36_B823_D804FCF18AEA", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4ne.extension", "latest")]
    public partial class Operation : XmiElement, IOperation
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
        [Property(xmiId: "EAID_srcF869B8_77B0_B827_8901_88C315314CAB", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Behaviour")]
        public IContainerList<IBehaviour> Behaviour
        {
            get => this.behaviour ??= new ContainerList<IBehaviour>(this);
            set => this.behaviour = value;
        }

        /// <summary>
        /// Backing field for <see cref="Behaviour"/>
        /// </summary>
        private IContainerList<IBehaviour> behaviour;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcAE30EC_D933_6804_A6E5_956AC537A188", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Code")]
        public IContainerList<ICode> Code
        {
            get => this.code ??= new ContainerList<ICode>(this);
            set => this.code = value;
        }

        /// <summary>
        /// Backing field for <see cref="Code"/>
        /// </summary>
        private IContainerList<ICode> code;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src54B7A4_2540_8975_AEE4_82E775F27BA5", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IDocumentedElement.Documentation")]
        public IContainerList<IDocumentation> Documentation
        {
            get => this.documentation ??= new ContainerList<IDocumentation>(this);
            set => this.documentation = value;
        }

        /// <summary>
        /// Backing field for <see cref="Documentation"/>
        /// </summary>
        private IContainerList<IDocumentation> documentation;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstF28C85_25C8_4727_B3FD_8F5AEA78232C", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElementReference.ExtendedElement")]
        public IXmiElement ExtendedElement { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcF7DA64_729F_95F3_82DE_A3F9E785FAC9", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Model")]
        public IContainerList<IModel> Model
        {
            get => this.model ??= new ContainerList<IModel>(this);
            set => this.model = value;
        }

        /// <summary>
        /// Backing field for <see cref="Model"/>
        /// </summary>
        private IContainerList<IModel> model;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8B42627D_1513_65E2_8B19_450CF0AF1923", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamedElement.Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7383AB_CC81_460a_B2A7_ECDCB713554F", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Parameters")]
        public IContainerList<IParametersCollection> Parameters
        {
            get => this.parameters ??= new ContainerList<IParametersCollection>(this);
            set => this.parameters = value;
        }

        /// <summary>
        /// Backing field for <see cref="Parameters"/>
        /// </summary>
        private IContainerList<IParametersCollection> parameters;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src0B7A84_B6A5_E500_82C0_8436217830FB", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Properties")]
        public IContainerList<IOperationProperties> Properties
        {
            get => this.properties ??= new ContainerList<IOperationProperties>(this);
            set => this.properties = value;
        }

        /// <summary>
        /// Backing field for <see cref="Properties"/>
        /// </summary>
        private IContainerList<IOperationProperties> properties;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_BB9E7B06_4FA0_348F_B3D4_B9D203D90797", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IScopedElement.Scope")]
        public string Scope { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcC4FE37_7709_8AFB_B613_6F5DFB33C18C", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Stereotype")]
        public IContainerList<IStereotypeDefinition> Stereotype
        {
            get => this.stereotype ??= new ContainerList<IStereotypeDefinition>(this);
            set => this.stereotype = value;
        }

        /// <summary>
        /// Backing field for <see cref="Stereotype"/>
        /// </summary>
        private IContainerList<IStereotypeDefinition> stereotype;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7CC3B5_842A_4CEF_89BB_626B2F8A6DC5", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Style")]
        public IContainerList<IStyle> Style
        {
            get => this.style ??= new ContainerList<IStyle>(this);
            set => this.style = value;
        }

        /// <summary>
        /// Backing field for <see cref="Style"/>
        /// </summary>
        private IContainerList<IStyle> style;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcB26D9A_9628_001F_B7E5_9DA6565F0338", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Styleex")]
        public IContainerList<IStyle> Styleex
        {
            get => this.styleex ??= new ContainerList<IStyle>(this);
            set => this.styleex = value;
        }

        /// <summary>
        /// Backing field for <see cref="Styleex"/>
        /// </summary>
        private IContainerList<IStyle> styleex;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src06CE26_9739_E0EB_83E0_937932D99CDA", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Tags")]
        public IContainerList<ITagsCollection> Tags
        {
            get => this.tags ??= new ContainerList<ITagsCollection>(this);
            set => this.tags = value;
        }

        /// <summary>
        /// Backing field for <see cref="Tags"/>
        /// </summary>
        private IContainerList<ITagsCollection> tags;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src874EE4_EE0F_CBF1_819F_75248B65176C", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Type")]
        public IContainerList<ITypeElement> Type
        {
            get => this.@type ??= new ContainerList<ITypeElement>(this);
            set => this.@type = value;
        }

        /// <summary>
        /// Backing field for <see cref="Type"/>
        /// </summary>
        private IContainerList<ITypeElement> @type;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcE2928D_20E7_AB24_A133_8AEF626AA658", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Xrefs")]
        public IContainerList<IXrefs> Xrefs
        {
            get => this.xrefs ??= new ContainerList<IXrefs>(this);
            set => this.xrefs = value;
        }

        /// <summary>
        /// Backing field for <see cref="Xrefs"/>
        /// </summary>
        private IContainerList<IXrefs> xrefs;
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
