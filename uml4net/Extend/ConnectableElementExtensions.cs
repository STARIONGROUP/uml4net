﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="ConnectableElementExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.StructuredClassifiers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="ConnectableElementExtensions"/> class provides extensions methods for <see cref="IConnectableElement"/>
    /// </summary>
    internal static class ConnectableElementExtensions
    {
        /// <summary>
        /// Queries A set of ConnectorEnds that attach to this ConnectableElement.
        /// </summary>
        /// <param name="connectableElement">
        /// The subject <see cref="IConnectableElement"/>
        /// </param>
        /// <returns>
        /// A set of ConnectorEnds that attach to this ConnectableElement.
        /// </returns>
        internal static List<IConnectorEnd> QueryEnd(this IConnectableElement connectableElement)
        {
            throw new NotSupportedException();
        }
    }
}
