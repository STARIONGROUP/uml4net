// -------------------------------------------------------------------------------------------------
// <copyright file="ModelReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using SimpleClassifiers;
    using StructuredClassifiers;
    using uml4net;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Readers.Classification;
    using uml4net.xmi.Readers.CommonStructure;
    using uml4net.xmi.Readers.Values;

    /// <summary>
    /// The purpose of the <see cref="ModelReader"/> is to read an instance of <see cref="IModel"/>
    /// from the XMI document
    /// </summary>
    public class ModelReader : XmiElementReader<IModel>, IXmiElementReader<IModel>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public ModelReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
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
                                    var packageImportReader = new PackageImportReader(this.Cache, this.LoggerFactory);
                                    var packageImport = packageImportReader.Read(packageImportXmlReader);
                                    model.PackageImport.Add(packageImport);
                                }
                                break;
                            case "packagedElement":
                                this.ReadPackagedElements(model, xmlReader);
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"ModelReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
                        var associationReader = new AssociationReader(this.Cache, this.LoggerFactory);
                        var association = associationReader.Read(associationXmlReader);
                        model.PackagedElement.Add(association);
                    }
                    break;
                case "uml:Class":
                    using (var classXmlReader = xmlReader.ReadSubtree())
                    {
                        var classReader = new ClassReader(this.Cache, this.LoggerFactory);
                        var packagedElement = classReader.Read(classXmlReader);
                        model.PackagedElement.Add(packagedElement);
                    }
                    break;
                case "uml:Enumeration":
                    using (var enumerationXmlReader = xmlReader.ReadSubtree())
                    {
                        var enumerationReader = new EnumerationReader(this.Cache, this.LoggerFactory);
                        var enumeration = enumerationReader.Read(enumerationXmlReader);
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
                        var primitiveTypeReader = new PrimitiveTypeReader(this.Cache, this.LoggerFactory);
                        var primitive = primitiveTypeReader.Read(primitiveTypeXmlReader);
                        model.PackagedElement.Add(primitive);
                    }
                    break;
                case "uml:Interface":
                    using (var interfaceXmlReader = xmlReader.ReadSubtree())
                    {
                        var interfaceReader = new InterfaceReader(this.Cache, this.LoggerFactory);
                        var @interface = interfaceReader.Read(interfaceXmlReader);
                        model.PackagedElement.Add(@interface);
                    }
                    break;
                case "uml:Realization":
                    using (var realizationXmlReader = xmlReader.ReadSubtree())
                    {
                        var realizationReader = new RealizationReader(this.Cache, this.LoggerFactory);
                        var realization = realizationReader.Read(realizationXmlReader);
                        model.PackagedElement.Add(realization);
                    }
                    break;
                default:
                    var defaultLineInfo = xmlReader as IXmlLineInfo;
                    throw new NotSupportedException($"ModelReader.ReadPackagedElements: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
            }
        }
    }
}
