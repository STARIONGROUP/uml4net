// -------------------------------------------------------------------------------------------------
//  <copyright file="IAssociationDiagramRenderer.cs" company="Starion Group S.A.">
//
//    Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.Reporting.Drawing
{
    using uml4net.Reporting.Payload;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// The purpose of the <see cref="IAssociationDiagramRenderer"/> is to render a UML association diagram
    /// that shows a class and all its first-order neighbours connected by typed properties
    /// </summary>
    public interface IAssociationDiagramRenderer
    {
        /// <summary>
        /// Renders a per-class association SVG diagram that shows the target class
        /// and all classes connected to it via typed properties, with multiplicity labels
        /// and UML notation (composition diamonds, aggregation diamonds, navigability arrows)
        /// </summary>
        /// <param name="targetClass">
        /// The <see cref="IClass"/> for which to render the association diagram
        /// </param>
        /// <param name="payload">
        /// The <see cref="HandlebarsPayload"/> that contains the UML content
        /// </param>
        /// <returns>
        /// a string that contains the per-class association diagram in SVG format,
        /// or an empty string if the class has no associations
        /// </returns>
        string SvgRenderForClass(IClass targetClass, HandlebarsPayload payload);
    }
}
