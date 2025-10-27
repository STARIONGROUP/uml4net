// -------------------------------------------------------------------------------------------------
//  <copyright file="IEnterpriseArchitectExtensionElementReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Readers
{
    using System.Xml;

    /// <summary>
    /// Defines a contract for reading <typeparamref name="TEnterpriseArchitectExtensionElement"/> objects
    /// from their XML representation.
    /// </summary>
    /// <typeparam name="TEnterpriseArchitectExtensionElement">The type of the XMI element to be read.</typeparam>
    public interface IEnterpriseArchitectExtensionElementReader<out TEnterpriseArchitectExtensionElement> where TEnterpriseArchitectExtensionElement : IEnterpriseArchitectExtensionElement
    {
        /// <summary>
        /// Reads the <typeparamref name="TEnterpriseArchitectExtensionElement"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <typeparamref name="TEnterpriseArchitectExtensionElement"/>
        /// </returns>
        public TEnterpriseArchitectExtensionElement Read(XmlReader xmlReader);
    }
}
