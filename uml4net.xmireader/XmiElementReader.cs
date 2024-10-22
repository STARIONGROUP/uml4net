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

namespace uml4net.xmi
{
    using System.Collections.Generic;

    using Microsoft.Extensions.Logging;
    
    using uml4net.POCO;

    /// <summary>
    /// The abstract super class from which eadh XMI reader needs to derive
    /// </summary>
    public abstract class XmiElementReader
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </summary>
        protected readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </summary>
        protected readonly Dictionary<string, IXmiElement> cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        protected XmiElementReader(Dictionary<string, IXmiElement> cache, ILoggerFactory loggerFactory = null)
        {
            this.cache = cache;
            this.loggerFactory = loggerFactory;
        }
    }
}