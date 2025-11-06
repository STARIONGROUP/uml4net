// -------------------------------------------------------------------------------------------------
// <copyright file="ExtensionContentReaderFacade.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EntrepriseArchitect.Structure.Readers
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The <see cref="ExtensionContentReaderFacade"/> provides extension content read capabilities via <see cref="IExtensionContentReader{TContent}"/> call
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ExtensionContentReaderFacade : IExtensionContentReaderFacade
    {
        /// <summary>
        /// A dictionary that contains functions that return extension content based a key that represents the type
        /// and a provided <see cref="IXmiElementCache"/>, <see cref="ILoggerFactory"/> and <see cref="XmlReader"/>
        /// </summary>
        protected readonly Dictionary<string, Func<IXmiElementCache, IXmiReaderSettings, INameSpaceResolver, ILoggerFactory, XmlReader, string, string, object>> readerCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionContentReaderFacade"/>
        /// </summary>
        public ExtensionContentReaderFacade()
        {
            this.readerCache = new Dictionary<string, Func<IXmiElementCache, IXmiReaderSettings, INameSpaceResolver, ILoggerFactory, XmlReader, string, string, object>>
            {
                ["Abstraction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var abstractionReader = new AbstractionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return abstractionReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Aggregation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var aggregationReader = new AggregationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return aggregationReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["AppearanceStyle"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var appearanceStyleReader = new AppearanceStyleReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return appearanceStyleReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Association"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var associationReader = new AssociationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return associationReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Attribute"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var attributeReader = new AttributeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return attributeReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["AttributeProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var attributePropertiesReader = new AttributePropertiesReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return attributePropertiesReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Behaviour"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var behaviourReader = new BehaviourReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return behaviourReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Bounds"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var boundsReader = new BoundsReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return boundsReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Code"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var codeReader = new CodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return codeReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Connector"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorReader = new ConnectorReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return connectorReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["ConnectorAppearance"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorAppearanceReader = new ConnectorAppearanceReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return connectorAppearanceReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["ConnectorEnd"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorEndReader = new ConnectorEndReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return connectorEndReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["ConnectorEndType"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorEndTypeReader = new ConnectorEndTypeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return connectorEndTypeReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["ConnectorExtendedProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorExtendedPropertiesReader = new ConnectorExtendedPropertiesReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return connectorExtendedPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["ConnectorProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorPropertiesReader = new ConnectorPropertiesReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return connectorPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Constraints"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var constraintsReader = new ConstraintsReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return constraintsReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["ContainmentDefinition"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var containmentDefinitionReader = new ContainmentDefinitionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return containmentDefinitionReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Coords"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var coordsReader = new CoordsReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return coordsReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Dependency"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var dependencyReader = new DependencyReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return dependencyReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Documentation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var documentationReader = new DocumentationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return documentationReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Element"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var elementReader = new ElementReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return elementReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["ElementProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var elementPropertiesReader = new ElementPropertiesReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return elementPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["ExtendedProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var extendedPropertiesReader = new ExtendedPropertiesReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return extendedPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Flags"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var flagsReader = new FlagsReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return flagsReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Generalization"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var generalizationReader = new GeneralizationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return generalizationReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Initial"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var initialReader = new InitialReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return initialReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Labels"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var labelsReader = new LabelsReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return labelsReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["LinksCollection"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var linksCollectionReader = new LinksCollectionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return linksCollectionReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Model"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var modelReader = new ModelReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return modelReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Modifiers"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var modifiersReader = new ModifiersReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return modifiersReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Nesting"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var nestingReader = new NestingReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return nestingReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["NoteLink"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var noteLinkReader = new NoteLinkReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return noteLinkReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Operation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var operationReader = new OperationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return operationReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["OperationProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var operationPropertiesReader = new OperationPropertiesReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return operationPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Options"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var optionsReader = new OptionsReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return optionsReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["PackageProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var packagePropertiesReader = new PackagePropertiesReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return packagePropertiesReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Parameter"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var parameterReader = new ParameterReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return parameterReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["ParameterProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var parameterPropertiesReader = new ParameterPropertiesReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return parameterPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["ParameterSubstitution"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var parameterSubstitutionReader = new ParameterSubstitutionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return parameterSubstitutionReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Path"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var pathReader = new PathReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return pathReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Project"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var projectReader = new ProjectReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return projectReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Realisation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var realisationReader = new RealisationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return realisationReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Role"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var roleReader = new RoleReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return roleReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["StereotypeDefinition"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var stereotypeDefinitionReader = new StereotypeDefinitionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return stereotypeDefinitionReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Style"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var styleReader = new StyleReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return styleReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Tag"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var tagReader = new TagReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return tagReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["TemplateBinding"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var templateBindingReader = new TemplateBindingReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return templateBindingReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Times"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var timesReader = new TimesReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return timesReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["TypeElement"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var typeElementReader = new TypeElementReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return typeElementReader.Read(subXmlReader, documentName, namespaceUri);
                    },
                ["Xrefs"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var xrefsReader = new XrefsReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                        return xrefsReader.Read(subXmlReader, documentName, namespaceUri);
                    },
            };
        }

        /// <summary>
        /// Queries an instance of an <see cref="IXmiElement"/> based on the position of the <see cref="XmlReader"/>. When the reader
        /// is at an XML Element and has an attribute of xmi:type, the value of that attribute is used to select the appropriate
        /// XmiElementReader from which the <see cref="IXmiElement"/> is returned.
        /// </summary>
        /// <param name="xmlReader">
        /// An instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IXmiElement"/> belongs to
        /// </param>
        /// <param name="cache">
        /// The <see cref="IXmiElementCache"/> in which all model instances are registered
        /// </param>
        /// <param name="xmiReaderSettings" >
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="SupportedNamespaces"/>
        /// </param>
        /// <param name="loggerFactory">
        /// The <see cref="ILoggerFactory"/> to set up logging
        /// </param>
        /// <returns>
        /// an instance of <typeparamref name="TContent "/>
        /// </returns>
        /// <typeparam name="TContent">Any supported type</typeparam>
        /// <exception cref="InvalidOperationException">
        /// thrown when the xmi:type is not supported and noXmiElementReader was found
        /// </exception>
        public TContent QueryExtensionContent<TContent>(XmlReader xmlReader, string documentName, string namespaceUri, IXmiElementCache cache, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            if (xmiReaderSettings == null)
            {
                throw new ArgumentNullException(nameof(xmiReaderSettings));
            }

            if (nameSpaceResolver == null)
            {
                throw new ArgumentNullException(nameof(nameSpaceResolver));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentNullException(nameof(documentName));
            }

            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentNullException(nameof(namespaceUri));
            }

            var extensionTypeName = typeof(TContent).Name;

            if (this.readerCache.TryGetValue(extensionTypeName, out var readerFactory)
                && readerFactory(cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) is TContent content)
            {
                return content;
            }

            throw new InvalidOperationException($"No reader found for extension type - {extensionTypeName}");
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
