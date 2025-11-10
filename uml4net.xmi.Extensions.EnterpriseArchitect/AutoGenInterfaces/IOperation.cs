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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Structure
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
    public partial interface IOperation : INamedElement, IScopedElement, IDocumentedElement, IElementReference
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst80BDCF_67DE_46ee_9574_4D1B668B3549", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IStyle Styleex { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst9D9CDC_97D3_402f_95B5_82278388E7B1", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IModel Model { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst8336A1_8C12_4891_B35F_ECF03A7C9E87", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public ITypeElement Type { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst512655_73D9_401d_B0CD_FE76A46F873E", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IBehaviour Behaviour { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst4836B1_ED36_4e0f_925D_C5A85F7AEC34", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public ICode Code { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst047BAC_0761_4e7e_B670_513411918814", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IStyle Style { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstFCB4EF_78DF_4d7e_BCCF_650A1CBE8710", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IStereotypeDefinition Stereotype { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst212952_F236_455f_936D_8CC86235A031", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IXrefs Xrefs { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstED051A_842E_40fa_91C4_FB3BEFE3FEA4", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IOperationProperties Properties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcFDB579_D278_43f5_877D_DBCF2ED71E9B", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<ITag> Tags { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7383AB_CC81_460a_B2A7_ECDCB713554F", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IParameter> Parameters { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
