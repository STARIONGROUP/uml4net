// -------------------------------------------------------------------------------------------------
// <copyright file="TypedElementExtensions.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2026 Starion Group S.A.
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
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Extension methods for the <see cref="ITypedElement"/> interface 
    /// </summary>
    public static class TypedElementExtensions
    {
                /// <summary>
        /// Queries the type-name of the <see cref="ITypedElement"/>
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// the name of the type, null for an untyped element (<c>TypedElement::type</c> is <c>[0..1]</c>)
        /// </returns>
        public static string QueryTypeName(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            return typedElement.Type?.Name;
        }

        /// <summary>
        /// Queries the name of the generated interface that types the values of the <see cref="ITypedElement"/>:
        /// <c>I</c> followed by the name of its type
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// <c>I</c> followed by the name of the type; for an untyped element (<c>TypedElement::type</c> is
        /// <c>[0..1]</c>) <c>object</c>, or <c>IElement</c> for a composite property, since the values of a composite
        /// property are owned elements
        /// </returns>
        public static string QueryInterfaceTypeName(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            if (typedElement.Type == null)
            {
                return typedElement is IProperty { IsComposite: true } ? "IElement" : "object";
            }

            return $"I{typedElement.Type.Name}";
        }

        /// <summary>
        /// Queries a value indicating whether the specified <see cref="ITypedElement"/> is a reference type
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true when the type is not a DataType; an untyped element is a reference type, its values are typed as
        /// <c>object</c> (see <see cref="QueryInterfaceTypeName"/>)
        /// </returns>
        public static bool QueryIsReferenceType(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            return typedElement.Type is not IDataType;
        }

        /// <summary>
        /// Queries whether the <see cref="ITypedElement.Type"/> is abstract or not
        /// </summary>
        /// <param name="typedElement">
        ///The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true when the type is abstract, false if not
        /// </returns>
        public static bool QueryIsTypeAbstract(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            // isAbstract is a property of Classifier (Class::isAbstract redefines it), so a DataType, an Interface,
            // an Association or a Signal can be abstract as well
            return typedElement.Type is IClassifier classifier && classifier.IsAbstract;
        }

        /// <summary>
        /// Queries a value indicating whether the specified <see cref="ITypedElement"/> type is a value type or <see cref="string"/>
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>
        /// </returns>
        public static bool QueryIsValueType(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            return typedElement.Type is IDataType;
        }
        
         /// <summary>
        /// Adds or overwrites the C# type mappings
        /// </summary>
        /// <param name="mappings">Collection of tuples with Key and Value data to add to custom mappings, or overwrite default mappings</param>
        public static void AddOrOverwriteCSharpTypeMappings(params (string Key, string Value)[] mappings)
        {
            TypeExtensions.AddOrOverwriteCSharpTypeMappings(mappings);
        }

        /// <summary>
        /// Removes any added custom C# type mapping and resets to the default in DefaultCSharpTypeMapping
        /// </summary>
        public static void ResetCSharpTypeMappingsToDefault()
        {
            TypeExtensions.ResetCSharpTypeMappingsToDefault();
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is an <see cref="IDataType"/>
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true of the type is a <see cref="IDataType"/>, false if not
        /// </returns>
        public static bool QueryIsDataType(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            return typedElement.Type is IDataType;
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is an <see cref="IEnumeration"/>
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true of the type is a <see cref="IEnumeration"/>, false if not
        /// </returns>
        public static bool QueryIsEnum(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            return typedElement.Type is IEnumeration;
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is an <see cref="IPrimitiveType"/>
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true of the type is a <see cref="IPrimitiveType"/>, false if not
        /// </returns>
        public static bool QueryIsPrimitiveType(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            return typedElement.Type is IPrimitiveType;
        }

        /// <summary>
        /// The C# names, and their .NET and tool-specific equivalents, of the boolean primitive types
        /// </summary>
        private static readonly HashSet<string> BooleanTypeNames = new(StringComparer.OrdinalIgnoreCase)
        {
            "bool", "boolean"
        };

        /// <summary>
        /// The C# names, and their .NET and tool-specific equivalents, of the integer primitive types
        /// </summary>
        private static readonly HashSet<string> IntegerTypeNames = new(StringComparer.OrdinalIgnoreCase)
        {
            "int", "uint", "long", "ulong", "short", "ushort", "byte", "sbyte", "integer",
            "int16", "int32", "int64", "uint16", "uint32", "uint64"
        };

        /// <summary>
        /// The C# names, and their .NET equivalents, of the single precision floating point primitive types
        /// </summary>
        private static readonly HashSet<string> FloatTypeNames = new(StringComparer.OrdinalIgnoreCase)
        {
            "float", "single"
        };

        /// <summary>
        /// The C# names, and their UML equivalents, of the double precision floating point primitive types
        /// </summary>
        private static readonly HashSet<string> DoubleTypeNames = new(StringComparer.OrdinalIgnoreCase)
        {
            "double", "real"
        };

        /// <summary>
        /// The C# names, and their .NET equivalents, of the decimal primitive types
        /// </summary>
        private static readonly HashSet<string> DecimalTypeNames = new(StringComparer.OrdinalIgnoreCase)
        {
            "decimal"
        };

        /// <summary>
        /// The C# names, and their .NET and tool-specific equivalents, of the date and time primitive types
        /// </summary>
        private static readonly HashSet<string> DateTimeTypeNames = new(StringComparer.OrdinalIgnoreCase)
        {
            "datetime", "date", "datetimeoffset", "dateonly"
        };

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is a <see cref="IPrimitiveType"/> whose C# type
        /// name is one of the provided <paramref name="typeNames"/>
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <param name="typeNames">
        /// The C# type names, compared case-insensitively
        /// </param>
        /// <returns>
        /// true when the type is a <see cref="IPrimitiveType"/> and its C# type name, after the configurable C# type
        /// mapping (see <see cref="AddOrOverwriteCSharpTypeMappings"/>), is one of the <paramref name="typeNames"/>
        /// </returns>
        /// <remarks>
        /// A type is a primitive type because it is a PrimitiveType, not because of its name (UML 2.5.1 defines
        /// Boolean, Integer, Real, String and UnlimitedNatural in the PrimitiveTypes package): a Class named <c>Point</c>
        /// or <c>Update</c> is neither numeric nor a date. The name is compared exactly, so that tools that export
        /// primitive types such as <c>int</c>, <c>float</c> or <c>DateTime</c> are supported without matching substrings.
        /// </remarks>
        private static bool QueryIsPrimitiveTypeNamed(ITypedElement typedElement, params HashSet<string>[] typeNames)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            if (typedElement.Type is not IPrimitiveType primitiveType)
            {
                return false;
            }

            var cSharpTypeName = primitiveType.QueryCSharpTypeName();

            return typeNames.Any(x => x.Contains(cSharpTypeName));
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is of type boolean
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if the type is a <see cref="IPrimitiveType"/> that maps to <see cref="bool"/> (UML <c>Boolean</c>),
        /// false if not
        /// </returns>
        public static bool QueryIsBool(this ITypedElement typedElement)
        {
            return QueryIsPrimitiveTypeNamed(typedElement, BooleanTypeNames);
        }

        /// <summary>
        /// Queries whether the <see cref="ITypedElement"/> Type is string
        /// </summary>
        /// <param name="typedElement">
        /// the subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if it maps, false if not
        /// </returns>
        public static bool QueryIsString(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            if (typedElement.QueryIsPrimitiveType())
            {
                return typedElement.Type.Name.Equals("string", StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is a numeric type (e.g., int, double, decimal, float, etc.)
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if the type is a <see cref="IPrimitiveType"/> that maps to an integer, floating point or decimal C#
        /// type (UML <c>Integer</c> and <c>Real</c>), false otherwise.
        /// </returns>
        public static bool QueryIsNumeric(this ITypedElement typedElement)
        {
            return QueryIsPrimitiveTypeNamed(typedElement, IntegerTypeNames, FloatTypeNames, DoubleTypeNames, DecimalTypeNames);
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is of type integer
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if the type is a <see cref="IPrimitiveType"/> that maps to an integer C# type such as <see cref="int"/>
        /// or <see cref="long"/> (UML <c>Integer</c>), false otherwise
        /// </returns>
        public static bool QueryIsInteger(this ITypedElement typedElement)
        {
            return QueryIsPrimitiveTypeNamed(typedElement, IntegerTypeNames);
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is of type float
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if the type is a <see cref="IPrimitiveType"/> that maps to <see cref="float"/>, false otherwise
        /// </returns>
        public static bool QueryIsFloat(this ITypedElement typedElement)
        {
            return QueryIsPrimitiveTypeNamed(typedElement, FloatTypeNames);
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is of type double
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if the type is a <see cref="IPrimitiveType"/> that maps to <see cref="double"/> (UML <c>Real</c>),
        /// false otherwise
        /// </returns>
        public static bool QueryIsDouble(this ITypedElement typedElement)
        {
            return QueryIsPrimitiveTypeNamed(typedElement, DoubleTypeNames);
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is of type <see cref="DateTime"/>
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if the type is a <see cref="IPrimitiveType"/> that maps to a date or time C# type such as
        /// <see cref="DateTime"/>, false otherwise
        /// </returns>
        public static bool QueryIsDateTime(this ITypedElement typedElement)
        {
            return QueryIsPrimitiveTypeNamed(typedElement, DateTimeTypeNames);
        }

        /// <summary>
        /// Queries the C# type-name of the <see cref="ITypedElement"/>
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <param name="shouldTargetInterface">Asserts that the type name should target the interface name in case of an <see cref="IClass"/></param>
        /// <returns>
        /// the C# name of the type, <c>object</c> for an untyped element (<c>TypedElement::type</c> is <c>[0..1]</c>)
        /// </returns>
        public static string QueryCSharpTypeName(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            return typedElement.Type == null ? "object" : typedElement.Type.QueryCSharpTypeName();
        }
    }
}
