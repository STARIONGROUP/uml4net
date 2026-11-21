// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiInspector.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Reporting.Generators
{
    using System.IO;

    /// <summary>
    /// The purpose of the <see cref="IXmiInspector"/> is to inspect the XMI and return a text based
    /// report
    /// </summary>
    public interface IXmiInspector
    {
        /// <summary>
        /// inspects the provided XMI document
        /// </summary>
        /// <param name="modelFileInfo">
        /// the path to the XMI document
        /// </param>
        /// <returns>
        /// a text based report
        /// </returns>
        public string Inspect(FileInfo modelFileInfo);
    }
}
