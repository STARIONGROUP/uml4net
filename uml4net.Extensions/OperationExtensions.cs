// -------------------------------------------------------------------------------------------------
// <copyright file="OperationExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2022-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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

        /// <summary>
        /// Queries the textual body of the <c>bodyCondition</c> of the <paramref name="operation"/>
        /// </summary>
        /// <param name="operation">
        /// the subject <see cref="IOperation"/>
        /// </param>
        /// <returns>
        /// the result of <see cref="ConstraintExtensions.QueryConstraintBody"/> for the body condition;
        /// <see cref="string.Empty"/> when the <paramref name="operation"/> has no body condition
        /// </returns>
        /// <remarks>
        /// <c>Operation::bodyCondition</c> is a [0..1] composite that subsets <c>Namespace::ownedRule</c> of the
        /// operation itself in UML 2.5.1; it is never one of the rules owned by the owning classifier.
        /// </remarks>
        public static string QueryBodyConditionText(this IOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return operation.BodyCondition.FirstOrDefault()?.QueryConstraintBody() ?? string.Empty;
        }
    }
}
