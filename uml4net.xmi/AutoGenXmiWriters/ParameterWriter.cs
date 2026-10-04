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

            if (writeContext.IsCanonical)
            {
                this.WriteCanonical(xmlWriter, element, elementName, writeContext);
                return;
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
                xmlWriter.WriteAttributeString("direction", element.Direction.QueryXmiLiteral());
            }

            if (element.Effect.HasValue)
            {
                xmlWriter.WriteAttributeString("effect", element.Effect.Value.QueryXmiLiteral());
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

            if (element.TemplateParameter != null && writeContext.IsLocal(element.TemplateParameter))
            {
                xmlWriter.WriteAttributeString("templateParameter", element.TemplateParameter.XmiId);
            }

            if (element.Type != null && writeContext.IsLocal(element.Type))
            {
                xmlWriter.WriteAttributeString("type", element.Type.XmiId);
            }

            if (element.Visibility.HasValue)
            {
                xmlWriter.WriteAttributeString("visibility", element.Visibility.Value.QueryXmiLiteral());
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

            foreach (var value in element.OwnedComment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
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


            WriteUnresolvedReferences(xmlWriter, element.UnresolvedReferences);

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

            if (writeContext.IsCanonical)
            {
                await this.WriteCanonicalAsync(xmlWriter, element, elementName, writeContext);
                return;
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
                await xmlWriter.WriteAttributeStringAsync(null, "direction", null, element.Direction.QueryXmiLiteral());
            }

            if (element.Effect.HasValue)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "effect", null, element.Effect.Value.QueryXmiLiteral());
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

            if (element.TemplateParameter != null && writeContext.IsLocal(element.TemplateParameter))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "templateParameter", null, element.TemplateParameter.XmiId);
            }

            if (element.Type != null && writeContext.IsLocal(element.Type))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "type", null, element.Type.XmiId);
            }

            if (element.Visibility.HasValue)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "visibility", null, element.Visibility.Value.QueryXmiLiteral());
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

            foreach (var value in element.OwnedComment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
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


            await WriteUnresolvedReferencesAsync(xmlWriter, element.UnresolvedReferences);

            await this.WriteExtensionsAsync(xmlWriter, element.Extensions);

            await xmlWriter.WriteEndElementAsync();
        }

        /// <summary>
        /// Writes the <see cref="IParameter"/> object as Canonical XMI (XMI 2.5.1 Annex B): xmi:id, xmi:uuid and
        /// xmi:type, then every property as an XML element in the canonical order, without extensions
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
        private void WriteCanonical(XmlWriter xmlWriter, IParameter element, string elementName, IXmiWriteContext writeContext)
        {
            this.WriteCanonicalStartElement(xmlWriter, element, elementName, "uml:Parameter", writeContext);

            foreach (var value in writeContext.QueryCanonicalOrder(element.OwnedComment, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }

            if (element.TemplateParameter != null)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.TemplateParameter, "templateParameter", writeContext);
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

            if (element.Type != null)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Type, "type", writeContext);
            }

            if (element.IsOrdered)
            {
                WriteValueElement(xmlWriter, "isOrdered", XmlConvert.ToString(element.IsOrdered));
            }

            if (!element.IsUnique)
            {
                WriteValueElement(xmlWriter, "isUnique", XmlConvert.ToString(element.IsUnique));
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.LowerValue, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "lowerValue", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.UpperValue, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "upperValue", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.DefaultValue, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "defaultValue", writeContext);
            }

            if (element.Direction != ParameterDirectionKind.In)
            {
                WriteValueElement(xmlWriter, "direction", element.Direction.QueryXmiLiteral());
            }

            if (element.Effect.HasValue)
            {
                WriteValueElement(xmlWriter, "effect", element.Effect.Value.QueryXmiLiteral());
            }

            if (element.IsException)
            {
                WriteValueElement(xmlWriter, "isException", XmlConvert.ToString(element.IsException));
            }

            if (element.IsStream)
            {
                WriteValueElement(xmlWriter, "isStream", XmlConvert.ToString(element.IsStream));
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.ParameterSet, false))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "parameterSet", writeContext);
            }


            WriteUnresolvedReferences(xmlWriter, element.UnresolvedReferences);

            xmlWriter.WriteFullEndElement();

            writeContext.EndCanonicalObject();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IParameter"/> object as Canonical XMI (XMI 2.5.1 Annex B): xmi:id,
        /// xmi:uuid and xmi:type, then every property as an XML element in the canonical order, without extensions
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
        private async Task WriteCanonicalAsync(XmlWriter xmlWriter, IParameter element, string elementName, IXmiWriteContext writeContext)
        {
            await this.WriteCanonicalStartElementAsync(xmlWriter, element, elementName, "uml:Parameter", writeContext);

            foreach (var value in writeContext.QueryCanonicalOrder(element.OwnedComment, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }

            if (element.TemplateParameter != null)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.TemplateParameter, "templateParameter", writeContext);
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

            if (element.Type != null)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Type, "type", writeContext);
            }

            if (element.IsOrdered)
            {
                await WriteValueElementAsync(xmlWriter, "isOrdered", XmlConvert.ToString(element.IsOrdered));
            }

            if (!element.IsUnique)
            {
                await WriteValueElementAsync(xmlWriter, "isUnique", XmlConvert.ToString(element.IsUnique));
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.LowerValue, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "lowerValue", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.UpperValue, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "upperValue", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.DefaultValue, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "defaultValue", writeContext);
            }

            if (element.Direction != ParameterDirectionKind.In)
            {
                await WriteValueElementAsync(xmlWriter, "direction", element.Direction.QueryXmiLiteral());
            }

            if (element.Effect.HasValue)
            {
                await WriteValueElementAsync(xmlWriter, "effect", element.Effect.Value.QueryXmiLiteral());
            }

            if (element.IsException)
            {
                await WriteValueElementAsync(xmlWriter, "isException", XmlConvert.ToString(element.IsException));
            }

            if (element.IsStream)
            {
                await WriteValueElementAsync(xmlWriter, "isStream", XmlConvert.ToString(element.IsStream));
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.ParameterSet, false))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "parameterSet", writeContext);
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
