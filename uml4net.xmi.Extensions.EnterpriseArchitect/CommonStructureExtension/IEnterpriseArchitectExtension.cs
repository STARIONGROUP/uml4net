﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="IEnterpriseArchitectExtension.cs" company="Starion Group S.A.">
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
    using uml4net.Packages;

    /// <summary>
    /// Represents an Enterprise Architect extension package that provides additional functionality
    /// and custom elements for integration with the Enterprise Architect environment.
    /// </summary>
    public interface IEnterpriseArchitectExtension : IPackage
    {
        /// <summary>
        /// Gets or sets the collection of extension elements associated with this extension.
        /// </summary>
        /// <value>A container list of <see cref="IExtensionElement" /> representing the elements.</value>
        IContainerList<IExtensionElement> Elements { get; set; }
        
        /// <summary>
        /// Gets or sets the collection of extension elements associated with this extension, for connectors.
        /// </summary>
        /// <value>A container list of <see cref="IExtensionElement" /> representing the elements.</value>
        IContainerList<IExtensionElement> Connectors { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the extender associated with this extension.
        /// </summary>
        /// <value>A string representing the extender identifier.</value>
        string ExtenderId { get; set; }

        /// <summary>
        /// Gets or sets the name of the extender associated with this extension.
        /// </summary>
        /// <value>A string representing the extender name.</value>
        string Extender { get; set; }
    }
}
