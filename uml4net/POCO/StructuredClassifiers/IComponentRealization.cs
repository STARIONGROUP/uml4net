// -------------------------------------------------------------------------------------------------
// <copyright file="IComponentRealization.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.StructuredClassifiers
{
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// Realization is specialized to (optionally) define the Classifiers that realize the contract offered
    /// by a Component in terms of its provided and required Interfaces. The Component forms an abstraction
    /// from these various Classifiers.
    /// </summary>
    public interface IComponentRealization : IRealization
    {
    }
}
