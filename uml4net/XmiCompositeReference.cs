// -------------------------------------------------------------------------------------------------
// <copyright file="XmiCompositeReference.cs" company="Starion Group S.A.">
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
    /// A proxy, read from a composite property, that refers to the definition of the owned element by
    /// <c>xmi:idref</c> or <c>href</c> instead of containing it (XMI 2.5.1 clause 7.10.1)
    /// </summary>
    public class XmiCompositeReference
    {
        /// <summary>
        /// Gets or sets the value of the <c>href</c> or <c>xmi:idref</c> attribute of the proxy
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the index, in document order, of the proxy among all the elements of the composite
        /// property, counting both contained definitions and proxies
        /// </summary>
        public int Position { get; set; }
    }
}
