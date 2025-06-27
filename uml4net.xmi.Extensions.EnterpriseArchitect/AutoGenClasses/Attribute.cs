// -------------------------------------------------------------------------------------------------
// <copyright file="Attribute.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_870CACC6_A17B_C6C3_AD64_F76B06048FCB", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class Attribute : XmiElement, IAttribute
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
        [Property(xmiId: "EAID_src5BD6D4_9D95_079E_8E70_16C1A31B6BCD", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Bounds")]
        public IContainerList<IBounds> Bounds
        {
            get => this.bounds ??= new ContainerList<IBounds>(this);
            set => this.bounds = value;
        }

        /// <summary>
        /// Backing field for <see cref="Bounds"/>
        /// </summary>
        private IContainerList<IBounds> bounds;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src4ABB13_BEEC_A416_8920_41997B4B1E32", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Containment")]
        public IContainerList<IContainmentDefinition> Containment
        {
            get => this.containment ??= new ContainerList<IContainmentDefinition>(this);
            set => this.containment = value;
        }

        /// <summary>
        /// Backing field for <see cref="Containment"/>
        /// </summary>
        private IContainerList<IContainmentDefinition> containment;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7154C4_58F7_56F0_997B_A2123073BF5B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Coords")]
        public IContainerList<ICoords> Coords
        {
            get => this.coords ??= new ContainerList<ICoords>(this);
            set => this.coords = value;
        }

        /// <summary>
        /// Backing field for <see cref="Coords"/>
        /// </summary>
        private IContainerList<ICoords> coords;

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
        [Property(xmiId: "EAID_srcF13CE3_4C56_16B1_A3C5_75926914505A", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Initial")]
        public IContainerList<IInitial> Initial
        {
            get => this.initial ??= new ContainerList<IInitial>(this);
            set => this.initial = value;
        }

        /// <summary>
        /// Backing field for <see cref="Initial"/>
        /// </summary>
        private IContainerList<IInitial> initial;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcC44E53_7D93_D092_9C34_3C5EA96D2454", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Model")]
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
        [Property(xmiId: "EAID_src70555F_7980_C993_8F9C_CDC6D00833EA", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Options")]
        public IContainerList<IOptions> Options
        {
            get => this.options ??= new ContainerList<IOptions>(this);
            set => this.options = value;
        }

        /// <summary>
        /// Backing field for <see cref="Options"/>
        /// </summary>
        private IContainerList<IOptions> options;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src73DF29_17CC_1481_9634_1BC51E69191E", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Properties")]
        public IContainerList<IAttributeProperties> Properties
        {
            get => this.properties ??= new ContainerList<IAttributeProperties>(this);
            set => this.properties = value;
        }

        /// <summary>
        /// Backing field for <see cref="Properties"/>
        /// </summary>
        private IContainerList<IAttributeProperties> properties;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_BB9E7B06_4FA0_348F_B3D4_B9D203D90797", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IScopedElement.Scope")]
        public string Scope { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src1141E6_ECDD_A8D7_8E57_3333297C8C72", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Stereotype")]
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
        [Property(xmiId: "EAID_src2223C2_328E_D21A_AA28_25C32DDB7C78", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Style")]
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
        [Property(xmiId: "EAID_src7AE473_6DC4_D407_A4E2_401F485BB6D3", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Styleex")]
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
        [Property(xmiId: "EAID_src22B637_569D_3426_820B_AF6DB0AC932A", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Tags")]
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
        [Property(xmiId: "EAID_src5343FE_0640_DCEC_A1E0_DBCC78516780", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IAttribute.Xrefs")]
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
