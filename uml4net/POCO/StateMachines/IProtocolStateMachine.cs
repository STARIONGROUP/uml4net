// -------------------------------------------------------------------------------------------------
// <copyright file="IProtocolStateMachine.cs" company="Starion Group S.A.">
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
    /// A ProtocolStateMachine is always defined in the context of a Classifier. It specifies which
    /// BehavioralFeatures of the Classifier can be called in which State and under which conditions, 
    /// thus specifying the allowed invocation sequences on the Classifier's BehavioralFeatures.
    /// A ProtocolStateMachine specifies the possible and permitted Transitions on the instances of its
    /// context Classifier, together with the BehavioralFeatures that carry the Transitions. In this manner,
    /// an instance lifecycle can be specified for a Classifier, by defining the order in which the
    /// BehavioralFeatures can be activated and the States through which an instance progresses during its existence.
    /// </summary>
    public interface IProtocolStateMachine : IStateMachine
    {
    }
}
