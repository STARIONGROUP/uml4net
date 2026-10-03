// -------------------------------------------------------------------------------------------------
// <copyright file="TaggedValueConverter.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Xml;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Profiling;
    using uml4net.SimpleClassifiers;

    /// <summary>
    /// Converts the raw values of a <see cref="TaggedValue"/> to typed values according to the type of the stereotype
    /// property, and typed values back to their XMI representation
    /// </summary>
    public static class TaggedValueConverter
    {
        /// <summary>
        /// The serialization of the unlimited value of an <c>UnlimitedNatural</c>
        /// </summary>
        private const string Unlimited = "*";

        /// <summary>
        /// Converts the <see cref="TaggedValue.RawValues"/> of the provided <see cref="TaggedValue"/> according to the type of
        /// the provided stereotype <see cref="IProperty"/>
        /// </summary>
        /// <param name="property">
        /// The property of the stereotype that the tagged value is a value of
        /// </param>
        /// <param name="taggedValue">
        /// The <see cref="TaggedValue"/> whose raw values are converted
        /// </param>
        /// <param name="resolveReference">
        /// Resolves a reference, an <c>xmi:idref</c> or an <c>href</c>, to the referenced <see cref="IXmiElement"/>; returns
        /// null when it cannot be resolved
        /// </param>
        /// <param name="values">
        /// The typed values: a <c>bool</c>, an <c>int</c>, a <c>double</c> or a <c>string</c> for a primitive type, an
        /// <see cref="IEnumerationLiteral"/> for an enumeration, and an <see cref="IXmiElement"/> for a reference
        /// </param>
        /// <param name="isReference">
        /// A value indicating whether the property is a reference to elements
        /// </param>
        /// <returns>
        /// true when every raw value could be converted, false otherwise, in which case <paramref name="values"/> is empty
        /// </returns>
        public static bool TryConvert(IProperty property, TaggedValue taggedValue, Func<string, IXmiElement> resolveReference, out List<object> values, out bool isReference)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (taggedValue == null)
            {
                throw new ArgumentNullException(nameof(taggedValue));
            }

            if (resolveReference == null)
            {
                throw new ArgumentNullException(nameof(resolveReference));
            }

            values = [];
            isReference = false;

            var type = property.Type;

            switch (type)
            {
                case null:
                    return false;
                case IPrimitiveType primitiveType:
                    foreach (var rawValue in taggedValue.RawValues)
                    {
                        if (!TryConvertPrimitive(primitiveType.Name, rawValue, out var value))
                        {
                            values.Clear();
                            return false;
                        }

                        values.Add(value);
                    }

                    return true;
                case IEnumeration enumeration:
                    foreach (var rawValue in taggedValue.RawValues)
                    {
                        var literal = enumeration.OwnedLiteral.FirstOrDefault(x => x.Name == rawValue);

                        if (literal == null)
                        {
                            values.Clear();
                            return false;
                        }

                        values.Add(literal);
                    }

                    return true;
                case IDataType:
                    // an instance of a structured data type is not a reference and is not supported
                    return false;
                default:
                    isReference = true;

                    // XMI 2.5.1 clause 9.5.2: references serialized as an attribute are separated by spaces
                    var references = taggedValue.IsReadAsAttribute
                        ? taggedValue.RawValues.SelectMany(x => x.Split([' ', '\t', '\r', '\n'], StringSplitOptions.RemoveEmptyEntries))
                        : taggedValue.RawValues;

                    foreach (var reference in references)
                    {
                        var element = resolveReference(reference);

                        if (element == null)
                        {
                            values.Clear();
                            return false;
                        }

                        values.Add(element);
                    }

                    return true;
            }
        }

        /// <summary>
        /// Formats a typed value that is not a reference to its XMI representation
        /// </summary>
        /// <param name="value">
        /// The value: a <c>bool</c>, a number, a <c>string</c> or an <see cref="INamedElement"/> such as an
        /// <see cref="IEnumerationLiteral"/>
        /// </param>
        /// <param name="property">
        /// The property of the stereotype that the value is a value of, may be null; for an <c>UnlimitedNatural</c>
        /// property <see cref="int.MaxValue"/> is formatted as <c>*</c>
        /// </param>
        /// <returns>
        /// The XMI representation of the value
        /// </returns>
        public static string Format(object value, IProperty property)
        {
            switch (value)
            {
                case null:
                    return string.Empty;
                case bool booleanValue:
                    return XmlConvert.ToString(booleanValue);
                case int integerValue when integerValue == int.MaxValue && property?.Type?.Name == "UnlimitedNatural":
                    return Unlimited;
                case int integerValue:
                    return XmlConvert.ToString(integerValue);
                case long longValue:
                    return XmlConvert.ToString(longValue);
                case double doubleValue:
                    return XmlConvert.ToString(doubleValue);
                case float floatValue:
                    return XmlConvert.ToString(floatValue);
                case decimal decimalValue:
                    return XmlConvert.ToString(decimalValue);
                case INamedElement namedElement:
                    return namedElement.Name;
                default:
                    return Convert.ToString(value, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Converts a raw value to the value of a primitive type, identified by its name
        /// </summary>
        /// <param name="primitiveTypeName">
        /// The name of the primitive type: <c>Boolean</c>, <c>Integer</c>, <c>Real</c> and <c>UnlimitedNatural</c> are
        /// converted, any other primitive type, such as <c>String</c>, is kept as a string
        /// </param>
        /// <param name="rawValue">
        /// The raw value
        /// </param>
        /// <param name="value">
        /// The converted value
        /// </param>
        /// <returns>
        /// true when the raw value could be converted
        /// </returns>
        private static bool TryConvertPrimitive(string primitiveTypeName, string rawValue, out object value)
        {
            value = null;

            try
            {
                switch (primitiveTypeName)
                {
                    case "Boolean":
                        value = XmlConvert.ToBoolean(rawValue);
                        return true;
                    case "Integer":
                        value = XmlConvert.ToInt32(rawValue);
                        return true;
                    case "Real":
                        value = XmlConvert.ToDouble(rawValue);
                        return true;
                    case "UnlimitedNatural":
                        value = rawValue == Unlimited ? int.MaxValue : XmlConvert.ToInt32(rawValue);
                        return true;
                    default:
                        value = rawValue;
                        return true;
                }
            }
            catch (Exception exception) when (exception is FormatException || exception is OverflowException)
            {
                return false;
            }
        }
    }
}
