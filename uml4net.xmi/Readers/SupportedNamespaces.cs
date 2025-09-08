// -------------------------------------------------------------------------------------------------
//  <copyright file="SupportedNamespaces.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers
{
    /// <summary>
    /// <see cref="SupportedNamespaces"/> enumerates the possible supported namespaces of an
    /// XMI document
    /// </summary>
    public enum SupportedNamespaces
    {
        /// <summary>
        /// Assertion that the supported namespace is XMI
        /// </summary>
        Xmi,

        /// <summary>
        /// Assertion that the supported namespace is UML
        /// </summary>
        Uml,

        /// <summary>
        /// Assertion that the supported namespace is UML/.../StandardProfile
        /// </summary>
        UmlStandardProfile,

        /// <summary>
        /// Assertion that the supported namespace is UML/.../UMLDI
        /// </summary>
        UmlDiagramInterchange,

        /// <summary>
        /// Assertion that the namespace is in fact not supported
        /// </summary>
        Other
    }
}
