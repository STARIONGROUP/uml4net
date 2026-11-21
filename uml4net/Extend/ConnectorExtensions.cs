// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorExtensions].cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.StructuredClassifiers
{
    using System;
    using System.Linq;

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
        internal static ConnectorKind QueryKind(this IConnector connector)
        {
            if (connector == null)
            {
                throw new ArgumentNullException(nameof(connector));
            }

            var isDelegation = connector.End.Any(x =>
                x.Role is IPort port && x.PartWithPort == null && !port.IsBehavior);

            return isDelegation ? ConnectorKind.Delegation : ConnectorKind.Assembly;
        }
    }
}
