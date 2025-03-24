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
    using uml4net.CommonStructure;

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
    }
}
