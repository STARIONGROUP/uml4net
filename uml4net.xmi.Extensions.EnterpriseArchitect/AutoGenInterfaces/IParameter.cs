// -------------------------------------------------------------------------------------------------
// <copyright file="IParameter.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_A6328F5F_8D23_924E_BA21_A2D627336B0E", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IParameter : IDocumentedElement, IElementReference, uml4net.CommonStructure.IElement
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_B5D1BD91_BD20_7E32_BCBE_6980E3CB2CBB", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public string Visibility { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcA36D9F_0F88_8FD8_9884_8A56CBB1646B", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IStyle> Style { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcF8AABB_8F38_48EE_BFE4_81F857A57910", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<ITagsCollection> Tags { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcEF220F_8380_6BC4_A3BA_28B446A4EA82", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IXrefs> Xrefs { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src230EE9_E339_77F7_970D_B44227A264C0", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IParameterProperties> Properties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src2BB311_640E_0B3D_A39C_92B9DEF95389", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IContainerList<IStyle> Styleex { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
