// -------------------------------------------------------------------------------------------------
// <copyright file="ReadLinkObjectEndActionWriter.cs" company="Starion Group S.A.">
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
    using System.Linq;
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
    /// The purpose of the <see cref="ReadLinkObjectEndActionWriter"/> is to write an instance of <see cref="IReadLinkObjectEndAction"/>
    /// to an XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ReadLinkObjectEndActionWriter : XmiElementWriter<IReadLinkObjectEndAction>, IXmiElementWriter<IReadLinkObjectEndAction>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ReadLinkObjectEndActionWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadLinkObjectEndActionWriter"/> class.
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
        public ReadLinkObjectEndActionWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
            : base(xmiElementWriterFacade, xmiWriterSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ReadLinkObjectEndActionWriter>.Instance : loggerFactory.CreateLogger<ReadLinkObjectEndActionWriter>();
        }

        /// <summary>
        /// Writes the <see cref="IReadLinkObjectEndAction"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IReadLinkObjectEndAction"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public override void Write(XmlWriter xmlWriter, IReadLinkObjectEndAction element, string elementName, IXmiWriteContext writeContext)
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

            if (writeContext.IsCanonical)
            {
                this.WriteCanonical(xmlWriter, element, elementName, writeContext);
            }
            else
            {
                this.WriteDefault(xmlWriter, element, elementName, writeContext);
            }
        }

        /// <summary>
        /// Writes the <see cref="IReadLinkObjectEndAction"/> object as default, non-canonical, XMI: the identifiers as read, the
        /// single values as XML attributes, the properties in alphabetical order, and the extensions
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IReadLinkObjectEndAction"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        private void WriteDefault(XmlWriter xmlWriter, IReadLinkObjectEndAction element, string elementName, IXmiWriteContext writeContext)
        {
            if (element.Extensions.Count > 0)
            {
                this.logger.LogTrace("writing the {Count} Extension(s) of the ReadLinkObjectEndAction with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ReadLinkObjectEndAction");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                xmlWriter.WriteAttributeString("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.End != null && writeContext.IsLocal(element.End))
            {
                xmlWriter.WriteAttributeString("end", element.End.XmiId);
            }

            if (element.IsLeaf)
            {
                xmlWriter.WriteAttributeString("isLeaf", XmlConvert.ToString(element.IsLeaf));
            }

            if (element.IsLocallyReentrant)
            {
                xmlWriter.WriteAttributeString("isLocallyReentrant", XmlConvert.ToString(element.IsLocallyReentrant));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                xmlWriter.WriteAttributeString("name", element.Name);
            }

            if (element.Visibility.HasValue)
            {
                xmlWriter.WriteAttributeString("visibility", element.Visibility.Value.QueryXmiLiteral());
            }


            if (element.End != null && !writeContext.IsLocal(element.End))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.End, "end", writeContext);
            }

            foreach (var value in element.Handler)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "handler", writeContext);
            }

            foreach (var value in element.Incoming)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "incoming", writeContext);
            }

            foreach (var value in element.InInterruptibleRegion)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "inInterruptibleRegion", writeContext);
            }

            foreach (var value in element.InPartition)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "inPartition", writeContext);
            }

            foreach (var value in element.LocalPostcondition)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "localPostcondition", writeContext);
            }

            foreach (var value in element.LocalPrecondition)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "localPrecondition", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "nameExpression", writeContext);
            }

            foreach (var value in element.Object)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "object", writeContext);
            }

            foreach (var value in element.Outgoing)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "outgoing", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.RedefinedNode)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "redefinedNode", writeContext);
            }

            foreach (var value in element.Result)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "result", writeContext);
            }


            WriteUnresolvedReferences(xmlWriter, element.UnresolvedReferences);

            this.WriteExtensions(xmlWriter, element.Extensions);

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IReadLinkObjectEndAction"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IReadLinkObjectEndAction"/> that is to be written
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
        public override async Task WriteAsync(XmlWriter xmlWriter, IReadLinkObjectEndAction element, string elementName, IXmiWriteContext writeContext)
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

            if (writeContext.IsCanonical)
            {
                await this.WriteCanonicalAsync(xmlWriter, element, elementName, writeContext);
            }
            else
            {
                await this.WriteDefaultAsync(xmlWriter, element, elementName, writeContext);
            }
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IReadLinkObjectEndAction"/> object as default, non-canonical, XMI: the identifiers
        /// as read, the single values as XML attributes, the properties in alphabetical order, and the extensions
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IReadLinkObjectEndAction"/> that is to be written
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
        private async Task WriteDefaultAsync(XmlWriter xmlWriter, IReadLinkObjectEndAction element, string elementName, IXmiWriteContext writeContext)
        {
            if (element.Extensions.Count > 0)
            {
                this.logger.LogTrace("writing the {Count} Extension(s) of the ReadLinkObjectEndAction with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ReadLinkObjectEndAction");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.End != null && writeContext.IsLocal(element.End))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "end", null, element.End.XmiId);
            }

            if (element.IsLeaf)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isLeaf", null, XmlConvert.ToString(element.IsLeaf));
            }

            if (element.IsLocallyReentrant)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isLocallyReentrant", null, XmlConvert.ToString(element.IsLocallyReentrant));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "name", null, element.Name);
            }

            if (element.Visibility.HasValue)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "visibility", null, element.Visibility.Value.QueryXmiLiteral());
            }


            if (element.End != null && !writeContext.IsLocal(element.End))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.End, "end", writeContext);
            }

            foreach (var value in element.Handler)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "handler", writeContext);
            }

            foreach (var value in element.Incoming)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "incoming", writeContext);
            }

            foreach (var value in element.InInterruptibleRegion)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "inInterruptibleRegion", writeContext);
            }

            foreach (var value in element.InPartition)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "inPartition", writeContext);
            }

            foreach (var value in element.LocalPostcondition)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "localPostcondition", writeContext);
            }

            foreach (var value in element.LocalPrecondition)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "localPrecondition", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "nameExpression", writeContext);
            }

            foreach (var value in element.Object)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "object", writeContext);
            }

            foreach (var value in element.Outgoing)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "outgoing", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.RedefinedNode)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "redefinedNode", writeContext);
            }

            foreach (var value in element.Result)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "result", writeContext);
            }


            await WriteUnresolvedReferencesAsync(xmlWriter, element.UnresolvedReferences);

            await this.WriteExtensionsAsync(xmlWriter, element.Extensions);

            await xmlWriter.WriteEndElementAsync();
        }

        /// <summary>
        /// Writes the <see cref="IReadLinkObjectEndAction"/> object as Canonical XMI (XMI 2.5.1 Annex B): xmi:id, xmi:uuid and
        /// xmi:type, then every property as an XML element in the canonical order, without extensions
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IReadLinkObjectEndAction"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        private void WriteCanonical(XmlWriter xmlWriter, IReadLinkObjectEndAction element, string elementName, IXmiWriteContext writeContext)
        {
            this.WriteCanonicalStartElement(xmlWriter, element, elementName, "uml:ReadLinkObjectEndAction", writeContext);

            foreach (var value in writeContext.QueryCanonicalOrder(element.OwnedComment, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                WriteValueElement(xmlWriter, "name", element.Name);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.NameExpression, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "nameExpression", writeContext);
            }

            if (element.Visibility.HasValue)
            {
                WriteValueElement(xmlWriter, "visibility", element.Visibility.Value.QueryXmiLiteral());
            }

            if (element.IsLeaf)
            {
                WriteValueElement(xmlWriter, "isLeaf", XmlConvert.ToString(element.IsLeaf));
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.InInterruptibleRegion, false))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "inInterruptibleRegion", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.InPartition, false))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "inPartition", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.Incoming, false))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "incoming", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.Outgoing, false))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "outgoing", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.RedefinedNode, false))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "redefinedNode", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.Handler, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "handler", writeContext);
            }

            if (element.IsLocallyReentrant)
            {
                WriteValueElement(xmlWriter, "isLocallyReentrant", XmlConvert.ToString(element.IsLocallyReentrant));
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.LocalPostcondition, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "localPostcondition", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.LocalPrecondition, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "localPrecondition", writeContext);
            }

            if (element.End != null)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.End, "end", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.Object, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "object", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.Result, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "result", writeContext);
            }


            WriteUnresolvedReferences(xmlWriter, element.UnresolvedReferences);

            xmlWriter.WriteFullEndElement();

            writeContext.EndCanonicalObject();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IReadLinkObjectEndAction"/> object as Canonical XMI (XMI 2.5.1 Annex B): xmi:id,
        /// xmi:uuid and xmi:type, then every property as an XML element in the canonical order, without extensions
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IReadLinkObjectEndAction"/> that is to be written
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
        private async Task WriteCanonicalAsync(XmlWriter xmlWriter, IReadLinkObjectEndAction element, string elementName, IXmiWriteContext writeContext)
        {
            await this.WriteCanonicalStartElementAsync(xmlWriter, element, elementName, "uml:ReadLinkObjectEndAction", writeContext);

            foreach (var value in writeContext.QueryCanonicalOrder(element.OwnedComment, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                await WriteValueElementAsync(xmlWriter, "name", element.Name);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.NameExpression, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "nameExpression", writeContext);
            }

            if (element.Visibility.HasValue)
            {
                await WriteValueElementAsync(xmlWriter, "visibility", element.Visibility.Value.QueryXmiLiteral());
            }

            if (element.IsLeaf)
            {
                await WriteValueElementAsync(xmlWriter, "isLeaf", XmlConvert.ToString(element.IsLeaf));
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.InInterruptibleRegion, false))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "inInterruptibleRegion", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.InPartition, false))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "inPartition", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.Incoming, false))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "incoming", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.Outgoing, false))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "outgoing", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.RedefinedNode, false))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "redefinedNode", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.Handler, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "handler", writeContext);
            }

            if (element.IsLocallyReentrant)
            {
                await WriteValueElementAsync(xmlWriter, "isLocallyReentrant", XmlConvert.ToString(element.IsLocallyReentrant));
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.LocalPostcondition, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "localPostcondition", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.LocalPrecondition, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "localPrecondition", writeContext);
            }

            if (element.End != null)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.End, "end", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.Object, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "object", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.Result, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "result", writeContext);
            }


            await WriteUnresolvedReferencesAsync(xmlWriter, element.UnresolvedReferences);

            await xmlWriter.WriteFullEndElementAsync();

            writeContext.EndCanonicalObject();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
