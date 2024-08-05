// -------------------------------------------------------------------------------------------------
// <copyright file="IDependency.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.CommonStructure
{
    using System.Collections.Generic;
    using uml4net.Decorators;
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// A Dependency is a Relationship that signifies that a single model Element or a set of model
    /// Elements requires other model Elements for their specification or implementation. This means
    /// that the complete semantics of the client Element(s) are either semantically or structurally 
    /// dependent on the definition of the supplier Element(s).
    /// </summary>
    public interface IDependency : IDirectedRelationship, IPackageableElement
    {
        /// <summary>
        /// The Element(s) dependent on the supplier Element(s). In some cases (such as a trace Abstraction)
        /// the assignment of direction (that is, the designation of the client Element) is at the discretion 
        /// of the modeler and is a stipulation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "DirectedRelationship.Source")]
        public List<INamedElement> Client { get; set; }

        /// <summary>
        /// The Element(s) on which the client Element(s) depend in some respect. The modeler may stipulate
        /// a sense of Dependency direction suitable for their domain.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "DirectedRelationship.Target")]
        public List<INamedElement> Supplier { get; set; }
    }
}
