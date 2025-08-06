// -------------------------------------------------------------------------------------------------
//  <copyright file="IInheritanceDiagramRenderer.cs" company="Starion Group S.A.">
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

namespace uml4net.Reporting.Drawing
{
    using System.IO;

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
        /// <param name="stream">
        /// The target <see cref="Stream"/> to write to
        /// </param>
        public void SvgRender(XmiReaderResult xmiReaderResult, Stream stream);

        /// <summary>
        /// Renders the content of the <see cref="XmiReaderResult"/>
        /// </summary>
        /// <param name="xmiReaderResult">
        /// The <see cref="XmiReaderResult"/> that contains the UML model
        /// </param>
        /// <returns>
        /// a string that contains the diagram in SVG format
        /// </returns>
        string SvgRender(XmiReaderResult xmiReaderResult);
    }
}