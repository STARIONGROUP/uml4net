// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiUnresolvedReference.cs" company="Starion Group S.A.">
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
    /// Defines the contract for objects representing a reference to an <see cref="IXmiElement"/> in another
    /// document that could not be resolved while reading.
    /// <para>
    /// A reference such as <c>&lt;appliedProfile xmi:type="uml:Profile" href="http://…#id"/&gt;</c> can only be
    /// turned into an object reference when the referenced document is available. When it is not - an
    /// Enterprise Architect profile identified by a <c>http://www.sparxsystems.com/profiles/…</c> URL for
    /// instance is not retrievable at all - the reference element is preserved in its original XMI form so
    /// that it is written back verbatim rather than silently lost.
    /// </para>
    /// </summary>
    public interface IXmiUnresolvedReference
    {
        /// <summary>
        /// Gets or sets the name of the reference property through which the referenced <see cref="IXmiElement"/>
        /// is reached, such as <c>appliedProfile</c>
        /// </summary>
        string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced <see cref="IXmiElement"/>, which is the value of
        /// the <c>href</c> attribute of the reference element
        /// </summary>
        string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the reference element in its original XMI form
        /// </summary>
        string ContentRawXmi { get; set; }
    }
}
