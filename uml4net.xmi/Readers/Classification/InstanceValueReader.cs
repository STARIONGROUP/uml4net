// -------------------------------------------------------------------------------------------------
//  <copyright file="InstanceValueReader.cs" company="Starion Group S.A.">
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
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    
    using uml4net.POCO;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="InstanceValueReader"/> is to read an instance of <see cref="IInstanceValue"/>
    /// from the XMI document
    /// </summary>
    public class InstanceValueReader : XmiElementReader<IInstanceValue>, IXmiElementReader<IInstanceValue>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IComment> CommentReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceValueReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public InstanceValueReader(IXmiReaderCache cache, ILogger<InstanceValueReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IInstanceValue"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IConstraint"/>
        /// </returns>
        public override IInstanceValue Read(XmlReader xmlReader)
        {
            IInstanceValue instanceValue = new InstanceValue();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:InstanceValue")
                {
                    throw new XmlException($"The XmiType should be: uml:InstanceValue while it is {xmiType}");
                }

                instanceValue.XmiType = xmiType;

                instanceValue.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(instanceValue.XmiId, instanceValue);

                instanceValue.Name = xmlReader.GetAttribute("name");

                var visibility = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibility))
                {
                    instanceValue.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibility, true);
                }

                var type = xmlReader.GetAttribute("type");
                if (!string.IsNullOrEmpty(type))
                {
                    instanceValue.SingleValueReferencePropertyIdentifiers.Add("type", type);
                }

                var instance = xmlReader.GetAttribute("instance");
                if (!string.IsNullOrEmpty(instance))
                {
                    instanceValue.SingleValueReferencePropertyIdentifiers.Add("instance", instance);
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
                                    var comment = this.CommentReader.Read(ownedCommentXmlReader);
                                    instanceValue.OwnedComment.Add(comment);
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotImplementedException($"InstanceValueReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }
            }

            return instanceValue;
        }
    }
}