// -------------------------------------------------------------------------------------------------
// <copyright file="Image.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Packages
{
    using System;
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// Physical definition of a graphical image.
    /// </summary>
    public class Image : XmiElement, IImage
    {
        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        List<IComment> IElement.OwnedComment { get; set; }

        /// <summary>
        /// The Elements owned by this Element
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        List<IElement> IElement.OwnedElement => throw new NotImplementedException();

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        IElement IElement.Owner => throw new NotImplementedException();


        /// <summary>
        /// This contains the serialization of the image according to the format. The value could represent a
        /// bitmap, image such as a GIF file, or drawing 'instructions' using a standard such as Scalable
        /// Vector Graphic (SVG) (which is XML based).
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "IImage.Content")]
        public string Content { get; set; }

        /// <summary>
        /// This indicates the format of the content, which is how the string content should be interpreted.
        /// The following values are reserved: SVG, GIF, PNG, JPG, WMF, EMF, BMP. In addition the prefix 'MIME: '
        /// is also reserved. This option can be used as an alternative to express the reserved values above,
        /// for example &quot;SVG&quot; could instead be expressed as &quot;MIME: image/svg+xml&quot;.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "IImage.Format")]
        public string Format { get; set; }

        /// <summary>
        /// This contains a location that can be used by a tool to locate the image as an alternative to embedding
        /// it in the stereotype.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "IImage.Location")]
        public string Location { get; set; }
    }
}
