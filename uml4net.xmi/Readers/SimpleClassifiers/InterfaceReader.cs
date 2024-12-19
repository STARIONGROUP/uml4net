// -------------------------------------------------------------------------------------------------
//  <copyright file="InterfaceReader.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Readers.SimpleClassifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;

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
    /// The purpose of the <see cref="InterfaceReader"/> is to read an instance of <see cref="IInterface"/>
    /// from the XMI document
    /// </summary>
    public class InterfaceReader : XmiElementReader<IInterface>, IXmiElementReader<IInterface>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterfaceReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public InterfaceReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
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
        public override IInterface Read(XmlReader xmlReader)
        {
            Guard.ThrowIfNull(xmlReader);

            IInterface poco = new Interface();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Interface")
                {
                    throw new XmlException($"The XmiType should be 'uml:Interface' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Interface";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                poco.Name = xmlReader.GetAttribute("name");

                var isAbstract = xmlReader.GetAttribute("isAbstract");
                if (!string.IsNullOrEmpty(isAbstract))
                {
                    poco.IsAbstract = bool.Parse(isAbstract);
                }

                var visibility = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibility))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibility, true);
                }

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "ownedRule":
                                var ownedRule = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.OwnedRule.Add(ownedRule);
                                break;
                            case "ownedAttribute":
                                using (var ownedAttributeXmlReader = xmlReader.ReadSubtree())
                                {
                                    var propertyReader = new PropertyReader(this.Cache, this.LoggerFactory);
                                    var property = propertyReader.Read(ownedAttributeXmlReader);
                                    poco.Attribute.Add(property);
                                }
                                break;
                            case "ownedOperation":
                                using (var ownedOperationXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.Logger.LogInformation("InterfaceReader.ownedOperation not yet implemented");
                                }
                                break;
                            case "generalization":
                                using (var generalizationXmlReader = xmlReader.ReadSubtree())
                                {
                                    var generalizationReader = new GeneralizationReader(this.Cache, this.LoggerFactory);
                                    var generalization = generalizationReader.Read(generalizationXmlReader);
                                    poco.Generalization.Add(generalization);
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"InterfaceReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }
            }

            return poco;
        }
    }
}
