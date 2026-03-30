// -------------------------------------------------------------------------------------------------
//  <copyright file="TypedElementExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2026 Starion Group S.A.
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
        /// the name of the type
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
        /// Queries a value indicating whether the specified <see cref="ITypedElement"/> is a reference type
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>
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

            if (typedElement.Type is IClass classifier)
            {
                return classifier.IsAbstract;
            }

            return false;
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
        /// Queries whether the type of the <see cref="ITypedElement"/> is of type boolean
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if the type is a <see cref="bool"/>, false if not
        /// </returns>
        public static bool QueryIsBool(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            return typedElement.Type?.Name?.IndexOf("bool", StringComparison.InvariantCultureIgnoreCase) >= 0;
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
        /// true if the type is a numeric type (e.g., int, double, decimal, float), false otherwise.
        /// </returns>
        public static bool QueryIsNumeric(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            if (typedElement.Type?.Name == null)
            {
                return false;
            }

            var typeName = typedElement.Type.Name.ToLowerInvariant();

            return typeName.Contains("int") ||
                   typeName.Contains("float") ||
                   typeName.Contains("double") ||
                   typeName.Contains("real") ||
                   typeName.Contains("decimal") ||
                   typeName.Contains("short") ||
                   typeName.Contains("long") ||
                   typeName.Contains("byte");
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is of type integer
        /// (contains the string "int" in its type name)
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if the type is an integer (contains the string "int" in its type name)
        /// </returns>
        public static bool QueryIsInteger(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            if (typedElement.Type?.Name == null)
            {
                return false;
            }

            var typeName = typedElement.Type?.Name?.ToLowerInvariant();
            return typeName is not null && typeName.Contains("int");
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is of type float
        /// (contains the string "single" or "float" in its type name)
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if the type is a float (contains the string "single" or "float" in its type name)
        /// </returns>
        public static bool QueryIsFloat(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            if (typedElement.Type?.Name == null)
            {
                return false;
            }

            var typeName = typedElement.Type?.Name?.ToLowerInvariant();
            return typeName is not null && (typeName.Contains("single") || typeName.Contains("float"));
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is of type double
        /// (contains the string "double" or "real" in its type name)
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if the type is a double (contains the string "double" or "real" in its type name)
        /// </returns>
        public static bool QueryIsDouble(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            if (typedElement.Type?.Name == null)
            {
                return false;
            }

            var typeName = typedElement.Type?.Name?.ToLowerInvariant();
            return typeName is not null && (typeName.Contains("double") || typeName.Contains("real"));
        }

        /// <summary>
        /// Queries whether the type of the <see cref="ITypedElement"/> is of type <see cref="DateTime"/>
        /// (contains the string "date" in its type name)
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <returns>
        /// true if the type is a DateTime (contains the string "date" in its type name)
        /// </returns>
        public static bool QueryIsDateTime(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            if (typedElement.Type?.Name == null)
            {
                return false;
            }

            var typeName = typedElement.Type?.Name?.ToLowerInvariant();
            return typeName is not null && typeName.Contains("date");
        }

        /// <summary>
        /// Queries the C# type-name of the <see cref="ITypedElement"/>
        /// </summary>
        /// <param name="typedElement">
        /// The subject <see cref="ITypedElement"/>
        /// </param>
        /// <param name="shouldTargetInterface">Asserts that the type name should target the interface name in case of an <see cref="IClass"/></param>
        /// <returns>
        /// the C# name of the type
        /// </returns>
        public static string QueryCSharpTypeName(this ITypedElement typedElement)
        {
            if (typedElement == null)
            {
                throw new ArgumentNullException(nameof(typedElement));
            }

            return typedElement.Type.QueryCSharpTypeName();
        }
    }
}
