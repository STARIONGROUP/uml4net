// -------------------------------------------------------------------------------------------------
// <copyright file="GeneralizationWriter.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="GeneralizationWriter"/> is to write an instance of <see cref="IGeneralization"/>
    /// to an XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class GeneralizationWriter : XmiElementWriter<IGeneralization>, IXmiElementWriter<IGeneralization>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<GeneralizationWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralizationWriter"/> class.
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
        public GeneralizationWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
            : base(xmiElementWriterFacade, xmiWriterSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<GeneralizationWriter>.Instance : loggerFactory.CreateLogger<GeneralizationWriter>();
        }

        /// <summary>
        /// Writes the <see cref="IGeneralization"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IGeneralization"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public override void Write(XmlWriter xmlWriter, IGeneralization element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the Generalization with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:Generalization");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                xmlWriter.WriteAttributeString("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.General != null && writeContext.IsLocal(element.General))
            {
                xmlWriter.WriteAttributeString("general", element.General.XmiId);
            }

            if (!element.IsSubstitutable)
            {
                xmlWriter.WriteAttributeString("isSubstitutable", XmlConvert.ToString(element.IsSubstitutable));
            }

            if (element.Specific != null && writeContext.IsLocal(element.Specific))
            {
                xmlWriter.WriteAttributeString("specific", element.Specific.XmiId);
            }


            if (element.General != null && !writeContext.IsLocal(element.General))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.General, "general", writeContext);
            }

            foreach (var value in element.GeneralizationSet)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "generalizationSet", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }

            if (element.Specific != null && !writeContext.IsLocal(element.Specific))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Specific, "specific", writeContext);
            }


            this.WriteExtensions(xmlWriter, element.Extensions);

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IGeneralization"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IGeneralization"/> that is to be written
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
        public override async Task WriteAsync(XmlWriter xmlWriter, IGeneralization element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the Generalization with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:Generalization");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.General != null && writeContext.IsLocal(element.General))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "general", null, element.General.XmiId);
            }

            if (!element.IsSubstitutable)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isSubstitutable", null, XmlConvert.ToString(element.IsSubstitutable));
            }

            if (element.Specific != null && writeContext.IsLocal(element.Specific))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "specific", null, element.Specific.XmiId);
            }


            if (element.General != null && !writeContext.IsLocal(element.General))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.General, "general", writeContext);
            }

            foreach (var value in element.GeneralizationSet)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "generalizationSet", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }

            if (element.Specific != null && !writeContext.IsLocal(element.Specific))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Specific, "specific", writeContext);
            }


            await this.WriteExtensionsAsync(xmlWriter, element.Extensions);

            await xmlWriter.WriteEndElementAsync();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
