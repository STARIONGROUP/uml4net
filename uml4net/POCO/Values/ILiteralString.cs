// -------------------------------------------------------------------------------------------------
// <copyright file="ILiteralString.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Values
{
    using uml4net.Decorators;

    using uml4net.POCO.Classification;

    /// <summary>
    /// A LiteralString is a specification of a String value.
    /// </summary>
    public interface ILiteralString : ILiteralSpecification
    {
        /// <summary>
        /// The specified String value.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        public string Value { get; set; }
    }
}
