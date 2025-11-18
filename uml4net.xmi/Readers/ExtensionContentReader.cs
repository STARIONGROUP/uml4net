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
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net.xmi.Extender;
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
        /// <param name="registry">The <see cref="IExtenderReaderRegistry"/> that allow resolve <see cref="IExtensionContentReaderFacade"/></param>
        /// <param name="xmiReaderSettings">The <see cref="IXmiReaderSettings"/> that provides settings to be followed during XMI reading</param>
        /// <param name="nameSpaceResolver">The <see cref="INameSpaceResolver"/> that provides namespace resolves features based on uri</param>
        /// <param name="cache">The <see cref="IXmiElementCache"/> that provides cached <see cref="IXmiElement"/> retriveal</param>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> that provides <see cref="ILogger{TCategoryName}"/> creation</param>
        protected ExtensionContentReader(IExtenderReaderRegistry registry,  IXmiReaderSettings xmiReaderSettings, 
            INameSpaceResolver nameSpaceResolver, IXmiElementCache cache, ILoggerFactory loggerFactory)
        {
            this.ExtensionContentReaderFacade = registry.ResolveFacade(this.Extender, this.ExtenderId) ?? throw new InvalidOperationException("Unable to resolve IExtensionContentReaderFacade");
            this.XmiReaderSettings = xmiReaderSettings;
            this.LoggerFactory =  loggerFactory;
            this.NameSpaceResolver =  nameSpaceResolver;
            this.Cache = cache;
        }

        /// <summary>
        /// Gets the name of the related extender
        /// </summary>
        private string Extender => this.GetExtender();
        
        /// <summary>
        /// Gets the identifier of the related extender
        /// </summary>
        private string ExtenderId => this.GetExtenderId();

        /// <summary>
        /// Gets the <see cref="IExtensionContentReaderFacade"/> that allow other <see cref="ExtensionContentReader{TContent}"/> read capabilities
        /// </summary>
        protected readonly IExtensionContentReaderFacade ExtensionContentReaderFacade;

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
        /// The <see cref="IXmiElementCache"/> that provides cached <see cref="IXmiElement"/> retriveal
        /// </summary>
        protected readonly IXmiElementCache Cache;

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
        public abstract TContent Read(XmlReader xmlReader, string documentName);

        /// <summary>
        /// Gets the name of the extender value
        /// </summary>
        /// <returns>The extender name</returns>
        protected abstract string GetExtender();

        /// <summary>
        /// Gets the identifier of the extender value
        /// </summary>
        /// <returns>The extender id</returns>
        protected abstract string GetExtenderId();
    }
}
