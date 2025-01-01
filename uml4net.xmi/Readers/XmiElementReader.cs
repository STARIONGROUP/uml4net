// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiElementReader.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net;
    using uml4net.xmi.Cache;

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
        /// The (injected) <see cref="ILogger"/> used to set up logging
        /// </summary>
        protected readonly ILogger<XmiElementReader<TXmiElement>> Logger;

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
        /// Initializes a new instance of the <see cref="XmiElementReader{T}"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        protected XmiElementReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, ILoggerFactory loggerFactory)
        {
            this.Cache = cache;
            this.XmiElementReaderFacade = xmiElementReaderFacade;

            this.LoggerFactory = loggerFactory;
            this.Logger = loggerFactory == null ? NullLogger<XmiElementReader<TXmiElement>>.Instance : loggerFactory.CreateLogger<XmiElementReader<TXmiElement>>();
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
            this.Logger = loggerFactory == null ? NullLogger<XmiElementReader<TXmiElement>>.Instance : loggerFactory.CreateLogger<XmiElementReader<TXmiElement>>();
        }

        /// <summary>
        /// Reads the <typeparamref name="TXmiElement"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <typeparamref name="TXmiElement"/>
        /// </returns>
        public abstract TXmiElement Read(XmlReader xmlReader);

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
                var reference = subXmlReader.GetAttribute("href");
                if (!string.IsNullOrEmpty(reference))
                {
                    xmiElement.SingleValueReferencePropertyIdentifiers.Add(localName, reference);
                }
                else if (subXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                {
                    xmiElement.SingleValueReferencePropertyIdentifiers.Add(localName, idRef);
                }
                else
                {
                    throw new InvalidOperationException($"{localName} xml-attribute reference could not be read");
                }
            }
        }

        /// <summary>
        /// Adds the unique identifier of the referenced <see cref="IXmiElement"/> to the
        /// provided <paramref name="references"/> collection
        /// </summary>
        /// <param name="xmlReader">
        /// An instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="references">
        /// The collection of string-based unique identifiers
        /// </param>
        /// <param name="localName">
        /// the name of the multi-value reference property used to verify that the cursor of the 
        /// <see cref="XmlReader"/> is at the right position
        /// </param>
        protected void CollectMultiValueReferencePropertyIdentifiers(XmlReader xmlReader, List<string> references, string localName)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (references == null)
            {
                throw new ArgumentNullException(nameof(references));
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
                    references.Add(href);
                }
                else if (subXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                {
                    references.Add(idRef);
                }
                else
                {
                    throw new InvalidOperationException($"{xmlReader.LocalName} xml-attribute href or xmi:idref could not be read");
                }
            }
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
                    return true;
                }

                var idRef = subXmlReader.GetAttribute("xmi:idref");
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
            }

            return false;
        }
    }
}
