// -------------------------------------------------------------------------------------------------
// <copyright file="ConstraintExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions
{
    using System;
    using System.Linq;

    using uml4net.CommonStructure;
    using uml4net.Values;

    /// <summary>
    /// The <see cref="ConstraintExtensions"/> class provides extensions methods for the <see cref="IConstraint"/>
    /// </summary>
    public static class ConstraintExtensions
    {
        /// <summary>
        /// Queries the textual body of the <see cref="IOpaqueExpression"/> that is the specification of the
        /// <paramref name="constraint"/>
        /// </summary>
        /// <param name="constraint">
        /// The subject <see cref="IConstraint"/>
        /// </param>
        /// <returns>
        /// the bodies of the <see cref="IOpaqueExpression"/> joined with <c>\n</c>, with <c>\r\n</c> normalized to
        /// <c>\n</c> and trimmed; <see cref="string.Empty"/> when the specification is not an
        /// <see cref="IOpaqueExpression"/> or when the <paramref name="constraint"/> has no specification
        /// </returns>
        /// <remarks>
        /// <c>Constraint::specification</c> is a [1..1] composite in UML 2.5.1, held in a container list by uml4net;
        /// a model that is not well-formed may lack it.
        /// </remarks>
        public static string QueryConstraintBody(this IConstraint constraint)
        {
            if (constraint == null)
            {
                throw new ArgumentNullException(nameof(constraint));
            }

            var expression = constraint.Specification.OfType<IOpaqueExpression>().FirstOrDefault();

            if (expression == null)
            {
                return string.Empty;
            }

            return string.Join("\n", expression.Body).Replace("\r\n", "\n").Trim();
        }
    }
}
