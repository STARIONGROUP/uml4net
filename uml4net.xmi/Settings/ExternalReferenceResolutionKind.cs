// -------------------------------------------------------------------------------------------------
// <copyright file="ExternalReferenceResolutionKind.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Settings
{
    /// <summary>
    /// Specifies how references to elements that are not contained by the selected <see cref="uml4net.Packages.IPackage"/>
    /// are serialized when writing an XMI document.
    /// </summary>
    public enum ExternalReferenceResolutionKind
    {
        /// <summary>
        /// References to external elements are serialized as href references to the document that
        /// contains the referenced element, such as <code>href="PrimitiveTypes.xmi#Boolean"</code>.
        /// The written document only contains the selected package.
        /// </summary>
        Href = 0,

        /// <summary>
        /// The top-level root packages that contain externally referenced elements are included in the
        /// written document, resulting in a self-contained document in which all references can be
        /// resolved by identifier.
        /// </summary>
        /// <remarks>
        /// Individual referenced elements cannot be re-contained without invalidating the containment
        /// hierarchy of the source model; therefore, the complete containment tree of the root package that
        /// owns each externally referenced element is included in the written document.
        /// </remarks>
        Include = 1
    }
}
