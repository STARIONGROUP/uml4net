// -------------------------------------------------------------------------------------------------
//  <copyright file="Tag.cs" company="Starion Group S.A.">
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

#pragma warning disable IDE0130
namespace uml4net.Mof.Extension
{
    using System.Collections.Generic;

    /// <summary>
    /// A Tag represents a single piece of information that can be associated with any number of model elements. A model
    /// element can be associated with many Tags, and the same Tag can be associated with many model elements
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Element in the XMI document
        /// </summary>
        public string XmiId { get; set; }

        /// <summary>
        /// Gets or sets the name of the xmi type
        /// </summary>
        public string XmiType { get; set; }

        /// <summary>
        /// The name used to distinguish Tags associated with a model element.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the Tag. MOF places no meaning on these values.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The elements that tag is applied to.
        /// </summary>
        public List<string> Element = [];
    }
}
