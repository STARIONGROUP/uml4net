// -------------------------------------------------------------------------------------------------
// <copyright file="ExpectedClasses.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CodeGenerator.Tests.Expected
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// provides a list of the expected Concrete classes
    /// </summary>
    public class ExpectedConcreteClasses : IEnumerable<string>
    {
        /// <summary>
        /// returns the list of class names
        /// </summary>
        /// <returns>
        /// list of class names
        /// </returns>
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Activity";
            yield return "Association";
            yield return "Connector";
            yield return "DurationConstraint";
            yield return "DurationObservation";
            yield return "ExceptionHandler";
            yield return "Expression";
            yield return "LiteralInteger";
            yield return "LiteralReal";
            yield return "LiteralUnlimitedNatural";
            yield return "OpaqueExpression";
            yield return "StateMachine";
            yield return "TimeConstraint";
        }

        /// <summary>
        /// returns the list of class names
        /// </summary>
        /// <returns>
        /// list of class names
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// provides a list of the all expected Abstract and Concrete classes
    /// </summary>
    public class ExpectedAllClasses : IEnumerable<string>
    {
        /// <summary>
        /// returns the list of class names
        /// </summary>
        /// <returns>
        /// list of class names
        /// </returns>
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Activity";
            yield return "ActivityEdge";
            yield return "Association";
            yield return "Connector";
            yield return "DurationConstraint";
            yield return "DurationObservation";
            yield return "ExceptionHandler";
            yield return "Expression";
            yield return "LiteralInteger";
            yield return "LiteralReal";
            yield return "LiteralUnlimitedNatural";
            yield return "NamedElement";
            yield return "ObjectNode";
            yield return "OpaqueExpression";
            yield return "TimeConstraint";
        }

        /// <summary>
        /// returns the list of class names
        /// </summary>
        /// <returns>
        /// list of class names
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
