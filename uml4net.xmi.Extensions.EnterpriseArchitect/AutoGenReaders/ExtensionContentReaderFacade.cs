// -------------------------------------------------------------------------------------------------
// <copyright file="ExtensionContentReaderFacade.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Structure.Readers
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net.xmi.Extender;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The <see cref="ExtensionContentReaderFacade"/> provides extension content read capabilities via <see cref="IExtensionContentReader{TContent}"/> call
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    [ExtenderReader("Enterprise Architect", "6.5")]
    public class ExtensionContentReaderFacade : IExtensionContentReaderFacade
    {
        /// <summary>
        /// A dictionary that contains functions that return extension content based a key that represents the type
        /// and a provided <see cref="IXmiElementCache"/>, <see cref="ILoggerFactory"/> and <see cref="XmlReader"/>
        /// </summary>
        protected readonly Dictionary<string, Func<IXmiElementCache, IXmiReaderSettings, INameSpaceResolver, ILoggerFactory, XmlReader, string, object>> readerCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionContentReaderFacade"/>
        /// </summary>
        /// <param name="registry">The injected <see cref="IExtenderReaderRegistry"/></param>
        public ExtensionContentReaderFacade(Lazy<IExtenderReaderRegistry> registry)
        {
            this.readerCache = new Dictionary<string, Func<IXmiElementCache, IXmiReaderSettings, INameSpaceResolver, ILoggerFactory, XmlReader, string, object>>
            {
                ["Abstraction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var abstractionReader = new AbstractionReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return abstractionReader.Read(subXmlReader, documentName);
                    },
                ["Aggregation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var aggregationReader = new AggregationReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return aggregationReader.Read(subXmlReader, documentName);
                    },
                ["AppearanceStyle"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var appearanceStyleReader = new AppearanceStyleReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return appearanceStyleReader.Read(subXmlReader, documentName);
                    },
                ["Association"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var associationReader = new AssociationReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return associationReader.Read(subXmlReader, documentName);
                    },
                ["Attribute"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var attributeReader = new AttributeReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return attributeReader.Read(subXmlReader, documentName);
                    },
                ["AttributeProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var attributePropertiesReader = new AttributePropertiesReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return attributePropertiesReader.Read(subXmlReader, documentName);
                    },
                ["Behaviour"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var behaviourReader = new BehaviourReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return behaviourReader.Read(subXmlReader, documentName);
                    },
                ["Bounds"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var boundsReader = new BoundsReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return boundsReader.Read(subXmlReader, documentName);
                    },
                ["Code"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var codeReader = new CodeReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return codeReader.Read(subXmlReader, documentName);
                    },
                ["Connector"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorReader = new ConnectorReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return connectorReader.Read(subXmlReader, documentName);
                    },
                ["ConnectorAppearance"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorAppearanceReader = new ConnectorAppearanceReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return connectorAppearanceReader.Read(subXmlReader, documentName);
                    },
                ["ConnectorEnd"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorEndReader = new ConnectorEndReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return connectorEndReader.Read(subXmlReader, documentName);
                    },
                ["ConnectorEndType"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorEndTypeReader = new ConnectorEndTypeReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return connectorEndTypeReader.Read(subXmlReader, documentName);
                    },
                ["ConnectorExtendedProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorExtendedPropertiesReader = new ConnectorExtendedPropertiesReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return connectorExtendedPropertiesReader.Read(subXmlReader, documentName);
                    },
                ["ConnectorProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var connectorPropertiesReader = new ConnectorPropertiesReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return connectorPropertiesReader.Read(subXmlReader, documentName);
                    },
                ["Constraints"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var constraintsReader = new ConstraintsReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return constraintsReader.Read(subXmlReader, documentName);
                    },
                ["ContainmentDefinition"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var containmentDefinitionReader = new ContainmentDefinitionReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return containmentDefinitionReader.Read(subXmlReader, documentName);
                    },
                ["Coords"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var coordsReader = new CoordsReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return coordsReader.Read(subXmlReader, documentName);
                    },
                ["Dependency"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var dependencyReader = new DependencyReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return dependencyReader.Read(subXmlReader, documentName);
                    },
                ["Documentation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var documentationReader = new DocumentationReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return documentationReader.Read(subXmlReader, documentName);
                    },
                ["Element"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var elementReader = new ElementReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return elementReader.Read(subXmlReader, documentName);
                    },
                ["ElementProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var elementPropertiesReader = new ElementPropertiesReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return elementPropertiesReader.Read(subXmlReader, documentName);
                    },
                ["ExtendedProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var extendedPropertiesReader = new ExtendedPropertiesReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return extendedPropertiesReader.Read(subXmlReader, documentName);
                    },
                ["Flags"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var flagsReader = new FlagsReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return flagsReader.Read(subXmlReader, documentName);
                    },
                ["Generalization"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var generalizationReader = new GeneralizationReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return generalizationReader.Read(subXmlReader, documentName);
                    },
                ["Initial"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var initialReader = new InitialReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return initialReader.Read(subXmlReader, documentName);
                    },
                ["Labels"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var labelsReader = new LabelsReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return labelsReader.Read(subXmlReader, documentName);
                    },
                ["Model"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var modelReader = new ModelReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return modelReader.Read(subXmlReader, documentName);
                    },
                ["Modifiers"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var modifiersReader = new ModifiersReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return modifiersReader.Read(subXmlReader, documentName);
                    },
                ["Nesting"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var nestingReader = new NestingReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return nestingReader.Read(subXmlReader, documentName);
                    },
                ["NoteLink"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var noteLinkReader = new NoteLinkReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return noteLinkReader.Read(subXmlReader, documentName);
                    },
                ["Operation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var operationReader = new OperationReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return operationReader.Read(subXmlReader, documentName);
                    },
                ["OperationProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var operationPropertiesReader = new OperationPropertiesReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return operationPropertiesReader.Read(subXmlReader, documentName);
                    },
                ["Options"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var optionsReader = new OptionsReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return optionsReader.Read(subXmlReader, documentName);
                    },
                ["PackageProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var packagePropertiesReader = new PackagePropertiesReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return packagePropertiesReader.Read(subXmlReader, documentName);
                    },
                ["Parameter"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var parameterReader = new ParameterReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return parameterReader.Read(subXmlReader, documentName);
                    },
                ["ParameterProperties"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var parameterPropertiesReader = new ParameterPropertiesReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return parameterPropertiesReader.Read(subXmlReader, documentName);
                    },
                ["ParameterSubstitution"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var parameterSubstitutionReader = new ParameterSubstitutionReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return parameterSubstitutionReader.Read(subXmlReader, documentName);
                    },
                ["Path"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var pathReader = new PathReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return pathReader.Read(subXmlReader, documentName);
                    },
                ["Project"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var projectReader = new ProjectReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return projectReader.Read(subXmlReader, documentName);
                    },
                ["Realisation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var realisationReader = new RealisationReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return realisationReader.Read(subXmlReader, documentName);
                    },
                ["Role"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var roleReader = new RoleReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return roleReader.Read(subXmlReader, documentName);
                    },
                ["StereotypeDefinition"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var stereotypeDefinitionReader = new StereotypeDefinitionReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return stereotypeDefinitionReader.Read(subXmlReader, documentName);
                    },
                ["Style"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var styleReader = new StyleReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return styleReader.Read(subXmlReader, documentName);
                    },
                ["Tag"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var tagReader = new TagReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return tagReader.Read(subXmlReader, documentName);
                    },
                ["TemplateBinding"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var templateBindingReader = new TemplateBindingReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return templateBindingReader.Read(subXmlReader, documentName);
                    },
                ["Times"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var timesReader = new TimesReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return timesReader.Read(subXmlReader, documentName);
                    },
                ["TypeElement"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var typeElementReader = new TypeElementReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return typeElementReader.Read(subXmlReader, documentName);
                    },
                ["Usage"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var usageReader = new UsageReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return usageReader.Read(subXmlReader, documentName);
                    },
                ["UseCase"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var useCaseReader = new UseCaseReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return useCaseReader.Read(subXmlReader, documentName);
                    },
                ["Xrefs"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) =>
                    {
                        using var subXmlReader = xmlReader.ReadSubtree();
                        var xrefsReader = new XrefsReader(registry.Value, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory);
                        return xrefsReader.Read(subXmlReader, documentName);
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
        /// <param name="xmiReaderSettings" >
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="SupportedNamespaces"/>
        /// </param>
        /// <param name="cache">The <see cref="IXmiElementCache"/> that provides cached <see cref="IXmiElement"/> retriveal</param>
        /// <param name="documentName">The name of the document that is currently read</param>
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
        public TContent QueryExtensionContent<TContent>(XmlReader xmlReader, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IXmiElementCache cache, string documentName, ILoggerFactory loggerFactory)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (xmiReaderSettings == null)
            {
                throw new ArgumentNullException(nameof(xmiReaderSettings));
            }

            if (nameSpaceResolver == null)
            {
                throw new ArgumentNullException(nameof(nameSpaceResolver));
            }

            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            var type = typeof(TContent);
            var extensionTypeName = type.IsInterface ? xmlReader.LocalName : typeof(TContent).Name;

            if (this.readerCache.TryGetValue(extensionTypeName, out var readerFactory)
                && readerFactory(cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName) is TContent content)
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
