// -------------------------------------------------------------------------------------------------
//  <copyright file="InterfaceReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.SimpleClassifiers
{
    using Cache;
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using POCO.Classification;
    using POCO;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Packages;

    using Packages;
    using POCO.SimpleClassifiers;
    using Readers;

    /// <summary>
    /// The purpose of the <see cref="InterfaceReader"/> is to read an instance of <see cref="IInterface"/>
    /// from the XMI document
    /// </summary>
    public class InterfaceReader : XmiElementReader<IInterface>, IXmiElementReader<IInterface>
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
        /// Initializes a new instance of the <see cref="PackageReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public InterfaceReader(IXmiReaderCache cache, ILogger<InterfaceReader> logger)
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
        public override IInterface Read(XmlReader xmlReader)
        {
            IInterface @interface = new Interface();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Interface")
                {
                    throw new XmlException($"The XmiType should be: uml:Interface while it is {xmiType}");
                }

                @interface.XmiType = xmiType;

                @interface.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(@interface.XmiId, @interface);

                @interface.Name = xmlReader.GetAttribute("name");
                @interface.IsAbstract = bool.TryParse(xmlReader.GetAttribute("isAbstract"), out var isAbstract) && isAbstract;
                
                var visibility = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibility))
                {
                    @interface.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibility, true);
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
                                    @interface.OwnedComment.Add(comment);
                                }
                                break;
                            case "ownedRule":
                                using (var ownedRuleXmlReader = xmlReader.ReadSubtree())
                                {
                                    var constraint = this.ConstraintReader.Read(ownedRuleXmlReader);
                                    @interface.OwnedRule.Add(constraint);
                                }
                                break;
                            case "ownedAttribute":
                                using (var ownedAttributeXmlReader = xmlReader.ReadSubtree())
                                {
                                    var property = this.PropertyReader.Read(ownedAttributeXmlReader);
                                    @interface.Attribute.Add(property);
                                }
                                break;
                            case "ownedOperation":
                                using (var ownedOperationXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.Logger.LogInformation("InterfaceReader.ownedOperation not yet implemented");
                                }
                                break;
                            case "generalization":
                                using (var generalizationXmlReader = xmlReader.ReadSubtree())
                                {
                                    var generalization = this.GeneralizationReader.Read(generalizationXmlReader);
                                    @interface.Generalization.Add(generalization);
                                }
                                break;
                            default:
                                throw new NotImplementedException($"InterfaceReader: {xmlReader.LocalName}");
                        }
                    }
                }
            }

            return @interface;
        }
    }
}