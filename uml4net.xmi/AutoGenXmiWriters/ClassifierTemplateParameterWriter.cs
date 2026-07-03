// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierTemplateParameterWriter.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ClassifierTemplateParameterWriter"/> is to write an instance of <see cref="IClassifierTemplateParameter"/>
    /// to an XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ClassifierTemplateParameterWriter : XmiElementWriter<IClassifierTemplateParameter>, IXmiElementWriter<IClassifierTemplateParameter>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ClassifierTemplateParameterWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassifierTemplateParameterWriter"/> class.
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
        public ClassifierTemplateParameterWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
            : base(xmiElementWriterFacade, xmiWriterSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ClassifierTemplateParameterWriter>.Instance : loggerFactory.CreateLogger<ClassifierTemplateParameterWriter>();
        }

        /// <summary>
        /// Writes the <see cref="IClassifierTemplateParameter"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IClassifierTemplateParameter"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public override void Write(XmlWriter xmlWriter, IClassifierTemplateParameter element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogWarning("The Extensions of the ClassifierTemplateParameter with id [{Id}] are not written", element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ClassifierTemplateParameter");

            xmlWriter.WriteAttributeString("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (!element.AllowSubstitutable)
            {
                xmlWriter.WriteAttributeString("allowSubstitutable", XmlConvert.ToString(element.AllowSubstitutable));
            }

            if (element.Default != null && writeContext.IsLocal(element.Default))
            {
                xmlWriter.WriteAttributeString("default", element.Default.XmiId);
            }

            if (element.ParameteredElement != null && writeContext.IsLocal(element.ParameteredElement))
            {
                xmlWriter.WriteAttributeString("parameteredElement", element.ParameteredElement.XmiId);
            }

            if (element.Signature != null && writeContext.IsLocal(element.Signature))
            {
                xmlWriter.WriteAttributeString("signature", element.Signature.XmiId);
            }


            foreach (var value in element.ConstrainingClassifier)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "constrainingClassifier", writeContext);
            }

            if (element.Default != null && !writeContext.IsLocal(element.Default))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Default, "default", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.OwnedDefault)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedDefault", writeContext);
            }

            foreach (var value in element.OwnedParameteredElement)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedParameteredElement", writeContext);
            }

            if (element.ParameteredElement != null && !writeContext.IsLocal(element.ParameteredElement))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.ParameteredElement, "parameteredElement", writeContext);
            }

            if (element.Signature != null && !writeContext.IsLocal(element.Signature))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Signature, "signature", writeContext);
            }


            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IClassifierTemplateParameter"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IClassifierTemplateParameter"/> that is to be written
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
        public override async Task WriteAsync(XmlWriter xmlWriter, IClassifierTemplateParameter element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogWarning("The Extensions of the ClassifierTemplateParameter with id [{Id}] are not written", element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ClassifierTemplateParameter");

            await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (!element.AllowSubstitutable)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "allowSubstitutable", null, XmlConvert.ToString(element.AllowSubstitutable));
            }

            if (element.Default != null && writeContext.IsLocal(element.Default))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "default", null, element.Default.XmiId);
            }

            if (element.ParameteredElement != null && writeContext.IsLocal(element.ParameteredElement))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "parameteredElement", null, element.ParameteredElement.XmiId);
            }

            if (element.Signature != null && writeContext.IsLocal(element.Signature))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "signature", null, element.Signature.XmiId);
            }


            foreach (var value in element.ConstrainingClassifier)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "constrainingClassifier", writeContext);
            }

            if (element.Default != null && !writeContext.IsLocal(element.Default))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Default, "default", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.OwnedDefault)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedDefault", writeContext);
            }

            foreach (var value in element.OwnedParameteredElement)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedParameteredElement", writeContext);
            }

            if (element.ParameteredElement != null && !writeContext.IsLocal(element.ParameteredElement))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.ParameteredElement, "parameteredElement", writeContext);
            }

            if (element.Signature != null && !writeContext.IsLocal(element.Signature))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Signature, "signature", writeContext);
            }


            await xmlWriter.WriteEndElementAsync();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
