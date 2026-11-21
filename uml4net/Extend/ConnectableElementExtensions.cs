// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectableElementExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.StructuredClassifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.CommonStructure;

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
        /// <remarks>
        /// Implements the OCL <c>ConnectorEnd.allInstances()->select(role = self)</c>, with <c>allInstances()</c>
        /// emulated by <see cref="ElementExtensions.QueryAllInstancesInModel"/>.
        /// </remarks>
        internal static List<IConnectorEnd> QueryEnd(this IConnectableElement connectableElement)
        {
            if (connectableElement == null)
            {
                throw new ArgumentNullException(nameof(connectableElement));
            }

            return connectableElement.QueryAllInstancesInModel()
                .OfType<IConnectorEnd>()
                .Where(connectorEnd => ReferenceEquals(connectorEnd.Role, connectableElement))
                .ToList();
        }
    }
}
