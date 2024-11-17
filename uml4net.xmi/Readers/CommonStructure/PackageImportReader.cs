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

namespace uml4net.xmi.Readers.CommonStructure
{
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net.POCO;
    using uml4net.POCO.CommonStructure;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="PackageImportReader"/> is to read an instance of <see cref="IPackageImport"/>
    /// from the XMI document
    /// </summary>
    public class PackageImportReader : XmiElementReader<IPackageImport>, IXmiElementReader<IPackageImport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PackageImportReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The <see cref="ILogger{T}"/>
        /// </param>
        public PackageImportReader(IXmiReaderCache cache, ILogger<PackageImportReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IPackageImport"/> 
        /// </summary>
        /// <param name="xmlReader">
        /// the active <see cref="XmlReader"/>>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IPackageImport"/>
        /// </returns>
        public override IPackageImport Read(XmlReader xmlReader)
        {
            var packageImport = new PackageImport();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                packageImport.XmiId = xmlReader.GetAttribute("xmi:id");

                var importedPackage = xmlReader.GetAttribute("importedPackage");
                if (!string.IsNullOrEmpty(importedPackage))
                {
                    packageImport.SingleValueReferencePropertyIdentifiers.Add("ImportedPackage", importedPackage);
                }

                var importingNamespace = xmlReader.GetAttribute("importingNamespace");
                if (!string.IsNullOrEmpty(importingNamespace))
                {
                    packageImport.SingleValueReferencePropertyIdentifiers.Add("ImportingNamespace", importingNamespace);
                }

                string visibility = xmlReader.GetAttribute("visibility");
                if (visibility != null)
                {
                    packageImport.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibility, true);
                }
            }

            return packageImport;
        }
    }
}
