// -------------------------------------------------------------------------------------------------
// <copyright file="XmiInspector.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

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
    
    /// <summary>
    /// The purpose of the <see cref="IXmiInspector"/> is to inspect the XMI and return a text based
    /// report
    /// </summary>
    public class XmiInspector : IXmiInspector
    {
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
            this.logger = loggerFactory == null ? NullLogger<XmiInspector>.Instance : loggerFactory.CreateLogger<XmiInspector>();
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

                        // The inspector reports the distinct element-to-attribute combinations found in the
                        // XMI. Elements without attributes carry no such combination and are intentionally
                        // omitted from the report, so result.Add is only reached when attributes are present.
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
