// -------------------------------------------------------------------------------------------------
// <copyright file="IPort.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.Classification;

    /// <summary>
    /// A Port is a property of an EncapsulatedClassifier that specifies a distinct interaction point between
    /// that EncapsulatedClassifier and its environment or between the (behavior of the) EncapsulatedClassifier 
    /// and its internal parts. Ports are connected to Properties of the EncapsulatedClassifier by Connectors 
    /// through which requests can be made to invoke BehavioralFeatures. A Port may specify the services an 
    /// EncapsulatedClassifier provides (offers) to its environment as well as the services that an EncapsulatedClassifier 
    /// expects (requires) of its environment.  A Port may have an associated ProtocolStateMachine.
    /// </summary>
    public interface IPort : IProperty
    {
    }
}
