// -------------------------------------------------------------------------------------------------
// <copyright file="OpaqueBehaviorReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.CommonBehavior
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
    /// The purpose of the <see cref="OpaqueBehaviorReader"/> is to read an instance of <see cref="IOpaqueBehavior"/>
    /// from the XMI document
    /// </summary>
    public class OpaqueBehaviorReader : XmiElementReader<IOpaqueBehavior>, IXmiElementReader<IOpaqueBehavior>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueBehaviorReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public OpaqueBehaviorReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IOpaqueBehavior"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IOpaqueBehavior"/>
        /// </returns>
        public override IOpaqueBehavior Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IOpaqueBehavior poco = new OpaqueBehavior();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:OpaqueBehavior")
                {
                    throw new XmlException($"The XmiType should be 'uml:OpaqueBehavior' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:OpaqueBehavior";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var bodyXmlAttribute = xmlReader.GetAttribute("body");
                if (!string.IsNullOrEmpty(bodyXmlAttribute))
                {
                    throw new NotSupportedException("DataTypes encoded as XML attributes are not (yet) supported: OpaqueBehavior.body");
                }

                var classifierBehaviorXmlAttribute = xmlReader.GetAttribute("classifierBehavior");
                if (!string.IsNullOrEmpty(classifierBehaviorXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("classifierBehavior", classifierBehaviorXmlAttribute);
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

                var languageXmlAttribute = xmlReader.GetAttribute("language");
                if (!string.IsNullOrEmpty(languageXmlAttribute))
                {
                    throw new NotSupportedException("DataTypes encoded as XML attributes are not (yet) supported: OpaqueBehavior.language");
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

                var redefinedBehaviorXmlAttribute = xmlReader.GetAttribute("redefinedBehavior");
                if (!string.IsNullOrEmpty(redefinedBehaviorXmlAttribute))
                {
                    var redefinedBehaviorXmlAttributeValues = redefinedBehaviorXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedBehavior", redefinedBehaviorXmlAttributeValues);
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


                var powertypeExtent = new List<string>();
                var redefinedBehavior = new List<string>();
                var redefinedClassifier = new List<string>();
                var useCases = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "body":
                                var body = xmlReader.ReadElementContentAsString();
                                poco.Body.Add(body);
                                break;
                            case "classifierBehavior":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "classifierBehavior");
                                break;
                            case "collaborationUse":
                                var collaborationUse = (ICollaborationUse)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:CollaborationUse");
                                poco.CollaborationUse.Add(collaborationUse);
                                break;
                            case "elementImport":
                                var elementImport = (IElementImport)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:ElementImport");
                                poco.ElementImport.Add(elementImport);
                                break;
                            case "generalization":
                                var generalization = (IGeneralization)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Generalization");
                                poco.Generalization.Add(generalization);
                                break;
                            case "interfaceRealization":
                                var interfaceRealization = (IInterfaceRealization)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:InterfaceRealization");
                                poco.InterfaceRealization.Add(interfaceRealization);
                                break;
                            case "isAbstract":
                                var isAbstractXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isAbstractXmlElement))
                                {
                                    poco.IsAbstract = bool.Parse(isAbstractXmlElement);
                                }
                                break;
                            case "isActive":
                                var isActiveXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isActiveXmlElement))
                                {
                                    poco.IsActive = bool.Parse(isActiveXmlElement);
                                }
                                break;
                            case "isFinalSpecialization":
                                var isFinalSpecializationXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isFinalSpecializationXmlElement))
                                {
                                    poco.IsFinalSpecialization = bool.Parse(isFinalSpecializationXmlElement);
                                }
                                break;
                            case "isLeaf":
                                var isLeafXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isLeafXmlElement))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafXmlElement);
                                }
                                break;
                            case "isReentrant":
                                var isReentrantXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isReentrantXmlElement))
                                {
                                    poco.IsReentrant = bool.Parse(isReentrantXmlElement);
                                }
                                break;
                            case "language":
                                var language = xmlReader.ReadElementContentAsString();
                                poco.Language.Add(language);
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpression = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpression);
                                break;
                            case "nestedClassifier":
                                var nestedClassifier = (IClassifier)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.NestedClassifier.Add(nestedClassifier);
                                break;
                            case "ownedAttribute":
                                var ownedAttribute = (IProperty)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Property");
                                poco.OwnedAttribute.Add(ownedAttribute);
                                break;
                            case "ownedBehavior":
                                var ownedBehavior = (IBehavior)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.OwnedBehavior.Add(ownedBehavior);
                                break;
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "ownedConnector":
                                var ownedConnector = (IConnector)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Connector");
                                poco.OwnedConnector.Add(ownedConnector);
                                break;
                            case "ownedOperation":
                                var ownedOperation = (IOperation)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Operation");
                                poco.OwnedOperation.Add(ownedOperation);
                                break;
                            case "ownedParameter":
                                var ownedParameter = (IParameter)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Parameter");
                                poco.OwnedParameter.Add(ownedParameter);
                                break;
                            case "ownedParameterSet":
                                var ownedParameterSet = (IParameterSet)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:ParameterSet");
                                poco.OwnedParameterSet.Add(ownedParameterSet);
                                break;
                            case "ownedReception":
                                var ownedReception = (IReception)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Reception");
                                poco.OwnedReception.Add(ownedReception);
                                break;
                            case "ownedRule":
                                var ownedRule = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.OwnedRule.Add(ownedRule);
                                break;
                            case "ownedTemplateSignature":
                                var ownedTemplateSignature = (IRedefinableTemplateSignature)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:RedefinableTemplateSignature");
                                poco.OwnedTemplateSignature.Add(ownedTemplateSignature);
                                break;
                            case "ownedUseCase":
                                var ownedUseCase = (IUseCase)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:UseCase");
                                poco.OwnedUseCase.Add(ownedUseCase);
                                break;
                            case "owningTemplateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case "package":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "package");
                                break;
                            case "packageImport":
                                var packageImport = (IPackageImport)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:PackageImport");
                                poco.PackageImport.Add(packageImport);
                                break;
                            case "postcondition":
                                var postcondition = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.Postcondition.Add(postcondition);
                                break;
                            case "powertypeExtent":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, powertypeExtent, "powertypeExtent");
                                break;
                            case "precondition":
                                var precondition = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.Precondition.Add(precondition);
                                break;
                            case "redefinedBehavior":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, redefinedBehavior, "redefinedBehavior");
                                break;
                            case "redefinedClassifier":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, redefinedClassifier, "redefinedClassifier");
                                break;
                            case "representation":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "representation");
                                break;
                            case "specification":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "specification");
                                break;
                            case "substitution":
                                var substitution = (ISubstitution)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Substitution");
                                poco.Substitution.Add(substitution);
                                break;
                            case "templateBinding":
                                var templateBinding = (ITemplateBinding)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:TemplateBinding");
                                poco.TemplateBinding.Add(templateBinding);
                                break;
                            case "templateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "templateParameter");
                                break;
                            case "useCases":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, useCases, "useCases");
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
                                throw new NotSupportedException($"OpaqueBehaviorReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (powertypeExtent.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("powertypeExtent", powertypeExtent);
                }

                if (redefinedBehavior.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedBehavior", redefinedBehavior);
                }

                if (redefinedClassifier.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedClassifier", redefinedClassifier);
                }

                if (useCases.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("useCases", useCases);
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
