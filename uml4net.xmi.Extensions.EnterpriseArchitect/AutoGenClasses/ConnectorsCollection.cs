// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorsCollection.cs" company="Starion Group S.A.">
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
    [Class(xmiId: "EAID_FCF71EC8_8C76_40ac_96A2_CF4E9E3B2047", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net.extension", "latest")]
    public partial class ConnectorsCollection : XmiElement, IConnectorsCollection
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
        [Property(xmiId: "EAID_src4AA76B_E867_4fc5_B93B_1C6C0E5E1A67", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IConnectorsCollection.Connector")]
        public IContainerList<IConnector> Connector
        {
            get => this.connector ??= new ContainerList<IConnector>(this);
            set => this.connector = value;
        }

        /// <summary>
        /// Backing field for <see cref="Connector"/>
        /// </summary>
        private IContainerList<IConnector> connector;
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
