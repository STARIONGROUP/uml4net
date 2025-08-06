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
    public partial class LinksCollection : XmiElement, ILinksCollection
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
        [Property(xmiId: "EAID_srcC87A37_7100_4360_B75E_CCA9B591076A", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Abstraction")]
        public IContainerList<IAbstraction> Abstraction
        {
            get => this.abstraction ??= new ContainerList<IAbstraction>(this);
            set => this.abstraction = value;
        }

        /// <summary>
        /// Backing field for <see cref="Abstraction"/>
        /// </summary>
        private IContainerList<IAbstraction> abstraction;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src2794E4_E960_447a_A950_065B0BF699CA", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Aggregation")]
        public IContainerList<IAggregation> Aggregation
        {
            get => this.aggregation ??= new ContainerList<IAggregation>(this);
            set => this.aggregation = value;
        }

        /// <summary>
        /// Backing field for <see cref="Aggregation"/>
        /// </summary>
        private IContainerList<IAggregation> aggregation;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcECEA59_6A04_403b_8E82_09EF23BDA1DD", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Association")]
        public IContainerList<IAssociation> Association
        {
            get => this.association ??= new ContainerList<IAssociation>(this);
            set => this.association = value;
        }

        /// <summary>
        /// Backing field for <see cref="Association"/>
        /// </summary>
        private IContainerList<IAssociation> association;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src10B0FC_977C_46a6_8A0D_F548095B8526", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Dependency")]
        public IContainerList<IDependency> Dependency
        {
            get => this.dependency ??= new ContainerList<IDependency>(this);
            set => this.dependency = value;
        }

        /// <summary>
        /// Backing field for <see cref="Dependency"/>
        /// </summary>
        private IContainerList<IDependency> dependency;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src297E45_68BF_40e4_8686_F85EB6092677", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Generalization")]
        public IContainerList<IGeneralization> Generalization
        {
            get => this.generalization ??= new ContainerList<IGeneralization>(this);
            set => this.generalization = value;
        }

        /// <summary>
        /// Backing field for <see cref="Generalization"/>
        /// </summary>
        private IContainerList<IGeneralization> generalization;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcD57C83_8F6B_46d7_BB69_BD3460C8A307", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Nesting")]
        public IContainerList<INesting> Nesting
        {
            get => this.nesting ??= new ContainerList<INesting>(this);
            set => this.nesting = value;
        }

        /// <summary>
        /// Backing field for <see cref="Nesting"/>
        /// </summary>
        private IContainerList<INesting> nesting;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src651CB9_65AD_4e09_B0EA_2BB5E0A40F1D", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.NoteLink")]
        public IContainerList<INoteLink> NoteLink
        {
            get => this.noteLink ??= new ContainerList<INoteLink>(this);
            set => this.noteLink = value;
        }

        /// <summary>
        /// Backing field for <see cref="NoteLink"/>
        /// </summary>
        private IContainerList<INoteLink> noteLink;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7F468F_F87A_4661_BCE7_737B6A6C7413", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.Realisation")]
        public IContainerList<IRealisation> Realisation
        {
            get => this.realisation ??= new ContainerList<IRealisation>(this);
            set => this.realisation = value;
        }

        /// <summary>
        /// Backing field for <see cref="Realisation"/>
        /// </summary>
        private IContainerList<IRealisation> realisation;

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcA73D13_C0FB_445f_892D_AE9C6FF1BD6A", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ILinksCollection.TemplateBinding")]
        public IContainerList<ITemplateBinding> TemplateBinding
        {
            get => this.templateBinding ??= new ContainerList<ITemplateBinding>(this);
            set => this.templateBinding = value;
        }

        /// <summary>
        /// Backing field for <see cref="TemplateBinding"/>
        /// </summary>
        private IContainerList<ITemplateBinding> templateBinding;
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
