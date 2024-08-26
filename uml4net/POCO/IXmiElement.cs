// -------------------------------------------------------------------------------------------------
// <copyright file="IPackage.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.POCO
{
    /// <summary>
    /// The <see cref="IXmiElement"/> captures the XMI properties of each element in the
    /// XMI document
    /// </summary>
    public interface IXmiElement
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Element in the XMI document
        /// </summary>
        public string XmiId { get; set; }

        /// <summary>
        /// Gets or sets the GUID unique identifier of the Element in the XMI document
        /// </summary>
        public string XmiGuid { get; set; }

        /// <summary>
        /// Gets or sets the name of the xmi type
        /// </summary>
        public string XmiType { get; set; }
    }
}