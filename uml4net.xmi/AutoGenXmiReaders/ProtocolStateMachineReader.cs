// -------------------------------------------------------------------------------------------------
// <copyright file="ProtocolStateMachineReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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
    using Microsoft.Extensions.Logging.Abstractions;

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
    using uml4net.xmi.ReferenceResolver;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="ProtocolStateMachineReader"/> is to read an instance of <see cref="IProtocolStateMachine"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ProtocolStateMachineReader : XmiElementReader<IProtocolStateMachine>, IXmiElementReader<IProtocolStateMachine>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ProtocolStateMachineReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolStateMachineReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The (injected) <see cref="IXmiElementCache"/>> in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </param>
        /// <param name="xmiReaderSettings">
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/>
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ProtocolStateMachineReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ProtocolStateMachineReader>.Instance : loggerFactory.CreateLogger<ProtocolStateMachineReader>();
        }

        /// <summary>
        /// Reads the <see cref="IProtocolStateMachine"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IProtocolStateMachine"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IProtocolStateMachine"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IProtocolStateMachine"/>
        /// </returns>
        public override IProtocolStateMachine Read(XmlReader xmlReader, string documentName, string namespaceUri)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException(nameof(documentName));
            }

            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentException(nameof(namespaceUri));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            IProtocolStateMachine poco = new ProtocolStateMachine();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading ProtocolStateMachine at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = xmlReader.GetAttribute("type", this.NameSpaceResolver.XmiNameSpace);

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ProtocolStateMachine")
                {
                    throw new XmlException($"The XmiType should be 'uml:ProtocolStateMachine' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ProtocolStateMachine";
                }

                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                this.NameSpaceResolver.ResolveAndSetNamespace(namespaceUri);

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("id", this.NameSpaceResolver.XmiNameSpace);

                poco.XmiGuid = xmlReader.GetAttribute("uuid", this.NameSpaceResolver.XmiNameSpace);

                poco.DocumentName = documentName;

                poco.XmiNamespaceUri = namespaceUri;

                if (!this.Cache.TryAdd(poco))
                {
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "ProtocolStateMachine", poco.XmiId);
                }

                var classifierBehaviorXmlAttribute = xmlReader.GetAttribute("classifierBehavior") ?? xmlReader.GetAttribute("classifierBehavior", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(classifierBehaviorXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("classifierBehavior", classifierBehaviorXmlAttribute);
                }

                var extendedStateMachineXmlAttribute = xmlReader.GetAttribute("extendedStateMachine") ?? xmlReader.GetAttribute("extendedStateMachine", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(extendedStateMachineXmlAttribute))
                {
                    var extendedStateMachineXmlAttributeValues = extendedStateMachineXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("extendedStateMachine", extendedStateMachineXmlAttributeValues);
                }

                var isAbstractXmlAttribute = xmlReader.GetAttribute("isAbstract") ?? xmlReader.GetAttribute("isAbstract", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isAbstractXmlAttribute))
                {
                    poco.IsAbstract = bool.Parse(isAbstractXmlAttribute);
                }

                var isActiveXmlAttribute = xmlReader.GetAttribute("isActive") ?? xmlReader.GetAttribute("isActive", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isActiveXmlAttribute))
                {
                    poco.IsActive = bool.Parse(isActiveXmlAttribute);
                }

                var isFinalSpecializationXmlAttribute = xmlReader.GetAttribute("isFinalSpecialization") ?? xmlReader.GetAttribute("isFinalSpecialization", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isFinalSpecializationXmlAttribute))
                {
                    poco.IsFinalSpecialization = bool.Parse(isFinalSpecializationXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf") ?? xmlReader.GetAttribute("isLeaf", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var isReentrantXmlAttribute = xmlReader.GetAttribute("isReentrant") ?? xmlReader.GetAttribute("isReentrant", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isReentrantXmlAttribute))
                {
                    poco.IsReentrant = bool.Parse(isReentrantXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", this.NameSpaceResolver.UmlNameSpace);

                var owningTemplateParameterXmlAttribute = xmlReader.GetAttribute("owningTemplateParameter") ?? xmlReader.GetAttribute("owningTemplateParameter", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(owningTemplateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", owningTemplateParameterXmlAttribute);
                }

                var packageXmlAttribute = xmlReader.GetAttribute("package") ?? xmlReader.GetAttribute("package", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(packageXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("package", packageXmlAttribute);
                }

                var powertypeExtentXmlAttribute = xmlReader.GetAttribute("powertypeExtent") ?? xmlReader.GetAttribute("powertypeExtent", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(powertypeExtentXmlAttribute))
                {
                    var powertypeExtentXmlAttributeValues = powertypeExtentXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("powertypeExtent", powertypeExtentXmlAttributeValues);
                }

                var redefinedClassifierXmlAttribute = xmlReader.GetAttribute("redefinedClassifier") ?? xmlReader.GetAttribute("redefinedClassifier", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(redefinedClassifierXmlAttribute))
                {
                    var redefinedClassifierXmlAttributeValues = redefinedClassifierXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedClassifier", redefinedClassifierXmlAttributeValues);
                }

                var representationXmlAttribute = xmlReader.GetAttribute("representation") ?? xmlReader.GetAttribute("representation", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(representationXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("representation", representationXmlAttribute);
                }

                var specificationXmlAttribute = xmlReader.GetAttribute("specification") ?? xmlReader.GetAttribute("specification", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(specificationXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("specification", specificationXmlAttribute);
                }

                var submachineStateXmlAttribute = xmlReader.GetAttribute("submachineState") ?? xmlReader.GetAttribute("submachineState", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(submachineStateXmlAttribute))
                {
                    var submachineStateXmlAttributeValues = submachineStateXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("submachineState", submachineStateXmlAttributeValues);
                }

                var templateParameterXmlAttribute = xmlReader.GetAttribute("templateParameter") ?? xmlReader.GetAttribute("templateParameter", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(templateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", templateParameterXmlAttribute);
                }

                var useCasesXmlAttribute = xmlReader.GetAttribute("useCases") ?? xmlReader.GetAttribute("useCases", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(useCasesXmlAttribute))
                {
                    var useCasesXmlAttributeValues = useCasesXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("useCases", useCasesXmlAttributeValues);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility") ?? xmlReader.GetAttribute("visibility", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(visibilityXmlAttribute))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlAttribute, true);
                }


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var activeNamespaceUri = string.IsNullOrEmpty(xmlReader.NamespaceURI) ? namespaceUri : xmlReader.NamespaceURI;

                        var activePrefix = this.NameSpaceResolver.ResolvePrefix(activeNamespaceUri);

                        switch (activePrefix, xmlReader.LocalName)
                        {
                            case (KnowNamespacePrefixes.Uml, "classifierBehavior"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "classifierBehavior");
                                break;
                            case (KnowNamespacePrefixes.Uml, "collaborationUse"):
                                var collaborationUseValue = (ICollaborationUse)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:CollaborationUse");
                                poco.CollaborationUse.Add(collaborationUseValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "conformance"):
                                var conformanceValue = (IProtocolConformance)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:ProtocolConformance");
                                poco.Conformance.Add(conformanceValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "connectionPoint"):
                                var connectionPointValue = (IPseudostate)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Pseudostate");
                                poco.ConnectionPoint.Add(connectionPointValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "elementImport"):
                                var elementImportValue = (IElementImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:ElementImport");
                                poco.ElementImport.Add(elementImportValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "extendedStateMachine"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "extendedStateMachine");
                                break;
                            case (KnowNamespacePrefixes.Uml, "generalization"):
                                var generalizationValue = (IGeneralization)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Generalization");
                                poco.Generalization.Add(generalizationValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "interfaceRealization"):
                                var interfaceRealizationValue = (IInterfaceRealization)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:InterfaceRealization");
                                poco.InterfaceRealization.Add(interfaceRealizationValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "isAbstract"):
                                var isAbstractValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isAbstractValue))
                                {
                                    poco.IsAbstract = bool.Parse(isAbstractValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isActive"):
                                var isActiveValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isActiveValue))
                                {
                                    poco.IsActive = bool.Parse(isActiveValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isFinalSpecialization"):
                                var isFinalSpecializationValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isFinalSpecializationValue))
                                {
                                    poco.IsFinalSpecialization = bool.Parse(isFinalSpecializationValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isLeaf"):
                                var isLeafValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isReentrant"):
                                var isReentrantValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isReentrantValue))
                                {
                                    poco.IsReentrant = bool.Parse(isReentrantValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "name"):
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case (KnowNamespacePrefixes.Uml, "nameExpression"):
                                var nameExpressionValue = (IStringExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "nestedClassifier"):
                                var nestedClassifierValue = (IClassifier)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory);
                                poco.NestedClassifier.Add(nestedClassifierValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedAttribute"):
                                var ownedAttributeValue = (IProperty)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Property");
                                poco.OwnedAttribute.Add(ownedAttributeValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedBehavior"):
                                var ownedBehaviorValue = (IBehavior)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory);
                                poco.OwnedBehavior.Add(ownedBehaviorValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedComment"):
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedConnector"):
                                var ownedConnectorValue = (IConnector)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Connector");
                                poco.OwnedConnector.Add(ownedConnectorValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedOperation"):
                                var ownedOperationValue = (IOperation)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Operation");
                                poco.OwnedOperation.Add(ownedOperationValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedParameter"):
                                var ownedParameterValue = (IParameter)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Parameter");
                                poco.OwnedParameter.Add(ownedParameterValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedParameterSet"):
                                var ownedParameterSetValue = (IParameterSet)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:ParameterSet");
                                poco.OwnedParameterSet.Add(ownedParameterSetValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedReception"):
                                var ownedReceptionValue = (IReception)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Reception");
                                poco.OwnedReception.Add(ownedReceptionValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedRule"):
                                var ownedRuleValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Constraint");
                                poco.OwnedRule.Add(ownedRuleValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedTemplateSignature"):
                                var ownedTemplateSignatureValue = (IRedefinableTemplateSignature)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:RedefinableTemplateSignature");
                                poco.OwnedTemplateSignature.Add(ownedTemplateSignatureValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedUseCase"):
                                var ownedUseCaseValue = (IUseCase)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:UseCase");
                                poco.OwnedUseCase.Add(ownedUseCaseValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "owningTemplateParameter"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case (KnowNamespacePrefixes.Uml, "package"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "package");
                                break;
                            case (KnowNamespacePrefixes.Uml, "packageImport"):
                                var packageImportValue = (IPackageImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:PackageImport");
                                poco.PackageImport.Add(packageImportValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "postcondition"):
                                if (!this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "postcondition"))
                                {
                                    this.logger.LogWarning("The ProtocolStateMachine.Postcondition attribute was not processed at {XmlLineInfo}", xmlLineInfo);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "powertypeExtent"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "powertypeExtent");
                                break;
                            case (KnowNamespacePrefixes.Uml, "precondition"):
                                if (!this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "precondition"))
                                {
                                    this.logger.LogWarning("The ProtocolStateMachine.Precondition attribute was not processed at {XmlLineInfo}", xmlLineInfo);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "redefinedClassifier"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedClassifier");
                                break;
                            case (KnowNamespacePrefixes.Uml, "region"):
                                var regionValue = (IRegion)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Region");
                                poco.Region.Add(regionValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "representation"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "representation");
                                break;
                            case (KnowNamespacePrefixes.Uml, "specification"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "specification");
                                break;
                            case (KnowNamespacePrefixes.Uml, "submachineState"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "submachineState");
                                break;
                            case (KnowNamespacePrefixes.Uml, "substitution"):
                                var substitutionValue = (ISubstitution)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Substitution");
                                poco.Substitution.Add(substitutionValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "templateBinding"):
                                var templateBindingValue = (ITemplateBinding)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:TemplateBinding");
                                poco.TemplateBinding.Add(templateBindingValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "templateParameter"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "templateParameter");
                                break;
                            case (KnowNamespacePrefixes.Uml, "useCases"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "useCases");
                                break;
                            case (KnowNamespacePrefixes.Uml, "visibility"):
                                var visibilityValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true);
                                }

                                break;
                            case (KnowNamespacePrefixes.Xmi, "Extension"):
                                this.logger.LogInformation("Extension not yet supported)");
                                xmlReader.Skip();
                                break;
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"ProtocolStateMachineReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ProtocolStateMachineReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
                                }

                                break;
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
