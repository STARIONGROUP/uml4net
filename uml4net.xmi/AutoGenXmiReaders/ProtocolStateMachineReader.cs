﻿// -------------------------------------------------------------------------------------------------
// <copyright file="ProtocolStateMachineReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ProtocolStateMachineReader"/> is to read an instance of <see cref="IProtocolStateMachine"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ProtocolStateMachineReader : XmiElementReader<IProtocolStateMachine>, IXmiElementReader<IProtocolStateMachine>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolStateMachineReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ProtocolStateMachineReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IProtocolStateMachine"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IProtocolStateMachine"/>
        /// </returns>
        public override IProtocolStateMachine Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            IProtocolStateMachine poco = new ProtocolStateMachine();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ProtocolStateMachine")
                {
                    throw new XmlException($"The XmiType should be 'uml:ProtocolStateMachine' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ProtocolStateMachine";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                poco.XmiGuid = xmlReader.GetAttribute("xmi:uuid");

                this.Cache.Add(poco.XmiId, poco);

                var classifierBehaviorXmlAttribute = xmlReader.GetAttribute("classifierBehavior");
                if (!string.IsNullOrEmpty(classifierBehaviorXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("classifierBehavior", classifierBehaviorXmlAttribute);
                }

                var extendedStateMachineXmlAttribute = xmlReader.GetAttribute("extendedStateMachine");
                if (!string.IsNullOrEmpty(extendedStateMachineXmlAttribute))
                {
                    var extendedStateMachineXmlAttributeValues = extendedStateMachineXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("extendedStateMachine", extendedStateMachineXmlAttributeValues);
                }

                var isAbstractXmlAttribute = xmlReader.GetAttribute("isAbstract");
                if (!string.IsNullOrEmpty(isAbstractXmlAttribute))
                {
                    poco.IsAbstract = bool.Parse(isAbstractXmlAttribute);
                }

                var isActiveXmlAttribute = xmlReader.GetAttribute("isActive");
                if (!string.IsNullOrEmpty(isActiveXmlAttribute))
                {
                    poco.IsActive = bool.Parse(isActiveXmlAttribute);
                }

                var isFinalSpecializationXmlAttribute = xmlReader.GetAttribute("isFinalSpecialization");
                if (!string.IsNullOrEmpty(isFinalSpecializationXmlAttribute))
                {
                    poco.IsFinalSpecialization = bool.Parse(isFinalSpecializationXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf");
                if (!string.IsNullOrEmpty(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var isReentrantXmlAttribute = xmlReader.GetAttribute("isReentrant");
                if (!string.IsNullOrEmpty(isReentrantXmlAttribute))
                {
                    poco.IsReentrant = bool.Parse(isReentrantXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var owningTemplateParameterXmlAttribute = xmlReader.GetAttribute("owningTemplateParameter");
                if (!string.IsNullOrEmpty(owningTemplateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", owningTemplateParameterXmlAttribute);
                }

                var packageXmlAttribute = xmlReader.GetAttribute("package");
                if (!string.IsNullOrEmpty(packageXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("package", packageXmlAttribute);
                }

                var powertypeExtentXmlAttribute = xmlReader.GetAttribute("powertypeExtent");
                if (!string.IsNullOrEmpty(powertypeExtentXmlAttribute))
                {
                    var powertypeExtentXmlAttributeValues = powertypeExtentXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("powertypeExtent", powertypeExtentXmlAttributeValues);
                }

                var redefinedClassifierXmlAttribute = xmlReader.GetAttribute("redefinedClassifier");
                if (!string.IsNullOrEmpty(redefinedClassifierXmlAttribute))
                {
                    var redefinedClassifierXmlAttributeValues = redefinedClassifierXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedClassifier", redefinedClassifierXmlAttributeValues);
                }

                var representationXmlAttribute = xmlReader.GetAttribute("representation");
                if (!string.IsNullOrEmpty(representationXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("representation", representationXmlAttribute);
                }

                var specificationXmlAttribute = xmlReader.GetAttribute("specification");
                if (!string.IsNullOrEmpty(specificationXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("specification", specificationXmlAttribute);
                }

                var submachineStateXmlAttribute = xmlReader.GetAttribute("submachineState");
                if (!string.IsNullOrEmpty(submachineStateXmlAttribute))
                {
                    var submachineStateXmlAttributeValues = submachineStateXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("submachineState", submachineStateXmlAttributeValues);
                }

                var templateParameterXmlAttribute = xmlReader.GetAttribute("templateParameter");
                if (!string.IsNullOrEmpty(templateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", templateParameterXmlAttribute);
                }

                var useCasesXmlAttribute = xmlReader.GetAttribute("useCases");
                if (!string.IsNullOrEmpty(useCasesXmlAttribute))
                {
                    var useCasesXmlAttributeValues = useCasesXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("useCases", useCasesXmlAttributeValues);
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
                            case "classifierBehavior":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "classifierBehavior");
                                break;
                            case "collaborationUse":
                                var collaborationUseValue = (ICollaborationUse)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:CollaborationUse");
                                poco.CollaborationUse.Add(collaborationUseValue);
                                break;
                            case "conformance":
                                var conformanceValue = (IProtocolConformance)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:ProtocolConformance");
                                poco.Conformance.Add(conformanceValue);
                                break;
                            case "connectionPoint":
                                var connectionPointValue = (IPseudostate)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Pseudostate");
                                poco.ConnectionPoint.Add(connectionPointValue);
                                break;
                            case "elementImport":
                                var elementImportValue = (IElementImport)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:ElementImport");
                                poco.ElementImport.Add(elementImportValue);
                                break;
                            case "extendedStateMachine":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "extendedStateMachine");
                                break;
                            case "generalization":
                                var generalizationValue = (IGeneralization)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Generalization");
                                poco.Generalization.Add(generalizationValue);
                                break;
                            case "interfaceRealization":
                                var interfaceRealizationValue = (IInterfaceRealization)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:InterfaceRealization");
                                poco.InterfaceRealization.Add(interfaceRealizationValue);
                                break;
                            case "isAbstract":
                                var isAbstractValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isAbstractValue))
                                {
                                    poco.IsAbstract = bool.Parse(isAbstractValue);
                                }
                                break;
                            case "isActive":
                                var isActiveValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isActiveValue))
                                {
                                    poco.IsActive = bool.Parse(isActiveValue);
                                }
                                break;
                            case "isFinalSpecialization":
                                var isFinalSpecializationValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isFinalSpecializationValue))
                                {
                                    poco.IsFinalSpecialization = bool.Parse(isFinalSpecializationValue);
                                }
                                break;
                            case "isLeaf":
                                var isLeafValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }
                                break;
                            case "isReentrant":
                                var isReentrantValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isReentrantValue))
                                {
                                    poco.IsReentrant = bool.Parse(isReentrantValue);
                                }
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpressionValue = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case "nestedClassifier":
                                var nestedClassifierValue = (IClassifier)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.NestedClassifier.Add(nestedClassifierValue);
                                break;
                            case "ownedAttribute":
                                var ownedAttributeValue = (IProperty)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Property");
                                poco.OwnedAttribute.Add(ownedAttributeValue);
                                break;
                            case "ownedBehavior":
                                var ownedBehaviorValue = (IBehavior)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.OwnedBehavior.Add(ownedBehaviorValue);
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "ownedConnector":
                                var ownedConnectorValue = (IConnector)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Connector");
                                poco.OwnedConnector.Add(ownedConnectorValue);
                                break;
                            case "ownedOperation":
                                var ownedOperationValue = (IOperation)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Operation");
                                poco.OwnedOperation.Add(ownedOperationValue);
                                break;
                            case "ownedParameter":
                                var ownedParameterValue = (IParameter)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Parameter");
                                poco.OwnedParameter.Add(ownedParameterValue);
                                break;
                            case "ownedParameterSet":
                                var ownedParameterSetValue = (IParameterSet)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:ParameterSet");
                                poco.OwnedParameterSet.Add(ownedParameterSetValue);
                                break;
                            case "ownedReception":
                                var ownedReceptionValue = (IReception)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Reception");
                                poco.OwnedReception.Add(ownedReceptionValue);
                                break;
                            case "ownedRule":
                                var ownedRuleValue = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.OwnedRule.Add(ownedRuleValue);
                                break;
                            case "ownedTemplateSignature":
                                var ownedTemplateSignatureValue = (IRedefinableTemplateSignature)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:RedefinableTemplateSignature");
                                poco.OwnedTemplateSignature.Add(ownedTemplateSignatureValue);
                                break;
                            case "ownedUseCase":
                                var ownedUseCaseValue = (IUseCase)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:UseCase");
                                poco.OwnedUseCase.Add(ownedUseCaseValue);
                                break;
                            case "owningTemplateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case "package":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "package");
                                break;
                            case "packageImport":
                                var packageImportValue = (IPackageImport)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:PackageImport");
                                poco.PackageImport.Add(packageImportValue);
                                break;
                            case "postcondition":
                                if (!this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "postcondition"))
                                {
                                    this.Logger.LogWarning("The ProtocolStateMachine.Postcondition attribute was not processed at {DefaultLineInfo}", defaultLineInfo);
                                }
                                break;
                            case "powertypeExtent":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "powertypeExtent");
                                break;
                            case "precondition":
                                if (!this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "precondition"))
                                {
                                    this.Logger.LogWarning("The ProtocolStateMachine.Precondition attribute was not processed at {DefaultLineInfo}", defaultLineInfo);
                                }
                                break;
                            case "redefinedClassifier":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedClassifier");
                                break;
                            case "region":
                                var regionValue = (IRegion)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Region");
                                poco.Region.Add(regionValue);
                                break;
                            case "representation":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "representation");
                                break;
                            case "specification":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "specification");
                                break;
                            case "submachineState":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "submachineState");
                                break;
                            case "substitution":
                                var substitutionValue = (ISubstitution)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Substitution");
                                poco.Substitution.Add(substitutionValue);
                                break;
                            case "templateBinding":
                                var templateBindingValue = (ITemplateBinding)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:TemplateBinding");
                                poco.TemplateBinding.Add(templateBindingValue);
                                break;
                            case "templateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "templateParameter");
                                break;
                            case "useCases":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "useCases");
                                break;
                            case "visibility":
                                var visibilityValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true); ;
                                }
                                break;
                            default:
                                throw new NotSupportedException($"ProtocolStateMachineReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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