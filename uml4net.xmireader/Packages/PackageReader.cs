// -------------------------------------------------------------------------------------------------
// <copyright file="PackageReader.cs" company="Starion Group S.A.">
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
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Packages;

    using uml4net.xmi.CommonStructure;
    using uml4net.xmi.SimpleClassifiers;
    using uml4net.xmi.StructuredClassifiers;

    /// <summary>
    /// The purpose of the <see cref="PackageReader"/> is to read an instance of <see cref="IPackage"/>
    /// from the XMI document
    /// </summary>
    public class PackageReader
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<PackageReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageReader"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public PackageReader(ILoggerFactory loggerFactory = null)
        {
            this.loggerFactory = loggerFactory;

            this.logger = this.loggerFactory == null ? NullLogger<PackageReader>.Instance : this.loggerFactory.CreateLogger<PackageReader>();
        }

        /// <summary>
        /// Reads the <see cref="IPackage"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IPackage"/>
        /// </returns>
        public IPackage Read(XmlReader xmlReader)
        {
            IPackage package = new Package();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                package.XmiId = xmlReader.GetAttribute("xmi:id");

                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Package")
                {
                    // TODO come up with a better exception here
                    throw new XmlException($"The XmiType should be: uml:Package while it is {xmiType}");
                }

                package.XmiType = xmlReader.GetAttribute("xmi:type");

                package.Name = xmlReader.GetAttribute("name");

                var visibility = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibility))
                {
                    package.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibility, true);
                }

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "ownedComment":
                                using (var ownedCommentXmlReader = xmlReader.ReadSubtree())
                                {
                                    var commentReader = new CommentReader(this.loggerFactory);
                                    var comment = commentReader.Read(ownedCommentXmlReader);
                                    package.OwnedComment.Add(comment);
                                }
                                break;
                            case "elementImport":
                                using (var elementImportXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.logger.LogInformation("PackageReader.elementImport not yet implemented");
                                }
                                break;
                            case "ownedRule":
                                using (var ownedRuleXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.logger.LogInformation("PackageReader.ownedRule not yet implemented");
                                }
                                break;
                            case "packageImport":
                                using (var packageImportXmlReader = xmlReader.ReadSubtree())
                                {
                                    var packageImportReader = new PackageImportReader(this.loggerFactory);
                                    var packageImport = packageImportReader.Read(packageImportXmlReader);
                                    package.PackageImport.Add(packageImport);
                                }
                                break;
                            case "templateBinding":
                                using (var templateBindingXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.logger.LogInformation("PackageReader.TemplateBinding not yet implemented");
                                }
                                break;
                            case "packagedElement":
                                this.ReadPackagedElements(package, xmlReader);
                                break;
                            default:
                                throw new NotImplementedException($"PackageReader: {xmlReader.LocalName}");
                        }
                    }
                }
            }

            return package;
        }

        /// <summary>
        /// Read the packaged elements
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that the nested packaged elements are added to
        /// </param>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        private void ReadPackagedElements(IPackage package, XmlReader xmlReader)
        {
            var xmiType = xmlReader.GetAttribute("xmi:type");

            switch (xmiType)
            {
                case "uml:Association":
                    using (var associationXmlReader = xmlReader.ReadSubtree())
                    {
                        this.logger.LogDebug("uml:Association not yet implements");
                    }
                    break;
                case "uml:Class":
                    using (var classXmlReader = xmlReader.ReadSubtree())
                    {
                        var classReader = new ClassReader();
                        var packagedElement = classReader.Read(classXmlReader);
                        package.PackagedElement.Add(packagedElement);
                    }
                    break;
                case "uml:Enumeration":
                    using (var enumerationXmlReader = xmlReader.ReadSubtree())
                    {
                        var enumerationReader = new EnumerationReader();
                        var enumeration = enumerationReader.Read(enumerationXmlReader);
                        package.PackagedElement.Add(enumeration);
                    }
                    break;
                case "uml:Package":
                    using (var packageXmlReader = xmlReader.ReadSubtree())
                    {
                        var packageReader = new PackageReader();
                        var packagedElement = packageReader.Read(packageXmlReader);
                        package.PackagedElement.Add(packagedElement);
                    }
                    break;
                case "uml:PrimitiveType":
                    using (var primitiveTypeXmlReader = xmlReader.ReadSubtree())
                    {
                        this.logger.LogDebug("uml:PrimitiveType not yet implements");
                    }
                    break;
                default:
                    throw new NotImplementedException(xmiType);
            }
        }
    }
}
