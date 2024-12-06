// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
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
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using uml4net.Classification;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;
    using Utils;

    /// <summary>
    /// Extension methods for <see cref="IProperty"/> class
    /// </summary>
    public static class PropertyExtensions
    {
        /// <summary>
        /// Queries whether the type of the <see cref="IProperty"/> is an <see cref="IEnumeration"/>
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true of the type is a <see cref="IEnumeration"/>, false if not
        /// </returns>
        public static bool QueryIsEnum(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            return property.Type is IEnumeration;
        }

        /// <summary>
        /// Queries whether the type of the <see cref="IProperty"/> is an <see cref="IPrimitiveType"/>
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true of the type is a <see cref="IPrimitiveType"/>, false if not
        /// </returns>
        public static bool QueryIsPrimitiveType(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            return property.Type is IPrimitiveType;
        }

        /// <summary>
        /// Queries whether the type of the <see cref="IProperty"/> is of type boolean
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true if the type is a <see cref="bool"/>, false if not
        /// </returns>
        public static bool QueryIsBool(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            return property?.Type?.Name?.IndexOf("bool", StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        /// <summary>
        /// Queries whether the type of the <see cref="IProperty"/> is a numeric type (e.g., int, double, decimal, float, etc.)
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true if the type is a numeric type (e.g., int, double, decimal, float), false otherwise.
        /// </returns>
        public static bool QueryIsNumeric(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            if (property?.Type?.Name == null)
            {
                return false;
            }

            var typeName = property.Type.Name.ToLowerInvariant();

            return typeName.Contains("int") ||
                   typeName.Contains("float") ||
                   typeName.Contains("double") ||
                   typeName.Contains("decimal") ||
                   typeName.Contains("short") ||
                   typeName.Contains("long") ||
                   typeName.Contains("byte");
        }

        /// <summary>
        /// A mapping of the known SysML value types to C# types
        /// </summary>
        private static readonly Dictionary<string, string> CSharpTypeMapping = new ()
        {
            {"Boolean", "bool"},
            {"Integer", "int"},
            {"Real", "double"},
            {"String", "string"},
            {"UnlimitedNatural", "int"},
        };

        /// <summary>
        /// Queries the C# type-name of the <see cref="IProperty"/>
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// the C# name of the type
        /// </returns>
        public static string QueryCSharpTypeName(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            if (!CSharpTypeMapping.TryGetValue(property.QueryTypeName(), out var typeName))
            {
                return property.QueryTypeName();
            }

            return typeName;
        }

        /// <summary>
        /// Queries whether the <see cref="IProperty"/> is Enumerable
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IStructuralFeature"/>
        /// </param>
        /// <returns>
        /// true if <see cref="IStructuralFeature.Upper"/> = -1 or > 1, false if not
        /// </returns>
        public static bool QueryIsEnumerable(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            int value;

            switch (property.UpperValue.SingleOrDefault())
            {
                case ILiteralUnlimitedNatural literalUnlimitedNatural:
                    value = literalUnlimitedNatural.Value;
                    break;
                case ILiteralInteger literalInteger:
                    value = literalInteger.Value;
                    break;
                default:
                    value = 0;
                    break;
            }

            return value is -1 or > 1;
        }

        /// <summary>
        /// Queries whether the <see cref="IProperty"/> is of type containment
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// True when it is, false when not
        /// </returns>
        public static bool QueryIsContainment(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            if (property.Aggregation == AggregationKind.Composite)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Queries whether the specified <see cref="IStructuralFeature.Name"/> is equal to the name of the containing <see cref="IClass"/>
        /// </summary>
        /// <param name="structuralFeature">
        /// The subject <see cref="IStructuralFeature"/>
        /// </param>
        /// <param name="class">
        /// The containing <see cref="IClass"/>
        /// </param>
        /// <returns>
        /// true when the <paramref name="structuralFeature"/> name equals the name of the containing <see cref="IClass"/>, false if not.
        /// </returns>
        public static bool QueryStructuralFeatureNameEqualsEnclosingType(this IStructuralFeature structuralFeature, IClass @class)
        {
            Guard.ThrowIfNull(structuralFeature);
            Guard.ThrowIfNull(@class);

            return string.Equals(structuralFeature.Name, @class.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Queries whether the <see cref="IProperty"/> is has a default value
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true when the <see cref="IProperty"/> has a default value
        /// </returns>
        public static bool QueryHasDefaultValue(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            return property.DefaultValue != null;
        }

        /// <summary>
        /// Queries the default value of a property and returns it as a string
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// the string representation of the default value
        /// </returns>
        public static string QueryDefaultValueAsString(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            var valueSpecification = property.DefaultValue.FirstOrDefault();

            return valueSpecification == null ? "null" : valueSpecification.QueryDefaultValueAsString();
        }

        /// <summary>
        /// Queries the type-name of the <see cref="IProperty"/>
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// the name of the type
        /// </returns>
        public static string QueryTypeName(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            return property.Type?.Name;
        }

        /// <summary>
        /// Queries the full type name which includes whether it's a <see cref="List{T}"/>
        /// <see cref="IContainerList{T}"/>
        /// </summary>
        /// <param name="property">
        /// the subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// a string representation of the type
        /// </returns>
        public static string QueryCSharpFullTypeName(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            if (property.Type is IDataType && property.QueryIsEnumerable() && !property.QueryIsContainment())
            {
                return $"List<{property.QueryCSharpTypeName() }> ";
            }

            if (property.QueryIsEnumerable() && !property.QueryIsContainment())
            {
                return $"List<I{property.QueryTypeName()}> ";
            }

            if (property.QueryIsContainment())
            {
                return $"IContainerList<I{property.QueryTypeName()}> ";
            }
            
            if (property.Type is IDataType)
            {
                return $"{property.QueryCSharpTypeName()} ";
            }
            
            return $"I{property.QueryTypeName()}";
        }

        /// <summary>
        /// Queries a value indicating whether the specified <see cref="IProperty"/> is a reference type
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>
        /// </returns>
        public static bool QueryIsReferenceProperty(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            return property.Type is not IDataType;
        }

        /// <summary>
        /// Queries a value indicating whether the specified <see cref="IProperty"/> type is a value type or <see cref="string"/>
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>
        /// </returns>
        public static bool QueryIsValueProperty(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            return property.Type is IDataType;
        }

        /// <summary>
        /// Queries whether the <see cref="IProperty"/> is nullable
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true if <see cref="IProperty.Lower"/> = 0, false if not
        /// </returns>
        public static bool QueryIsNullable(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            return property.Lower == 0 && !property.QueryIsEnumerable();
        }

        /// <summary>
        /// Queries the Upper value of a <see cref="IProperty"/>
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// a string representation of the Upper value 
        /// </returns>
        public static string QueryUpperValue(this IProperty property)
        {
            Guard.ThrowIfNull(property);

            if (property.Upper == int.MaxValue)
            {
                return "*";
            }

            return property.Upper.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Asserts whether the <paramref name="property"/> is redefined in the context of the provided <see cref="IClass"/>
        /// </summary>
        /// <param name="property">
        /// the subject <see cref="IProperty"/>
        /// </param>
        /// <param name="context">
        /// The <see cref="IClass"/> in whose context the redefinition is to be asserted
        /// </param>
        /// <param name="redefinedByProperty">
        /// The redefined <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true when the property is redefined, false if not
        /// </returns>
        public static bool TryQueryRedefinedByProperty(this IProperty property, IClass context, out IProperty redefinedByProperty)
        {
            Guard.ThrowIfNull(property);
            Guard.ThrowIfNull(context);

            var properties = context.QueryAllProperties();

            foreach (var prop in properties)
            {
                if (prop.RedefinedProperty.Any(x => x.XmiId == property.XmiId))
                {
                    redefinedByProperty = prop;
                    return true;
                }
            }

            redefinedByProperty = null;
            return false;
        }
    }
}
