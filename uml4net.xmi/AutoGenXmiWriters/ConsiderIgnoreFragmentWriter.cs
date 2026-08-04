// -------------------------------------------------------------------------------------------------
// <copyright file="ConsiderIgnoreFragmentWriter.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ConsiderIgnoreFragmentWriter"/> is to write an instance of <see cref="IConsiderIgnoreFragment"/>
    /// to an XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ConsiderIgnoreFragmentWriter : XmiElementWriter<IConsiderIgnoreFragment>, IXmiElementWriter<IConsiderIgnoreFragment>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ConsiderIgnoreFragmentWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsiderIgnoreFragmentWriter"/> class.
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
        public ConsiderIgnoreFragmentWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
            : base(xmiElementWriterFacade, xmiWriterSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ConsiderIgnoreFragmentWriter>.Instance : loggerFactory.CreateLogger<ConsiderIgnoreFragmentWriter>();
        }

        /// <summary>
        /// Writes the <see cref="IConsiderIgnoreFragment"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IConsiderIgnoreFragment"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public override void Write(XmlWriter xmlWriter, IConsiderIgnoreFragment element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the ConsiderIgnoreFragment with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ConsiderIgnoreFragment");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                xmlWriter.WriteAttributeString("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.EnclosingInteraction != null && writeContext.IsLocal(element.EnclosingInteraction))
            {
                xmlWriter.WriteAttributeString("enclosingInteraction", element.EnclosingInteraction.XmiId);
            }

            if (element.EnclosingOperand != null && writeContext.IsLocal(element.EnclosingOperand))
            {
                xmlWriter.WriteAttributeString("enclosingOperand", element.EnclosingOperand.XmiId);
            }

            if (element.InteractionOperator != InteractionOperatorKind.Seq)
            {
                xmlWriter.WriteAttributeString("interactionOperator", LowerCaseFirstLetter(element.InteractionOperator.ToString()));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                xmlWriter.WriteAttributeString("name", element.Name);
            }

            if (element.Visibility != default(VisibilityKind))
            {
                xmlWriter.WriteAttributeString("visibility", LowerCaseFirstLetter(element.Visibility.ToString()));
            }


            foreach (var value in element.CfragmentGate)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "cfragmentGate", writeContext);
            }

            foreach (var value in element.Covered)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "covered", writeContext);
            }

            if (element.EnclosingInteraction != null && !writeContext.IsLocal(element.EnclosingInteraction))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.EnclosingInteraction, "enclosingInteraction", writeContext);
            }

            if (element.EnclosingOperand != null && !writeContext.IsLocal(element.EnclosingOperand))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.EnclosingOperand, "enclosingOperand", writeContext);
            }

            foreach (var value in element.GeneralOrdering)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "generalOrdering", writeContext);
            }

            foreach (var value in element.Message)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "message", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "nameExpression", writeContext);
            }

            foreach (var value in element.Operand)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "operand", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }


            this.WriteExtensions(xmlWriter, element.Extensions);

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IConsiderIgnoreFragment"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IConsiderIgnoreFragment"/> that is to be written
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
        public override async Task WriteAsync(XmlWriter xmlWriter, IConsiderIgnoreFragment element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the ConsiderIgnoreFragment with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:ConsiderIgnoreFragment");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.EnclosingInteraction != null && writeContext.IsLocal(element.EnclosingInteraction))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "enclosingInteraction", null, element.EnclosingInteraction.XmiId);
            }

            if (element.EnclosingOperand != null && writeContext.IsLocal(element.EnclosingOperand))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "enclosingOperand", null, element.EnclosingOperand.XmiId);
            }

            if (element.InteractionOperator != InteractionOperatorKind.Seq)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "interactionOperator", null, LowerCaseFirstLetter(element.InteractionOperator.ToString()));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "name", null, element.Name);
            }

            if (element.Visibility != default(VisibilityKind))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "visibility", null, LowerCaseFirstLetter(element.Visibility.ToString()));
            }


            foreach (var value in element.CfragmentGate)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "cfragmentGate", writeContext);
            }

            foreach (var value in element.Covered)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "covered", writeContext);
            }

            if (element.EnclosingInteraction != null && !writeContext.IsLocal(element.EnclosingInteraction))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.EnclosingInteraction, "enclosingInteraction", writeContext);
            }

            if (element.EnclosingOperand != null && !writeContext.IsLocal(element.EnclosingOperand))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.EnclosingOperand, "enclosingOperand", writeContext);
            }

            foreach (var value in element.GeneralOrdering)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "generalOrdering", writeContext);
            }

            foreach (var value in element.Message)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "message", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "nameExpression", writeContext);
            }

            foreach (var value in element.Operand)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "operand", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }


            await this.WriteExtensionsAsync(xmlWriter, element.Extensions);

            await xmlWriter.WriteEndElementAsync();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
