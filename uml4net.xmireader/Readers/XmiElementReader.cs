// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiElementReader.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Readers
{
    using Cache;
    using Microsoft.Extensions.Logging;
    using System.Xml;
    using POCO;

    /// <summary>
    /// The abstract super class from which eadh XMI reader needs to derive
    /// </summary> 
    /// <typeparam name="TXmiElement">The type of the XMI element to be read.</typeparam>
    public abstract class XmiElementReader<TXmiElement> where TXmiElement : IXmiElement
    {
        /// <summary>
        /// The (injected) <see cref="ILogger"/> used to setup logging
        /// </summary>
        protected readonly ILogger<XmiElementReader<TXmiElement>> Logger;

        /// <summary>
        /// The (injected) <see cref="IXmiReaderCache"/> used to setup logging
        /// </summary>
        protected readonly IXmiReaderCache Cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReader{T}"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        protected XmiElementReader(IXmiReaderCache cache, ILogger<XmiElementReader<TXmiElement>> logger)
        {
            this.Cache = cache;
            this.Logger = logger;
        }

        /// <summary>
        /// Reads the <typeparamref name="TXmiElement"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <typeparamref name="TXmiElement"/>
        /// </returns>
        public abstract TXmiElement Read(XmlReader xmlReader);
    }
}