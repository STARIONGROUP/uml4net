// -------------------------------------------------------------------------------------------------
// <copyright file="IInheritanceDiagramRenderer.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Reporting.Drawing
{
    using System.IO;

    using uml4net.Reporting.Payload;
    using uml4net.StructuredClassifiers;

    using xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="IInheritanceDiagramRenderer"/> is to render a UML class diagram
    /// that shows the inheritance of the classes in a UML model
    /// </summary>
    public interface IInheritanceDiagramRenderer
    {
        /// <summary>
        /// Renders the content of the <see cref="XmiReaderResult"/> to a stream
        /// </summary>
        /// <param name="xmiReaderResult">
        /// The <see cref="XmiReaderResult"/> that contains the UML model
        /// </param>
        /// <param name="xmiId">
        /// the unique identifier of the root package to generate
        /// </param>
        /// <param name="rootName">
        /// the name of the root package to generate
        /// </param>
        /// <param name="stream">
        /// The target <see cref="Stream"/> to write to
        /// </param>
        public void SvgRender(XmiReaderResult xmiReaderResult, string xmiId, string rootName, Stream stream);

        /// <summary>
        /// Renders the content of the <see cref="XmiReaderResult"/>
        /// </summary>
        /// <param name="xmiReaderResult">
        /// The <see cref="XmiReaderResult"/> that contains the UML model
        /// </param>
        /// <param name="xmiId">
        /// the unique identifier of the root package to generate
        /// </param>
        /// <param name="rootName">
        /// the name of the root package to generate
        /// </param>
        /// <returns>
        /// a string that contains the diagram in SVG format
        /// </returns>
        string SvgRender(XmiReaderResult xmiReaderResult, string xmiId, string rootName);

        /// <summary>
        /// Renders a per-class inheritance tree SVG diagram that highlights the target class
        /// and shows all its ancestors and descendants
        /// </summary>
        /// <param name="targetClass">
        /// The <see cref="IClass"/> for which to render the inheritance tree
        /// </param>
        /// <param name="payload">
        /// The <see cref="HandlebarsPayload"/> that contains the UML content
        /// </param>
        /// <returns>
        /// a string that contains the per-class inheritance diagram in SVG format
        /// </returns>
        string SvgRenderForClass(IClass targetClass, HandlebarsPayload payload);
    }
}