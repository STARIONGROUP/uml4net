// -------------------------------------------------------------------------------------------------
// <copyright file="IBehavior.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.CommonBehavior
{
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// Behavior is a specification of how its context BehavioredClassifier changes state over time.
    /// This specification may be either a definition of possible behavior execution or emergent behavior, 
    /// or a selective illustration of an interesting subset of possible executions. The latter form is
    /// typically used for capturing examples, such as a trace of a particular execution.
    /// </summary>
    public interface IBehavior : IClass
    {
    }
}
