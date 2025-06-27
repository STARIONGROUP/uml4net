// -------------------------------------------------------------------------------------------------
// <copyright file="Element.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_82D87274_FF2E_BDC4_BB27_B53181643B13", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class Element : XmiElement, IElement
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
        [Property(xmiId: "EAID_srcFB13EF_6F86_4b26_8575_254200A6DEBF", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Attributes")]
        public IContainerList<IAttributesCollection> Attributes
        {
            get => this.attributes ??= new ContainerList<IAttributesCollection>(this);
            set => this.attributes = value;
        }

        /// <summary>
        /// Backing field for <see cref="Attributes"/>
        /// </summary>
        private IContainerList<IAttributesCollection> attributes;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src219605_045E_4605_ACE3_DEB203358D6F", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Code")]
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
        [Property(xmiId: "EAID_dstF28C85_25C8_4727_B3FD_8F5AEA78232C", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElementReference.ExtendedElement")]
        public IXmiElement ExtendedElement { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcABC002_61B8_84B7_A09C_690662236345", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.ExtendedProperties")]
        public IContainerList<IExtendedProperties> ExtendedProperties
        {
            get => this.extendedProperties ??= new ContainerList<IExtendedProperties>(this);
            set => this.extendedProperties = value;
        }

        /// <summary>
        /// Backing field for <see cref="ExtendedProperties"/>
        /// </summary>
        private IContainerList<IExtendedProperties> extendedProperties;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src022177_9894_FD6B_8100_AA14F84A9D67", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Flags")]
        public IContainerList<IFlags> Flags
        {
            get => this.flags ??= new ContainerList<IFlags>(this);
            set => this.flags = value;
        }

        /// <summary>
        /// Backing field for <see cref="Flags"/>
        /// </summary>
        private IContainerList<IFlags> flags;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src296286_E45E_47a2_A95E_850F51FB28EC", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Links")]
        public IContainerList<ILinksCollection> Links
        {
            get => this.links ??= new ContainerList<ILinksCollection>(this);
            set => this.links = value;
        }

        /// <summary>
        /// Backing field for <see cref="Links"/>
        /// </summary>
        private IContainerList<ILinksCollection> links;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcE7F2A0_AFE4_38DD_ACD0_C51ACA4C9A0E", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Model")]
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
        [Property(xmiId: "EAID_src0190FB_C450_4753_9D96_D753A47A938C", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Operations")]
        public IContainerList<IOperations> Operations
        {
            get => this.operations ??= new ContainerList<IOperations>(this);
            set => this.operations = value;
        }

        /// <summary>
        /// Backing field for <see cref="Operations"/>
        /// </summary>
        private IContainerList<IOperations> operations;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src024073_CC9E_3F8B_8105_B55861903707", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Packageproperties")]
        public IContainerList<IPackageProperties> Packageproperties
        {
            get => this.packageproperties ??= new ContainerList<IPackageProperties>(this);
            set => this.packageproperties = value;
        }

        /// <summary>
        /// Backing field for <see cref="Packageproperties"/>
        /// </summary>
        private IContainerList<IPackageProperties> packageproperties;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src169A19_16E7_40cc_B4F5_304A9694039A", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Paths")]
        public IContainerList<IPaths> Paths
        {
            get => this.paths ??= new ContainerList<IPaths>(this);
            set => this.paths = value;
        }

        /// <summary>
        /// Backing field for <see cref="Paths"/>
        /// </summary>
        private IContainerList<IPaths> paths;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src9E8012_0CF1_807A_84A2_EDD1927A3348", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Project")]
        public IContainerList<IProject> Project
        {
            get => this.project ??= new ContainerList<IProject>(this);
            set => this.project = value;
        }

        /// <summary>
        /// Backing field for <see cref="Project"/>
        /// </summary>
        private IContainerList<IProject> project;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src5633FA_CEB0_1407_AE1D_25C10B9F654B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Properties")]
        public IContainerList<IElementProperties> Properties
        {
            get => this.properties ??= new ContainerList<IElementProperties>(this);
            set => this.properties = value;
        }

        /// <summary>
        /// Backing field for <see cref="Properties"/>
        /// </summary>
        private IContainerList<IElementProperties> properties;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_BB9E7B06_4FA0_348F_B3D4_B9D203D90797", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IScopedElement.Scope")]
        public string Scope { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcE6AF01_AA38_E470_A20E_73170E49ACD1", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Style")]
        public IContainerList<IAppearanceStyle> Style
        {
            get => this.style ??= new ContainerList<IAppearanceStyle>(this);
            set => this.style = value;
        }

        /// <summary>
        /// Backing field for <see cref="Style"/>
        /// </summary>
        private IContainerList<IAppearanceStyle> style;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcEF615B_21A6_4929_AA2D_ECB583792236", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Tags")]
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
        [Property(xmiId: "EAID_src423E98_7EFC_50D3_B556_5D67372DBB7E", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Times")]
        public IContainerList<ITimes> Times
        {
            get => this.times ??= new ContainerList<ITimes>(this);
            set => this.times = value;
        }

        /// <summary>
        /// Backing field for <see cref="Times"/>
        /// </summary>
        private IContainerList<ITimes> times;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcEB4F08_CF0C_865B_A6DD_0BD6998A4795", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Xrefs")]
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
