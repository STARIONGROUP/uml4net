﻿// -------------------------------------------------------------------------------------------------
// <copyright file="LinkEndDestructionData.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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

namespace uml4net.Actions
{
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

    using uml4net.Utils;

    /// <summary>
    /// LinkEndDestructionData is LinkEndData used to provide values for one end of a link to be destroyed
    /// by a DestroyLinkAction.
    /// </summary>
    [Class(xmiId: "LinkEndDestructionData", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial class LinkEndDestructionData : XmiElement, ILinkEndDestructionData
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// The InputPin that provides the position of an existing link to be destroyed in an ordered, nonunique
        /// Association end. The type of the destroyAt InputPin is UnlimitedNatural, but the value cannot be
        /// zero or unlimited.
        /// </summary>
        [Property(xmiId: "LinkEndDestructionData-destroyAt", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "ILinkEndDestructionData.DestroyAt")]
        public IInputPin DestroyAt { get; set; }

        /// <summary>
        /// The Association end for which this LinkEndData specifies values.
        /// </summary>
        [Property(xmiId: "LinkEndData-end", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "ILinkEndData.End")]
        public IProperty End { get; set; }

        /// <summary>
        /// Specifies whether to destroy duplicates of the value in nonunique Association ends.
        /// </summary>
        [Property(xmiId: "LinkEndDestructionData-isDestroyDuplicates", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "ILinkEndDestructionData.IsDestroyDuplicates")]
        public bool IsDestroyDuplicates { get; set; }

        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedComment", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IElement.OwnedComment")]
        public IContainerList<IComment> OwnedComment
        {
            get => this.ownedComment ??= new ContainerList<IComment>(this);
            set => this.ownedComment = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedComment"/>
        /// </summary>
        private IContainerList<IComment> ownedComment;

        /// <summary>
        /// The Elements owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.OwnedElement")]
        public IContainerList<IElement> OwnedElement => this.QueryOwnedElement();

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(xmiId: "Element-owner", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// A set of QualifierValues used to provide values for the qualifiers of the end.
        /// </summary>
        [Property(xmiId: "LinkEndData-qualifier", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "ILinkEndData.Qualifier")]
        public IContainerList<IQualifierValue> Qualifier
        {
            get => this.qualifier ??= new ContainerList<IQualifierValue>(this);
            set => this.qualifier = value;
        }

        /// <summary>
        /// Backing field for <see cref="Qualifier"/>
        /// </summary>
        private IContainerList<IQualifierValue> qualifier;

        /// <summary>
        /// The InputPin that provides the specified value for the given end. This InputPin is omitted if the
        /// LinkEndData specifies the "open" end for a ReadLinkAction.
        /// </summary>
        [Property(xmiId: "LinkEndData-value", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "ILinkEndData.Value")]
        public IInputPin Value { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------