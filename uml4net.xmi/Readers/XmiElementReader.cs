// -------------------------------------------------------------------------------------------------
// <copyright file="XmiElementReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net;
    using uml4net.xmi.Extender;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The abstract super class from which each XMI reader needs to derive
    /// </summary> 
    /// <typeparam name="TXmiElement">The type of the XMI element to be read.</typeparam>
    public abstract class XmiElementReader<TXmiElement> where TXmiElement : IXmiElement
    {
        /// <summary>
        /// the character used to split the values (of xml attributes) using a white space as separator
        /// </summary>
        protected static readonly char[] SplitMultiReference = new[] { ' ' };

        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </summary>
        protected readonly ILoggerFactory LoggerFactory;

        /// <summary>
        /// The (injected) <see cref="IXmiElementCache"/> used cache the <see cref="IXmiElement"/>s
        /// </summary>
        protected readonly IXmiElementCache Cache;

        /// <summary>
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </summary>
        protected readonly IXmiElementReaderFacade XmiElementReaderFacade;

        /// <summary>
        /// The injected <see cref="IXmiReaderSettings" /> that provides Xmi Reader settings
        /// </summary>
        protected readonly IXmiReaderSettings XmiReaderSettings;

        /// <summary>
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/>
        /// </summary>
        protected readonly INameSpaceResolver NameSpaceResolver;

        /// <summary>
        /// The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve
        /// </summary>
        protected readonly IExtenderReaderRegistry ExtenderReaderRegistry;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReader{T}"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </param>
        /// <param name="xmiReaderSettings">
        /// The injected <see cref="IXmiReaderSettings" /> that provides Xmi Reader settings
        /// </param>
        /// <param  name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/>
        /// </param>
        /// <param name="extenderReaderRegistry">The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve</param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        protected XmiElementReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IExtenderReaderRegistry extenderReaderRegistry, ILoggerFactory loggerFactory)
        {
            this.Cache = cache;
            this.XmiElementReaderFacade = xmiElementReaderFacade;
            this.XmiReaderSettings = xmiReaderSettings;
            this.NameSpaceResolver = nameSpaceResolver;
            this.LoggerFactory = loggerFactory;
            this.ExtenderReaderRegistry = extenderReaderRegistry;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReader{T}"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        protected XmiElementReader(IXmiElementCache cache, ILoggerFactory loggerFactory)
        {
            this.Cache = cache;

            this.LoggerFactory = loggerFactory;
        }

        /// <summary>
        /// The <see cref="ILogger"/> used to report XMI errors when <see cref="IXmiReaderSettings.UseStrictReading"/>
        /// is not set, created on first use
        /// </summary>
        private ILogger xmiErrorLogger;

        /// <summary>
        /// Reports a value that is not valid according to XMI 2.5.1: throws an <see cref="XmiReadException"/> when
        /// <see cref="IXmiReaderSettings.UseStrictReading"/> is set (or no settings are available), logs an error
        /// otherwise so that reading continues with a defined result
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/> positioned at the invalid value, used for the line position
        /// </param>
        /// <param name="xmiElement">
        /// The <see cref="IXmiElement"/> that is being read
        /// </param>
        /// <param name="propertyName">
        /// The name of the property whose value is invalid
        /// </param>
        /// <param name="message">
        /// The message that describes the invalid value
        /// </param>
        /// <exception cref="XmiReadException">
        /// thrown when <see cref="IXmiReaderSettings.UseStrictReading"/> is set
        /// </exception>
        protected void ReportXmiError(XmlReader xmlReader, IXmiElement xmiElement, string propertyName, string message)
        {
            var xmlLineInfo = xmlReader as IXmlLineInfo;
            var elementType = xmiElement?.XmiType ?? typeof(TXmiElement).Name;
            var lineNumber = xmlLineInfo?.LineNumber ?? 0;
            var linePosition = xmlLineInfo?.LinePosition ?? 0;

            if (this.XmiReaderSettings == null || this.XmiReaderSettings.UseStrictReading)
            {
                throw new XmiReadException(message, elementType, xmiElement?.XmiId, propertyName, lineNumber, linePosition);
            }

            this.xmiErrorLogger ??= this.LoggerFactory == null ? NullLogger.Instance : this.LoggerFactory.CreateLogger(this.GetType());

            this.xmiErrorLogger.LogError("{Message}: {ElementType} [{XmiId}] property [{PropertyName}] at line:position {LineNumber}:{LinePosition}", message, elementType, xmiElement?.XmiId, propertyName, lineNumber, linePosition);
        }

        /// <summary>
        /// Reads the <typeparamref name="TXmiElement"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement"/>
        /// </param>
        /// <param name="namespaceUri">
        /// The namespaceUri of the parent <see cref="XmlReader"/>>.
        /// Since <see cref="XmlReader.ReadSubtree"/> is used extensively the <see cref="XmlReader.NamespaceURI"/>
        /// returns the empty string when reading from a subtree, therefore it is passed from the caller
        /// </param>
        /// <returns>
        /// an instance of <typeparamref name="TXmiElement"/>
        /// </returns>
        public abstract TXmiElement Read(XmlReader xmlReader, string documentName, string namespaceUri);

        /// <summary>
        /// Adds the property-name and unique identifier of the referenced <see cref="IXmiElement"/> to the
        /// <see cref="IXmiElement.SingleValueReferencePropertyIdentifiers"/> collection
        /// </summary>
        /// <param name="xmlReader">
        /// An instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="xmiElement">
        /// The target <see cref="IXmiElement"/> to which the property-name and unique identifier key-value pair
        /// are added in the <see cref="IXmiElement.SingleValueReferencePropertyIdentifiers"/> collection
        /// </param>
        /// <param name="localName">
        /// the name of the single-value reference property used to verify that the cursor of the 
        /// <see cref="XmlReader"/> is at the right position
        /// </param>
        protected void CollectSingleValueReferencePropertyIdentifier(XmlReader xmlReader, IXmiElement xmiElement, string localName)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (xmiElement == null)
            {
                throw new ArgumentNullException(nameof(xmiElement));
            }

            if (localName != xmlReader.LocalName)
            {
                throw new InvalidOperationException($"LocalName:{xmlReader.LocalName} is not equal to the provided localName:{localName}");
            }

            using var subXmlReader = xmlReader.ReadSubtree();

            if (subXmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmlLineInfo = subXmlReader as IXmlLineInfo;

                var reference = subXmlReader.GetAttribute("href");
                if (!string.IsNullOrEmpty(reference))
                {
                    if (this.TryAddSingleValueReference(subXmlReader, xmiElement, localName, reference))
                    {
                        CollectUnresolvedReference(subXmlReader, xmiElement, localName, reference);
                    }
                }
                else if (subXmlReader.GetXmiAttribute("idref") is { Length: > 0 } idRef)
                {
                    this.TryAddSingleValueReference(subXmlReader, xmiElement, localName, idRef);
                }
                else if (subXmlReader.IsNil())
                {
                    // a null reference (XMI 2.5.1 clause 9.5.2, rule 2b): the property keeps no value
                }
                else
                {
                    throw new InvalidOperationException($"{localName} xml-attribute reference could not be read at {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
                }
            }
        }

        /// <summary>
        /// Adds the unique identifier of a single-valued reference, unless the property was already given a value
        /// in the document, which XMI 2.5.1 (clause 9.5.2, rule 2h) does not allow: the first value is kept and the
        /// repetition is reported through <see cref="ReportXmiError"/>
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/> positioned on the reference element
        /// </param>
        /// <param name="xmiElement">
        /// The <see cref="IXmiElement"/> that declares the reference
        /// </param>
        /// <param name="localName">
        /// The name of the single-valued reference property
        /// </param>
        /// <param name="reference">
        /// The unique identifier of the referenced <see cref="IXmiElement"/>
        /// </param>
        /// <returns>
        /// true when the reference was added, false when the property already had a value
        /// </returns>
        private bool TryAddSingleValueReference(XmlReader xmlReader, IXmiElement xmiElement, string localName, string reference)
        {
            if (xmiElement.SingleValueReferencePropertyIdentifiers.TryGetValue(localName, out var existingReference))
            {
                this.ReportXmiError(xmlReader, xmiElement, localName, $"The single-valued reference is given more than once, [{existingReference}] is kept and [{reference}] is ignored");
                return false;
            }

            xmiElement.SingleValueReferencePropertyIdentifiers.Add(localName, reference);
            return true;
        }

        /// <summary>
        /// Tries to add the unique identifier of the referenced (using either href or idref) of the
        /// <see cref="IXmiElement"/> to the MultiValueReferencePropertyIdentifiers
        /// </summary>
        /// <param name="xmlReader">
        /// An instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="xmiElement">
        /// The <see cref="IXmiElement"/> to which the referenced identifier is added
        /// </param>
        /// <param name="localName">
        /// the name of the multi-value reference property used to verify that the cursor of the
        /// <see cref="XmlReader"/> is at the right position
        /// </param>
        protected bool TryCollectMultiValueReferencePropertyIdentifiers(XmlReader xmlReader, IXmiElement xmiElement, string localName)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (xmiElement == null)
            {
                throw new ArgumentNullException(nameof(xmiElement));
            }

            if (localName != xmlReader.LocalName)
            {
                throw new InvalidOperationException($"LocalName:{xmlReader.LocalName} is not equal to the provided localName:{localName}");
            }

            using var subXmlReader = xmlReader.ReadSubtree();

            if (subXmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var href = subXmlReader.GetAttribute("href");
                if (!string.IsNullOrEmpty(href))
                {
                    if (!xmiElement.MultiValueReferencePropertyIdentifiers.TryGetValue(localName, out var references))
                    {
                        references = new List<string>();
                        xmiElement.MultiValueReferencePropertyIdentifiers.Add(localName, references);
                    }

                    references.Add(href);

                    CollectUnresolvedReference(subXmlReader, xmiElement, localName, href);

                    return true;
                }

                var idRef = subXmlReader.GetXmiAttribute("idref");
                if (!string.IsNullOrEmpty(idRef))
                {
                    if (!xmiElement.MultiValueReferencePropertyIdentifiers.TryGetValue(localName, out var references))
                    {
                        references = new List<string>();
                        xmiElement.MultiValueReferencePropertyIdentifiers.Add(localName, references);
                    }

                    references.Add(idRef);
                    return true;
                }

                if (subXmlReader.IsNil())
                {
                    // a null reference (XMI 2.5.1 clause 9.5.2, rule 2b) adds nothing to the collection
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Tries to record the element that the <see cref="XmlReader"/> is positioned on as a proxy of a
        /// composite property, which refers to the definition of the owned element by <c>href</c> or
        /// <c>xmi:idref</c> instead of containing it (XMI 2.5.1 clause 7.10.1)
        /// </summary>
        /// <param name="xmlReader">
        /// An instance of <see cref="XmlReader"/> that is positioned on the element of the composite property
        /// </param>
        /// <param name="xmiElement">
        /// The <see cref="IXmiElement"/> that owns the composite property
        /// </param>
        /// <param name="localName">
        /// The name of the composite property, used to verify that the cursor of the <see cref="XmlReader"/>
        /// is at the right position
        /// </param>
        /// <param name="containedCount">
        /// The number of elements that the composite property contains so far
        /// </param>
        /// <returns>
        /// true when the element is a proxy and has been recorded, or is nil and contains nothing, in which
        /// case the <see cref="XmlReader"/> has moved past it; false when the element is a definition, in which case the
        /// <see cref="XmlReader"/> has not moved
        /// </returns>
        protected bool TryCollectCompositeReferencePropertyIdentifier(XmlReader xmlReader, IXmiElement xmiElement, string localName, int containedCount)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (xmiElement == null)
            {
                throw new ArgumentNullException(nameof(xmiElement));
            }

            if (localName != xmlReader.LocalName)
            {
                throw new InvalidOperationException($"LocalName:{xmlReader.LocalName} is not equal to the provided localName:{localName}");
            }

            if (xmlReader.IsNil())
            {
                // a null value (XMI 2.5.1 clause 9.5.2, rule 2b) contains nothing
                xmlReader.SkipInPlace();
                return true;
            }

            var href = xmlReader.GetAttribute("href");
            var identifier = string.IsNullOrEmpty(href) ? xmlReader.GetXmiAttribute("idref") : href;

            if (string.IsNullOrEmpty(identifier))
            {
                return false;
            }

            if (!xmiElement.CompositeReferencePropertyIdentifiers.TryGetValue(localName, out var references))
            {
                references = new List<XmiCompositeReference>();
                xmiElement.CompositeReferencePropertyIdentifiers.Add(localName, references);
            }

            references.Add(new XmiCompositeReference
            {
                Identifier = identifier,
                Position = containedCount + references.Count
            });

            using var subXmlReader = xmlReader.ReadSubtree();
            subXmlReader.MoveToContent();

            if (!string.IsNullOrEmpty(href))
            {
                CollectUnresolvedReference(subXmlReader, xmiElement, localName, href);
            }

            return true;
        }

        /// <summary>
        /// Adds the reference element, in its original XMI form, to the
        /// <see cref="IXmiElement.UnresolvedReferences"/> collection of the provided <see cref="IXmiElement"/>
        /// </summary>
        /// <param name="xmlReader">
        /// An instance of <see cref="XmlReader"/> that is positioned on the reference element
        /// </param>
        /// <param name="xmiElement">
        /// The <see cref="IXmiElement"/> that declares the reference
        /// </param>
        /// <param name="localName">
        /// The name of the reference property through which the referenced <see cref="IXmiElement"/> is reached
        /// </param>
        /// <param name="reference">
        /// The unique identifier of the referenced <see cref="IXmiElement"/>, which is the value of the
        /// <c>href</c> attribute of the reference element
        /// </param>
        /// <remarks>
        /// Only a reference to another document - an <c>href</c> - is captured, since it is the only reference
        /// that depends on a document that may not be available. The captured reference is removed again by the
        /// <see cref="IAssembler"/> as soon as it is resolved, so that only the references that could not be
        /// resolved remain and are written back verbatim
        /// </remarks>
        protected static void CollectUnresolvedReference(XmlReader xmlReader, IXmiElement xmiElement, string localName, string reference)
        {
            var stringWriter = new StringWriter();

            using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { OmitXmlDeclaration = true }))
            {
                xmlWriter.WriteNode(xmlReader, true);
            }

            xmiElement.UnresolvedReferences.Add(new XmiUnresolvedReference
            {
                PropertyName = localName,
                Identifier = reference,
                ContentRawXmi = stringWriter.ToString()
            });
        }

        /// <summary>
        /// Handles the read of XMI Element manually, when a specific case cannot be code-generated
        /// </summary>
        /// <param name="poco">The <typeparamref name="TXmiElement"/> instance</param>
        /// <param name="xmlReader">The <see cref="XmlReader"/></param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement"/>
        /// </param>
        /// <param name="namespaceUri">
        /// The namespaceUri of the parent <see cref="XmlReader"/>>.
        /// Since <see cref="XmlReader.ReadSubtree"/> is used extensively the <see cref="XmlReader.NamespaceURI"/>
        /// returns the empty string when reading from a subtree, therefore it is passed from the caller
        /// </param>
        /// <returns>
        /// True if the manual code could handle the Xmi read
        /// </returns>
        protected virtual bool HandleManualXmlRead(TXmiElement poco, XmlReader xmlReader, string documentName, string namespaceUri)
        {
            return false;
        }
    }
}
