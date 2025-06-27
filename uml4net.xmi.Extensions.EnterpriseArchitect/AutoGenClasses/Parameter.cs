// -------------------------------------------------------------------------------------------------
// <copyright file="Parameter.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_A6328F5F_8D23_924E_BA21_A2D627336B0E", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4ne.extension", "latest")]
    public partial class Parameter : XmiElement, IParameter
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
        [Property(xmiId: "EAID_src230EE9_E339_77F7_970D_B44227A264C0", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IParameter.Properties")]
        public IContainerList<IParameterProperties> Properties
        {
            get => this.properties ??= new ContainerList<IParameterProperties>(this);
            set => this.properties = value;
        }

        /// <summary>
        /// Backing field for <see cref="Properties"/>
        /// </summary>
        private IContainerList<IParameterProperties> properties;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcA36D9F_0F88_8FD8_9884_8A56CBB1646B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IParameter.Style")]
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
        [Property(xmiId: "EAID_src2BB311_640E_0B3D_A39C_92B9DEF95389", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IParameter.Styleex")]
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
        [Property(xmiId: "EAID_srcF8AABB_8F38_48EE_BFE4_81F857A57910", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IParameter.Tags")]
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
        [Property(xmiId: "EAID_B5D1BD91_BD20_7E32_BCBE_6980E3CB2CBB", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IParameter.Visibility")]
        public string Visibility { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcEF220F_8380_6BC4_A3BA_28B446A4EA82", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IParameter.Xrefs")]
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
