// -------------------------------------------------------------------------------------------------
// <copyright file="IBroadcastSignalAction.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Actions
{
    /// <summary>
    /// A BroadcastSignalAction is an InvocationAction that transmits a Signal instance to all the 
    /// potential target objects in the system. Values from the argument InputPins are used to provide 
    /// values for the attributes of the Signal. The requestor continues execution immediately after 
    /// the Signal instances are sent out and cannot receive reply values.
    /// </summary>
    public interface IBroadcastSignalAction : IInvocationAction
    {
    }
}
