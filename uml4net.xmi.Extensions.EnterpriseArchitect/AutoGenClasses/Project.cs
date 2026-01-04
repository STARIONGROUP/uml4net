// -------------------------------------------------------------------------------------------------
// <copyright file="Project.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_BCB8EEBE_E533_D371_A45A_7997441EA00B", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class Project : IProject
    {
        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_9CC4E6F9_F2EA_0BA8_A78D_A97B27B82A9B", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IProject.Author")]
        public string Author { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_B505D903_265C_3700_88ED_EFE33BD595F4", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IProject.Complexity")]
        public int Complexity { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_9BD50F93_6458_A6BB_9F27_DFC61F1F4E1D", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITimes.Created")]
        public string Created { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_9A003EC5_45A8_8365_B80C_27B5F393ECFF", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITimes.Modified")]
        public string Modified { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_ABBEF05E_EFD1_A0C0_B7D3_E275DD74F386", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IProject.Phase")]
        public string Phase { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_8C3C6C19_33BA_6246_9658_54AAC209BAD9", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IProject.Status")]
        public Status Status { get; set; }

        /// <summary>
        /// </summary>
        [Property(xmiId: "EAID_B1C69BDF_E3EE_011D_80F9_25FA69988CD0", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IProject.Version")]
        public string Version { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
