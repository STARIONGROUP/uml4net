// -------------------------------------------------------------------------------------------------
//  <copyright file="StereoTypeApplicationReader.cs" company="Starion Group S.A.">
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
    using Microsoft.Extensions.Logging.Abstractions;
    
    using uml4net.Profiling;
    
    /// <summary>
    /// The purpose of the <see cref="StereoTypeApplicationReader"/> is to read an instance
    /// of <see cref="StereoTypeApplication"/> from the XMI document
    /// </summary>
    public class StereoTypeApplicationReader
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<StereoTypeApplicationReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StereoTypeApplicationReader"/> class.
        /// </summary>>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public StereoTypeApplicationReader(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<StereoTypeApplicationReader>.Instance : loggerFactory.CreateLogger<StereoTypeApplicationReader>();
        }

        /// <summary>
        /// Reads the <see cref="StereoTypeApplication"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="stereoTypeApplication">
        /// The <see cref="StereoTypeApplication"/> that is being read.
        /// </param>
        /// <returns>
        /// an instance of <see cref="StereoTypeApplication"/>
        /// </returns>
        public bool TryRead(XmlReader xmlReader, out StereoTypeApplication stereoTypeApplication)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            stereoTypeApplication = new StereoTypeApplication();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading StereoTypeApplication at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var profileName = xmlReader.Prefix;
                var stereoTypeName = xmlReader.LocalName;

                if (xmlReader.HasAttributes)
                {
                    var isStereoTypeApplication = false;

                    for (int i = 0; i < xmlReader.AttributeCount; i++)
                    {
                        xmlReader.MoveToAttribute(i);

                        if (xmlReader.Name == "xmi:id")
                        {
                            stereoTypeApplication.XmiId = xmlReader.Value;
                        }
                        else if (xmlReader.LocalName.StartsWith("base_", StringComparison.Ordinal))
                        {
                            stereoTypeApplication.MetaClass = xmlReader.LocalName.Substring("base_".Length);
                            stereoTypeApplication.ElementIdentifier = xmlReader.Value;

                            isStereoTypeApplication = true;
                        }
                        else
                        {
                            stereoTypeApplication.Attributes.Add(xmlReader.LocalName, xmlReader.Value);
                        }
                    }

                    xmlReader.MoveToElement();

                    if (!isStereoTypeApplication)
                    {
                        this.logger.LogTrace("The XML Element {ProfileName}:{StereoTypeName} at line:position {LineNumber}:{LinePosition} does not appear to be a StereoTypeApplication", profileName, stereoTypeName, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                        stereoTypeApplication = null;
                        return false;
                    }

                    stereoTypeApplication.ProfileName = profileName;
                    stereoTypeApplication.StereoTypeName = stereoTypeName;
                }
                else
                {
                    this.logger.LogTrace("The XML Element {ProfileName}:{StereoTypeName} at line:position {LineNumber}:{LinePosition} does not appear to be a StereoTypeApplication", profileName, stereoTypeName, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                    stereoTypeApplication = null;
                    return false;
                }
            }

            return true;
        }
    }
}
