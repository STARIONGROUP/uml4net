// -------------------------------------------------------------------------------------------------
// <copyright file="ClassReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.StructuredClassifiers
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="ClassReader"/> is to read an instance of <see cref="IClass"/>
    /// from the XMI document
    /// </summary>
    public class ClassReader : XmiElementReader<IClass>, IXmiElementReader<IClass>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="ICollaborationUse"/> to read
        /// the <see cref="IClass.CollaborationUse"/> property.
        /// </summary>
        public IXmiElementReader<ICollaborationUse> CollaborationUseReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IElementImport"/> to read
        /// the <see cref="IClass.ElementImport"/> property.
        /// </summary>
        public IXmiElementReader<IElementImport> ElementImportReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IGeneralization"/> to read
        /// the <see cref="IClass.Generalization"/> property.
        /// </summary>
        public IXmiElementReader<IGeneralization> GeneralizationReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IInterfaceRealization"/> to read
        /// the <see cref="IClass.InterfaceRealization"/> property.
        /// </summary>
        public IXmiElementReader<IInterfaceRealization> InterfaceRealizationReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IStringExpression"/> to read
        /// the <see cref="IClass.NameExpression"/> property.
        /// </summary>
        public IXmiElementReader<IStringExpression> NameExpressionReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IClassifier"/> to read
        /// the <see cref="IClass.NestedClassifier"/> property.
        /// </summary>
        public IXmiElementReader<IClassifier> NestedClassifierReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IProperty"/> to read
        /// the <see cref="IClass.OwnedAttribute"/> property.
        /// </summary>
        public IXmiElementReader<IProperty> OwnedAttributeReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IBehavior"/> to read
        /// the <see cref="IClass.OwnedBehavior"/> property.
        /// </summary>
        public IXmiElementReader<IBehavior> OwnedBehaviorReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/> to read
        /// the <see cref="IClass.OwnedComment"/> property.
        /// </summary>
        public IXmiElementReader<IComment> OwnedCommentReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IConnector"/> to read
        /// the <see cref="IClass.OwnedConnector"/> property.
        /// </summary>
        public IXmiElementReader<IConnector> OwnedConnectorReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IOperation"/> to read
        /// the <see cref="IClass.OwnedOperation"/> property.
        /// </summary>
        public IXmiElementReader<IOperation> OwnedOperationReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IReception"/> to read
        /// the <see cref="IClass.OwnedReception"/> property.
        /// </summary>
        public IXmiElementReader<IReception> OwnedReceptionReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IConstraint"/> to read
        /// the <see cref="IClass.OwnedRule"/> property.
        /// </summary>
        public IXmiElementReader<IConstraint> OwnedRuleReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IRedefinableTemplateSignature"/> to read
        /// the <see cref="IClass.OwnedTemplateSignature"/> property.
        /// </summary>
        public IXmiElementReader<IRedefinableTemplateSignature> OwnedTemplateSignatureReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IUseCase"/> to read
        /// the <see cref="IClass.OwnedUseCase"/> property.
        /// </summary>
        public IXmiElementReader<IUseCase> OwnedUseCaseReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IPackageImport"/> to read
        /// the <see cref="IClass.PackageImport"/> property.
        /// </summary>
        public IXmiElementReader<IPackageImport> PackageImportReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="ISubstitution"/> to read
        /// the <see cref="IClass.Substitution"/> property.
        /// </summary>
        public IXmiElementReader<ISubstitution> SubstitutionReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="ITemplateBinding"/> to read
        /// the <see cref="IClass.TemplateBinding"/> property.
        /// </summary>
        public IXmiElementReader<ITemplateBinding> TemplateBindingReader { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ClassReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to set up logging
        /// </param>
        public ClassReader(IXmiReaderCache cache, ILogger<ClassReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IClass"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IClass"/>
        /// </returns>
        public override IClass Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IClass poco = new Class();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Class")
                {
                    throw new XmlException($"The XmiType should be 'uml:Class' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Class";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

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

                poco.Name = xmlReader.GetAttribute("name");

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibilityXmlAttribute))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlAttribute, true);
                }


                var powertypeExtents = new List<string>();
                var redefinedClassifiers = new List<string>();
                var useCasess = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "classifierBehavior":
                                using (var typeXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (typeXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = typeXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("classifierBehavior", reference);
                                        }
                                        else if (typeXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("classifierBehavior", idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("classifierBehavior xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "collaborationUse":
                                using (var collaborationUseXmlReader = xmlReader.ReadSubtree())
                                {
                                    var collaborationUse = this.CollaborationUseReader.Read(collaborationUseXmlReader);
                                    poco.CollaborationUse.Add(collaborationUse);
                                }
                                break;
                            case "elementImport":
                                using (var elementImportXmlReader = xmlReader.ReadSubtree())
                                {
                                    var elementImport = this.ElementImportReader.Read(elementImportXmlReader);
                                    poco.ElementImport.Add(elementImport);
                                }
                                break;
                            case "generalization":
                                using (var generalizationXmlReader = xmlReader.ReadSubtree())
                                {
                                    var generalization = this.GeneralizationReader.Read(generalizationXmlReader);
                                    poco.Generalization.Add(generalization);
                                }
                                break;
                            case "interfaceRealization":
                                using (var interfaceRealizationXmlReader = xmlReader.ReadSubtree())
                                {
                                    var interfaceRealization = this.InterfaceRealizationReader.Read(interfaceRealizationXmlReader);
                                    poco.InterfaceRealization.Add(interfaceRealization);
                                }
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
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                using (var nameExpressionXmlReader = xmlReader.ReadSubtree())
                                {
                                    var nameExpression = this.NameExpressionReader.Read(nameExpressionXmlReader);
                                    poco.NameExpression.Add(nameExpression);
                                }
                                break;
                            case "nestedClassifier":
                                using (var nestedClassifierXmlReader = xmlReader.ReadSubtree())
                                {
                                    var nestedClassifier = this.NestedClassifierReader.Read(nestedClassifierXmlReader);
                                    poco.NestedClassifier.Add(nestedClassifier);
                                }
                                break;
                            case "ownedAttribute":
                                using (var ownedAttributeXmlReader = xmlReader.ReadSubtree())
                                {
                                    var ownedAttribute = this.OwnedAttributeReader.Read(ownedAttributeXmlReader);
                                    poco.OwnedAttribute.Add(ownedAttribute);
                                }
                                break;
                            case "ownedBehavior":
                                using (var ownedBehaviorXmlReader = xmlReader.ReadSubtree())
                                {
                                    var ownedBehavior = this.OwnedBehaviorReader.Read(ownedBehaviorXmlReader);
                                    poco.OwnedBehavior.Add(ownedBehavior);
                                }
                                break;
                            case "ownedComment":
                                using (var ownedCommentXmlReader = xmlReader.ReadSubtree())
                                {
                                    var ownedComment = this.OwnedCommentReader.Read(ownedCommentXmlReader);
                                    poco.OwnedComment.Add(ownedComment);
                                }
                                break;
                            case "ownedConnector":
                                using (var ownedConnectorXmlReader = xmlReader.ReadSubtree())
                                {
                                    var ownedConnector = this.OwnedConnectorReader.Read(ownedConnectorXmlReader);
                                    poco.OwnedConnector.Add(ownedConnector);
                                }
                                break;
                            case "ownedOperation":
                                using (var ownedOperationXmlReader = xmlReader.ReadSubtree())
                                {
                                    var ownedOperation = this.OwnedOperationReader.Read(ownedOperationXmlReader);
                                    poco.OwnedOperation.Add(ownedOperation);
                                }
                                break;
                            case "ownedReception":
                                using (var ownedReceptionXmlReader = xmlReader.ReadSubtree())
                                {
                                    var ownedReception = this.OwnedReceptionReader.Read(ownedReceptionXmlReader);
                                    poco.OwnedReception.Add(ownedReception);
                                }
                                break;
                            case "ownedRule":
                                using (var ownedRuleXmlReader = xmlReader.ReadSubtree())
                                {
                                    var ownedRule = this.OwnedRuleReader.Read(ownedRuleXmlReader);
                                    poco.OwnedRule.Add(ownedRule);
                                }
                                break;
                            case "ownedTemplateSignature":
                                using (var ownedTemplateSignatureXmlReader = xmlReader.ReadSubtree())
                                {
                                    var ownedTemplateSignature = this.OwnedTemplateSignatureReader.Read(ownedTemplateSignatureXmlReader);
                                    poco.OwnedTemplateSignature.Add(ownedTemplateSignature);
                                }
                                break;
                            case "ownedUseCase":
                                using (var ownedUseCaseXmlReader = xmlReader.ReadSubtree())
                                {
                                    var ownedUseCase = this.OwnedUseCaseReader.Read(ownedUseCaseXmlReader);
                                    poco.OwnedUseCase.Add(ownedUseCase);
                                }
                                break;
                            case "owningTemplateParameter":
                                using (var typeXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (typeXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = typeXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", reference);
                                        }
                                        else if (typeXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("owningTemplateParameter xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "package":
                                using (var typeXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (typeXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = typeXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("package", reference);
                                        }
                                        else if (typeXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("package", idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("package xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "packageImport":
                                using (var packageImportXmlReader = xmlReader.ReadSubtree())
                                {
                                    var packageImport = this.PackageImportReader.Read(packageImportXmlReader);
                                    poco.PackageImport.Add(packageImport);
                                }
                                break;
                            case "powertypeExtent":
                                using (var powertypeExtentXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (powertypeExtentXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var href = powertypeExtentXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            powertypeExtents.Add(href);
                                        }
                                        else if (powertypeExtentXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            powertypeExtents.Add(idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("powertypeExtent xml - attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "redefinedClassifier":
                                using (var redefinedClassifierXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (redefinedClassifierXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var href = redefinedClassifierXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            redefinedClassifiers.Add(href);
                                        }
                                        else if (redefinedClassifierXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            redefinedClassifiers.Add(idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("redefinedClassifier xml - attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "representation":
                                using (var typeXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (typeXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = typeXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("representation", reference);
                                        }
                                        else if (typeXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("representation", idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("representation xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "substitution":
                                using (var substitutionXmlReader = xmlReader.ReadSubtree())
                                {
                                    var substitution = this.SubstitutionReader.Read(substitutionXmlReader);
                                    poco.Substitution.Add(substitution);
                                }
                                break;
                            case "templateBinding":
                                using (var templateBindingXmlReader = xmlReader.ReadSubtree())
                                {
                                    var templateBinding = this.TemplateBindingReader.Read(templateBindingXmlReader);
                                    poco.TemplateBinding.Add(templateBinding);
                                }
                                break;
                            case "templateParameter":
                                using (var typeXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (typeXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = typeXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", reference);
                                        }
                                        else if (typeXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("templateParameter xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "useCases":
                                using (var useCasesXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (useCasesXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var href = useCasesXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            useCasess.Add(href);
                                        }
                                        else if (useCasesXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            useCasess.Add(idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("useCases xml - attribute reference could not be read");
                                        }
                                    }
                                }
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
                                throw new NotSupportedException($"ClassReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (powertypeExtents.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("powertypeExtent", powertypeExtents);
                }

                if (redefinedClassifiers.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedClassifier", redefinedClassifiers);
                }

                if (useCasess.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("useCases", useCasess);
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
