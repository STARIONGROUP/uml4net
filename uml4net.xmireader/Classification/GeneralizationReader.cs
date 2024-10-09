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

namespace uml4net.xmi.Classification
{
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.POCO.Classification;

    /// <summary>
    /// The purpose of the <see cref="GeneralizationReader"/> is to read an instance of <see cref="IGeneralization"/>
    /// from the XMI document
    /// </summary>
    public class GeneralizationReader
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<GeneralizationReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralizationReader"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public GeneralizationReader(ILoggerFactory loggerFactory = null)
        {
            this.loggerFactory = loggerFactory;

            this.logger = this.loggerFactory == null ? NullLogger<GeneralizationReader>.Instance : this.loggerFactory.CreateLogger<GeneralizationReader>();
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
        public IGeneralization Read(XmlReader xmlReader)
        {
            IGeneralization generalization = new Generalization();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                generalization.XmiId = xmlReader.GetAttribute("xmi:id");

                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Generalization")
                {
                    throw new XmlException($"The XmiType should be: uml:Generalization while it is {xmiType}");
                }

                generalization.XmiType = xmlReader.GetAttribute("xmi:type");

                var isSubstitutable = xmlReader.GetAttribute("isSubstitutable");
                if (!string.IsNullOrEmpty(isSubstitutable))
                {
                    generalization.IsSubstitutable = bool.Parse(isSubstitutable);
                }

                var general = xmlReader.GetAttribute("general");
                if (!string.IsNullOrEmpty(general))
                {
                    generalization.ReferencePropertyValueIdentifies.Add("general", general);
                }
            }

            return generalization;
        }
    }
}