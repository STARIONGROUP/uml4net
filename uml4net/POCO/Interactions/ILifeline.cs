// -------------------------------------------------------------------------------------------------
// <copyright file="ILifeline.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Interactions
{
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// A Lifeline represents an individual participant in the Interaction. While parts and structural
    /// features may have multiplicity greater than 1, Lifelines represent only one interacting entity.
    /// </summary>
    public interface ILifeline : INamedElement
    {
    }
}
