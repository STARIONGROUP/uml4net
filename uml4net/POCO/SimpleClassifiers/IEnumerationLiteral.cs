﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IEnumerationLiteral.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.SimpleClassifiers
{
    using uml4net.Decorators;
    using uml4net.POCO.Classification;

    /// <summary>
    /// An EnumerationLiteral is a user-defined data value for an Enumeration.
    /// </summary>
    public interface IEnumerationLiteral : IInstanceSpecification
    {
        /// <summary>
        /// The classifier of this EnumerationLiteral derived to be equal to its Enumeration.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isReadOnly:true, isDerived:true)]
        [RedefinedProperty("InstanceSpecification-classifier")]
        public new IEnumeration Classifier { get; }

        /// <summary>
        /// The Enumeration that this EnumerationLiteral is a member of.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [SubsettedProperty("NamedElement-namespace")]
        public IEnumeration Enumeration { get; set; }
    }
}
