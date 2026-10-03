// -------------------------------------------------------------------------------------------------
// <copyright file="TaggedValue.cs" company="Starion Group S.A.">
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

namespace uml4net.Profiling
{
    using System.Collections.Generic;

    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;

    /// <summary>
    /// The value of a property of an applied <see cref="IStereotype"/>, traditionally called a tagged value
    /// (UML 2.5.1 clause 12.3.3). In XMI the value is serialized as an attribute or as child elements of the
    /// stereotype application, according to the MOF to XMI mapping of the stereotype property.
    /// </summary>
    public class TaggedValue
    {
        /// <summary>
        /// Gets or sets the name of the property of the stereotype, which is the name of the XML attribute or of
        /// the child elements that hold the value
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property of the <see cref="IStereotype"/> that the value is a value of; null when the
        /// stereotype application, or the property, could not be resolved
        /// </summary>
        public IProperty Property { get; set; }

        /// <summary>
        /// Gets or sets the values as they were read: the value of the XML attribute, or one entry per child element,
        /// which is the text of the element or, for a reference, its <c>xmi:idref</c> or <c>href</c>
        /// </summary>
        public List<string> RawValues { get; set; } = [];

        /// <summary>
        /// Gets or sets a value indicating whether the value was read from an XML attribute rather than from child
        /// elements
        /// </summary>
        public bool IsReadAsAttribute { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="RawValues"/> are references to elements, read from the
        /// <c>xmi:idref</c> or <c>href</c> of child elements
        /// </summary>
        public bool IsReference { get; set; }

        /// <summary>
        /// Gets or sets the typed values, according to the type of the <see cref="Property"/>: a <c>bool</c>, an
        /// <c>int</c>, a <c>double</c> or a <c>string</c> for a primitive type, an <see cref="IEnumerationLiteral"/> for an
        /// enumeration, and an <see cref="IXmiElement"/> for a reference. Empty when the value could not be typed, in
        /// which case the <see cref="RawValues"/> are written back
        /// </summary>
        /// <remarks>
        /// The writer writes the <see cref="Values"/> when there are any, so a value that is set or changed in code is
        /// written; the value <c>*</c> of an <c>UnlimitedNatural</c> is represented by <see cref="int.MaxValue"/>
        /// </remarks>
        public List<object> Values { get; set; } = [];
    }
}
