// -------------------------------------------------------------------------------------------------
// <copyright file="ExtensionEndWriter.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ExtensionEndWriter"/> is to write an instance of <see cref="IExtensionEnd"/>
    /// to an XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ExtensionEndWriter : XmiElementWriter<IExtensionEnd>, IXmiElementWriter<IExtensionEnd>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ExtensionEndWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionEndWriter"/> class.
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
        public ExtensionEndWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
            : base(xmiElementWriterFacade, xmiWriterSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ExtensionEndWriter>.Instance : loggerFactory.CreateLogger<ExtensionEndWriter>();
        }

        /// <summary>
        /// Writes the <see cref="IExtensionEnd"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IExtensionEnd"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public override void Write(XmlWriter xmlWriter, IExtensionEnd element, string elementName, IXmiWriteContext writeContext)
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
        /// Writes the <see cref="IExtensionEnd"/> object as default, non-canonical, XMI: the identifiers as read, the
        /// single values as XML attributes, the properties in alphabetical order, and the extensions
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IExtensionEnd"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        private void WriteDefault(XmlWriter xmlWriter, IExtensionEnd element, string elementName, IXmiWriteContext writeContext)
        {
            if (element.Extensions.Count > 0)
            {
                this.logger.LogTrace("writing the {Count} Extension(s) of the ExtensionEnd with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ExtensionEnd");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                xmlWriter.WriteAttributeString("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.Aggregation != AggregationKind.None)
            {
                xmlWriter.WriteAttributeString("aggregation", element.Aggregation.QueryXmiLiteral());
            }

            if (element.Association != null && writeContext.IsLocal(element.Association))
            {
                xmlWriter.WriteAttributeString("association", element.Association.XmiId);
            }

            if (element.IsDerived)
            {
                xmlWriter.WriteAttributeString("isDerived", XmlConvert.ToString(element.IsDerived));
            }

            if (element.IsDerivedUnion)
            {
                xmlWriter.WriteAttributeString("isDerivedUnion", XmlConvert.ToString(element.IsDerivedUnion));
            }

            if (element.IsID)
            {
                xmlWriter.WriteAttributeString("isID", XmlConvert.ToString(element.IsID));
            }

            if (element.IsLeaf)
            {
                xmlWriter.WriteAttributeString("isLeaf", XmlConvert.ToString(element.IsLeaf));
            }

            if (element.IsOrdered)
            {
                xmlWriter.WriteAttributeString("isOrdered", XmlConvert.ToString(element.IsOrdered));
            }

            if (element.IsReadOnly)
            {
                xmlWriter.WriteAttributeString("isReadOnly", XmlConvert.ToString(element.IsReadOnly));
            }

            if (element.IsStatic)
            {
                xmlWriter.WriteAttributeString("isStatic", XmlConvert.ToString(element.IsStatic));
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


            if (element.Association != null && !writeContext.IsLocal(element.Association))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Association, "association", writeContext);
            }

            foreach (var value in element.DefaultValue)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "defaultValue", writeContext);
            }

            foreach (var value in element.Deployment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "deployment", writeContext);
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

            foreach (var value in element.Qualifier)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "qualifier", writeContext);
            }

            foreach (var value in element.RedefinedProperty)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "redefinedProperty", writeContext);
            }

            foreach (var value in element.SubsettedProperty)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "subsettedProperty", writeContext);
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
        /// Asynchronously writes the <see cref="IExtensionEnd"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IExtensionEnd"/> that is to be written
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
        public override async Task WriteAsync(XmlWriter xmlWriter, IExtensionEnd element, string elementName, IXmiWriteContext writeContext)
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
        /// Asynchronously writes the <see cref="IExtensionEnd"/> object as default, non-canonical, XMI: the identifiers
        /// as read, the single values as XML attributes, the properties in alphabetical order, and the extensions
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IExtensionEnd"/> that is to be written
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
        private async Task WriteDefaultAsync(XmlWriter xmlWriter, IExtensionEnd element, string elementName, IXmiWriteContext writeContext)
        {
            if (element.Extensions.Count > 0)
            {
                this.logger.LogTrace("writing the {Count} Extension(s) of the ExtensionEnd with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ExtensionEnd");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.Aggregation != AggregationKind.None)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "aggregation", null, element.Aggregation.QueryXmiLiteral());
            }

            if (element.Association != null && writeContext.IsLocal(element.Association))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "association", null, element.Association.XmiId);
            }

            if (element.IsDerived)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isDerived", null, XmlConvert.ToString(element.IsDerived));
            }

            if (element.IsDerivedUnion)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isDerivedUnion", null, XmlConvert.ToString(element.IsDerivedUnion));
            }

            if (element.IsID)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isID", null, XmlConvert.ToString(element.IsID));
            }

            if (element.IsLeaf)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isLeaf", null, XmlConvert.ToString(element.IsLeaf));
            }

            if (element.IsOrdered)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isOrdered", null, XmlConvert.ToString(element.IsOrdered));
            }

            if (element.IsReadOnly)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isReadOnly", null, XmlConvert.ToString(element.IsReadOnly));
            }

            if (element.IsStatic)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isStatic", null, XmlConvert.ToString(element.IsStatic));
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


            if (element.Association != null && !writeContext.IsLocal(element.Association))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Association, "association", writeContext);
            }

            foreach (var value in element.DefaultValue)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "defaultValue", writeContext);
            }

            foreach (var value in element.Deployment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "deployment", writeContext);
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

            foreach (var value in element.Qualifier)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "qualifier", writeContext);
            }

            foreach (var value in element.RedefinedProperty)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "redefinedProperty", writeContext);
            }

            foreach (var value in element.SubsettedProperty)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "subsettedProperty", writeContext);
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
        /// Writes the <see cref="IExtensionEnd"/> object as Canonical XMI (XMI 2.5.1 Annex B): xmi:id, xmi:uuid and
        /// xmi:type, then every property as an XML element in the canonical order, without extensions
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IExtensionEnd"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        private void WriteCanonical(XmlWriter xmlWriter, IExtensionEnd element, string elementName, IXmiWriteContext writeContext)
        {
            this.WriteCanonicalStartElement(xmlWriter, element, elementName, "uml:ExtensionEnd", writeContext);

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

            foreach (var value in writeContext.QueryCanonicalOrder(element.Deployment, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "deployment", writeContext);
            }

            if (element.IsLeaf)
            {
                WriteValueElement(xmlWriter, "isLeaf", XmlConvert.ToString(element.IsLeaf));
            }

            if (element.IsStatic)
            {
                WriteValueElement(xmlWriter, "isStatic", XmlConvert.ToString(element.IsStatic));
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

            if (element.IsReadOnly)
            {
                WriteValueElement(xmlWriter, "isReadOnly", XmlConvert.ToString(element.IsReadOnly));
            }

            if (element.Aggregation != AggregationKind.None)
            {
                WriteValueElement(xmlWriter, "aggregation", element.Aggregation.QueryXmiLiteral());
            }

            if (element.Association != null)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Association, "association", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.DefaultValue, true))
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "defaultValue", writeContext);
            }

            if (element.IsDerived)
            {
                WriteValueElement(xmlWriter, "isDerived", XmlConvert.ToString(element.IsDerived));
            }

            if (element.IsDerivedUnion)
            {
                WriteValueElement(xmlWriter, "isDerivedUnion", XmlConvert.ToString(element.IsDerivedUnion));
            }

            if (element.IsID)
            {
                WriteValueElement(xmlWriter, "isID", XmlConvert.ToString(element.IsID));
            }

            foreach (var value in element.Qualifier)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "qualifier", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.RedefinedProperty, false))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "redefinedProperty", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.SubsettedProperty, false))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "subsettedProperty", writeContext);
            }


            WriteUnresolvedReferences(xmlWriter, element.UnresolvedReferences);

            xmlWriter.WriteFullEndElement();

            writeContext.EndCanonicalObject();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IExtensionEnd"/> object as Canonical XMI (XMI 2.5.1 Annex B): xmi:id,
        /// xmi:uuid and xmi:type, then every property as an XML element in the canonical order, without extensions
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IExtensionEnd"/> that is to be written
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
        private async Task WriteCanonicalAsync(XmlWriter xmlWriter, IExtensionEnd element, string elementName, IXmiWriteContext writeContext)
        {
            await this.WriteCanonicalStartElementAsync(xmlWriter, element, elementName, "uml:ExtensionEnd", writeContext);

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

            foreach (var value in writeContext.QueryCanonicalOrder(element.Deployment, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "deployment", writeContext);
            }

            if (element.IsLeaf)
            {
                await WriteValueElementAsync(xmlWriter, "isLeaf", XmlConvert.ToString(element.IsLeaf));
            }

            if (element.IsStatic)
            {
                await WriteValueElementAsync(xmlWriter, "isStatic", XmlConvert.ToString(element.IsStatic));
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

            if (element.IsReadOnly)
            {
                await WriteValueElementAsync(xmlWriter, "isReadOnly", XmlConvert.ToString(element.IsReadOnly));
            }

            if (element.Aggregation != AggregationKind.None)
            {
                await WriteValueElementAsync(xmlWriter, "aggregation", element.Aggregation.QueryXmiLiteral());
            }

            if (element.Association != null)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Association, "association", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.DefaultValue, true))
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "defaultValue", writeContext);
            }

            if (element.IsDerived)
            {
                await WriteValueElementAsync(xmlWriter, "isDerived", XmlConvert.ToString(element.IsDerived));
            }

            if (element.IsDerivedUnion)
            {
                await WriteValueElementAsync(xmlWriter, "isDerivedUnion", XmlConvert.ToString(element.IsDerivedUnion));
            }

            if (element.IsID)
            {
                await WriteValueElementAsync(xmlWriter, "isID", XmlConvert.ToString(element.IsID));
            }

            foreach (var value in element.Qualifier)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "qualifier", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.RedefinedProperty, false))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "redefinedProperty", writeContext);
            }

            foreach (var value in writeContext.QueryCanonicalOrder(element.SubsettedProperty, false))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "subsettedProperty", writeContext);
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
