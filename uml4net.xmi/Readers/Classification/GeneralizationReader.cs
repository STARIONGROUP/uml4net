// -------------------------------------------------------------------------------------------------
//  <copyright file="GeneralizationReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.Classification
{
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.Classification;
    using uml4net.Utils;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;
    
    /// <summary>
    /// The purpose of the <see cref="GeneralizationReader"/> is to read an instance of <see cref="IGeneralization"/>
    /// from the XMI document
    /// </summary>
    public class GeneralizationReader : XmiElementReader<IGeneralization>, IXmiElementReader<IGeneralization>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralizationReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The <see cref="ILogger{T}"/>
        /// </param>
        public GeneralizationReader(IXmiReaderCache cache, ILogger<GeneralizationReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IGeneralization"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IGeneralization"/>
        /// </returns>
        public override IGeneralization Read(XmlReader xmlReader)
        {
            Guard.ThrowIfNull(xmlReader);

            IGeneralization generalization = new Generalization();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Generalization")
                {
                    throw new XmlException($"The XmiType should be 'uml:Generalization' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Generalization";
                }

                generalization.XmiType = xmiType;

                generalization.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(generalization.XmiId, generalization);

                var isSubstitutable = xmlReader.GetAttribute("isSubstitutable");
                if (!string.IsNullOrEmpty(isSubstitutable))
                {
                    generalization.IsSubstitutable = bool.Parse(isSubstitutable);
                }

                var general = xmlReader.GetAttribute("general");
                if (!string.IsNullOrEmpty(general))
                {
                    generalization.SingleValueReferencePropertyIdentifiers.Add("general", general);
                }
            }

            return generalization;
        }
    }
}
