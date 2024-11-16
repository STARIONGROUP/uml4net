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

namespace uml4net.xmi.Readers.Packages
{
    using Cache;
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using POCO.SimpleClassifiers;
    using POCO.StructuredClassifiers;
    using POCO;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Packages;

    using Readers;

    /// <summary>
    /// The purpose of the <see cref="PackageReader"/> is to read an instance of <see cref="IPackage"/>
    /// from the XMI document
    /// </summary>
    public class PackageReader : XmiElementReader<IPackage>, IXmiElementReader<IPackage>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IClass> ClassReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IEnumeration"/>
        /// </summary>
        public IXmiElementReader<IEnumeration> EnumerationReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IPackageImport"/>
        /// </summary>
        public IXmiElementReader<IPackageImport> PackageImportReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IPrimitiveType"/>
        /// </summary>
        public IXmiElementReader<IPrimitiveType> PrimitiveReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IComment> CommentReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IInterface"/>
        /// </summary>
        public IXmiElementReader<IInterface> InterfaceReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IRealization"/>
        /// </summary>
        public IXmiElementReader<IRealization> RealizationReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IAssociation"/>
        /// </summary>
        public IXmiElementReader<IAssociation> AssociationReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public PackageReader(IXmiReaderCache cache, ILogger<PackageReader> logger)
            : base(cache, logger)
        {
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
        public override IPackage Read(XmlReader xmlReader)
        {
            IPackage package = new Package();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Package")
                {
                    throw new XmlException($"The XmiType should be: uml:Package while it is {xmiType}");
                }

                package.XmiType = xmiType;

                package.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(package.XmiId, package);

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
                                    var comment = this.CommentReader.Read(ownedCommentXmlReader);
                                    package.OwnedComment.Add(comment);
                                }
                                break;
                            case "elementImport":
                                using (var elementImportXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.Logger.LogInformation("PackageReader.elementImport not yet implemented");
                                }
                                break;
                            case "ownedRule":
                                using (var ownedRuleXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.Logger.LogInformation("PackageReader.ownedRule not yet implemented");
                                }
                                break;
                            case "packageImport":
                                using (var packageImportXmlReader = xmlReader.ReadSubtree())
                                {
                                    var packageImport = this.PackageImportReader.Read(packageImportXmlReader);
                                    package.PackageImport.Add(packageImport);
                                }
                                break;
                            case "templateBinding":
                                using (var templateBindingXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.Logger.LogInformation("PackageReader.TemplateBinding not yet implemented");
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
        /// Reads the packaged elements
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
                        var association = this.AssociationReader.Read(associationXmlReader);
                        package.PackagedElement.Add(association);
                    }
                    break;
                case "uml:Class":
                    using (var classXmlReader = xmlReader.ReadSubtree())
                    {
                        var packagedElement = this.ClassReader.Read(classXmlReader);
                        package.PackagedElement.Add(packagedElement);
                    }
                    break;
                case "uml:Enumeration":
                    using (var enumerationXmlReader = xmlReader.ReadSubtree())
                    {
                        var enumeration = this.EnumerationReader.Read(enumerationXmlReader);
                        package.PackagedElement.Add(enumeration);
                    }
                    break;
                case "uml:Package":
                    using (var packageXmlReader = xmlReader.ReadSubtree())
                    {
                        var packagedElement = this.Read(packageXmlReader);
                        package.PackagedElement.Add(packagedElement);
                    }
                    break;
                case "uml:PrimitiveType":
                    using (var primitiveTypeXmlReader = xmlReader.ReadSubtree())
                    {
                        var primitive = this.PrimitiveReader.Read(primitiveTypeXmlReader);
                        package.PackagedElement.Add(primitive);
                    }
                    break;
                case "uml:Interface":
                    using (var interfaceXmlReader = xmlReader.ReadSubtree())
                    {
                        var @interface = this.InterfaceReader.Read(interfaceXmlReader);
                        package.PackagedElement.Add(@interface);
                    }
                    break;
                case "uml:Realization":
                    using (var realizationXmlReader = xmlReader.ReadSubtree())
                    {
                        var realization = this.RealizationReader.Read(realizationXmlReader);
                        package.PackagedElement.Add(realization);
                    }
                    break;
                default: 
                    throw new NotImplementedException(xmiType);
            }
        }
    }
}
