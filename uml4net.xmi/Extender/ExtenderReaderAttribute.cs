// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtenderReaderAttribute.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extender
{
    using System;

    /// <summary>
    /// Identifies an <see cref="IExtenderReader"/> implementation and declares
    /// which XMI <c>xmi:Extension</c> element(s) it is responsible for processing.
    /// <para>
    /// The <see cref="Extender"/> and <see cref="ExtenderId"/> values correspond
    /// to the <c>extender</c> and <c>extenderID</c> XML attributes found on an
    /// <c>xmi:Extension</c> element in an XMI document.
    /// </para>
    /// <para>
    /// This attribute is used during registration and discovery to associate
    /// a concrete reader with a particular tool or exporter (e.g.,
    /// “Enterprise Architect 6.5” or “MagicDraw UML 19.0”).
    /// </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ExtenderReaderAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtenderReaderAttribute"/> class.
        /// </summary>
        /// <param name="extender">
        /// The value of the <c>extender</c> attribute in the XMI document that this reader handles.
        /// </param>
        /// <param name="extenderId">
        /// Optional identifier corresponding to the <c>extenderID</c> attribute in the XMI document.
        /// </param>
        public ExtenderReaderAttribute(string extender, string extenderId = null)
        {
            this.Extender = extender;
            this.ExtenderId = extenderId;
        }

        /// <summary>
        /// Gets the tool name or producer of the XMI extension (e.g. “Enterprise Architect”, “MagicDraw UML”).
        /// </summary>
        public string Extender { get; }

        /// <summary>
        /// Gets the optional tool or exporter version (e.g. “6.5”, “19.0”).
        /// </summary>
        public string ExtenderId { get; }
    }
}
