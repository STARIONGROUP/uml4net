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

namespace uml4net.xmi.Readers
{
    using System;
    using System.CodeDom.Compiler;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.InformationFlows;
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Values;
    using uml4net.xmi.Cache;

    /// <summary>
    /// The purpose of the <see cref="ExtensionEndReader"/> is to read an instance of <see cref="IExtensionEnd"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
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
        public ExtensionEndReader(IXmiElementCache cache, ILoggerFactory loggerFactory)
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

            var defaultLineInfo = xmlReader as IXmlLineInfo;

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

                poco.XmiGuid = xmlReader.GetAttribute("xmi:uuid");

                if (!this.Cache.TryAdd(poco.XmiId, poco))
                {
                    this.Logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the cache. The XMI document seems to have duplicate xmi:id values", "ExtensionEnd", poco.XmiId);
                }

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


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "aggregation":
                                var aggregationValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(aggregationValue))
                                {
                                    poco.Aggregation = (AggregationKind)Enum.Parse(typeof(AggregationKind), aggregationValue, true); ;
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
                                var defaultValueValue = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.DefaultValue.Add(defaultValueValue);
                                break;
                            case "deployment":
                                var deploymentValue = (IDeployment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Deployment");
                                poco.Deployment.Add(deploymentValue);
                                break;
                            case "interface":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "interface");
                                break;
                            case "isDerived":
                                var isDerivedValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isDerivedValue))
                                {
                                    poco.IsDerived = bool.Parse(isDerivedValue);
                                }
                                break;
                            case "isDerivedUnion":
                                var isDerivedUnionValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isDerivedUnionValue))
                                {
                                    poco.IsDerivedUnion = bool.Parse(isDerivedUnionValue);
                                }
                                break;
                            case "isID":
                                var isIDValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isIDValue))
                                {
                                    poco.IsID = bool.Parse(isIDValue);
                                }
                                break;
                            case "isLeaf":
                                var isLeafValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }
                                break;
                            case "isOrdered":
                                var isOrderedValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isOrderedValue))
                                {
                                    poco.IsOrdered = bool.Parse(isOrderedValue);
                                }
                                break;
                            case "isReadOnly":
                                var isReadOnlyValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isReadOnlyValue))
                                {
                                    poco.IsReadOnly = bool.Parse(isReadOnlyValue);
                                }
                                break;
                            case "isStatic":
                                var isStaticValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isStaticValue))
                                {
                                    poco.IsStatic = bool.Parse(isStaticValue);
                                }
                                break;
                            case "isUnique":
                                var isUniqueValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isUniqueValue))
                                {
                                    poco.IsUnique = bool.Parse(isUniqueValue);
                                }
                                break;
                            case "lowerValue":
                                var lowerValueValue = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.LowerValue.Add(lowerValueValue);
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpressionValue = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "owningAssociation":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningAssociation");
                                break;
                            case "owningTemplateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case "qualifier":
                                var qualifierValue = (IProperty)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Property");
                                poco.Qualifier.Add(qualifierValue);
                                break;
                            case "redefinedProperty":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedProperty");
                                break;
                            case "subsettedProperty":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "subsettedProperty");
                                break;
                            case "templateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "templateParameter");
                                break;
                            case "type":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "type");
                                break;
                            case "upperValue":
                                var upperValueValue = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.UpperValue.Add(upperValueValue);
                                break;
                            case "visibility":
                                var visibilityValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true); ;
                                }
                                break;
                            default:
                                throw new NotSupportedException($"ExtensionEndReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
