// -------------------------------------------------------------------------------------------------
// <copyright file="XmiElementExtensionReaderFacade.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="XmiElementReaderFacade"/> is to read an <see cref="IXmiElement"/> from an
    /// <see cref="XmlReader"/>
    /// </summary>
    [GeneratedCode("uml4net.extension", "latest")]
    public class XmiElementExtensionReaderFacade : XmiElementReaderFacade
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReaderFacade"/>
        /// </summary>
        public XmiElementExtensionReaderFacade()
        {
            this.ReaderCache["Abstraction"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var abstractionReader = new AbstractionReader(cache, this, xmiReaderSettings, loggerFactory);
                return abstractionReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Aggregation"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var aggregationReader = new AggregationReader(cache, this, xmiReaderSettings, loggerFactory);
                return aggregationReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["AppearanceStyle"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var appearanceStyleReader = new AppearanceStyleReader(cache, this, xmiReaderSettings, loggerFactory);
                return appearanceStyleReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Association"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var associationReader = new AssociationReader(cache, this, xmiReaderSettings, loggerFactory);
                return associationReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Attribute"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var attributeReader = new AttributeReader(cache, this, xmiReaderSettings, loggerFactory);
                return attributeReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["AttributeProperties"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var attributePropertiesReader = new AttributePropertiesReader(cache, this, xmiReaderSettings, loggerFactory);
                return attributePropertiesReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["AttributesCollection"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var attributesCollectionReader = new AttributesCollectionReader(cache, this, xmiReaderSettings, loggerFactory);
                return attributesCollectionReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Behaviour"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var behaviourReader = new BehaviourReader(cache, this, xmiReaderSettings, loggerFactory);
                return behaviourReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Bounds"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var boundsReader = new BoundsReader(cache, this, xmiReaderSettings, loggerFactory);
                return boundsReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Code"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var codeReader = new CodeReader(cache, this, xmiReaderSettings, loggerFactory);
                return codeReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Connector"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var connectorReader = new ConnectorReader(cache, this, xmiReaderSettings, loggerFactory);
                return connectorReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ConnectorAppearance"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var connectorAppearanceReader = new ConnectorAppearanceReader(cache, this, xmiReaderSettings, loggerFactory);
                return connectorAppearanceReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ConnectorEnd"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var connectorEndReader = new ConnectorEndReader(cache, this, xmiReaderSettings, loggerFactory);
                return connectorEndReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ConnectorEndType"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var connectorEndTypeReader = new ConnectorEndTypeReader(cache, this, xmiReaderSettings, loggerFactory);
                return connectorEndTypeReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ConnectorExtendedProperties"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var connectorExtendedPropertiesReader = new ConnectorExtendedPropertiesReader(cache, this, xmiReaderSettings, loggerFactory);
                return connectorExtendedPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ConnectorProperties"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var connectorPropertiesReader = new ConnectorPropertiesReader(cache, this, xmiReaderSettings, loggerFactory);
                return connectorPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ConnectorsCollection"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var connectorsCollectionReader = new ConnectorsCollectionReader(cache, this, xmiReaderSettings, loggerFactory);
                return connectorsCollectionReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Constraints"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var constraintsReader = new ConstraintsReader(cache, this, xmiReaderSettings, loggerFactory);
                return constraintsReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ContainmentDefinition"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var containmentDefinitionReader = new ContainmentDefinitionReader(cache, this, xmiReaderSettings, loggerFactory);
                return containmentDefinitionReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Coords"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var coordsReader = new CoordsReader(cache, this, xmiReaderSettings, loggerFactory);
                return coordsReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Dependency"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var dependencyReader = new DependencyReader(cache, this, xmiReaderSettings, loggerFactory);
                return dependencyReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Documentation"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var documentationReader = new DocumentationReader(cache, this, xmiReaderSettings, loggerFactory);
                return documentationReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Element"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var elementReader = new ElementReader(cache, this, xmiReaderSettings, loggerFactory);
                return elementReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ElementProperties"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var elementPropertiesReader = new ElementPropertiesReader(cache, this, xmiReaderSettings, loggerFactory);
                return elementPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ElementsCollection"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var elementsCollectionReader = new ElementsCollectionReader(cache, this, xmiReaderSettings, loggerFactory);
                return elementsCollectionReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ExtendedProperties"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var extendedPropertiesReader = new ExtendedPropertiesReader(cache, this, xmiReaderSettings, loggerFactory);
                return extendedPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Extension"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var extensionReader = new ExtensionReader(cache, this, xmiReaderSettings, loggerFactory);
                return extensionReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Flags"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var flagsReader = new FlagsReader(cache, this, xmiReaderSettings, loggerFactory);
                return flagsReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Initial"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var initialReader = new InitialReader(cache, this, xmiReaderSettings, loggerFactory);
                return initialReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Labels"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var labelsReader = new LabelsReader(cache, this, xmiReaderSettings, loggerFactory);
                return labelsReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["LinksCollection"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var linksCollectionReader = new LinksCollectionReader(cache, this, xmiReaderSettings, loggerFactory);
                return linksCollectionReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Model"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var modelReader = new ModelReader(cache, this, xmiReaderSettings, loggerFactory);
                return modelReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Modifiers"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var modifiersReader = new ModifiersReader(cache, this, xmiReaderSettings, loggerFactory);
                return modifiersReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Nesting"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var nestingReader = new NestingReader(cache, this, xmiReaderSettings, loggerFactory);
                return nestingReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Operation"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var operationReader = new OperationReader(cache, this, xmiReaderSettings, loggerFactory);
                return operationReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["OperationProperties"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var operationPropertiesReader = new OperationPropertiesReader(cache, this, xmiReaderSettings, loggerFactory);
                return operationPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Operations"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var operationsReader = new OperationsReader(cache, this, xmiReaderSettings, loggerFactory);
                return operationsReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Options"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var optionsReader = new OptionsReader(cache, this, xmiReaderSettings, loggerFactory);
                return optionsReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["PackageProperties"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var packagePropertiesReader = new PackagePropertiesReader(cache, this, xmiReaderSettings, loggerFactory);
                return packagePropertiesReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Parameter"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var parameterReader = new ParameterReader(cache, this, xmiReaderSettings, loggerFactory);
                return parameterReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ParameterProperties"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var parameterPropertiesReader = new ParameterPropertiesReader(cache, this, xmiReaderSettings, loggerFactory);
                return parameterPropertiesReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ParametersCollection"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var parametersCollectionReader = new ParametersCollectionReader(cache, this, xmiReaderSettings, loggerFactory);
                return parametersCollectionReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["ParameterSubstitutions"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var parameterSubstitutionsReader = new ParameterSubstitutionsReader(cache, this, xmiReaderSettings, loggerFactory);
                return parameterSubstitutionsReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Path"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var pathReader = new PathReader(cache, this, xmiReaderSettings, loggerFactory);
                return pathReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Paths"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var pathsReader = new PathsReader(cache, this, xmiReaderSettings, loggerFactory);
                return pathsReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Project"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var projectReader = new ProjectReader(cache, this, xmiReaderSettings, loggerFactory);
                return projectReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Realisation"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var realisationReader = new RealisationReader(cache, this, xmiReaderSettings, loggerFactory);
                return realisationReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Role"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var roleReader = new RoleReader(cache, this, xmiReaderSettings, loggerFactory);
                return roleReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["StereotypeDefinition"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var stereotypeDefinitionReader = new StereotypeDefinitionReader(cache, this, xmiReaderSettings, loggerFactory);
                return stereotypeDefinitionReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Style"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var styleReader = new StyleReader(cache, this, xmiReaderSettings, loggerFactory);
                return styleReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Tag"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var tagReader = new TagReader(cache, this, xmiReaderSettings, loggerFactory);
                return tagReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["TagsCollection"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var tagsCollectionReader = new TagsCollectionReader(cache, this, xmiReaderSettings, loggerFactory);
                return tagsCollectionReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Times"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var timesReader = new TimesReader(cache, this, xmiReaderSettings, loggerFactory);
                return timesReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["TypeElement"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var typeElementReader = new TypeElementReader(cache, this, xmiReaderSettings, loggerFactory);
                return typeElementReader.Read(subXmlReader, documentName, namespaceUri);
            };

            this.ReaderCache["Xrefs"] = (cache, xmiReaderSettings, loggerFactory, xmlReader, documentName, namespaceUri) =>
            {
                using var subXmlReader = xmlReader.ReadSubtree();
                var xrefsReader = new XrefsReader(cache, this, xmiReaderSettings, loggerFactory);
                return xrefsReader.Read(subXmlReader, documentName, namespaceUri);
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
