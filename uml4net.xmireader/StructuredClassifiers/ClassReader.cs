// -------------------------------------------------------------------------------------------------
//  <copyright file="ClassReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.StructuredClassifiers
{
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.Packages;

    using uml4net.xmi.Classification;
    using uml4net.xmi.CommonStructure;
    using uml4net.xmi.Packages;
    
    /// <summary>
    /// The purpose of the <see cref="ClassReader"/> is to read an instance of <see cref="IClass"/>
    /// from the XMI document
    /// </summary>
    public class ClassReader
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<ClassReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageReader"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public ClassReader(ILoggerFactory loggerFactory = null)
        {
            this.loggerFactory = loggerFactory;

            this.logger = this.loggerFactory == null ? NullLogger<ClassReader>.Instance : this.loggerFactory.CreateLogger<ClassReader>();
        }

        /// <summary>
        /// Reads the <see cref="IPackage"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IPackage"/>
        /// </returns>
        public IClass Read(XmlReader xmlReader)
        {
            IClass @class = new Class();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                @class.XmiId = xmlReader.GetAttribute("xmi:id");

                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Class")
                {
                    throw new XmlException($"The XmiType should be: uml:Class while it is {xmiType}");
                }

                @class.XmiType = xmlReader.GetAttribute("xmi:type");

                @class.Name = xmlReader.GetAttribute("name");

                var visibility = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibility))
                {
                    @class.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibility, true);
                }

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "ownedComment":
                                using (var ownedCommentXmlReader = xmlReader.ReadSubtree())
                                {
                                    var commentReader = new CommentReader(this.loggerFactory);
                                    var comment = commentReader.Read(ownedCommentXmlReader);
                                    @class.OwnedComment.Add(comment);
                                }
                                break;
                            case "ownedRule":
                                using (var ownedRuleXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.logger.LogInformation("ClassReader.ownedRule not yet implemented");
                                }
                                break;
                            case "ownedAttribute":
                                using (var ownedAttributeXmlReader = xmlReader.ReadSubtree())
                                {
                                    var propertyReader = new PropertyReader(this.loggerFactory);
                                    var property = propertyReader.Read(ownedAttributeXmlReader);
                                    @class.OwnedAttribute.Add(property);
                                }
                                break;
                            case "ownedOperation":
                                using (var ownedOperationXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.logger.LogInformation("ClassReader.ownedOperation not yet implemented");
                                }
                                break;
                            case "generalization":
                                using (var generalizationXmlReader = xmlReader.ReadSubtree())
                                {
                                    var generalizationReader = new GeneralizationReader(this.loggerFactory);
                                    var generalization = generalizationReader.Read(generalizationXmlReader);
                                    @class.Generalization.Add(generalization);
                                }
                                break;
                            default:
                                throw new NotImplementedException($"ClassReader: {xmlReader.LocalName}");
                        }
                    }
                }
            }

            return @class;
        }
    }
}