﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IEnumeration.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    
    using uml4net.Decorators;
    using uml4net.POCO.Classification;

    /// <summary>
    /// An Enumeration is a DataType whose values are enumerated in the model as EnumerationLiterals.
    /// </summary>
    public interface IEnumeration : IDataType
    {
        /// <summary>
        /// The ordered set of literals owned by this Enumeration.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Namespace-ownedMember")]
        public List<IEnumerationLiteral> OwnedLiteral { get; set; }
    }
}
