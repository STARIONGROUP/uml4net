// -------------------------------------------------------------------------------------------------
// <copyright file="IAssociation.cs" company="Starion Group S.A.">
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

namespace uml4net.StructuredClassifiers
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

    using uml4net.Utils;

    /// <summary>
    /// A link is a tuple of values that refer to typed objects.  An Association classifies a set of links,
    /// each of which is an instance of the Association.  Each value in the link refers to an instance of
    /// the type of the corresponding end of the Association.
    /// </summary>
    [Class(xmiId: "Association", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IAssociation : IRelationship, IClassifier
    {
        /// <summary>
        /// The Classifiers that are used as types of the ends of the Association.
        /// </summary>
        [Property(xmiId: "Association-endType", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Relationship-relatedElement")]
        public List<IType> EndType { get; }

        /// <summary>
        /// Specifies whether the Association is derived from other model elements such as other Associations.
        /// </summary>
        [Property(xmiId: "Association-isDerived", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsDerived { get; set; }

        /// <summary>
        /// Each end represents participation of instances of the Classifier connected to the end in links of
        /// the Association.
        /// </summary>
        [Property(xmiId: "Association-memberEnd", aggregation: AggregationKind.None, lowerValue: 2, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        public List<IProperty> MemberEnd { get; set; }

        /// <summary>
        /// The navigable ends that are owned by the Association itself.
        /// </summary>
        [Property(xmiId: "Association-navigableOwnedEnd", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Association-ownedEnd")]
        public List<IProperty> NavigableOwnedEnd { get; set; }

        /// <summary>
        /// The ends that are owned by the Association itself.
        /// </summary>
        [Property(xmiId: "Association-ownedEnd", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Association-memberEnd")]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IProperty> OwnedEnd { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
