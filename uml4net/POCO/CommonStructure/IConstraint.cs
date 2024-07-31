// -------------------------------------------------------------------------------------------------
// <copyright file="IConstraint.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.Values;

    /// <summary>
    /// A Constraint is a condition or restriction expressed in natural language text or in a machine
    /// readable language for the purpose of declaring some of the semantics of an Element or set of Elements.
    /// </summary>
    public interface IConstraint : IPackageableElement
    {
        /// <summary>
        /// The ordered set of Elements referenced by this Constraint.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true)]
        public List<IElement> ConstrainedElement { get; set; }

        /// <summary>
        /// Specifies the Namespace that owns the Constraint.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: true, subsets: "NamedElement::namespace")]
        public INamespace Context { get; set; }

        /// <summary>
        /// A condition that must be true when evaluated in order for the Constraint to be satisfied.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1)]
        public IValueSpecification Specification { get; set; }
    }
}
