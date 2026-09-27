// -------------------------------------------------------------------------------------------------
// <copyright file="ValueSpecificationExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using uml4net.Classification;
    using uml4net.Values;

    /// <summary>
    /// The <see cref="ValueSpecificationExtensions"/> class provides extensions methods for the <see cref="IValueSpecification"/>
    /// </summary>
    public static class ValueSpecificationExtensions
    {
        /// <summary>
        /// The text that <see cref="QueryDefaultValueAsString"/> returns when the <see cref="IValueSpecification"/> has
        /// no value that can be rendered
        /// </summary>
        private const string NoValue = "null";

        /// <summary>
        /// Queries the textual representation of the value of the <paramref name="valueSpecification"/>, as used for
        /// the default value of a property in generated code
        /// </summary>
        /// <param name="valueSpecification">
        /// The subject <see cref="IValueSpecification"/>
        /// </param>
        /// <returns>
        /// The value of a literal (a <see cref="ILiteralReal"/> in the invariant culture), the name of the
        /// instance of an <see cref="IInstanceValue"/>, the first body of an <see cref="IOpaqueExpression"/>, the
        /// notation of an <see cref="IExpression"/>, the <c>stringValue()</c> of an <see cref="IStringExpression"/>,
        /// the <c>expr</c> of an <see cref="ITimeExpression"/> or an <see cref="IDuration"/>, and <c>min..max</c> for an
        /// <see cref="IInterval"/>; the text <c>null</c> when there is no value that can be rendered
        /// </returns>
        /// <remarks>
        /// UML 2.5.1 allows any ValueSpecification as a default value (<c>Property::defaultValue</c>); tools such as
        /// Enterprise Architect export default values as OpaqueExpressions. The notation of an Expression is its
        /// symbol, followed by its operands between round parentheses and separated by commas when it has operands
        /// (clause 8.3.4).
        /// </remarks>
        public static string QueryDefaultValueAsString(this IValueSpecification valueSpecification)
        {
            if (valueSpecification == null)
            {
                throw new ArgumentNullException(nameof(valueSpecification));
            }

            switch (valueSpecification)
            {
                case ILiteralBoolean literalBoolean:
                    return literalBoolean.Value.ToString(CultureInfo.InvariantCulture).ToLower(CultureInfo.InvariantCulture);
                case ILiteralInteger literalInteger:
                    return literalInteger.Value.ToString(CultureInfo.InvariantCulture);
                case ILiteralReal literalReal:
                    return QueryRealAsString(literalReal.Value);
                case ILiteralNull:
                    return NoValue;
                case ILiteralString literalString:
                    return literalString.Value;
                case ILiteralUnlimitedNatural literalUnlimitedNatural:
                    if (literalUnlimitedNatural.Value == "*")
                    {
                        return "int.MaxValue";
                    }

                    return literalUnlimitedNatural.Value;
                case IInstanceValue instanceValue:
                    return instanceValue.Instance?.Name ?? NoValue;
                case IOpaqueExpression opaqueExpression:
                    return opaqueExpression.Body.FirstOrDefault(x => !string.IsNullOrEmpty(x)) ?? NoValue;
                case IStringExpression stringExpression:
                    return QueryStringValue(stringExpression);
                case IExpression expression:
                    return QueryExpressionAsString(expression);
                case ITimeExpression timeExpression:
                    return QueryOptionalValueAsString(timeExpression.Expr.SingleOrDefault());
                case IDuration duration:
                    return QueryOptionalValueAsString(duration.Expr.SingleOrDefault());
                case IInterval interval:
                    return interval.Min == null && interval.Max == null
                        ? NoValue
                        : $"{QueryOptionalValueAsString(interval.Min)}..{QueryOptionalValueAsString(interval.Max)}";
                default:
                    return NoValue;
            }
        }

        /// <summary>
        /// Queries the textual representation of a <see cref="double"/> in the invariant culture, using the
        /// <see cref="double"/> constants for the values that have no numeric literal
        /// </summary>
        /// <param name="value">
        /// The subject value
        /// </param>
        /// <returns>
        /// the textual representation
        /// </returns>
        private static string QueryRealAsString(double value)
        {
            if (double.IsNaN(value))
            {
                return "double.NaN";
            }

            if (double.IsPositiveInfinity(value))
            {
                return "double.PositiveInfinity";
            }

            if (double.IsNegativeInfinity(value))
            {
                return "double.NegativeInfinity";
            }

            return value.ToString("R", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Queries the textual representation of a <see cref="IValueSpecification"/> that may be null
        /// </summary>
        /// <param name="valueSpecification">
        /// The <see cref="IValueSpecification"/>, may be null
        /// </param>
        /// <returns>
        /// the result of <see cref="QueryDefaultValueAsString"/>, or the text <c>null</c> when there is no
        /// <paramref name="valueSpecification"/>
        /// </returns>
        private static string QueryOptionalValueAsString(IValueSpecification valueSpecification)
        {
            return valueSpecification == null ? NoValue : valueSpecification.QueryDefaultValueAsString();
        }

        /// <summary>
        /// Queries the notation of an <see cref="IExpression"/>: its symbol, followed by its operands between round
        /// parentheses and separated by commas when it has operands (UML 2.5.1 clause 8.3.4)
        /// </summary>
        /// <param name="expression">
        /// The subject <see cref="IExpression"/>
        /// </param>
        /// <returns>
        /// the notation, or the text <c>null</c> for an expression without symbol and operands
        /// </returns>
        private static string QueryExpressionAsString(IExpression expression)
        {
            if (expression.Operand.Count == 0)
            {
                return string.IsNullOrEmpty(expression.Symbol) ? NoValue : expression.Symbol;
            }

            return $"{expression.Symbol}({string.Join(", ", expression.Operand.Select(x => x.QueryDefaultValueAsString()))})";
        }

        /// <summary>
        /// Queries the <c>stringValue()</c> of an <see cref="IStringExpression"/>: the concatenation of the string
        /// values of its sub-expressions when it has any, otherwise of its operands
        /// </summary>
        /// <param name="stringExpression">
        /// The subject <see cref="IStringExpression"/>
        /// </param>
        /// <returns>
        /// the concatenated string value
        /// </returns>
        private static string QueryStringValue(IStringExpression stringExpression)
        {
            if (stringExpression.SubExpression.Count > 0)
            {
                return string.Concat(stringExpression.SubExpression.Select(QueryStringValue));
            }

            // ValueSpecification::stringValue() is null for everything but a LiteralString (and a StringExpression)
            return string.Concat(stringExpression.Operand.Select(x => x switch
            {
                IStringExpression nested => QueryStringValue(nested),
                ILiteralString literalString => literalString.Value,
                _ => null
            }));
        }

        /// <summary>
        /// Queries a textual representation of the language–body pairs defined
        /// by the specified <see cref="IValueSpecification"/>.
        /// </summary>
        /// <param name="valueSpecification">
        /// The <see cref="IValueSpecification"/> to query.
        /// </param>
        /// <returns>
        /// A formatted string containing one or more language–body pairs.
        /// If <paramref name="valueSpecification"/> is not an
        /// <see cref="IOpaqueExpression"/>, an empty string is returned.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method is primarily intended to support UML
        /// <see cref="IOpaqueExpression"/> values, where the expression is
        /// represented as parallel collections of <c>language</c> and
        /// <c>body</c> entries.
        /// </para>
        /// <para>
        /// The method iterates up to the maximum count of the
        /// <see cref="IOpaqueExpression.Language"/> and
        /// <see cref="IOpaqueExpression.Body"/> collections. If one collection
        /// is shorter than the other, missing entries are ignored.
        /// </para>
        /// <para>
        /// Each pair is formatted as:
        /// </para>
        /// <code>
        /// language: body
        /// </code>
        /// <para>
        /// with each pair separated by a blank line.
        /// </para>
        /// </remarks>
        public static string QueryLanguageAndBody(this IValueSpecification valueSpecification)
        {
            if (valueSpecification == null)
            {
                throw new ArgumentNullException(nameof(valueSpecification));
            }

            var result = new StringBuilder();

            if (valueSpecification is IOpaqueExpression opaqueExpression)
            {
                var maxCount = Math.Max(opaqueExpression.Language.Count, opaqueExpression.Body.Count);

                for (var i = 0; i < maxCount; i++)
                {
                    try
                    {
                        result.Append(opaqueExpression.Language[i]);
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        // do nothing
                    }

                    result.Append(": ");

                    try
                    {
                        result.AppendLine(opaqueExpression.Body[i]);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // do nothing
                    }

                    result.AppendLine();
                }
            }

            return result.ToString();
        }
    }
}
