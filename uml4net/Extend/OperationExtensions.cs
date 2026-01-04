// -------------------------------------------------------------------------------------------------
//  <copyright file="OperationExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
{
    using System;
    
    using uml4net.CommonStructure;
    using uml4net.Values;

    /// <summary>
    /// The <see cref="OperationExtensions"/> class provides extensions methods for <see cref="IOperation"/>
    /// </summary>
    internal static class OperationExtensions
    {
        /// <summary>
        /// Queries whether the return parameter is ordered or not, if present.  This information is derived
        /// from the return result for this Operation.
        /// </summary>
        /// <param name="operation">
        /// The subject <see cref="IOperation"/>
        /// </param>
        /// <returns>
        /// whether the return parameter is ordered or not, if present.  This information is derived
        /// from the return result for this Operation.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static bool QueryIsOrdered(this IOperation operation)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries whether the return parameter is unique or not, if present. This information is derived
        /// from the return result for this Operation.
        /// </summary>
        /// <param name="operation">
        /// The subject <see cref="IOperation"/>
        /// </param>
        /// <returns>
        /// whether the return parameter is unique or not, if present. This information is derived
        /// from the return result for this Operation.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static bool QueryIsUnique(this IOperation operation)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries the lower multiplicity of the return parameter, if present. This information is derived
        /// from the return result for this Operation.
        /// </summary>
        /// <param name="operation">
        /// The subject <see cref="IOperation"/>
        /// </param>
        /// <returns>
        /// the lower multiplicity of the return parameter, if present. This information is derived
        /// from the return result for this Operation.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static int QueryLower(this IOperation operation)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries The return type of the operation, if present. This information is derived from the return result for
        /// this Operation.
        /// </summary>
        /// <param name="operation">
        /// The subject <see cref="IOperation"/>
        /// </param>
        /// <returns>
        /// The return type of the operation, if present. This information is derived from the return result for
        /// this Operation.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static IType QueryType(this IOperation operation)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries The upper multiplicity of the return parameter, if present. This information is derived from the
        /// return result for this Operation.
        /// </summary>
        /// <param name="operation">
        /// The subject <see cref="IOperation"/>
        /// </param>
        /// <returns>
        /// The upper multiplicity of the return parameter, if present. This information is derived from the
        /// return result for this Operation.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static string QueryUpper(this IOperation operation)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }
    }
}
