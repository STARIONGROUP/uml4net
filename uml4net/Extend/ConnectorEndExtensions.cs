// -------------------------------------------------------------------------------------------------
//  <copyright file="ConnectorEndExtensions.cs" company="Starion Group S.A.">
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

    using uml4net.Classification;

    /// <summary>
    /// The <see cref="ConnectorEndExtensions"/> class provides extensions methods for <see cref="IConnectorEnd"/>
    /// </summary>
    internal static class ConnectorEndExtensions
    {
        /// <summary>
        /// Queries A derived property referencing the corresponding end on the Association which types the Connector
        /// owing this ConnectorEnd, if any. It is derived by selecting the end at the same place in the
        /// ordering of Association ends as this ConnectorEnd.
        /// </summary>
        /// </summary>
        /// <param name="connectorEnd">
        /// The subject <see cref="IConnectorEnd"/>
        /// </param>
        /// <returns>
        /// A derived property referencing the corresponding end on the Association which types the Connector
        /// owing this ConnectorEnd, if any. It is derived by selecting the end at the same place in the
        /// ordering of Association ends as this ConnectorEnd.
        /// </summary>
        /// </returns>
        internal static IProperty QueryDefiningEnd(this IConnectorEnd connectorEnd)
        {
            throw new NotSupportedException();
        }
    }
}
