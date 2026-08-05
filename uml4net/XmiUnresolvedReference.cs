// -------------------------------------------------------------------------------------------------
// <copyright file="XmiUnresolvedReference.cs" company="Starion Group S.A.">
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

namespace uml4net
{
    /// <summary>
    /// Represents a reference to an <see cref="IXmiElement"/> in another document that could not be resolved
    /// while reading, preserved in its original XMI form.
    /// <para>
    /// The reference element is captured verbatim while reading and is removed again as soon as the reference
    /// is resolved, so that after the object graph has been assembled the
    /// <see cref="IXmiElement.UnresolvedReferences"/> of an <see cref="IXmiElement"/> hold exactly those
    /// references that could not be turned into an object reference. Those are written back verbatim, which
    /// preserves them across a read - write cycle even though uml4net cannot interpret them.
    /// </para>
    /// </summary>
    public class XmiUnresolvedReference : IXmiUnresolvedReference
    {
        /// <summary>
        /// Gets or sets the name of the reference property through which the referenced <see cref="IXmiElement"/>
        /// is reached, such as <c>appliedProfile</c>
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced <see cref="IXmiElement"/>, which is the value of
        /// the <c>href</c> attribute of the reference element
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the reference element in its original XMI form
        /// </summary>
        public string ContentRawXmi { get; set; }
    }
}
