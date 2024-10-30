// -------------------------------------------------------------------------------------------------
// <copyright file="ModelReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.Packages
{
    using Cache;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using POCO.CommonStructure;
    using POCO;
    using uml4net.POCO.Packages;
    using Readers;

    /// <summary>
    /// The purpose of the <see cref="ModelReader"/> is to read an instance of <see cref="IModel"/>
    /// from the XMI document
    /// </summary>
    public class ModelReader : XmiElementReader<IModel>, IXmiElementReader<IModel>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IPackageImport"/>
        /// </summary>
        public IXmiElementReader<IPackageImport> PackageImportReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IPackage"/>
        /// </summary>
        public IXmiElementReader<IPackage> PackageReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public ModelReader(IXmiReaderCache cache, ILogger<ModelReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IPackage"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        ///  an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IPackage"/>
        /// </returns>
        public override IModel Read(XmlReader xmlReader)
        {
            IModel model = new Model();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Model")
                {
                    throw new XmlException($"The XmiType should be: uml:Model while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Model";
                }

                model.XmiType = xmiType;

                model.Name = xmlReader.GetAttribute("name");

                model.XmiId = xmlReader.GetAttribute("xmi:id") ?? model.Name;
                this.Cache.Add(model.XmiId, model);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "packageImport":
                                using (var packageImportXmlReader = xmlReader.ReadSubtree())
                                {
                                    var packageImport = this.PackageImportReader.Read(packageImportXmlReader);
                                    model.PackageImport.Add(packageImport);
                                }
                                break;
                            case "packagedElement" when xmlReader.GetAttribute("xmi:type") == "uml:Package":
                                using (var packageXmlReader = xmlReader.ReadSubtree())
                                {
                                    var package = this.PackageReader.Read(packageXmlReader);
                                    model.PackagedElement.Add(package);
                                }

                                break;
                        }
                    }
                }
            }

            return model;
        }
    }
}
