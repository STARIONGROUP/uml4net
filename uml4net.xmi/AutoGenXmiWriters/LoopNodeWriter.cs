// -------------------------------------------------------------------------------------------------
// <copyright file="LoopNodeWriter.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="LoopNodeWriter"/> is to write an instance of <see cref="ILoopNode"/>
    /// to an XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class LoopNodeWriter : XmiElementWriter<ILoopNode>, IXmiElementWriter<ILoopNode>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<LoopNodeWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoopNodeWriter"/> class.
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
        public LoopNodeWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
            : base(xmiElementWriterFacade, xmiWriterSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<LoopNodeWriter>.Instance : loggerFactory.CreateLogger<LoopNodeWriter>();
        }

        /// <summary>
        /// Writes the <see cref="ILoopNode"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="ILoopNode"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public override void Write(XmlWriter xmlWriter, ILoopNode element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the LoopNode with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:LoopNode");

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

            if (element.Decider != null && writeContext.IsLocal(element.Decider))
            {
                xmlWriter.WriteAttributeString("decider", element.Decider.XmiId);
            }

            if (element.InStructuredNode != null && writeContext.IsLocal(element.InStructuredNode))
            {
                xmlWriter.WriteAttributeString("inStructuredNode", element.InStructuredNode.XmiId);
            }

            if (element.IsLeaf)
            {
                xmlWriter.WriteAttributeString("isLeaf", XmlConvert.ToString(element.IsLeaf));
            }

            if (element.IsLocallyReentrant)
            {
                xmlWriter.WriteAttributeString("isLocallyReentrant", XmlConvert.ToString(element.IsLocallyReentrant));
            }

            if (element.IsTestedFirst)
            {
                xmlWriter.WriteAttributeString("isTestedFirst", XmlConvert.ToString(element.IsTestedFirst));
            }

            if (element.MustIsolate)
            {
                xmlWriter.WriteAttributeString("mustIsolate", XmlConvert.ToString(element.MustIsolate));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                xmlWriter.WriteAttributeString("name", element.Name);
            }

            if (element.Visibility != default(VisibilityKind))
            {
                xmlWriter.WriteAttributeString("visibility", LowerCaseFirstLetter(element.Visibility.ToString()));
            }


            if (element.Activity != null && !writeContext.IsLocal(element.Activity))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Activity, "activity", writeContext);
            }

            foreach (var value in element.BodyOutput)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "bodyOutput", writeContext);
            }

            foreach (var value in element.BodyPart)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "bodyPart", writeContext);
            }

            if (element.Decider != null && !writeContext.IsLocal(element.Decider))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Decider, "decider", writeContext);
            }

            foreach (var value in element.Edge)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "edge", writeContext);
            }

            foreach (var value in element.ElementImport)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "elementImport", writeContext);
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

            if (element.InStructuredNode != null && !writeContext.IsLocal(element.InStructuredNode))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.InStructuredNode, "inStructuredNode", writeContext);
            }

            foreach (var value in element.LocalPostcondition)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "localPostcondition", writeContext);
            }

            foreach (var value in element.LocalPrecondition)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "localPrecondition", writeContext);
            }

            foreach (var value in element.LoopVariable)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "loopVariable", writeContext);
            }

            foreach (var value in element.LoopVariableInput)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "loopVariableInput", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "nameExpression", writeContext);
            }

            foreach (var value in element.Node)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "node", writeContext);
            }

            foreach (var value in element.Outgoing)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "outgoing", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.OwnedRule)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedRule", writeContext);
            }

            foreach (var value in element.PackageImport)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "packageImport", writeContext);
            }

            foreach (var value in element.RedefinedNode)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "redefinedNode", writeContext);
            }

            foreach (var value in element.Result)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "result", writeContext);
            }

            foreach (var value in element.SetupPart)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "setupPart", writeContext);
            }

            foreach (var value in element.Test)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "test", writeContext);
            }

            foreach (var value in element.Variable)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "variable", writeContext);
            }


            WriteUnresolvedReferences(xmlWriter, element.UnresolvedReferences);

            this.WriteExtensions(xmlWriter, element.Extensions);

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="ILoopNode"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="ILoopNode"/> that is to be written
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
        public override async Task WriteAsync(XmlWriter xmlWriter, ILoopNode element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the LoopNode with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:LoopNode");

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

            if (element.Decider != null && writeContext.IsLocal(element.Decider))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "decider", null, element.Decider.XmiId);
            }

            if (element.InStructuredNode != null && writeContext.IsLocal(element.InStructuredNode))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "inStructuredNode", null, element.InStructuredNode.XmiId);
            }

            if (element.IsLeaf)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isLeaf", null, XmlConvert.ToString(element.IsLeaf));
            }

            if (element.IsLocallyReentrant)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isLocallyReentrant", null, XmlConvert.ToString(element.IsLocallyReentrant));
            }

            if (element.IsTestedFirst)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isTestedFirst", null, XmlConvert.ToString(element.IsTestedFirst));
            }

            if (element.MustIsolate)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "mustIsolate", null, XmlConvert.ToString(element.MustIsolate));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "name", null, element.Name);
            }

            if (element.Visibility != default(VisibilityKind))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "visibility", null, LowerCaseFirstLetter(element.Visibility.ToString()));
            }


            if (element.Activity != null && !writeContext.IsLocal(element.Activity))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Activity, "activity", writeContext);
            }

            foreach (var value in element.BodyOutput)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "bodyOutput", writeContext);
            }

            foreach (var value in element.BodyPart)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "bodyPart", writeContext);
            }

            if (element.Decider != null && !writeContext.IsLocal(element.Decider))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Decider, "decider", writeContext);
            }

            foreach (var value in element.Edge)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "edge", writeContext);
            }

            foreach (var value in element.ElementImport)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "elementImport", writeContext);
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

            if (element.InStructuredNode != null && !writeContext.IsLocal(element.InStructuredNode))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.InStructuredNode, "inStructuredNode", writeContext);
            }

            foreach (var value in element.LocalPostcondition)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "localPostcondition", writeContext);
            }

            foreach (var value in element.LocalPrecondition)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "localPrecondition", writeContext);
            }

            foreach (var value in element.LoopVariable)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "loopVariable", writeContext);
            }

            foreach (var value in element.LoopVariableInput)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "loopVariableInput", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "nameExpression", writeContext);
            }

            foreach (var value in element.Node)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "node", writeContext);
            }

            foreach (var value in element.Outgoing)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "outgoing", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.OwnedRule)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedRule", writeContext);
            }

            foreach (var value in element.PackageImport)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "packageImport", writeContext);
            }

            foreach (var value in element.RedefinedNode)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "redefinedNode", writeContext);
            }

            foreach (var value in element.Result)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "result", writeContext);
            }

            foreach (var value in element.SetupPart)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "setupPart", writeContext);
            }

            foreach (var value in element.Test)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "test", writeContext);
            }

            foreach (var value in element.Variable)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "variable", writeContext);
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
