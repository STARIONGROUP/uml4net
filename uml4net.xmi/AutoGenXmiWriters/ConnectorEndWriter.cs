// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorEndWriter.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Writers
{
    using System;
    using System.CodeDom.Compiler;
    using System.Threading.Tasks;
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
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="ConnectorEndWriter"/> is to write an instance of <see cref="IConnectorEnd"/>
    /// to an XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ConnectorEndWriter : XmiElementWriter<IConnectorEnd>, IXmiElementWriter<IConnectorEnd>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ConnectorEndWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorEndWriter"/> class.
        /// </summary>
        /// <param name="xmiElementWriterFacade">
        /// The (injected) <see cref="IXmiElementWriterFacade"/> used to write contained and referenced
        /// <see cref="IXmiElement"/>s
        /// </param>
        /// <param name="xmiWriterSettings">
        /// The <see cref="IXmiWriterSettings"/> used to configure writing
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ConnectorEndWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
            : base(xmiElementWriterFacade, xmiWriterSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ConnectorEndWriter>.Instance : loggerFactory.CreateLogger<ConnectorEndWriter>();
        }

        /// <summary>
        /// Writes the <see cref="IConnectorEnd"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IConnectorEnd"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public override void Write(XmlWriter xmlWriter, IConnectorEnd element, string elementName, IXmiWriteContext writeContext)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (string.IsNullOrEmpty(elementName))
            {
                throw new ArgumentException(nameof(elementName));
            }

            if (writeContext == null)
            {
                throw new ArgumentNullException(nameof(writeContext));
            }

            if (element.Extensions.Count > 0)
            {
                this.logger.LogTrace("writing the {Count} Extension(s) of the ConnectorEnd with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ConnectorEnd");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                xmlWriter.WriteAttributeString("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.IsOrdered)
            {
                xmlWriter.WriteAttributeString("isOrdered", XmlConvert.ToString(element.IsOrdered));
            }

            if (!element.IsUnique)
            {
                xmlWriter.WriteAttributeString("isUnique", XmlConvert.ToString(element.IsUnique));
            }

            if (element.PartWithPort != null && writeContext.IsLocal(element.PartWithPort))
            {
                xmlWriter.WriteAttributeString("partWithPort", element.PartWithPort.XmiId);
            }

            if (element.Role != null && writeContext.IsLocal(element.Role))
            {
                xmlWriter.WriteAttributeString("role", element.Role.XmiId);
            }


            foreach (var value in element.LowerValue)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "lowerValue", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }

            if (element.PartWithPort != null && !writeContext.IsLocal(element.PartWithPort))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.PartWithPort, "partWithPort", writeContext);
            }

            if (element.Role != null && !writeContext.IsLocal(element.Role))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Role, "role", writeContext);
            }

            foreach (var value in element.UpperValue)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "upperValue", writeContext);
            }


            WriteUnresolvedReferences(xmlWriter, element.UnresolvedReferences);

            this.WriteExtensions(xmlWriter, element.Extensions);

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IConnectorEnd"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IConnectorEnd"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public override async Task WriteAsync(XmlWriter xmlWriter, IConnectorEnd element, string elementName, IXmiWriteContext writeContext)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (string.IsNullOrEmpty(elementName))
            {
                throw new ArgumentException(nameof(elementName));
            }

            if (writeContext == null)
            {
                throw new ArgumentNullException(nameof(writeContext));
            }

            if (element.Extensions.Count > 0)
            {
                this.logger.LogTrace("writing the {Count} Extension(s) of the ConnectorEnd with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ConnectorEnd");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.IsOrdered)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isOrdered", null, XmlConvert.ToString(element.IsOrdered));
            }

            if (!element.IsUnique)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isUnique", null, XmlConvert.ToString(element.IsUnique));
            }

            if (element.PartWithPort != null && writeContext.IsLocal(element.PartWithPort))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "partWithPort", null, element.PartWithPort.XmiId);
            }

            if (element.Role != null && writeContext.IsLocal(element.Role))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "role", null, element.Role.XmiId);
            }


            foreach (var value in element.LowerValue)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "lowerValue", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }

            if (element.PartWithPort != null && !writeContext.IsLocal(element.PartWithPort))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.PartWithPort, "partWithPort", writeContext);
            }

            if (element.Role != null && !writeContext.IsLocal(element.Role))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Role, "role", writeContext);
            }

            foreach (var value in element.UpperValue)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "upperValue", writeContext);
            }


            await WriteUnresolvedReferencesAsync(xmlWriter, element.UnresolvedReferences);

            await this.WriteExtensionsAsync(xmlWriter, element.Extensions);

            await xmlWriter.WriteEndElementAsync();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
