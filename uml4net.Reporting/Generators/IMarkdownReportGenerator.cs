// -------------------------------------------------------------------------------------------------
//  <copyright file="IMarkdownReportGenerator.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.Reporting.Generators
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// The purpose of the <see cref="IMarkdownReportGenerator"/> is to generate a Markdown report of an
    /// UML Model
    /// </summary>
    public interface IMarkdownReportGenerator : IReportGenerator
    {
        /// <summary>
        /// Generates a Markdown document with a table that contains all classes, attributes and their documentation
        /// </summary>
        /// <param name="modelPath">
        /// the path to the UML model of which the report is to be generated.
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
        /// <returns>
        /// the content of a Markdown report in a string
        /// </returns>
        public string GenerateReport(FileInfo modelPath, DirectoryInfo rootDirectory, string rootPackageXmiId, string rootPackageName, bool useStrictReading, Dictionary<string, string> pathMap);
    }
}
