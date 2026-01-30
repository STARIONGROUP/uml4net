// -------------------------------------------------------------------------------------------------
//  <copyright file="ValueSpecificationExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions
{
    using System;
    using System.Globalization;
    using System.Text;

    using uml4net.Classification;
    using uml4net.Values;

    /// <summary>
    /// The <see cref="ValueSpecificationExtensions"/> class provides extensions methods for the <see cref="IValueSpecification"/>
    /// </summary>
    public static class ValueSpecificationExtensions
    {
        /// <summary>
        /// Queries the 
        /// </summary>
        /// <param name="valueSpecification"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
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
                case ILiteralNull:
                    return "null";
                case ILiteralString literalString:
                    return literalString.Value;
                case ILiteralUnlimitedNatural literalUnlimitedNatural:

                    if (literalUnlimitedNatural.Value == "*")
                    {
                        return "int.MaxValue";
                    }
                    
                    return literalUnlimitedNatural.Value;
                case IInstanceValue instanceValue:
                    return instanceValue.Instance.Name;
                default:
                    throw new NotSupportedException($"The {valueSpecification.GetType()} is not supported");
            }
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
