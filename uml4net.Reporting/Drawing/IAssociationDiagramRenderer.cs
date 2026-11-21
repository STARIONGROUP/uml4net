// -------------------------------------------------------------------------------------------------
// <copyright file="IAssociationDiagramRenderer.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

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
