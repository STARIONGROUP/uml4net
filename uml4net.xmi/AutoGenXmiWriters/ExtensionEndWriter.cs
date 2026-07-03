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

            if (element.Extensions.Count > 0)
            {
                this.logger.LogWarning("The Extensions of the ExtensionEnd with id [{Id}] are not written", element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ExtensionEnd");

            xmlWriter.WriteAttributeString("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.Aggregation != AggregationKind.None)
            {
                xmlWriter.WriteAttributeString("aggregation", LowerCaseFirstLetter(element.Aggregation.ToString()));
            }

            if (element.Association != null && writeContext.IsLocal(element.Association))
            {
                xmlWriter.WriteAttributeString("association", element.Association.XmiId);
            }

            if (element.AssociationEnd != null && writeContext.IsLocal(element.AssociationEnd))
            {
                xmlWriter.WriteAttributeString("associationEnd", element.AssociationEnd.XmiId);
            }

            if (element.Class != null && writeContext.IsLocal(element.Class))
            {
                xmlWriter.WriteAttributeString("class", element.Class.XmiId);
            }

            if (element.Datatype != null && writeContext.IsLocal(element.Datatype))
            {
                xmlWriter.WriteAttributeString("datatype", element.Datatype.XmiId);
            }

            if (element.Interface != null && writeContext.IsLocal(element.Interface))
            {
                xmlWriter.WriteAttributeString("interface", element.Interface.XmiId);
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

            if (element.OwningAssociation != null && writeContext.IsLocal(element.OwningAssociation))
            {
                xmlWriter.WriteAttributeString("owningAssociation", element.OwningAssociation.XmiId);
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


            if (element.Association != null && !writeContext.IsLocal(element.Association))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Association, "association", writeContext);
            }

            if (element.AssociationEnd != null && !writeContext.IsLocal(element.AssociationEnd))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.AssociationEnd, "associationEnd", writeContext);
            }

            if (element.Class != null && !writeContext.IsLocal(element.Class))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Class, "class", writeContext);
            }

            if (element.Datatype != null && !writeContext.IsLocal(element.Datatype))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Datatype, "datatype", writeContext);
            }

            foreach (var value in element.DefaultValue)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "defaultValue", writeContext);
            }

            foreach (var value in element.Deployment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "deployment", writeContext);
            }

            if (element.Interface != null && !writeContext.IsLocal(element.Interface))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Interface, "interface", writeContext);
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

            if (element.OwningAssociation != null && !writeContext.IsLocal(element.OwningAssociation))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.OwningAssociation, "owningAssociation", writeContext);
            }

            if (element.OwningTemplateParameter != null && !writeContext.IsLocal(element.OwningTemplateParameter))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.OwningTemplateParameter, "owningTemplateParameter", writeContext);
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

            if (element.Extensions.Count > 0)
            {
                this.logger.LogWarning("The Extensions of the ExtensionEnd with id [{Id}] are not written", element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ExtensionEnd");

            await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.Aggregation != AggregationKind.None)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "aggregation", null, LowerCaseFirstLetter(element.Aggregation.ToString()));
            }

            if (element.Association != null && writeContext.IsLocal(element.Association))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "association", null, element.Association.XmiId);
            }

            if (element.AssociationEnd != null && writeContext.IsLocal(element.AssociationEnd))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "associationEnd", null, element.AssociationEnd.XmiId);
            }

            if (element.Class != null && writeContext.IsLocal(element.Class))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "class", null, element.Class.XmiId);
            }

            if (element.Datatype != null && writeContext.IsLocal(element.Datatype))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "datatype", null, element.Datatype.XmiId);
            }

            if (element.Interface != null && writeContext.IsLocal(element.Interface))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "interface", null, element.Interface.XmiId);
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

            if (element.OwningAssociation != null && writeContext.IsLocal(element.OwningAssociation))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "owningAssociation", null, element.OwningAssociation.XmiId);
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


            if (element.Association != null && !writeContext.IsLocal(element.Association))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Association, "association", writeContext);
            }

            if (element.AssociationEnd != null && !writeContext.IsLocal(element.AssociationEnd))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.AssociationEnd, "associationEnd", writeContext);
            }

            if (element.Class != null && !writeContext.IsLocal(element.Class))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Class, "class", writeContext);
            }

            if (element.Datatype != null && !writeContext.IsLocal(element.Datatype))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Datatype, "datatype", writeContext);
            }

            foreach (var value in element.DefaultValue)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "defaultValue", writeContext);
            }

            foreach (var value in element.Deployment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "deployment", writeContext);
            }

            if (element.Interface != null && !writeContext.IsLocal(element.Interface))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Interface, "interface", writeContext);
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

            if (element.OwningAssociation != null && !writeContext.IsLocal(element.OwningAssociation))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.OwningAssociation, "owningAssociation", writeContext);
            }

            if (element.OwningTemplateParameter != null && !writeContext.IsLocal(element.OwningTemplateParameter))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.OwningTemplateParameter, "owningTemplateParameter", writeContext);
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


            await xmlWriter.WriteEndElementAsync();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
