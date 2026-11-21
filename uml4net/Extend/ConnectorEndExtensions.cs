// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorEndExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

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
        /// <param name="connectorEnd">
        /// The subject <see cref="IConnectorEnd"/>
        /// </param>
        /// <returns>
        /// A derived property referencing the corresponding end on the Association which types the Connector
        /// owing this ConnectorEnd, if any. It is derived by selecting the end at the same place in the
        /// ordering of Association ends as this ConnectorEnd.
        /// </returns>
        internal static IProperty QueryDefiningEnd(this IConnectorEnd connectorEnd)
        {
            if (connectorEnd == null)
            {
                throw new ArgumentNullException(nameof(connectorEnd));
            }

            if (connectorEnd.Owner is not IConnector connector || connector.Type == null)
            {
                return null;
            }

            var index = connector.End.IndexOf(connectorEnd);

            return connector.Type.MemberEnd[index];
        }
    }
}
