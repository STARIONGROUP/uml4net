// -------------------------------------------------------------------------------------------------
// <copyright file="IAcceptCallAction.cs" company="Starion Group S.A.">
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
    /// An AcceptCallAction is an AcceptEventAction that handles the receipt of a synchronous call request. 
    /// In addition to the values from the Operation input parameters, the Action produces an output that
    /// is needed later to supply the information to the ReplyAction necessary to return control to the caller. 
    /// An AcceptCallAction is for synchronous calls. If it is used to handle an asynchronous call, execution 
    /// of the subsequent ReplyAction will complete immediately with no effect.
    /// </summary>
    public interface IAcceptCallAction : IAcceptEventAction
    {
    }
}
