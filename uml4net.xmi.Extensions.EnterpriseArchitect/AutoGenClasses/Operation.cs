// -------------------------------------------------------------------------------------------------
// <copyright file="Operation.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class Operation : IOperation
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst512655_73D9_401d_B0CD_FE76A46F873E", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Behaviour")]
        public IBehaviour Behaviour { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst4836B1_ED36_4e0f_925D_C5A85F7AEC34", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Code")]
        public ICode Code { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstFF2578_3AE2_4c11_997D_0158FD3C5A82", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IDocumentedElement.Documentation")]
        public IDocumentation Documentation { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstF28C85_25C8_4727_B3FD_8F5AEA78232C", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElementReference.ExtendedElement")]
        public IXmiElement ExtendedElement { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst9D9CDC_97D3_402f_95B5_82278388E7B1", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Model")]
        public IModel Model { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8B42627D_1513_65E2_8B19_450CF0AF1923", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamedElement.Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_src7383AB_CC81_460a_B2A7_ECDCB713554F", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Parameters")]
        public List<IParameter> Parameters { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstED051A_842E_40fa_91C4_FB3BEFE3FEA4", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Properties")]
        public IOperationProperties Properties { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_BB9E7B06_4FA0_348F_B3D4_B9D203D90797", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IScopedElement.Scope")]
        public string Scope { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dstFCB4EF_78DF_4d7e_BCCF_650A1CBE8710", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Stereotype")]
        public IStereotypeDefinition Stereotype { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst047BAC_0761_4e7e_B670_513411918814", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Style")]
        public IStyle Style { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst80BDCF_67DE_46ee_9574_4D1B668B3549", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Styleex")]
        public IStyle Styleex { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_srcFDB579_D278_43f5_877D_DBCF2ED71E9B", aggregation: AggregationKind.Shared, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Tags")]
        public List<ITag> Tags { get; set; } = new();

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst8336A1_8C12_4891_B35F_ECF03A7C9E87", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Type")]
        public ITypeElement Type { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_dst212952_F236_455f_936D_8CC86235A031", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IOperation.Xrefs")]
        public IXrefs Xrefs { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
