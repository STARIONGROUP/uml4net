// -------------------------------------------------------------------------------------------------
//  <copyright file="AssociationReader.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.StructuredClassifiers;
    using uml4net.Utils;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="AssociationReader"/> is to read an instance of <see cref="IAssociation"/>
    /// from the XMI document
    /// </summary>
    public class AssociationReader : XmiElementReader<IAssociation>, IXmiElementReader<IAssociation>
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
        /// Initializes a new instance of the <see cref="AssociationReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public AssociationReader(IXmiReaderCache cache, ILogger<AssociationReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IAssociation"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IAssociation"/>
        /// </returns>
        public override IAssociation Read(XmlReader xmlReader)
        {
            Guard.ThrowIfNull(xmlReader);

            IAssociation association = new Association();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Association")
                {
                    throw new XmlException($"The XmiType should be 'uml:Association' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Association";
                }

                association.XmiType = xmiType;

                association.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(association.XmiId, association);

                association.Name = xmlReader.GetAttribute("name");

                var visibility = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibility))
                {
                    association.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibility, true);
                }

                var isDerived = xmlReader.GetAttribute("isDerived");
                if (!string.IsNullOrEmpty(isDerived))
                {
                    association.IsDerived = bool.Parse(isDerived);
                }

                var memberEnds = new List<string>();

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
                                    association.OwnedComment.Add(comment);
                                }
                                break;
                            case "ownedRule":
                                using (var ownedRuleXmlReader = xmlReader.ReadSubtree())
                                {
                                    var constraint = this.ConstraintReader.Read(ownedRuleXmlReader);
                                    association.OwnedRule.Add(constraint);
                                }
                                break;
                            case "memberEnd":
                                using (var memberXmlReader = xmlReader.ReadSubtree())
                                {
                                    if(memberXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = memberXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            memberEnds.Add(reference);
                                        }
                                        else if (memberXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            memberEnds.Add(idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("memberEnd xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;

                            case "ownedEnd":
                                using (var ownedEndXmlReader = xmlReader.ReadSubtree())
                                {
                                    var ownedEnd = this.PropertyReader.Read(ownedEndXmlReader);
                                    association.OwnedEnd.Add(ownedEnd);
                                }
                                break;
                            case "ownedOperation":
                                using (var ownedOperationXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.Logger.LogInformation("ClassReader.ownedOperation not yet implemented");
                                }
                                break;
                            case "generalization":
                                using (var generalizationXmlReader = xmlReader.ReadSubtree())
                                {
                                    var generalization = this.GeneralizationReader.Read(generalizationXmlReader);
                                    association.Generalization.Add(generalization);
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotImplementedException($"AssociationReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (memberEnds.Count > 0)
                {
                    association.MultiValueReferencePropertyIdentifiers.Add("memberEnd", memberEnds);
                }
            }

            return association;
        }
    }
}
