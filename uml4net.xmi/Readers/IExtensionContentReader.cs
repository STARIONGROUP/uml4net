// -------------------------------------------------------------------------------------------------
//  <copyright file="IExtensionContentReader.cs" company="Starion Group S.A.">
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
    using System.Xml;

    /// <summary>
    /// The <see cref="IExtensionContentReader{TContent}"/> provides XML content read for elements that are part of an extension
    /// </summary>
    /// <typeparam name="TContent">Any type</typeparam>
    public interface IExtensionContentReader<out TContent>
    {
        /// <summary>
        /// Reads the <typeparamref name="TContent"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">The name of the document that is currently read</param>
        /// <returns>
        /// an instance of <typeparamref name="TContent"/>
        /// </returns>
        public TContent Read(XmlReader xmlReader, string documentName);
    }
}
