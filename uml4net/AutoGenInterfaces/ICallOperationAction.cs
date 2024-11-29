// -------------------------------------------------------------------------------------------------
// <copyright file="ICallOperationAction.cs" company="Starion Group S.A.">
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
    /// A CallOperationAction is a CallAction that transmits an Operation call request to the target 
    /// object, where it may cause the invocation of associated Behavior. The argument values of the 
    /// CallOperationAction are passed on the input Parameters of the Operation. If call is synchronous, 
    /// the execution of the CallOperationAction waits until the execution of the invoked Operation completes 
    /// and the values of output Parameters of the Operation are placed on the result OutputPins. If 
    /// the call is asynchronous, the CallOperationAction completes immediately and no results values can be provided.
    /// </summary>
    public interface ICallOperationAction : ICallAction
    {
    }
}
