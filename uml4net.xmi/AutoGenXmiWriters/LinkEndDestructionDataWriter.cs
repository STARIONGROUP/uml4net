// -------------------------------------------------------------------------------------------------
// <copyright file="LinkEndDestructionDataWriter.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="LinkEndDestructionDataWriter"/> is to write an instance of <see cref="ILinkEndDestructionData"/>
    /// to an XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class LinkEndDestructionDataWriter : XmiElementWriter<ILinkEndDestructionData>, IXmiElementWriter<ILinkEndDestructionData>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<LinkEndDestructionDataWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkEndDestructionDataWriter"/> class.
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
        public LinkEndDestructionDataWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
            : base(xmiElementWriterFacade, xmiWriterSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<LinkEndDestructionDataWriter>.Instance : loggerFactory.CreateLogger<LinkEndDestructionDataWriter>();
        }

        /// <summary>
        /// Writes the <see cref="ILinkEndDestructionData"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="ILinkEndDestructionData"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public override void Write(XmlWriter xmlWriter, ILinkEndDestructionData element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the LinkEndDestructionData with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:LinkEndDestructionData");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                xmlWriter.WriteAttributeString("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.DestroyAt != null && writeContext.IsLocal(element.DestroyAt))
            {
                xmlWriter.WriteAttributeString("destroyAt", element.DestroyAt.XmiId);
            }

            if (element.End != null && writeContext.IsLocal(element.End))
            {
                xmlWriter.WriteAttributeString("end", element.End.XmiId);
            }

            if (element.IsDestroyDuplicates)
            {
                xmlWriter.WriteAttributeString("isDestroyDuplicates", XmlConvert.ToString(element.IsDestroyDuplicates));
            }

            if (element.Value != null && writeContext.IsLocal(element.Value))
            {
                xmlWriter.WriteAttributeString("value", element.Value.XmiId);
            }


            if (element.DestroyAt != null && !writeContext.IsLocal(element.DestroyAt))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.DestroyAt, "destroyAt", writeContext);
            }

            if (element.End != null && !writeContext.IsLocal(element.End))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.End, "end", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.Qualifier)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "qualifier", writeContext);
            }

            if (element.Value != null && !writeContext.IsLocal(element.Value))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Value, "value", writeContext);
            }


            this.WriteExtensions(xmlWriter, element.Extensions);

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="ILinkEndDestructionData"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="ILinkEndDestructionData"/> that is to be written
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
        public override async Task WriteAsync(XmlWriter xmlWriter, ILinkEndDestructionData element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the LinkEndDestructionData with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:LinkEndDestructionData");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.DestroyAt != null && writeContext.IsLocal(element.DestroyAt))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "destroyAt", null, element.DestroyAt.XmiId);
            }

            if (element.End != null && writeContext.IsLocal(element.End))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "end", null, element.End.XmiId);
            }

            if (element.IsDestroyDuplicates)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isDestroyDuplicates", null, XmlConvert.ToString(element.IsDestroyDuplicates));
            }

            if (element.Value != null && writeContext.IsLocal(element.Value))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "value", null, element.Value.XmiId);
            }


            if (element.DestroyAt != null && !writeContext.IsLocal(element.DestroyAt))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.DestroyAt, "destroyAt", writeContext);
            }

            if (element.End != null && !writeContext.IsLocal(element.End))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.End, "end", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.Qualifier)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "qualifier", writeContext);
            }

            if (element.Value != null && !writeContext.IsLocal(element.Value))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Value, "value", writeContext);
            }


            await this.WriteExtensionsAsync(xmlWriter, element.Extensions);

            await xmlWriter.WriteEndElementAsync();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
