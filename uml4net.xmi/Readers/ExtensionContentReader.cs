// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionContentReader.cs" company="Starion Group S.A.">
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
    /// The <see cref="ExtensionContentReader{TContent}"/> provides XML content read for elements that are part of an extension
    /// </summary>
    /// <typeparam name="TContent">Any type</typeparam>
    public abstract class ExtensionContentReader<TContent>: IExtensionContentReader<TContent>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ExtensionContentReader{TContent}"/>
        /// </summary>
        /// <param name="cache">The <see cref="IXmiElementCache"/> that allow retrieving XMI Elements</param>
        /// <param name="extensionContentReaderFacade">The <see cref="IExtensionContentReaderFacade"/> that allow other <see cref="ExtensionContentReader{TContent}"/> read capabilities</param>
        /// <param name="xmiReaderSettings">The <see cref="IXmiReaderSettings"/> that provides settings to be followed during XMI reading</param>
        /// <param name="nameSpaceResolver">The <see cref="INameSpaceResolver"/> that provides namespace resolves features based on uri</param>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> that provides <see cref="ILogger{TCategoryName}"/> creation</param>
        protected ExtensionContentReader(IXmiElementCache cache,  IExtensionContentReaderFacade extensionContentReaderFacade,  IXmiReaderSettings xmiReaderSettings, 
            INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
        {
            this.Cache = cache;
            this.ExtensionContentReaderFacade = extensionContentReaderFacade;
            this.XmiReaderSettings = xmiReaderSettings;
            this.NameSpaceResolver = nameSpaceResolver;
            this.LoggerFactory =  loggerFactory;
        }

        /// <summary>
        /// Gets the <see cref="IExtensionContentReaderFacade"/> that allow other <see cref="ExtensionContentReader{TContent}"/> read capabilities
        /// </summary>
        protected readonly IExtensionContentReaderFacade ExtensionContentReaderFacade;

        /// <summary>
        /// Gets the <see cref="IXmiElementCache"/> that allow retrieving XMI Elements
        /// </summary>
        protected readonly IXmiElementCache Cache;
        
        /// <summary>
        /// Gets the <see cref="IXmiReaderSettings"/> that provides settings to be followed during XMI reading
        /// </summary>
        protected readonly IXmiReaderSettings XmiReaderSettings;
        
        /// <summary>
        /// Gets the <see cref="INameSpaceResolver"/> that provides namespace resolves features based on uri
        /// </summary>
        protected readonly INameSpaceResolver NameSpaceResolver;
        
        /// <summary>
        /// Gets the <see cref="ILoggerFactory"/> that provides <see cref="ILogger{TCategoryName}"/> creation
        /// </summary>
        protected readonly ILoggerFactory LoggerFactory;

        /// <summary>
        /// Reads the <typeparamref name="TContent"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">The actual document name</param>
        /// <param name="namespaceUri">The uri namespace</param>
        /// <returns>
        /// an instance of <typeparamref name="TContent"/>
        /// </returns>
        public abstract TContent Read(XmlReader xmlReader, string documentName, string namespaceUri);
    }
}
