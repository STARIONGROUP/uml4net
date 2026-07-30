// -------------------------------------------------------------------------------------------------
// <copyright file="DeploymentSpecificationWriter.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="DeploymentSpecificationWriter"/> is to write an instance of <see cref="IDeploymentSpecification"/>
    /// to an XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class DeploymentSpecificationWriter : XmiElementWriter<IDeploymentSpecification>, IXmiElementWriter<IDeploymentSpecification>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<DeploymentSpecificationWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentSpecificationWriter"/> class.
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
        public DeploymentSpecificationWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
            : base(xmiElementWriterFacade, xmiWriterSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<DeploymentSpecificationWriter>.Instance : loggerFactory.CreateLogger<DeploymentSpecificationWriter>();
        }

        /// <summary>
        /// Writes the <see cref="IDeploymentSpecification"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IDeploymentSpecification"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public override void Write(XmlWriter xmlWriter, IDeploymentSpecification element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the DeploymentSpecification with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            this.WriteStartElement(xmlWriter, elementName);

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:DeploymentSpecification");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                xmlWriter.WriteAttributeString("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.Deployment != null && writeContext.IsLocal(element.Deployment))
            {
                xmlWriter.WriteAttributeString("deployment", element.Deployment.XmiId);
            }

            if (!string.IsNullOrEmpty(element.DeploymentLocation))
            {
                xmlWriter.WriteAttributeString("deploymentLocation", element.DeploymentLocation);
            }

            if (!string.IsNullOrEmpty(element.ExecutionLocation))
            {
                xmlWriter.WriteAttributeString("executionLocation", element.ExecutionLocation);
            }

            if (!string.IsNullOrEmpty(element.FileName))
            {
                xmlWriter.WriteAttributeString("fileName", element.FileName);
            }

            if (element.IsAbstract)
            {
                xmlWriter.WriteAttributeString("isAbstract", XmlConvert.ToString(element.IsAbstract));
            }

            if (element.IsFinalSpecialization)
            {
                xmlWriter.WriteAttributeString("isFinalSpecialization", XmlConvert.ToString(element.IsFinalSpecialization));
            }

            if (element.IsLeaf)
            {
                xmlWriter.WriteAttributeString("isLeaf", XmlConvert.ToString(element.IsLeaf));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                xmlWriter.WriteAttributeString("name", element.Name);
            }

            if (element.OwningTemplateParameter != null && writeContext.IsLocal(element.OwningTemplateParameter))
            {
                xmlWriter.WriteAttributeString("owningTemplateParameter", element.OwningTemplateParameter.XmiId);
            }

            if (element.Package != null && writeContext.IsLocal(element.Package))
            {
                xmlWriter.WriteAttributeString("package", element.Package.XmiId);
            }

            if (element.Representation != null && writeContext.IsLocal(element.Representation))
            {
                xmlWriter.WriteAttributeString("representation", element.Representation.XmiId);
            }

            if (element.TemplateParameter != null && writeContext.IsLocal(element.TemplateParameter))
            {
                xmlWriter.WriteAttributeString("templateParameter", element.TemplateParameter.XmiId);
            }

            if (element.Visibility != VisibilityKind.Public)
            {
                xmlWriter.WriteAttributeString("visibility", LowerCaseFirstLetter(element.Visibility.ToString()));
            }


            foreach (var value in element.CollaborationUse)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "collaborationUse", writeContext);
            }

            if (element.Deployment != null && !writeContext.IsLocal(element.Deployment))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Deployment, "deployment", writeContext);
            }

            foreach (var value in element.ElementImport)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "elementImport", writeContext);
            }

            foreach (var value in element.Generalization)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "generalization", writeContext);
            }

            foreach (var value in element.Manifestation)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "manifestation", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "nameExpression", writeContext);
            }

            foreach (var value in element.NestedArtifact)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "nestedArtifact", writeContext);
            }

            foreach (var value in element.OwnedAttribute)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedAttribute", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.OwnedOperation)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedOperation", writeContext);
            }

            foreach (var value in element.OwnedRule)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedRule", writeContext);
            }

            foreach (var value in element.OwnedTemplateSignature)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedTemplateSignature", writeContext);
            }

            foreach (var value in element.OwnedUseCase)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "ownedUseCase", writeContext);
            }

            if (element.OwningTemplateParameter != null && !writeContext.IsLocal(element.OwningTemplateParameter))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.OwningTemplateParameter, "owningTemplateParameter", writeContext);
            }

            if (element.Package != null && !writeContext.IsLocal(element.Package))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Package, "package", writeContext);
            }

            foreach (var value in element.PackageImport)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "packageImport", writeContext);
            }

            foreach (var value in element.PowertypeExtent)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "powertypeExtent", writeContext);
            }

            foreach (var value in element.RedefinedClassifier)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "redefinedClassifier", writeContext);
            }

            if (element.Representation != null && !writeContext.IsLocal(element.Representation))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Representation, "representation", writeContext);
            }

            foreach (var value in element.Substitution)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "substitution", writeContext);
            }

            foreach (var value in element.TemplateBinding)
            {
                this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, "templateBinding", writeContext);
            }

            if (element.TemplateParameter != null && !writeContext.IsLocal(element.TemplateParameter))
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.TemplateParameter, "templateParameter", writeContext);
            }

            foreach (var value in element.UseCases)
            {
                this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, "useCases", writeContext);
            }


            this.WriteExtensions(xmlWriter, element.Extensions);

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="IDeploymentSpecification"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="element">
        /// The <see cref="IDeploymentSpecification"/> that is to be written
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
        public override async Task WriteAsync(XmlWriter xmlWriter, IDeploymentSpecification element, string elementName, IXmiWriteContext writeContext)
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
                this.logger.LogTrace("writing the {Count} Extension(s) of the DeploymentSpecification with id [{Id}]", element.Extensions.Count, element.XmiId);
            }

            await this.WriteStartElementAsync(xmlWriter, elementName);

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiWriterSettings.XmiNamespaceUri, "uml:DeploymentSpecification");

            if (!string.IsNullOrEmpty(element.XmiId))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiWriterSettings.XmiNamespaceUri, element.XmiId);
            }

            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiWriterSettings.XmiNamespaceUri, element.XmiGuid);
            }

            if (element.Deployment != null && writeContext.IsLocal(element.Deployment))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "deployment", null, element.Deployment.XmiId);
            }

            if (!string.IsNullOrEmpty(element.DeploymentLocation))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "deploymentLocation", null, element.DeploymentLocation);
            }

            if (!string.IsNullOrEmpty(element.ExecutionLocation))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "executionLocation", null, element.ExecutionLocation);
            }

            if (!string.IsNullOrEmpty(element.FileName))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "fileName", null, element.FileName);
            }

            if (element.IsAbstract)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isAbstract", null, XmlConvert.ToString(element.IsAbstract));
            }

            if (element.IsFinalSpecialization)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isFinalSpecialization", null, XmlConvert.ToString(element.IsFinalSpecialization));
            }

            if (element.IsLeaf)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "isLeaf", null, XmlConvert.ToString(element.IsLeaf));
            }

            if (!string.IsNullOrEmpty(element.Name))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "name", null, element.Name);
            }

            if (element.OwningTemplateParameter != null && writeContext.IsLocal(element.OwningTemplateParameter))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "owningTemplateParameter", null, element.OwningTemplateParameter.XmiId);
            }

            if (element.Package != null && writeContext.IsLocal(element.Package))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "package", null, element.Package.XmiId);
            }

            if (element.Representation != null && writeContext.IsLocal(element.Representation))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "representation", null, element.Representation.XmiId);
            }

            if (element.TemplateParameter != null && writeContext.IsLocal(element.TemplateParameter))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "templateParameter", null, element.TemplateParameter.XmiId);
            }

            if (element.Visibility != VisibilityKind.Public)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "visibility", null, LowerCaseFirstLetter(element.Visibility.ToString()));
            }


            foreach (var value in element.CollaborationUse)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "collaborationUse", writeContext);
            }

            if (element.Deployment != null && !writeContext.IsLocal(element.Deployment))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Deployment, "deployment", writeContext);
            }

            foreach (var value in element.ElementImport)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "elementImport", writeContext);
            }

            foreach (var value in element.Generalization)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "generalization", writeContext);
            }

            foreach (var value in element.Manifestation)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "manifestation", writeContext);
            }

            foreach (var value in element.NameExpression)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "nameExpression", writeContext);
            }

            foreach (var value in element.NestedArtifact)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "nestedArtifact", writeContext);
            }

            foreach (var value in element.OwnedAttribute)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedAttribute", writeContext);
            }

            foreach (var value in element.OwnedComment)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedComment", writeContext);
            }

            foreach (var value in element.OwnedOperation)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedOperation", writeContext);
            }

            foreach (var value in element.OwnedRule)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedRule", writeContext);
            }

            foreach (var value in element.OwnedTemplateSignature)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedTemplateSignature", writeContext);
            }

            foreach (var value in element.OwnedUseCase)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "ownedUseCase", writeContext);
            }

            if (element.OwningTemplateParameter != null && !writeContext.IsLocal(element.OwningTemplateParameter))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.OwningTemplateParameter, "owningTemplateParameter", writeContext);
            }

            if (element.Package != null && !writeContext.IsLocal(element.Package))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Package, "package", writeContext);
            }

            foreach (var value in element.PackageImport)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "packageImport", writeContext);
            }

            foreach (var value in element.PowertypeExtent)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "powertypeExtent", writeContext);
            }

            foreach (var value in element.RedefinedClassifier)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "redefinedClassifier", writeContext);
            }

            if (element.Representation != null && !writeContext.IsLocal(element.Representation))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.Representation, "representation", writeContext);
            }

            foreach (var value in element.Substitution)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "substitution", writeContext);
            }

            foreach (var value in element.TemplateBinding)
            {
                await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, "templateBinding", writeContext);
            }

            if (element.TemplateParameter != null && !writeContext.IsLocal(element.TemplateParameter))
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, element.TemplateParameter, "templateParameter", writeContext);
            }

            foreach (var value in element.UseCases)
            {
                await this.XmiElementWriterFacade.WriteReferenceElementAsync(xmlWriter, value, "useCases", writeContext);
            }


            await this.WriteExtensionsAsync(xmlWriter, element.Extensions);

            await xmlWriter.WriteEndElementAsync();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
