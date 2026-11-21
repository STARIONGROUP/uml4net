// -------------------------------------------------------------------------------------------------
// <copyright file="ModelInspectionCommand.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tools.Commands
{
    using System.CommandLine;
    using System.IO;

    using uml4net.Reporting.Generators;
    using uml4net.Tools.Services;

    /// <summary>
    /// The <see cref="ModelInspectionCommand"/> that inspects a UML model and generates
    /// a text report
    /// </summary>
    public class ModelInspectionCommand : ReportCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelInspectionCommand"/>
        /// </summary>
        public ModelInspectionCommand() : base("inspect", "Inspects an UML model and generates a text report")
        {
            var reportFileOption = new Option<FileInfo>(name: "--output-report")
            {
                Description =  "The path to the text report file. Supported extensions is '.txt'",
                DefaultValueFactory = parseResult => new FileInfo("inspection-report.txt"),
                Required = true,
            };

            reportFileOption.Aliases.Add("-o");

            this.Options.Add(reportFileOption);

            var includeOperationsOption = new Option<bool>(name: "--include-operations")
            {
                Description = "Include the arguments and return types of operations when determining the interesting classes",
                DefaultValueFactory = parseResult => false,
                Required = false
            };

            this.Options.Add(includeOperationsOption);
        }

        /// <summary>
        /// The Command Handler of the <see cref="ModelInspectionCommand"/>
        /// </summary>
        public class Handler : ReportHandler
        {
            /// <summary>
            /// Initializes a nwe instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="modelInspector">
            /// The (injected) <see cref="IModelInspector"/> that is used to generate the
            /// inspection report
            /// </param>
            /// <param name="versionChecker">
            /// The <see cref="IVersionChecker"/> used to check the github version
            /// </param>
            public Handler(IModelInspector modelInspector, IVersionChecker versionChecker)
                : base(modelInspector, versionChecker)
            {
            }
        }
    }
}
