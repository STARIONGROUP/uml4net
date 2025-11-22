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
            var noLogoOption = new Option<bool>(name: "--no-logo")
            {
                Description = "Suppress the logo",
                DefaultValueFactory = parseResult => false
            };

            this.Options.Add(noLogoOption);

            var inputModelFileOption = new Option<FileInfo>(name: "--input-model")
            {
                Description = "The path to the UML XMI file",
                DefaultValueFactory = parseResult => new FileInfo("model.xmi"),
                Required = true
            };
    
            inputModelFileOption.Aliases.Add("-i");

            this.Options.Add(inputModelFileOption);

            var pathMaps = new Option<string[]>(name: "--pathmaps")
            {
                Description = "Add pathmap key-value pairs",
                AllowMultipleArgumentsPerToken = true
            };
            pathMaps.Aliases.Add("-m");
            
            this.Options.Add(pathMaps);

            var autoOpenReportOption = new Option<bool>(name: "--auto-open-report")
            {
                Description = "Open the generated report with its default application",
                DefaultValueFactory = parseResult => false,
                Required = true
            };

            autoOpenReportOption.Aliases.Add("-a");

            this.Options.Add(autoOpenReportOption);

            var useStrictReadingOption = new Option<bool>(name: "--use-strict-reading")
            {
                Description = "When Strict Reading is set to true the reader will throw an exception if it encounters an unknown element or attribute. Otherwise, it will ignore the unknown element or attribute and log a warning.",
                DefaultValueFactory = parseResult => true,
                Required = false
            };
            useStrictReadingOption.Aliases.Add("-s");

            this.Options.Add(useStrictReadingOption);

            var xmiIdOption = new Option<string>(name: "--root-package-xmi-id")
            {
                Description = "The unique identifier of the of the root package to report on",
                DefaultValueFactory = parseResult => "",
                Required = false
            };

            xmiIdOption.Aliases.Add("-rmi");

            this.Options.Add(xmiIdOption);

            var rootPackageNameOption = new Option<string>(name: "--root-package-name")
            {
                Description = "The name of the of the root package to report on",
                DefaultValueFactory = parseResult => "",
                Required = false
            };

            rootPackageNameOption.Aliases.Add("-rn");

            this.Options.Add(rootPackageNameOption);
        }
    }
}
