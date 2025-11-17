// -------------------------------------------------------------------------------------------------
//  <copyright file="IExtensionContentReaderFacade.cs" company="Starion Group S.A.">
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

    using Microsoft.Extensions.Logging;

    using uml4net.xmi.Settings;

    /// <summary>
    /// The <see cref="IExtensionContentReaderFacade"/> provides extension content read capabilities via <see cref="IExtensionContentReader{TContent}"/> call
    /// </summary>
    public interface IExtensionContentReaderFacade
    {
        /// <summary>
        /// Queries the extension content 
        /// </summary>
        /// <param name="xmlReader">The <see cref="XmlReader"/> that provides XML read capabilities</param>
        /// <param name="xmiReaderSettings" >
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the 
        /// </param>
        /// <param name="xmiElementCache">The <see cref="IXmiElementCache"/> that provides cached <see cref="IXmiElement"/> retriveal</param>
        /// <param name="documentName">The name of the document that is currently read</param>
        /// <param name="loggerFactory">
        /// The <see cref="ILoggerFactory"/> to set up logging
        /// </param>
        /// <typeparam name="TContent">Any supported type by the facade</typeparam>
        /// <returns>The read <typeparamref name="TContent"/></returns>
        TContent QueryExtensionContent<TContent>(XmlReader xmlReader, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IXmiElementCache xmiElementCache, string documentName, ILoggerFactory loggerFactory);
    }
}
