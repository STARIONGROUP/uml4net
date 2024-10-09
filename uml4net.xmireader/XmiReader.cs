// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReader.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.POCO.Packages;
    using uml4net.xmi.Packages;

    /// <summary>
    /// The purpose of the <see cref="XmiReader"/> is to provide a means to read (deserialize)
    /// an UML 2.5.1 model from XMI
    /// </summary>
    public class XmiReader : IXmiReader
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<XmiReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReader"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public XmiReader(ILoggerFactory loggerFactory = null)
        {
            this.loggerFactory = loggerFactory;

            this.logger = this.loggerFactory == null ? NullLogger<XmiReader>.Instance : this.loggerFactory.CreateLogger<XmiReader>();
        }

        /// <summary>
        /// reads the content of a UML XMI 2.5.1 file
        /// </summary>
        /// <param name="fileUri">
        /// the path to the XMI file
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{Package}"/>
        /// </returns>
        public IEnumerable<IPackage> Read(string fileUri)
        {
            using (var fileStream = File.OpenRead(fileUri))
            {
                var sw = Stopwatch.StartNew();

                this.logger.LogTrace("start deserializing from {path}", fileUri);

                var result = this.Read(fileStream);

                this.logger.LogTrace("File {path} deserialized in {time} [ms]", fileUri, sw.ElapsedMilliseconds);

                return result;
            }
        }

        /// <summary>
        /// reads the content of a UML XMI 2.5.1 stream
        /// </summary>
        /// <param name="stream">
        /// the <see cref="Stream"/> that contains the XMI content
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{Package}"/>
        /// </returns>
        public IEnumerable<IPackage> Read(Stream stream)
        {
            XmlReader xmlReader;

            var settings = new XmlReaderSettings();

            stream.Seek(0, SeekOrigin.Begin);

            using (xmlReader = XmlReader.Create(stream, settings))
            {
                var sw = Stopwatch.StartNew();

                var packages = new List<IPackage>();

                this.logger.LogTrace("starting to read xml");

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        //TODO: this should probably be a full list of all kinds of UML classes, use codegen
                        switch (xmlReader.Name)
                        {
                            case "uml:Package":
                                using (var packageXmlReader = xmlReader.ReadSubtree())
                                {
                                    var packageReader = new PackageReader();
                                    var package = packageReader.Read(packageXmlReader);
                                    packages.Add(package);
                                }
                                break;
                            case "uml:Model":
                                using (var modelXmlReader = xmlReader.ReadSubtree())
                                {
                                    var modelReader = new ModelReader();
                                    var model = modelReader.Read(modelXmlReader);
                                    packages.Add(model);
                                }
                                break;
                        }
                    }
                }

                this.logger.LogTrace("xml read in {time}", sw.ElapsedMilliseconds);
                sw.Stop();

                return packages;
            }
        }
    }
}
