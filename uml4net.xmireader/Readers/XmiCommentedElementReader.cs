// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiCommentedElementReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers
{
    using Microsoft.Extensions.Logging;

    using POCO;
    using POCO.CommonStructure;
    using Cache;

    /// <summary>
    /// An abstract class for reading XMI elements that include comments.
    /// </summary>
    /// <typeparam name="TXmiElement">The type of the XMI element to be read, must inherit from <see cref="IXmiElement"/>.</typeparam>
    /// <param name="cache">An instance of <see cref="IXmiReaderCache"/> for caching XMI elements.</param>
    /// <param name="logger">An instance of <see cref="ILogger{XmiElementReader}"/> for logging.</param>
    /// <param name="commentReader">An instance of <see cref="IXmiElementReader{IComment}"/> to read comments associated with the XMI elements.</param>
    public abstract class XmiCommentedElementReader<TXmiElement>(IXmiReaderCache cache, ILogger<XmiElementReader<TXmiElement>> logger, IXmiElementReader<IComment> commentReader)
        : XmiElementReader<TXmiElement>(cache, logger) where TXmiElement : IXmiElement
    {
        /// <summary>
        /// The <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        protected readonly IXmiElementReader<IComment> CommentReader = commentReader;
    }
}
