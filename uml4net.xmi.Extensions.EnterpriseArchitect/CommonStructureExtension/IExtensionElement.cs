// -------------------------------------------------------------------------------------------------
//  <copyright file="IExtensionElement.cs" company="Starion Group S.A.">
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
    public interface IExtensionElement : IElement
    {
        /// <summary>
        /// Gets or sets the ID of the extended element.
        /// </summary>
        string ExtendedElementId { get; set; }

        /// <summary>
        /// Gets or sets the extended element associated with this element.
        /// </summary>
        IXmiElement ExtendedElement { get; set; }

        /// <summary>
        /// Gets or sets the documentation for this element.
        /// </summary>
        string Documentation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this element is a specification.
        /// </summary>
        bool IsSpecification { get; set; }

        /// <summary>
        /// Gets or sets the supertype of this element.
        /// </summary>
        string SuperType { get; set; }

        /// <summary>
        /// Gets or sets the scope of this element.
        /// </summary>
        string Scope { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this element is abstract.
        /// </summary>
        bool IsAbstract { get; set; }
    }
}
