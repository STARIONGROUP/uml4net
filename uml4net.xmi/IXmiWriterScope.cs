// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiWriterScope.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi
{
    using System;

    /// <summary>
    /// Represents a scope for managing the lifecycle of services used during the XMI writing process.
    /// </summary>
    public interface IXmiWriterScope : IDisposable;
}
