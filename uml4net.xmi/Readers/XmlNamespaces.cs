// -------------------------------------------------------------------------------------------------
//  <copyright file="XmlNamespaces.cs" company="Starion Group S.A.">
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
    using System;

    /// <summary>
    /// static definitions of the supported XML namespaces that uml4net can read and deserialize
    /// to an object graph
    /// </summary>
    public static class XmlNamespaces
    {
        /// <summary>
        /// Queries the supported XMI or UML related namespaces
        /// </summary>
        /// <param name="nameSpaceUri">
        /// The namespace URI, typically from a xml element
        /// </param>
        /// <returns>
        /// A <see cref="SupportedNamespaces"/>
        /// </returns>
        public static SupportedNamespaces QuerySupportedNamespaces(string nameSpaceUri)
        {
            if (string.IsNullOrWhiteSpace(nameSpaceUri)) return SupportedNamespaces.Other;

            var trimmedNameSpaceUri = nameSpaceUri.Trim();

            // captures for example http://www.omg.org/spec/XMI/20161101
            if (trimmedNameSpaceUri.StartsWith("http://www.omg.org/spec/XMI/", StringComparison.OrdinalIgnoreCase) 
                || trimmedNameSpaceUri.StartsWith("https://www.omg.org/spec/XMI/", StringComparison.OrdinalIgnoreCase))
            {
                return SupportedNamespaces.Xmi;
            }

            // captures for example http://www.omg.org/spec/UML/20161101
            if (trimmedNameSpaceUri.StartsWith("http://www.omg.org/spec/UML/", StringComparison.OrdinalIgnoreCase) 
                || trimmedNameSpaceUri.StartsWith("https://www.omg.org/spec/UML/", StringComparison.OrdinalIgnoreCase))
            {
                // captures for example http://www.omg.org/spec/UML/20131001/StandardProfile
                if (trimmedNameSpaceUri.EndsWith("/StandardProfile", StringComparison.OrdinalIgnoreCase) 
                    || trimmedNameSpaceUri.EndsWith("/StandardProfile/", StringComparison.OrdinalIgnoreCase))
                {
                    return SupportedNamespaces.UmlStandardProfile;
                }

                if (trimmedNameSpaceUri.EndsWith("/UMLDI", StringComparison.OrdinalIgnoreCase) 
                    || trimmedNameSpaceUri.EndsWith("/UMLDI/", StringComparison.OrdinalIgnoreCase))
                {
                    return SupportedNamespaces.UmlStandardProfile;
                }

                return SupportedNamespaces.Uml;
            }

            // captures for example http://www.eclipse.org/uml2/5.0.0/UML
            if (trimmedNameSpaceUri.StartsWith("http://www.eclipse.org/uml2/") 
                || trimmedNameSpaceUri.StartsWith("https://www.eclipse.org/uml2/"))
            {
                if (trimmedNameSpaceUri.EndsWith("/UML", StringComparison.OrdinalIgnoreCase) 
                    || trimmedNameSpaceUri.EndsWith("/UML/", StringComparison.OrdinalIgnoreCase))
                {
                    return SupportedNamespaces.Uml;
                }
            }

            return SupportedNamespaces.Other;
        }
    }
}
