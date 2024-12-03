// -------------------------------------------------------------------------------------------------
//  <copyright file="IHtmlReportGenerator.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
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
        /// <param name="pathMap">
        /// a dictionary of key-value pairs used to map PATHMAP references to local xmi files
        /// </param>
        /// <returns>
        /// the content of an HTML report in a string
        /// </returns>
        public string GenerateReport(FileInfo modelPath, DirectoryInfo rootDirectory, Dictionary<string, string> pathMap);
    }
}
