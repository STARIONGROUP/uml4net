// -------------------------------------------------------------------------------------------------
// <copyright file="ICollaboration.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.POCO.StructuredClassifiers
{
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// A CollaborationUse is used to specify the application of a pattern specified by a Collaboration to a specific situation.
    /// </summary>
    public interface ICollaborationUse : INamedElement
    {
        /// <summary>
        /// A mapping between features of the Collaboration and features of the owning Classifier.
        /// This mapping indicates which ConnectableElement of the Classifier plays which role(s) in the
        /// Collaboration. A ConnectableElement may be bound to multiple roles in the same CollaborationUse
        /// (that is, it may play multiple roles).
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Element-ownedElement")]
        public List<IDependency> RoleBinding { get; set; }

        /// <summary>
        /// The Collaboration which is used in this CollaborationUse. The Collaboration defines the cooperation
        /// between its roles which are mapped to ConnectableElements relating to the Classifier owning the
        /// CollaborationUse.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        public ICollaboration Type { get; set; }
    }
}
