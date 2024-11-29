// -------------------------------------------------------------------------------------------------
// <copyright file="IFinalState.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.StateMachines
{
    /// <summary>
    /// A special kind of State, which, when entered, signifies that the enclosing Region has completed.
    /// If the enclosing Region is directly contained in a StateMachine and all other Regions in that 
    /// StateMachine also are completed, then it means that the entire StateMachine behavior is completed.
    /// </summary>
    public interface IFinalState : IState
    {
    }
}
