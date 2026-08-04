// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterWriter.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ParameterWriter"/> is to write an instance of <see cref="IParameter"/>
    /// to an XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ParameterWriter : XmiElementWriter<IParameter>, IXmiElementWriter<IParameter>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ParameterWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterWriter"/> class.
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
        public ParameterWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
            : base(xmiElementWriterFacade, xmiWriterSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ParameterWriter>.Instance : loggerFactory.CreateLogger<ParameterWriter>();
        }

        /// <summary>
        /// Writes the <see cref="IParameter"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IParameter"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public override void Write(XmlWriter xmlWriter, IParameter element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the Parameter with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:Parameter");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                xmlWriter.WriteAttributeString("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.Direction != ParameterDirectionKind.In)
            {
                xmlWriter.WriteAttributeString("direction", LowerCaseFirstLetter(element.Direction.ToString()));
            }

            if (element.Effect != default(ParameterEffectKind))
            {
                xmlWriter.WriteAttributeString("effect", LowerCaseFirstLetter(element.Effect.ToString()));
            }

            if (element.IsException)
            {
                xmlWriter.WriteAttributeString("isException", XmlConvert.ToString(element.IsException));
            }

            if (element.IsOrdered)
            {
                xmlWriter.WriteAttributeString("isOrdered", XmlConvert.ToString(element.IsOrdered));
            }

            if (element.IsStream)
            {
                xmlWriter.WriteAttributeString("isStream", XmlConvert.ToString(element.IsStream));
            }

            if (!element.IsUnique)
            {
                xmlWriter.WriteAttributeString("isUnique", XmlConvert.ToString(element.IsUnique));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                xmlWriter.WriteAttributeString("name", element.Name);
            }

            if (element.Operation != null && writeContext.IsLocal(element.Operation))
            {
                xmlWriter.WriteAttributeString("operation", element.Operation.XmiId);
            }

            if (element.OwningTemplateParameter != null && writeContext.IsLocal(element.OwningTemplateParameter))
            {
                xmlWriter.WriteAttributeString("owningTemplateParameter", element.OwningTemplateParameter.XmiId);
            }

            if (element.TemplateParameter != null && writeContext.IsLocal(element.TemplateParameter))
            {
                xmlWriter.WriteAttributeString("templateParameter", element.TemplateParameter.XmiId);
            }

            if (element.Type != null && writeContext.IsLocal(element.Type))
            {
                xmlWriter.WriteAttributeString("type", element.Type.XmiId);
            }

            if (element.Visibility != default(VisibilityKind))
            {
                xmlWriter.WriteAttributeString("visibility", LowerCaseFirstLetter(element.Visibility.ToString()));
            }


            foreach (var value in element.DefaultValue)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "defaultValue", writeContext);
            }

            foreach (var value in element.LowerValue)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "lowerValue", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "nameExpression", writeContext);
            }

            if (element.Operation != null && !writeContext.IsLocal(element.Operation))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Operation, "operation", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }

            if (element.OwningTemplateParameter != null && !writeContext.IsLocal(element.OwningTemplateParameter))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.OwningTemplateParameter, "owningTemplateParameter", writeContext);
            }

            foreach (var value in element.ParameterSet)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "parameterSet", writeContext);
            }

            if (element.TemplateParameter != null && !writeContext.IsLocal(element.TemplateParameter))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.TemplateParameter, "templateParameter", writeContext);
            }

            if (element.Type != null && !writeContext.IsLocal(element.Type))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Type, "type", writeContext);
            }

            foreach (var value in element.UpperValue)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "upperValue", writeContext);
            }


            this.WriteExtensions(xmlWriter, element.Extensions);

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IParameter"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IParameter"/> that is to be written
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
        public override async Task WriteAsync(XmlWriter xmlWriter, IParameter element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the Parameter with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:Parameter");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.Direction != ParameterDirectionKind.In)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "direction", null, LowerCaseFirstLetter(element.Direction.ToString()));
            }

            if (element.Effect != default(ParameterEffectKind))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "effect", null, LowerCaseFirstLetter(element.Effect.ToString()));
            }

            if (element.IsException)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isException", null, XmlConvert.ToString(element.IsException));
            }

            if (element.IsOrdered)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isOrdered", null, XmlConvert.ToString(element.IsOrdered));
            }

            if (element.IsStream)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isStream", null, XmlConvert.ToString(element.IsStream));
            }

            if (!element.IsUnique)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isUnique", null, XmlConvert.ToString(element.IsUnique));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "name", null, element.Name);
            }

            if (element.Operation != null && writeContext.IsLocal(element.Operation))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "operation", null, element.Operation.XmiId);
            }

            if (element.OwningTemplateParameter != null && writeContext.IsLocal(element.OwningTemplateParameter))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "owningTemplateParameter", null, element.OwningTemplateParameter.XmiId);
            }

            if (element.TemplateParameter != null && writeContext.IsLocal(element.TemplateParameter))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "templateParameter", null, element.TemplateParameter.XmiId);
            }

            if (element.Type != null && writeContext.IsLocal(element.Type))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "type", null, element.Type.XmiId);
            }

            if (element.Visibility != default(VisibilityKind))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "visibility", null, LowerCaseFirstLetter(element.Visibility.ToString()));
            }


            foreach (var value in element.DefaultValue)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "defaultValue", writeContext);
            }

            foreach (var value in element.LowerValue)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "lowerValue", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "nameExpression", writeContext);
            }

            if (element.Operation != null && !writeContext.IsLocal(element.Operation))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Operation, "operation", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }

            if (element.OwningTemplateParameter != null && !writeContext.IsLocal(element.OwningTemplateParameter))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.OwningTemplateParameter, "owningTemplateParameter", writeContext);
            }

            foreach (var value in element.ParameterSet)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "parameterSet", writeContext);
            }

            if (element.TemplateParameter != null && !writeContext.IsLocal(element.TemplateParameter))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.TemplateParameter, "templateParameter", writeContext);
            }

            if (element.Type != null && !writeContext.IsLocal(element.Type))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Type, "type", writeContext);
            }

            foreach (var value in element.UpperValue)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "upperValue", writeContext);
            }


            await this.WriteExtensionsAsync(xmlWriter, element.Extensions);

            await xmlWriter.WriteEndElementAsync();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
