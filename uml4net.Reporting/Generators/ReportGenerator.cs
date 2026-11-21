// -------------------------------------------------------------------------------------------------
// <copyright file="ReportGenerator.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Reporting.Generators
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.Packages;
    using uml4net.xmi;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Extender;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Structure.Readers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// abstract class from which all report generators need to derive
    /// </summary>
    public abstract class ReportGenerator
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<ReportGenerator> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportGenerator"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        protected ReportGenerator(ILoggerFactory loggerFactory = null)
        {
            this.loggerFactory = loggerFactory;

            this.logger = this.loggerFactory == null ? NullLogger<ReportGenerator>.Instance : this.loggerFactory.CreateLogger<ReportGenerator>();
        }

        /// <summary>
        /// Verifies whether the extension of the <paramref name="outputPath"/> is valid or not
        /// </summary>
        /// <param name="outputPath">
        /// The subject <see cref="FileInfo"/> to check
        /// </param>
        /// <returns>
        /// A Tuple of bool and string, where the string contains a description of the verification.
        /// Either stating that the extension is valid or not.
        /// </returns>
        public abstract Tuple<bool, string> IsValidReportExtension(FileInfo outputPath);

        /// <summary>
        /// Loads the root UML package from the provided model
        /// </summary>
        /// <param name="modelPath">
        /// the path to the Uml model that is to be loaded
        /// </param>
        /// <param name="rootDirectory">
        /// The base directory path used as the local root for resolving referenced XMI files.
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
        /// a list of <see cref="IPackage"/>s
        /// </returns>
        protected XmiReaderResult LoadPackages(FileInfo modelPath, DirectoryInfo rootDirectory, bool useStrictReading, Dictionary<string, string> pathMap)
        {
            if (modelPath == null)
            {
                throw new ArgumentNullException(nameof(modelPath));
            }

            if (rootDirectory == null)
            {
                throw new ArgumentNullException(nameof(rootDirectory));
            }

            this.logger.LogInformation("Loading UML model from {0}", modelPath.FullName);

            var readerBuilder = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = rootDirectory.FullName;
                    x.UseStrictReading = useStrictReading;
                    x.PathMaps = pathMap;
                })
                .WithLogger(this.loggerFactory);

            readerBuilder.WithExtender<EnterpriseArchitectExtenderReader>();
            readerBuilder.WithExtensionContentReaderFacade<ExtensionContentReaderFacade>();

            using var reader = readerBuilder.Build();
            return reader.Read(modelPath.FullName);
        }
    }
}
