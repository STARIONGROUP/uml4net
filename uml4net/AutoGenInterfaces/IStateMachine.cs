// -------------------------------------------------------------------------------------------------
// <copyright file="IStateMachine.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.CommonBehavior;

    /// <summary>
    /// StateMachines can be used to express event-driven behaviors of parts of a system. Behavior is
    /// modeled as a traversal of a graph of Vertices interconnected by one or more joined Transition
    /// arcs that are triggered by the dispatching of successive Event occurrences. During this traversal,
    /// the StateMachine may execute a sequence of Behaviors associated with various elements of the StateMachine.
    /// </summary>
    public interface IStateMachine : IBehavior
    {
    }
}
