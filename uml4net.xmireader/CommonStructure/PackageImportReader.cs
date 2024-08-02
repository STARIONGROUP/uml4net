// -------------------------------------------------------------------------------------------------
// <copyright file="PackageImportReader.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.CommonStructure
{
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Packages;
    using uml4net.xmi.Packages;

    /// <summary>
    /// The purpose of the <see cref="PackageImportReader"/> is to read an instance of <see cref="IPackageImport"/>
    /// from the XMI document
    /// </summary>
    public class PackageImportReader
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<PackageImportReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageImportReader"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public PackageImportReader(ILoggerFactory loggerFactory = null)
        {
            this.loggerFactory = loggerFactory;

            this.logger = this.loggerFactory == null ? NullLogger<PackageImportReader>.Instance : this.loggerFactory.CreateLogger<PackageImportReader>();
        }

        /// <summary>
        /// Reads the <see cref="IPackageImport"/> 
        /// </summary>
        /// <param name="xmlreader">
        /// the active xmlreader
        /// </param>
        /// <returns>
        /// an instance of <see cref="IPackageImport"/>
        /// </returns>
        public IPackageImport Read(XmlReader xmlreader)
        { 
            var packageImport = new PackageImport();

            return packageImport;
        }
    }
}
