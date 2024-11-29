// -------------------------------------------------------------------------------------------------
// <copyright file="IPackageMerge.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Packages
{
    using uml4net.Decorators;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// A package merge defines how the contents of one package are extended by the contents of another package.
    /// </summary>
    public interface IPackageMerge : IDirectedRelationship
    {
        /// <summary>
        /// References the Package that is to be merged with the receiving package of the PackageMerge.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [SubsettedProperty("DirectedRelationship-target")]
        public IPackage MergedPackage { get; set; }

        /// <summary>
        /// References the Package that is being extended with the contents of the merged package of the PackageMerge.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [SubsettedProperty("DirectedRelationship-source")]
        [SubsettedProperty("Element-owner")]
        public IPackage ReceivingPackage { get; set; }
    }
}
