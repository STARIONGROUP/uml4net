// -------------------------------------------------------------------------------------------------
//  <copyright file="RealizationReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.CommonStructure
{
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using POCO;
    using uml4net.POCO.CommonStructure;
    using Cache;
    using Readers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The purpose of the <see cref="CommentReader"/> is to read an instance of <see cref="IRealization"/>
    /// from the XMI document
    /// </summary>
    public class RealizationReader : XmiElementReader<IRealization>, IXmiElementReader<IRealization>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RealizationReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public RealizationReader(IXmiReaderCache cache, ILogger<RealizationReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IRealization"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IRealization"/>
        /// </returns>
        public override IRealization Read(XmlReader xmlReader)
        {
            IRealization realization = new Realization();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Realization")
                {
                    throw new XmlException($"The XmiType should be: uml:Realization while it is {xmiType}");
                }

                realization.XmiType = xmiType;

                realization.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(realization.XmiId, realization);
                
                var clientIds = xmlReader.GetAttribute("client");
                if (!string.IsNullOrEmpty(clientIds))
                {
                    realization.MultiValueReferencePropertyIdentifiers.Add("Client", clientIds.Split([' '], StringSplitOptions.RemoveEmptyEntries).ToList());
                }

                var supplierIds = xmlReader.GetAttribute("supplier");
                if (!string.IsNullOrEmpty(supplierIds))
                {
                    realization.MultiValueReferencePropertyIdentifiers.Add("Supplier", supplierIds.Split([' '], StringSplitOptions.RemoveEmptyEntries).ToList());
                }
            }

            return realization;
        }
    }
}