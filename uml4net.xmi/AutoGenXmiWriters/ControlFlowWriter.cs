// -------------------------------------------------------------------------------------------------
// <copyright file="ControlFlowWriter.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ControlFlowWriter"/> is to write an instance of <see cref="IControlFlow"/>
    /// to an XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ControlFlowWriter : XmiElementWriter<IControlFlow>, IXmiElementWriter<IControlFlow>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ControlFlowWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlFlowWriter"/> class.
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
        public ControlFlowWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
            : base(xmiElementWriterFacade, xmiWriterSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ControlFlowWriter>.Instance : loggerFactory.CreateLogger<ControlFlowWriter>();
        }

        /// <summary>
        /// Writes the <see cref="IControlFlow"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IControlFlow"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public override void Write(XmlWriter xmlWriter, IControlFlow element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the ControlFlow with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ControlFlow");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                xmlWriter.WriteAttributeString("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.Activity != null && writeContext.IsLocal(element.Activity))
            {
                xmlWriter.WriteAttributeString("activity", element.Activity.XmiId);
            }

            if (element.InStructuredNode != null && writeContext.IsLocal(element.InStructuredNode))
            {
                xmlWriter.WriteAttributeString("inStructuredNode", element.InStructuredNode.XmiId);
            }

            if (element.Interrupts != null && writeContext.IsLocal(element.Interrupts))
            {
                xmlWriter.WriteAttributeString("interrupts", element.Interrupts.XmiId);
            }

            if (element.IsLeaf)
            {
                xmlWriter.WriteAttributeString("isLeaf", XmlConvert.ToString(element.IsLeaf));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                xmlWriter.WriteAttributeString("name", element.Name);
            }

            if (element.Source != null && writeContext.IsLocal(element.Source))
            {
                xmlWriter.WriteAttributeString("source", element.Source.XmiId);
            }

            if (element.Target != null && writeContext.IsLocal(element.Target))
            {
                xmlWriter.WriteAttributeString("target", element.Target.XmiId);
            }

            if (element.Visibility != default(VisibilityKind))
            {
                xmlWriter.WriteAttributeString("visibility", LowerCaseFirstLetter(element.Visibility.ToString()));
            }


            if (element.Activity != null && !writeContext.IsLocal(element.Activity))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Activity, "activity", writeContext);
            }

            foreach (var value in element.Guard)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "guard", writeContext);
            }

            foreach (var value in element.InPartition)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "inPartition", writeContext);
            }

            if (element.InStructuredNode != null && !writeContext.IsLocal(element.InStructuredNode))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.InStructuredNode, "inStructuredNode", writeContext);
            }

            if (element.Interrupts != null && !writeContext.IsLocal(element.Interrupts))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Interrupts, "interrupts", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "nameExpression", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.RedefinedEdge)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "redefinedEdge", writeContext);
            }

            if (element.Source != null && !writeContext.IsLocal(element.Source))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Source, "source", writeContext);
            }

            if (element.Target != null && !writeContext.IsLocal(element.Target))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Target, "target", writeContext);
            }

            foreach (var value in element.Weight)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "weight", writeContext);
            }


            WriteUnresolvedReferences(xmlWriter, element.UnresolvedReferences);

            this.WriteExtensions(xmlWriter, element.Extensions);

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IControlFlow"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IControlFlow"/> that is to be written
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
        public override async Task WriteAsync(XmlWriter xmlWriter, IControlFlow element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the ControlFlow with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ControlFlow");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.Activity != null && writeContext.IsLocal(element.Activity))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "activity", null, element.Activity.XmiId);
            }

            if (element.InStructuredNode != null && writeContext.IsLocal(element.InStructuredNode))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "inStructuredNode", null, element.InStructuredNode.XmiId);
            }

            if (element.Interrupts != null && writeContext.IsLocal(element.Interrupts))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "interrupts", null, element.Interrupts.XmiId);
            }

            if (element.IsLeaf)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isLeaf", null, XmlConvert.ToString(element.IsLeaf));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "name", null, element.Name);
            }

            if (element.Source != null && writeContext.IsLocal(element.Source))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "source", null, element.Source.XmiId);
            }

            if (element.Target != null && writeContext.IsLocal(element.Target))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "target", null, element.Target.XmiId);
            }

            if (element.Visibility != default(VisibilityKind))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "visibility", null, LowerCaseFirstLetter(element.Visibility.ToString()));
            }


            if (element.Activity != null && !writeContext.IsLocal(element.Activity))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Activity, "activity", writeContext);
            }

            foreach (var value in element.Guard)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "guard", writeContext);
            }

            foreach (var value in element.InPartition)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "inPartition", writeContext);
            }

            if (element.InStructuredNode != null && !writeContext.IsLocal(element.InStructuredNode))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.InStructuredNode, "inStructuredNode", writeContext);
            }

            if (element.Interrupts != null && !writeContext.IsLocal(element.Interrupts))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Interrupts, "interrupts", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "nameExpression", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.RedefinedEdge)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "redefinedEdge", writeContext);
            }

            if (element.Source != null && !writeContext.IsLocal(element.Source))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Source, "source", writeContext);
            }

            if (element.Target != null && !writeContext.IsLocal(element.Target))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Target, "target", writeContext);
            }

            foreach (var value in element.Weight)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "weight", writeContext);
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
