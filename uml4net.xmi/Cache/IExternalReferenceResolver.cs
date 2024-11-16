// -------------------------------------------------------------------------------------------------
//  <copyright file="IExternalReferenceResolver.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Cache
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Defines a contract for resolving external references associated with XMI elements.
    /// </summary>
    public interface IExternalReferenceResolver
    {
        /// <summary>
        /// Asynchronously attempts to resolve external references and yields their context and stream.
        /// </summary>
        /// <returns>An enumerable of tuples containing the context and stream of resolved references.</returns>
        IEnumerable<(string Context, Stream Stream)> TryResolve();
    }
}
