// -------------------------------------------------------------------------------------------------
// <copyright file="OperationExtensions.cs" company="Starion Group S.A.">
// 
//   Copyright 2022-2026 Starion Group S.A.
// 
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions
{
    using System;
    using System.Linq;

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Extensions class for the <see cref="IOperation"/> interface
    /// </summary>
    public static class OperationExtensions
    {
        /// <summary>
        /// Asserts whether the <paramref name="operation"/> is redefined in the context of the provided <see cref="IClass"/>
        /// </summary>
        /// <param name="operation">
        /// the subject <see cref="IOperation"/>
        /// </param>
        /// <param name="context">
        /// The <see cref="IClass"/> in whose context the redefinition is to be asserted
        /// </param>
        /// <param name="redefinedByOperation">
        /// The redefined <see cref="IOperation"/>
        /// </param>
        /// <returns>
        /// true when the operation is redefined, false if not
        /// </returns>
        public static bool TryQueryRedefinedByOperation(this IOperation operation, IClass context, out IOperation redefinedByOperation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            redefinedByOperation = context.QueryAllOperations()
                .FirstOrDefault(op => op.RedefinedOperation.Any(x => x.XmiId == operation.XmiId));

            return redefinedByOperation != null;
        }
    }
}
