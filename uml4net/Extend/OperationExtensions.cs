// -------------------------------------------------------------------------------------------------
// <copyright file="OperationExtensions.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Classification
{
    using System;
    using System.Linq;

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
        internal static bool QueryIsOrdered(this IOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            var returnResult = operation.QueryReturnResult();

            return returnResult?.IsOrdered ?? false;
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
        internal static bool QueryIsUnique(this IOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            var returnResult = operation.QueryReturnResult();

            return returnResult?.IsUnique ?? true;
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
        internal static int QueryLower(this IOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            var returnResult = operation.QueryReturnResult();

            return returnResult?.Lower ?? 0;
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
        internal static IType QueryType(this IOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            var returnResult = operation.QueryReturnResult();

            return returnResult?.Type;
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
        internal static string QueryUpper(this IOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            var returnResult = operation.QueryReturnResult();

            return returnResult?.Upper ?? "0";
        }

        /// <summary>
        /// Queries the <see cref="IParameter"/> of the <paramref name="operation"/> whose <see cref="IParameter.Direction"/>
        /// is <see cref="ParameterDirectionKind.Return"/>, if any.
        /// </summary>
        /// <param name="operation">
        /// The subject <see cref="IOperation"/>
        /// </param>
        /// <returns>
        /// the return-directed <see cref="IParameter"/>, or null if the <paramref name="operation"/> does not
        /// declare one.
        /// </returns>
        private static IParameter QueryReturnResult(this IOperation operation)
        {
            return operation.OwnedParameter.FirstOrDefault(x => x.Direction == ParameterDirectionKind.Return);
        }
    }
}
