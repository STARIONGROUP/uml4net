// -------------------------------------------------------------------------------------------------
// <copyright file="ExtensionEndReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Readers.Packages
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

    /// <summary>
    /// The purpose of the <see cref="ExtensionEndReader"/> is to read an instance of <see cref="IExtensionEnd"/>
    /// from the XMI document
    /// </summary>
    public class ExtensionEndReader : XmiElementReader<IExtensionEnd>, IXmiElementReader<IExtensionEnd>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionEndReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ExtensionEndReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IExtensionEnd"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IExtensionEnd"/>
        /// </returns>
        public override IExtensionEnd Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IExtensionEnd poco = new ExtensionEnd();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ExtensionEnd")
                {
                    throw new XmlException($"The XmiType should be 'uml:ExtensionEnd' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ExtensionEnd";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var aggregationXmlAttribute = xmlReader.GetAttribute("aggregation");
                if (!string.IsNullOrEmpty(aggregationXmlAttribute))
                {
                    poco.Aggregation = (AggregationKind)Enum.Parse(typeof(AggregationKind), aggregationXmlAttribute, true);
                }

                var associationXmlAttribute = xmlReader.GetAttribute("association");
                if (!string.IsNullOrEmpty(associationXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("association", associationXmlAttribute);
                }

                var associationEndXmlAttribute = xmlReader.GetAttribute("associationEnd");
                if (!string.IsNullOrEmpty(associationEndXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("associationEnd", associationEndXmlAttribute);
                }

                var classXmlAttribute = xmlReader.GetAttribute("class");
                if (!string.IsNullOrEmpty(classXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("class", classXmlAttribute);
                }

                var datatypeXmlAttribute = xmlReader.GetAttribute("datatype");
                if (!string.IsNullOrEmpty(datatypeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("datatype", datatypeXmlAttribute);
                }

                var interfaceXmlAttribute = xmlReader.GetAttribute("interface");
                if (!string.IsNullOrEmpty(interfaceXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("interface", interfaceXmlAttribute);
                }

                var isDerivedXmlAttribute = xmlReader.GetAttribute("isDerived");
                if (!string.IsNullOrEmpty(isDerivedXmlAttribute))
                {
                    poco.IsDerived = bool.Parse(isDerivedXmlAttribute);
                }

                var isDerivedUnionXmlAttribute = xmlReader.GetAttribute("isDerivedUnion");
                if (!string.IsNullOrEmpty(isDerivedUnionXmlAttribute))
                {
                    poco.IsDerivedUnion = bool.Parse(isDerivedUnionXmlAttribute);
                }

                var isIDXmlAttribute = xmlReader.GetAttribute("isID");
                if (!string.IsNullOrEmpty(isIDXmlAttribute))
                {
                    poco.IsID = bool.Parse(isIDXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf");
                if (!string.IsNullOrEmpty(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var isOrderedXmlAttribute = xmlReader.GetAttribute("isOrdered");
                if (!string.IsNullOrEmpty(isOrderedXmlAttribute))
                {
                    poco.IsOrdered = bool.Parse(isOrderedXmlAttribute);
                }

                var isReadOnlyXmlAttribute = xmlReader.GetAttribute("isReadOnly");
                if (!string.IsNullOrEmpty(isReadOnlyXmlAttribute))
                {
                    poco.IsReadOnly = bool.Parse(isReadOnlyXmlAttribute);
                }

                var isStaticXmlAttribute = xmlReader.GetAttribute("isStatic");
                if (!string.IsNullOrEmpty(isStaticXmlAttribute))
                {
                    poco.IsStatic = bool.Parse(isStaticXmlAttribute);
                }

                var isUniqueXmlAttribute = xmlReader.GetAttribute("isUnique");
                if (!string.IsNullOrEmpty(isUniqueXmlAttribute))
                {
                    poco.IsUnique = bool.Parse(isUniqueXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var owningAssociationXmlAttribute = xmlReader.GetAttribute("owningAssociation");
                if (!string.IsNullOrEmpty(owningAssociationXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("owningAssociation", owningAssociationXmlAttribute);
                }

                var owningTemplateParameterXmlAttribute = xmlReader.GetAttribute("owningTemplateParameter");
                if (!string.IsNullOrEmpty(owningTemplateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", owningTemplateParameterXmlAttribute);
                }

                var redefinedPropertyXmlAttribute = xmlReader.GetAttribute("redefinedProperty");
                if (!string.IsNullOrEmpty(redefinedPropertyXmlAttribute))
                {
                    var redefinedPropertyXmlAttributeValues = redefinedPropertyXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedProperty", redefinedPropertyXmlAttributeValues);
                }

                var subsettedPropertyXmlAttribute = xmlReader.GetAttribute("subsettedProperty");
                if (!string.IsNullOrEmpty(subsettedPropertyXmlAttribute))
                {
                    var subsettedPropertyXmlAttributeValues = subsettedPropertyXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("subsettedProperty", subsettedPropertyXmlAttributeValues);
                }

                var templateParameterXmlAttribute = xmlReader.GetAttribute("templateParameter");
                if (!string.IsNullOrEmpty(templateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", templateParameterXmlAttribute);
                }

                var typeXmlAttribute = xmlReader.GetAttribute("type");
                if (!string.IsNullOrEmpty(typeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("type", typeXmlAttribute);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibilityXmlAttribute))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlAttribute, true);
                }


                var redefinedProperty = new List<string>();
                var subsettedProperty = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "aggregation":
                                var aggregationXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(aggregationXmlElement))
                                {
                                    poco.Aggregation = (AggregationKind)Enum.Parse(typeof(AggregationKind), aggregationXmlElement, true); ;
                                }
                                break;
                            case "association":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "association");
                                break;
                            case "associationEnd":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "associationEnd");
                                break;
                            case "class":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "class");
                                break;
                            case "datatype":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "datatype");
                                break;
                            case "defaultValue":
                                var defaultValue = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.DefaultValue.Add(defaultValue);
                                break;
                            case "deployment":
                                var deployment = (IDeployment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Deployment");
                                poco.Deployment.Add(deployment);
                                break;
                            case "interface":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "interface");
                                break;
                            case "isDerived":
                                var isDerivedXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isDerivedXmlElement))
                                {
                                    poco.IsDerived = bool.Parse(isDerivedXmlElement);
                                }
                                break;
                            case "isDerivedUnion":
                                var isDerivedUnionXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isDerivedUnionXmlElement))
                                {
                                    poco.IsDerivedUnion = bool.Parse(isDerivedUnionXmlElement);
                                }
                                break;
                            case "isID":
                                var isIDXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isIDXmlElement))
                                {
                                    poco.IsID = bool.Parse(isIDXmlElement);
                                }
                                break;
                            case "isLeaf":
                                var isLeafXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isLeafXmlElement))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafXmlElement);
                                }
                                break;
                            case "isOrdered":
                                var isOrderedXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isOrderedXmlElement))
                                {
                                    poco.IsOrdered = bool.Parse(isOrderedXmlElement);
                                }
                                break;
                            case "isReadOnly":
                                var isReadOnlyXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isReadOnlyXmlElement))
                                {
                                    poco.IsReadOnly = bool.Parse(isReadOnlyXmlElement);
                                }
                                break;
                            case "isStatic":
                                var isStaticXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isStaticXmlElement))
                                {
                                    poco.IsStatic = bool.Parse(isStaticXmlElement);
                                }
                                break;
                            case "isUnique":
                                var isUniqueXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isUniqueXmlElement))
                                {
                                    poco.IsUnique = bool.Parse(isUniqueXmlElement);
                                }
                                break;
                            case "lowerValue":
                                var lowerValue = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.LowerValue.Add(lowerValue);
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpression = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpression);
                                break;
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "owningAssociation":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningAssociation");
                                break;
                            case "owningTemplateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case "qualifier":
                                var qualifier = (IProperty)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Property");
                                poco.Qualifier.Add(qualifier);
                                break;
                            case "redefinedProperty":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, redefinedProperty, "redefinedProperty");
                                break;
                            case "subsettedProperty":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, subsettedProperty, "subsettedProperty");
                                break;
                            case "templateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "templateParameter");
                                break;
                            case "type":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "type");
                                break;
                            case "upperValue":
                                var upperValue = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.UpperValue.Add(upperValue);
                                break;
                            case "visibility":
                                var visibilityXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityXmlElement))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlElement, true); ;
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"ExtensionEndReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (redefinedProperty.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedProperty", redefinedProperty);
                }

                if (subsettedProperty.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("subsettedProperty", subsettedProperty);
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
