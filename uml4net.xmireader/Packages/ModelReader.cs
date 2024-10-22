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

namespace uml4net.xmi.Packages
{
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    
    using uml4net.POCO;
    using uml4net.POCO.Packages;
    using uml4net.xmi.CommonStructure;

    /// <summary>
    /// The purpose of the <see cref="ModelReader"/> is to read an instance of <see cref="IModel"/>
    /// from the XMI document
    /// </summary>
    public class ModelReader : XmiElementReader
    {
        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<ModelReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public ModelReader(Dictionary<string, IXmiElement> cache, ILoggerFactory loggerFactory = null)
            : base(cache, loggerFactory)
        {
            this.logger = this.loggerFactory == null ? NullLogger<ModelReader>.Instance : this.loggerFactory.CreateLogger<ModelReader>();
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
        public IModel Read(XmlReader xmlReader)
        { 
            IModel model = new Model();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && (xmiType != "uml:Model"))
                {
                    throw new XmlException($"The XmiType should be: uml:Model while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Model";
                }

                model.XmiType = xmiType;

                model.XmiId = xmlReader.GetAttribute("xmi:id");

                this.cache.Add(model.XmiId, model);

                model.Name = xmlReader.GetAttribute("name");

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {

                        switch (xmlReader.LocalName)
                        {
                            case "packageImport":
                                using (var packageImportXmlReader = xmlReader.ReadSubtree())
                                {
                                    var packageImportReader = new PackageImportReader(this.cache, this.loggerFactory);
                                    var packageImport = packageImportReader.Read(packageImportXmlReader);
                                    model.PackageImport.Add(packageImport);
                                }
                                break;
                            case "packagedElement":
                                using (var packagedElementXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.logger.LogInformation("ModelReader.packagedElement not yet implemented");
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
