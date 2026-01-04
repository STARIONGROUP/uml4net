// -------------------------------------------------------------------------------------------------
//  <copyright file="StereoTypeApplication.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.Profiling
{
    using System.Collections.Generic;

    using uml4net.CommonStructure;
    using uml4net.Packages;

    /// <summary>
    /// The purpose of the <see cref="StereoTypeApplication"/> is to make of record of the
    /// <see cref="IStereotype"/>s that have been applied to an <see cref="IElement"/>.
    /// </summary>
    public class StereoTypeApplication
    {
        /// <summary>
        /// Gets or sets the unique identifier of the XML Element in the XMI document.
        /// </summary>
        public string XmiId { get; set; }

        /// <summary>
        /// Gets or sets the name of the MetaClass that the <see cref="IStereotype"/>
        /// has been applied to.
        /// </summary>
        public string MetaClass { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the <see cref="IElement"/> that
        /// the <see cref="IStereotype"/> has been applied to.
        /// </summary>
        public string ElementIdentifier { get; set; }

        /// <summary>
        /// gets or sets the name of the applied <see cref="IStereotype"/>.
        /// </summary>
        public string StereoTypeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="IProfile"/> that the applied <see cref="IStereotype"/>
        /// is a member of.
        /// </summary>
        public string ProfileName { get; set; }

        /// <summary>
        /// Gets or sets the key-value pair of attributes (or properties) that
        /// the <see cref="StereoTypeApplication"/> holds.
        /// </summary>
        public Dictionary<string, string> Attributes = new();
    }
}
