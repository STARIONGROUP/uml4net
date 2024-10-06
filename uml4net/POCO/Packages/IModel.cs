// -------------------------------------------------------------------------------------------------
// <copyright file="IModel.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// A model captures a view of a physical system. It is an abstraction of the physical system,
    /// with a certain purpose. This purpose determines what is to be included in the model and what
    /// is irrelevant. Thus the model completely describes those aspects of the physical system that
    /// are relevant to the purpose of the model, at the appropriate level of detail.
    /// </summary>
    public interface IModel : IPackage
    {
        /// <summary>
        /// The name of the viewpoint that is expressed by a model (this name may refer to a profile definition).
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        public string Viewpoint { get; set; }
    }
}
