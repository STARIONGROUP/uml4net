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

namespace uml4net.xmi.Readers.StructuredClassifiers
{
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net.POCO;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.Packages;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers.Packages;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="ClassReader"/> is to read an instance of <see cref="IClass"/>
    /// from the XMI document
    /// </summary>
    public class ClassReader : XmiElementReader<IClass>, IXmiElementReader<IClass>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IConstraint"/>
        /// </summary>
        public IXmiElementReader<IConstraint> ConstraintReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IProperty"/>
        /// </summary>
        public IXmiElementReader<IProperty> PropertyReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IGeneralization"/>
        /// </summary>
        public IXmiElementReader<IGeneralization> GeneralizationReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IComment> CommentReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IOperation"/>
        /// </summary>
        public IXmiElementReader<IOperation> OperationReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public ClassReader(IXmiReaderCache cache, ILogger<ClassReader> logger)
            : base(cache, logger)
        {
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
        public override IClass Read(XmlReader xmlReader)
        {
            IClass @class = new Class();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Class")
                {
                    throw new XmlException($"The XmiType should be: uml:Class while it is {xmiType}");
                }

                @class.XmiType = xmiType;

                @class.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(@class.XmiId, @class);

                @class.Name = xmlReader.GetAttribute("name");

                var isAbstract = xmlReader.GetAttribute("isAbstract");
                if (!string.IsNullOrEmpty(isAbstract))
                {
                    @class.IsAbstract = bool.Parse(isAbstract);
                }
                
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
                                    var comment = this.CommentReader.Read(ownedCommentXmlReader);
                                    @class.OwnedComment.Add(comment);
                                }
                                break;
                            case "ownedRule":
                                using (var ownedRuleXmlReader = xmlReader.ReadSubtree())
                                {
                                    var constraint = this.ConstraintReader.Read(ownedRuleXmlReader);
                                    @class.OwnedRule.Add(constraint);
                                }
                                break;
                            case "ownedAttribute":
                                using (var ownedAttributeXmlReader = xmlReader.ReadSubtree())
                                {
                                    var property = this.PropertyReader.Read(ownedAttributeXmlReader);
                                    @class.OwnedAttribute.Add(property);
                                }
                                break;
                            case "ownedOperation":
                                using (var ownedOperationXmlReader = xmlReader.ReadSubtree())
                                {
                                    var operation = this.OperationReader.Read(ownedOperationXmlReader);
                                    @class.OwnedOperation.Add(operation);
                                }
                                break;
                            case "generalization":
                                using (var generalizationXmlReader = xmlReader.ReadSubtree())
                                {
                                    var generalization = this.GeneralizationReader.Read(generalizationXmlReader);
                                    @class.Generalization.Add(generalization);
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotImplementedException($"ClassReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }
            }

            return @class;
        }
    }
}
