// -------------------------------------------------------------------------------------------------
//  <copyright file="MessageExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Interactions
{
    using System;

    /// <summary>
    /// The <see cref="MessageExtensions"/> class provides extensions methods for <see cref="IMessage"/>
    /// </summary>
    internal static class MessageExtensions
    {
        /// <summary>
        /// Queries The derived kind of the Message (complete, lost, found, or unknown).
        /// </summary>
        /// <param name="message">
        /// The subject <see cref="IMessage"/>
        /// </param>
        /// <returns>
        /// The derived kind of the Message (complete, lost, found, or unknown).
        /// </returns>
        internal static MessageKind QueryMessageKind(this IMessage message)
        {
            throw new NotSupportedException();
        }
    }
}
