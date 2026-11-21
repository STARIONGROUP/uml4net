// -------------------------------------------------------------------------------------------------
// <copyright file="IHtmlReportGenerator.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Reporting.Generators
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// The purpose of the <see cref="IHtmlReportGenerator"/> is to generate an HTML report of an
    /// UML Model
    /// </summary>
    public interface IHtmlReportGenerator : IReportGenerator
    {
        /// <summary>
        /// Generates a table that contains all classes, attributes and their documentation
        /// </summary>
        /// <param name="modelPath">
        /// /// the path to the UML model of which the report is to be generated.
        /// </param>
        /// <param name="rootDirectory">
        /// The base directory path used as the local root for resolving referenced XMI files.
        /// </param>
        /// <param name="rootPackageXmiId">
        /// the unique identifier of the root package to report in
        /// </param>
        /// <param name="rootPackageName">
        /// the name of the root package to report in
        /// </param>
        /// <param name="useStrictReading">
        /// A value indicating whether to use strict reading. When Strict Reading is set to true the
        /// reader will throw an exception if it encounters an unknown element or attribute.
        /// Otherwise, it will ignore the unknown element or attribute and log a warning.
        /// </param>
        /// <param name="pathMap">
        /// a dictionary of key-value pairs used to map PATHMAP references to local xmi files
        /// </param>
        /// <param name="customHtml">
        /// Custom HTML that will be displayed below the Starion logo
        /// </param>
        /// <returns>
        /// the content of an HTML report in a string
        /// </returns>
        public string GenerateReport(FileInfo modelPath, DirectoryInfo rootDirectory, string rootPackageXmiId, string rootPackageName, bool useStrictReading, Dictionary<string, string> pathMap, string customHtml = "");
    }
}
