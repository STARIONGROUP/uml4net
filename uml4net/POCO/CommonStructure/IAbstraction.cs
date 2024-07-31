// -------------------------------------------------------------------------------------------------
// <copyright file="IAbstraction.cs" company="Starion Group S.A.">
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
    using uml4net.Decorators;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.Values;

    /// <summary>
    /// An Abstraction is a Relationship that relates two Elements or sets of Elements that represent the
    /// same concept at different levels of abstraction or from different viewpoints.
    /// </summary>
    public interface IAbstraction : IDependency
    {
        /// <summary>
        /// An OpaqueExpression that states the abstraction relationship between the supplier(s) and the client(s). 
        /// In some cases, such as derivation, it is usually formal and unidirectional; in other cases, such as trace, 
        /// it is usually informal and bidirectional. The mapping expression is optional and may be omitted if the
        /// precise relationship between the Elements is not specified.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        public IOpaqueExpression Mapping { get; set; }
    }
}
