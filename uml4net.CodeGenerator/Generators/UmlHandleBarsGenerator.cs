// -------------------------------------------------------------------------------------------------
// <copyright file="UmlHandleBarsGenerator.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CodeGenerator.Generators
{
    using System.IO;
    using System.Threading.Tasks;

    using uml4net.xmi.Readers;

    /// <summary>
    /// Abstract super class from which all uml based <see cref="HandlebarsDotNet"/> generators
    /// need to derive
    /// </summary>
    public abstract class UmlHandleBarsGenerator : HandleBarsGenerator
    {
        /// <summary>
        /// Generates code specific to the concrete implementation
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult"/> that contains the UML model to generate from
        /// </param>
        /// <param name="rootPackageXmiId">
        /// the unique identifier of the root package to report in
        /// </param>
        /// <param name="rootPackageName">
        /// the name of the root package to report in
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public abstract Task GenerateAsync(XmiReaderResult xmiReaderResult, string rootPackageXmiId, string rootPackageName, DirectoryInfo outputDirectory);
    }
}
