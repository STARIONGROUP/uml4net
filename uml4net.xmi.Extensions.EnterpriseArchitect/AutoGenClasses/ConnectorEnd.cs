// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorEnd.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_80AD1F93_B9D1_8742_BAEE_4732F4BCF72B", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class ConnectorEnd : XmiElement, IConnectorEnd
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
        [Property(xmiId: "EAID_src1B8EF2_CA40_412A_9040_37B3DFF453E1", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Constraints")]
        public IContainerList<IConstraints> Constraints
        {
            get => this.constraints ??= new ContainerList<IConstraints>(this);
            set => this.constraints = value;
        }

        /// <summary>
        /// Backing field for <see cref="Constraints"/>
        /// </summary>
        private IContainerList<IConstraints> constraints;

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
        [Property(xmiId: "EAID_srcCD812D_9C77_03EE_A658_B148DC3D0C27", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Model")]
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
        [Property(xmiId: "EAID_src622164_C256_D3B6_A45A_ADB28EF4503E", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Modifiers")]
        public IContainerList<IModifiers> Modifiers
        {
            get => this.modifiers ??= new ContainerList<IModifiers>(this);
            set => this.modifiers = value;
        }

        /// <summary>
        /// Backing field for <see cref="Modifiers"/>
        /// </summary>
        private IContainerList<IModifiers> modifiers;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src26F873_298D_C17A_A9A0_ECC4C96BEFD6", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Role")]
        public IContainerList<IRole> Role
        {
            get => this.role ??= new ContainerList<IRole>(this);
            set => this.role = value;
        }

        /// <summary>
        /// Backing field for <see cref="Role"/>
        /// </summary>
        private IContainerList<IRole> role;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcF86C1F_7AB7_F024_A19D_7FDC7AFACC87", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Style")]
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
        [Property(xmiId: "EAID_srcAAE1BD_4327_5F48_A3FC_69310C0E53C2", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Tags")]
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
        [Property(xmiId: "EAID_srcDBBDF2_31FB_BC9D_8681_95DDEEAB31F8", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Type")]
        public IContainerList<IConnectorEndType> Type
        {
            get => this.@type ??= new ContainerList<IConnectorEndType>(this);
            set => this.@type = value;
        }

        /// <summary>
        /// Backing field for <see cref="Type"/>
        /// </summary>
        private IContainerList<IConnectorEndType> @type;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src2E56AD_D1F9_0C44_AB53_DB2A78AC44C1", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorEnd.Xrefs")]
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
