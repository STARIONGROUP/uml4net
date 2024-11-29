// -------------------------------------------------------------------------------------------------
// <copyright file="IStereotype.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// A stereotype defines how an existing metaclass may be extended, and enables the use of platform or domain
    /// specific terminology or notation in place of, or in addition to, the ones used for the extended metaclass.
    /// </summary>
    public interface IStereotype : IClass
    {
        /// <summary>
        /// Stereotype can change the graphical appearance of the extended model element by using attached icons.
        /// When this association is not null, it references the location of the icon content to be displayed within
        /// diagrams presenting the extended model elements.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        public List<IImage> Icon { get; set; }

        /// <summary>
        /// The profile that directly or indirectly contains this stereotype.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isReadOnly:true, isDerived:true)]
        public IProfile Profile { get; }
    }
}
