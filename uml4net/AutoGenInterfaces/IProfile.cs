// -------------------------------------------------------------------------------------------------
// <copyright file="IProfile.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;
    using Utils;

    /// <summary>
    /// A profile defines limited extensions to a reference metamodel with the purpose of adapting
    /// the metamodel to a specific platform or domain.
    /// </summary>
    public interface IProfile : IPackage
    {
        /// <summary>
        /// References a metaclass that may be extended.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Namespace-elementImport")]
        public IContainerList<IElementImport> MetaclassReference { get; set; }

        /// <summary>
        /// References a package containing (directly or indirectly) metaclasses that may be extended.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Namespace-packageImport")]
        public IContainerList<IPackageImport> MetamodelReference { get; set; }
    }
}
