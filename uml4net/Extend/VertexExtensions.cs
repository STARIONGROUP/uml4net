// -------------------------------------------------------------------------------------------------
//  <copyright file="VertexExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.StateMachines
{
    using System;
    using System.Collections.Generic;

    using uml4net.Classification;

    /// <summary>
    /// The <see cref="VertexExtensions"/> class provides extensions methods for <see cref="IVertex"/>
    /// </summary>
    internal static class VertexExtensions
    {
        /// <summary>
        /// Specifies the Transitions entering this Vertex.
        /// </summary>
        /// <param name="vertex">
        /// The subject <see cref="IVertex"/>
        /// </param>
        /// <returns>
        /// The Transitions entering this Vertex.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<ITransition> QueryIncoming(this IVertex vertex)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Specifies the Transitions departing from this Vertex.
        /// </summary>
        /// <param name="vertex">
        /// The subject <see cref="IVertex"/>
        /// </param>
        /// <returns>
        /// The Transitions departing from this Vertex.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<ITransition> QueryOutgoing(this IVertex vertex)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Classifier in which context this element may be redefined.
        /// </summary>
        /// <param name="vertex">
        /// The subject <see cref="IVertex"/>
        /// </param>
        /// <returns>
        /// Classifier in which context this element may be redefined.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static IClassifier QueryRedefinitionContext(this IVertex vertex)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }
    }
}
