// -------------------------------------------------------------------------------------------------
//  <copyright file="ReportCommand.cs" company="Starion Group S.A.">
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

namespace uml4net.Tools.Commands
{
    using System.CommandLine;
    using System.IO;

    /// <summary>
    /// Abstract super class from which all report commands shall inherit
    /// </summary>
    public abstract class ReportCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportCommand"/>
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="description">The description of the command, shown in help.</param>
        protected ReportCommand(string name, string description = null) : base(name, description)
        {
            var noLogoOption = new Option<bool>(
                name: "--no-logo",
                description: "Suppress the logo",
                getDefaultValue: () => false);
            this.AddOption(noLogoOption);

            var inputModelFileOption = new Option<FileInfo>(
                name: "--input-model",
                description: "The path to the UML XMI file",
                getDefaultValue: () => new FileInfo("model.xmi"));
            inputModelFileOption.AddAlias("-i");
            inputModelFileOption.IsRequired = true;
            this.AddOption(inputModelFileOption);

            var pathMaps = new Option<string[]>(
                name: "--pathmaps",
                description: "Add pathmap key-value pairs");
            pathMaps.AddAlias("-m");
            pathMaps.AllowMultipleArgumentsPerToken = true;
            this.AddOption(pathMaps);

            var autoOpenReportOption = new Option<bool>(
                name: "--auto-open-report",
                description: "Open the generated report with its default application",
                getDefaultValue: () => false);
            autoOpenReportOption.AddAlias("-a");
            autoOpenReportOption.IsRequired = false;
            this.AddOption(autoOpenReportOption);

            var useStrictReadingOption = new Option<bool>(
                name: "--use-strict-reading",
                description: "When Strict Reading is set to true the reader will throw an exception if it encounters an unknown element or attribute. Otherwise, it will ignore the unknown element or attribute and log a warning.",
                getDefaultValue: () => true);
            useStrictReadingOption.AddAlias("-s");
            useStrictReadingOption.IsRequired = false;
            this.AddOption(useStrictReadingOption);
        }
    }
}
