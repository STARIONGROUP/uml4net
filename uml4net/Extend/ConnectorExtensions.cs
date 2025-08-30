// -------------------------------------------------------------------------------------------------
//  <copyright file="ConnectorExtensions].cs" company="Starion Group S.A.">
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

    /// <summary>
    /// The <see cref="ConnectorExtensions"/> class provides extensions methods for <see cref="IConnector"/>
    /// </summary>
    internal static class ConnectorExtensions
    {
        /// <summary>
        /// Queries the kind of Connector. This is derived: a Connector with one or more ends connected to a
        /// Port which is not on a Part and which is not a behavior port is a delegation; otherwise it is an
        /// assembly.
        /// </summary>
        /// <param name="connector">
        /// The subject <see cref="IConnector"/>
        /// </param>
        /// <returns>
        /// the kind of Connector. This is derived: a Connector with one or more ends connected to a
        /// Port which is not on a Part and which is not a behavior port is a delegation; otherwise it is an
        /// assembly.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static ConnectorKind QueryKind(this IConnector connector)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }
    }
}
