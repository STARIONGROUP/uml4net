// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.Classification
{
    using System;
    using System.Collections.Generic;
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
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="ParameterReader"/> is to read an instance of <see cref="IParameter"/>
    /// from the XMI document
    /// </summary>
    public class ParameterReader : XmiElementReader<IParameter>, IXmiElementReader<IParameter>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ParameterReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IParameter"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IParameter"/>
        /// </returns>
        public override IParameter Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IParameter poco = new Parameter();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Parameter")
                {
                    throw new XmlException($"The XmiType should be 'uml:Parameter' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Parameter";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var directionXmlAttribute = xmlReader.GetAttribute("direction");
                if (!string.IsNullOrEmpty(directionXmlAttribute))
                {
                    poco.Direction = (ParameterDirectionKind)Enum.Parse(typeof(ParameterDirectionKind), directionXmlAttribute, true);
                }

                var effectXmlAttribute = xmlReader.GetAttribute("effect");
                if (!string.IsNullOrEmpty(effectXmlAttribute))
                {
                    poco.Effect = (ParameterEffectKind)Enum.Parse(typeof(ParameterEffectKind), effectXmlAttribute, true);
                }

                var isExceptionXmlAttribute = xmlReader.GetAttribute("isException");
                if (!string.IsNullOrEmpty(isExceptionXmlAttribute))
                {
                    poco.IsException = bool.Parse(isExceptionXmlAttribute);
                }

                var isOrderedXmlAttribute = xmlReader.GetAttribute("isOrdered");
                if (!string.IsNullOrEmpty(isOrderedXmlAttribute))
                {
                    poco.IsOrdered = bool.Parse(isOrderedXmlAttribute);
                }

                var isStreamXmlAttribute = xmlReader.GetAttribute("isStream");
                if (!string.IsNullOrEmpty(isStreamXmlAttribute))
                {
                    poco.IsStream = bool.Parse(isStreamXmlAttribute);
                }

                var isUniqueXmlAttribute = xmlReader.GetAttribute("isUnique");
                if (!string.IsNullOrEmpty(isUniqueXmlAttribute))
                {
                    poco.IsUnique = bool.Parse(isUniqueXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var operationXmlAttribute = xmlReader.GetAttribute("operation");
                if (!string.IsNullOrEmpty(operationXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("operation", operationXmlAttribute);
                }

                var owningTemplateParameterXmlAttribute = xmlReader.GetAttribute("owningTemplateParameter");
                if (!string.IsNullOrEmpty(owningTemplateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", owningTemplateParameterXmlAttribute);
                }

                var parameterSetXmlAttribute = xmlReader.GetAttribute("parameterSet");
                if (!string.IsNullOrEmpty(parameterSetXmlAttribute))
                {
                    var parameterSetXmlAttributeValues = parameterSetXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("parameterSet", parameterSetXmlAttributeValues);
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


                var parameterSetValues = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "defaultValue":
                                var defaultValueValue = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.DefaultValue.Add(defaultValueValue);
                                break;
                            case "direction":
                                var directionValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(directionValue))
                                {
                                    poco.Direction = (ParameterDirectionKind)Enum.Parse(typeof(ParameterDirectionKind), directionValue, true); ;
                                }
                                break;
                            case "effect":
                                var effectValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(effectValue))
                                {
                                    poco.Effect = (ParameterEffectKind)Enum.Parse(typeof(ParameterEffectKind), effectValue, true); ;
                                }
                                break;
                            case "isException":
                                var isExceptionValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isExceptionValue))
                                {
                                    poco.IsException = bool.Parse(isExceptionValue);
                                }
                                break;
                            case "isOrdered":
                                var isOrderedValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isOrderedValue))
                                {
                                    poco.IsOrdered = bool.Parse(isOrderedValue);
                                }
                                break;
                            case "isStream":
                                var isStreamValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isStreamValue))
                                {
                                    poco.IsStream = bool.Parse(isStreamValue);
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
                            case "operation":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "operation");
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "owningTemplateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case "parameterSet":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, parameterSetValues, "parameterSet");
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
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"ParameterReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (parameterSetValues.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("parameterSet", parameterSetValues);
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
