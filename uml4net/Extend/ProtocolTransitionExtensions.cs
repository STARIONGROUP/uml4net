// -------------------------------------------------------------------------------------------------
//  <copyright file="ProtocolTransitionExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.StateMachines
{
    using System;
    using System.Collections.Generic;

    using uml4net.Classification;

    /// <summary>
    /// The <see cref="ProtocolTransitionExtensions"/> class provides extensions methods for <see cref="IProtocolTransition"/>
    /// </summary>
    internal static class ProtocolTransitionExtensions
    {
        /// <summary>
        /// Queries the association refers to the associated Operation. It is derived from the Operation of the
        /// CallEvent Trigger when applicable.
        /// </summary>
        /// <param name="protocolTransition">
        /// The subject <see cref="IProtocolTransition"/>
        /// </param>
        /// <returns>
        /// The association refers to the associated Operation. It is derived from the Operation of the
        /// CallEvent Trigger when applicable.
        /// </returns>
        internal static List<IOperation> QueryReferred(this IProtocolTransition protocolTransition)
        {
            throw new NotSupportedException();
        }
    }
}
