// -------------------------------------------------------------------------------------------------
// <copyright file="OpaqueExpressionExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Values
{
    using System;
    using System.Linq;

    using uml4net.Classification;

    /// <summary>
    /// The <see cref="OpaqueExpressionExtensions"/> class provides extensions methods for <see cref="IOpaqueExpression"/>
    /// </summary>
    internal static class OpaqueExpressionExtensions
    {
        /// <summary>
        /// Queries If an OpaqueExpression is specified using a UML Behavior, then this refers to the single required
        /// return Parameter of that Behavior. When the Behavior completes execution, the values on this
        /// Parameter give the result of evaluating the OpaqueExpression.
        /// </summary>
        /// <param name="opaqueExpression">
        /// The subject <see cref="IOpaqueExpression"/>
        /// </param>
        /// <returns>
        /// If an OpaqueExpression is specified using a UML Behavior, then this refers to the single required
        /// return Parameter of that Behavior. When the Behavior completes execution, the values on this
        /// Parameter give the result of evaluating the OpaqueExpression.
        /// </returns>
        internal static IParameter QueryResult(this IOpaqueExpression opaqueExpression)
        {
            if (opaqueExpression == null)
            {
                throw new ArgumentNullException(nameof(opaqueExpression));
            }

            return opaqueExpression.Behavior?.OwnedParameter.FirstOrDefault();
        }
    }
}
