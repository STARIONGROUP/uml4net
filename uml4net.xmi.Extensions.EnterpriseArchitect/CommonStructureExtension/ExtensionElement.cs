// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionElement.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Extensions.EnterpriseArchitect.CommonStructureExtension
{
    using System;
    using System.Xml;

    using uml4net.CommonStructure;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Extensions;

    /// <summary>
    /// Represents an extension element within the system.
    /// This class provides functionality for managing owned comments,
    /// owned elements, and other attributes of an extension element.
    /// </summary>
    public class ExtensionElement : XmiElement, IExtensionElement
    {
        /// <summary>
        /// Backing field for the <see cref="OwnedComment" />
        /// </summary>
        private IContainerList<IComment> ownedComment;

        /// <summary>
        /// Backing field for the <see cref="OwnedElement" />
        /// </summary>
        private IContainerList<IElement> ownedElement;

        /// <summary>
        /// Backing field for <see cref="Tags"/>
        /// </summary>
        private IContainerList<IExtensionTag> tags;
        
        /// <summary>
        /// Gets or sets the container of this element.
        /// </summary>
        public IElement Container { get; set; }

        /// <summary>
        /// Gets or sets the container of this <see cref="IElement" />
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// Gets or sets the comments owned by this element.
        /// </summary>
        public IContainerList<IComment> OwnedComment
        {
            get => this.ownedComment ??= new ContainerList<IComment>(this);
            set => this.ownedComment = value;
        }

        /// <summary>
        /// The Elements owned by this Element.
        /// </summary>
        public IContainerList<IElement> OwnedElement => this.ownedElement ??= new ContainerList<IElement>(this);

        /// <summary>
        /// Gets the element that owns this element.
        /// </summary>
        public IElement Owner => this.Container;

        /// <summary>
        /// Gets or sets the extended element associated with this element.
        /// </summary>
        public IXmiElement ExtendedElement { get; set; }

        /// <summary>
        /// Gets or sets the ID of the extended element.
        /// </summary>
        public string ExtendedElementId { get; set; }

        /// <summary>
        /// Gets or sets the documentation for this element.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this element is a specification.
        /// </summary>
        public bool IsSpecification { get; set; }

        /// <summary>
        /// Gets or sets the supertype of this element.
        /// </summary>
        public string SuperType { get; set; }

        /// <summary>
        /// Gets or sets the scope of this element.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this element is abstract.
        /// </summary>
        public bool IsAbstract { get; set; }

        /// <summary>
        /// Gets the collection of <see cref="IExtensionTag" />
        /// </summary>
        public IContainerList<IExtensionTag> Tags
        {
            get => this.tags ??= new ContainerList<IExtensionTag>(this);
            set => this.tags = value;
        }

        /// <summary>
        /// Initialize a new <typeparamref name="TExtension"/> and assign basic values to it
        /// </summary>
        /// <param name="xmlReader">The <see cref="XmlReader"/></param>
        /// <param name="cache">The <see cref="IXmiElementCache"/></param>
        /// <param name="documentName">The associated document name</param>
        /// <typeparam name="TExtension">Any instantiable <see cref="IExtensionElement"/></typeparam>
        /// <returns>The initialized <typeparamref name="TExtension"/></returns>
        public static TExtension InitializeElement<TExtension>(XmlReader xmlReader, IXmiElementCache cache, string documentName) where TExtension : IExtensionElement, new()
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            var element = new TExtension();

            if (xmlReader.MoveToContent() != XmlNodeType.Element ||
                xmlReader.GetAttribute("xmi:idref") is not { Length: > 0 } extendedElementId)
            {
                return element;
            }

            element.ExtendedElementId = extendedElementId;
            element.XmiType = xmlReader.GetAttribute("xmi:type");
            element.XmiId = $"{element.ExtendedElementId}_extension";

            element.SetExtensionElement(cache, documentName);
            cache.TryAdd(element);
            
            return element;
        }
    }
}
