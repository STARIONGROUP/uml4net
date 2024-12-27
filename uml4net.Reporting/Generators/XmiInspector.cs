// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiInspector.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
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

namespace uml4net.Reporting.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    
    using uml4net.Utils;
    
    /// <summary>
    /// The purpose of the <see cref="IXmiInspector"/> is to inspect the XMI and return a text based
    /// report
    /// </summary>
    public class XmiInspector : IXmiInspector
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<XmiInspector> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiInspector"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public XmiInspector(ILoggerFactory loggerFactory = null)
        {
            this.loggerFactory = loggerFactory;

            this.logger = this.loggerFactory == null ? NullLogger<XmiInspector>.Instance : this.loggerFactory.CreateLogger<XmiInspector>();
        }

        /// <summary>
        /// inspects the provided XMI document
        /// </summary>
        /// <param name="modelFileInfo">
        /// the path to the XMI document
        /// </param>
        /// <returns>
        /// a text based report
        /// </returns>
        public string Inspect(FileInfo modelFileInfo)
        {
            if (modelFileInfo == null)
            {
                throw new ArgumentNullException(nameof(modelFileInfo));
            }

            using var fileStream = File.OpenRead(modelFileInfo.FullName);

            var settings = new XmlReaderSettings();

            fileStream.Seek(0, SeekOrigin.Begin);

            var sw = Stopwatch.StartNew();

            var result = new List<string>();

            using (var reader = new StreamReader(fileStream, detectEncodingFromByteOrderMarks: true))

            using (var xmlReader = XmlReader.Create(reader, settings))
            {
                this.logger.LogInformation("starting to read xml at: {ModelFileInfo}", modelFileInfo);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var entry = $"{xmlReader.Name}:";

                        if (xmlReader.HasAttributes)
                        {
                            while (xmlReader.MoveToNextAttribute())
                            {
                                entry = $"{entry} {xmlReader.Name}";
                            }
   
                            xmlReader.MoveToElement();
                            result.Add(entry);
                        }
                    }
                }
            }

            this.logger.LogTrace("xml at {ModelFileInfo} read in {ElapsedMilliseconds} [ms]", modelFileInfo, sw.ElapsedMilliseconds);
            
            result = result.Distinct().OrderBy(item => item).ToList();

            return string.Join(Environment.NewLine, result);
        }
    }
}
