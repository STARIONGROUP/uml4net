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
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.Utils;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="ModelReader"/> is to read an instance of <see cref="IModel"/>
    /// from the XMI document
    /// </summary>
    public class ModelReader : XmiElementReader<IModel>, IXmiElementReader<IModel>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IAssociation"/>
        /// </summary>
        public IXmiElementReader<IAssociation> AssociationReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IClass> ClassReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IEnumeration"/>
        /// </summary>
        public IXmiElementReader<IEnumeration> EnumerationReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IInterface"/>
        /// </summary>
        public IXmiElementReader<IInterface> InterfaceReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IPackageImport"/>
        /// </summary>
        public IXmiElementReader<IPackageImport> PackageImportReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IPackage"/>
        /// </summary>
        public IXmiElementReader<IPackage> PackageReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IPrimitiveType"/>
        /// </summary>
        public IXmiElementReader<IPrimitiveType> PrimitiveTypeReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IRealization"/>
        /// </summary>
        public IXmiElementReader<IRealization> RealizationReader { get; set; }

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
            Guard.ThrowIfNull(xmlReader);

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

                model.URI = xmlReader.GetAttribute("URI");

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
                            case "packagedElement":
                                this.ReadPackagedElements(model, xmlReader);
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotImplementedException($"ModelReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }
            }

            return model;
        }

        /// <summary>
        /// Reads the packaged elements
        /// </summary>
        /// <param name="model">
        /// The <see cref="IModel"/> that the nested packaged elements are added to
        /// </param>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        private void ReadPackagedElements(IModel model, XmlReader xmlReader)
        {
            var xmiType = xmlReader.GetAttribute("xmi:type");

            switch (xmiType)
            {
                case "uml:Association":
                    using (var associationXmlReader = xmlReader.ReadSubtree())
                    {
                        var association = this.AssociationReader.Read(associationXmlReader);
                        model.PackagedElement.Add(association);
                    }
                    break;
                case "uml:Class":
                    using (var classXmlReader = xmlReader.ReadSubtree())
                    {
                        var packagedElement = this.ClassReader.Read(classXmlReader);
                        model.PackagedElement.Add(packagedElement);
                    }
                    break;
                case "uml:Enumeration":
                    using (var enumerationXmlReader = xmlReader.ReadSubtree())
                    {
                        var enumeration = this.EnumerationReader.Read(enumerationXmlReader);
                        model.PackagedElement.Add(enumeration);
                    }
                    break;
                case "uml:Package":
                    using (var packageXmlReader = xmlReader.ReadSubtree())
                    {
                        var packagedElement = this.Read(packageXmlReader);
                        model.PackagedElement.Add(packagedElement);
                    }
                    break;
                case "uml:PrimitiveType":
                    using (var primitiveTypeXmlReader = xmlReader.ReadSubtree())
                    {
                        var primitive = this.PrimitiveTypeReader.Read(primitiveTypeXmlReader);
                        model.PackagedElement.Add(primitive);
                    }
                    break;
                case "uml:Interface":
                    using (var interfaceXmlReader = xmlReader.ReadSubtree())
                    {
                        var @interface = this.InterfaceReader.Read(interfaceXmlReader);
                        model.PackagedElement.Add(@interface);
                    }
                    break;
                case "uml:Realization":
                    using (var realizationXmlReader = xmlReader.ReadSubtree())
                    {
                        var realization = this.RealizationReader.Read(realizationXmlReader);
                        model.PackagedElement.Add(realization);
                    }
                    break;
                default:
                    var defaultLineInfo = xmlReader as IXmlLineInfo;
                    throw new NotImplementedException($"ModelReader.ReadPackagedElements: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
            }
        }
    }
}
