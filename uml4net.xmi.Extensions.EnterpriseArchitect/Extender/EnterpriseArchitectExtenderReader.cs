// -------------------------------------------------------------------------------------------------
//  <copyright file="EnterpriseArchitectExtenderReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Extender
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.xmi.Extender;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// An <see cref="IExtenderReader"/> implementation that processes <c>xmi:Extension</c> elements
    /// produced by <strong>Sparx Systems Enterprise Architect</strong> version <c>6.5</c>.
    /// </summary>
    /// <remarks>
    /// Enterprise Architect embeds tool-specific metadata inside <c>xmi:Extension</c> blocks,
    /// including diagram layout, tagged values, and other proprietary modeling data.
    /// This reader extracts and interprets such content for downstream usage.
    /// </remarks>
    [ExtenderReader("Enterprise Architect", "6.5")]
    public class EnterpriseArchitectExtenderReader : IExtenderReader
    {
        /// <summary>
        /// The (injected) <see cref="ILogger{XmiReader}"/> used to perform logging
        /// </summary>
        private readonly ILogger<XmiReader> logger;

        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </summary>
        protected readonly ILoggerFactory LoggerFactory;

        /// <summary>
        /// The <see cref="IXmiReaderScope"/>
        /// </summary>
        private readonly IXmiReaderScope scope;

        /// <summary>
        /// The (injected) <see cref="IXmiReaderSettings"/> used to configure reading
        /// </summary>
        protected readonly IXmiReaderSettings XmiReaderSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReader"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        /// <param name="scope">The <see cref="IXmiReaderScope"/></param>
        /// <param name="xmiReaderSettings">The injected <see cref="IXmiReaderSettings"/> that provides reading setting for XMI</param>
        public EnterpriseArchitectExtenderReader(IXmiReaderScope scope, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
        {
            this.XmiReaderSettings = xmiReaderSettings;
            this.LoggerFactory = loggerFactory;
            this.logger = this.LoggerFactory == null ? NullLogger<XmiReader>.Instance : this.LoggerFactory.CreateLogger<XmiReader>();
            this.scope = scope;
        }

        /// <summary>
        /// Reads the content of the Enterprise Architect <see cref="XmiExtension"/>
        /// </summary>
        /// <param name="extensionXmi">
        /// the xml content of the <see cref="XmiExtension"/>
        /// </param>
        /// <returns>
        /// the contents as a <see cref="List{Object}"/>
        /// </returns>
        public List<object> ReadContent(string extensionXmi)
        {
            var sw = Stopwatch.StartNew();

            this.logger.LogDebug("Starting to read Enterprise Architect 6.5 extension");

            var result = new List<object>();

            using (var xmlReader = XmlReader.Create(new StringReader(extensionXmi)))
            {
                // process content of Extensions
            }

            this.logger.LogDebug("Enterprise Architect 6.5 extension read in {ElapsedMilliseconds} [ms]", sw.ElapsedMilliseconds);

            return result;
        }

        /// <summary>
        /// Performs post-processing of a UMl model using content of the extension
        /// </summary>
        public void PostProcess()
        {
            // here we can update the documentation  based on docs in EA extension -> then
            // we do not need a separate QueryDocs method.

            throw new System.NotImplementedException();
        }
    }
}
