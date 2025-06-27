// -------------------------------------------------------------------------------------------------
// <copyright file="Connector.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_AC4AB105_BB28_F334_9B5A_11B7E91D68BE", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class Connector : XmiElement, IConnector
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
        [Property(xmiId: "EAID_src8F5DE8_C432_0C66_BD49_BFE407F59D4F", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.Appearance")]
        public IContainerList<IConnectorAppearance> Appearance
        {
            get => this.appearance ??= new ContainerList<IConnectorAppearance>(this);
            set => this.appearance = value;
        }

        /// <summary>
        /// Backing field for <see cref="Appearance"/>
        /// </summary>
        private IContainerList<IConnectorAppearance> appearance;

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
        [Property(xmiId: "EAID_srcE5F922_3930_166D_9D38_3B87457062DE", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.ExtendedProperties")]
        public IContainerList<IConnectorExtendedProperties> ExtendedProperties
        {
            get => this.extendedProperties ??= new ContainerList<IConnectorExtendedProperties>(this);
            set => this.extendedProperties = value;
        }

        /// <summary>
        /// Backing field for <see cref="ExtendedProperties"/>
        /// </summary>
        private IContainerList<IConnectorExtendedProperties> extendedProperties;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src5DF87A_9163_FF34_9E70_26446DA1889B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.Labels")]
        public IContainerList<ILabels> Labels
        {
            get => this.labels ??= new ContainerList<ILabels>(this);
            set => this.labels = value;
        }

        /// <summary>
        /// Backing field for <see cref="Labels"/>
        /// </summary>
        private IContainerList<ILabels> labels;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src874E62_E32F_C2F1_97A0_F5AA5EC8D5FC", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.Model")]
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
        [Property(xmiId: "EAID_src7B1C55_D1B1_4245_BCA4_E1AD2FEA033B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.Modifiers")]
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
        [Property(xmiId: "EAID_8B42627D_1513_65E2_8B19_450CF0AF1923", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamedElement.Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcCDB14F_9286_7431_9FFC_165542344C6F", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.ParameterSubstitutions")]
        public IContainerList<IParameterSubstitutions> ParameterSubstitutions
        {
            get => this.parameterSubstitutions ??= new ContainerList<IParameterSubstitutions>(this);
            set => this.parameterSubstitutions = value;
        }

        /// <summary>
        /// Backing field for <see cref="ParameterSubstitutions"/>
        /// </summary>
        private IContainerList<IParameterSubstitutions> parameterSubstitutions;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcF568CB_7031_8742_B7C5_6EAB0B3F10A1", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.Properties")]
        public IContainerList<IConnectorProperties> Properties
        {
            get => this.properties ??= new ContainerList<IConnectorProperties>(this);
            set => this.properties = value;
        }

        /// <summary>
        /// Backing field for <see cref="Properties"/>
        /// </summary>
        private IContainerList<IConnectorProperties> properties;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src6DD9D6_A0C0_3455_A4A2_F6B697D4A086", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.Source")]
        public IContainerList<IConnectorEnd> Source
        {
            get => this.source ??= new ContainerList<IConnectorEnd>(this);
            set => this.source = value;
        }

        /// <summary>
        /// Backing field for <see cref="Source"/>
        /// </summary>
        private IContainerList<IConnectorEnd> source;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcD5D1DA_C2B2_7D99_8F85_0A8833D27C3B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.Style")]
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
        [Property(xmiId: "EAID_src7ADDA0_DEB6_3D69_8184_60DA602C9139", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.Tags")]
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
        [Property(xmiId: "EAID_src774A2E_6750_862F_AF88_ABCD8460AEAF", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.Target")]
        public IContainerList<IConnectorEnd> Target
        {
            get => this.target ??= new ContainerList<IConnectorEnd>(this);
            set => this.target = value;
        }

        /// <summary>
        /// Backing field for <see cref="Target"/>
        /// </summary>
        private IContainerList<IConnectorEnd> target;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcE3A113_7D16_6765_8C32_5ACE0D30F0FE", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnector.Xrefs")]
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
