// -------------------------------------------------------------------------------------------------
// <copyright file="ExecutionOccurrenceSpecificationReader.cs" company="Starion Group S.A.">
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
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;

    /// <summary>
    /// The purpose of the <see cref="ExecutionOccurrenceSpecificationReader"/> is to read an instance of <see cref="IExecutionOccurrenceSpecification"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ExecutionOccurrenceSpecificationReader : XmiElementReader<IExecutionOccurrenceSpecification>, IXmiElementReader<IExecutionOccurrenceSpecification>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionOccurrenceSpecificationReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ExecutionOccurrenceSpecificationReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IExecutionOccurrenceSpecification"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IExecutionOccurrenceSpecification"/>
        /// </returns>
        public override IExecutionOccurrenceSpecification Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            IExecutionOccurrenceSpecification poco = new ExecutionOccurrenceSpecification();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ExecutionOccurrenceSpecification")
                {
                    throw new XmlException($"The XmiType should be 'uml:ExecutionOccurrenceSpecification' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ExecutionOccurrenceSpecification";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                poco.XmiGuid = xmlReader.GetAttribute("xmi:uuid");

                this.Cache.Add(poco.XmiId, poco);

                var coveredXmlAttribute = xmlReader.GetAttribute("covered");
                if (!string.IsNullOrEmpty(coveredXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("covered", coveredXmlAttribute);
                }

                var enclosingInteractionXmlAttribute = xmlReader.GetAttribute("enclosingInteraction");
                if (!string.IsNullOrEmpty(enclosingInteractionXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("enclosingInteraction", enclosingInteractionXmlAttribute);
                }

                var enclosingOperandXmlAttribute = xmlReader.GetAttribute("enclosingOperand");
                if (!string.IsNullOrEmpty(enclosingOperandXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("enclosingOperand", enclosingOperandXmlAttribute);
                }

                var executionXmlAttribute = xmlReader.GetAttribute("execution");
                if (!string.IsNullOrEmpty(executionXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("execution", executionXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var toAfterXmlAttribute = xmlReader.GetAttribute("toAfter");
                if (!string.IsNullOrEmpty(toAfterXmlAttribute))
                {
                    var toAfterXmlAttributeValues = toAfterXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("toAfter", toAfterXmlAttributeValues);
                }

                var toBeforeXmlAttribute = xmlReader.GetAttribute("toBefore");
                if (!string.IsNullOrEmpty(toBeforeXmlAttribute))
                {
                    var toBeforeXmlAttributeValues = toBeforeXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("toBefore", toBeforeXmlAttributeValues);
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
                            case "covered":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "covered");
                                break;
                            case "enclosingInteraction":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "enclosingInteraction");
                                break;
                            case "enclosingOperand":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "enclosingOperand");
                                break;
                            case "execution":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "execution");
                                break;
                            case "generalOrdering":
                                var generalOrderingValue = (IGeneralOrdering)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:GeneralOrdering");
                                poco.GeneralOrdering.Add(generalOrderingValue);
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
                            case "toAfter":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "toAfter");
                                break;
                            case "toBefore":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "toBefore");
                                break;
                            case "visibility":
                                var visibilityValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true); ;
                                }
                                break;
                            default:
                                throw new NotSupportedException($"ExecutionOccurrenceSpecificationReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
