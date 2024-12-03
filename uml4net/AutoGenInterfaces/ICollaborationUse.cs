// -------------------------------------------------------------------------------------------------
// <copyright file="ICollaborationUse.cs" company="Starion Group S.A.">
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
    /// A CollaborationUse is used to specify the application of a pattern specified by a Collaboration to a
    /// specific situation.
    /// </summary>
    [Class(xmiId: "CollaborationUse", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface ICollaborationUse : INamedElement
    {
        /// <summary>
        /// A mapping between features of the Collaboration and features of the owning Classifier. This mapping
        /// indicates which ConnectableElement of the Classifier plays which role(s) in the Collaboration. A
        /// ConnectableElement may be bound to multiple roles in the same CollaborationUse (that is, it may play
        /// multiple roles).
        /// </summary>
        [Property(xmiId: "CollaborationUse-roleBinding", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IDependency> RoleBinding { get; set; }

        /// <summary>
        /// The Collaboration which is used in this CollaborationUse. The Collaboration defines the cooperation
        /// between its roles which are mapped to ConnectableElements relating to the Classifier owning the
        /// CollaborationUse.
        /// </summary>
        [Property(xmiId: "CollaborationUse-type", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public ICollaboration Type { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
