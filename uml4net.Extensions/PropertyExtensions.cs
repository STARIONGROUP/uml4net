// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyExtensions.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;

    /// <summary>
    /// Extension methods for <see cref="IProperty"/> class
    /// </summary>
    public static class PropertyExtensions
    {
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
        /// Queries whether the type of the <see cref="IProperty"/> is an <see cref="IDataType"/>
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true of the type is a <see cref="IDataType"/>, false if not
        /// </returns>
        public static bool QueryIsDataType(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.Type is IDataType;
        }

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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.Type?.Name?.IndexOf("bool", StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        /// <summary>
        /// Queries whether the <see cref="IProperty"/> Type is string
        /// </summary>
        /// <param name="property">
        /// the subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true if it maps, false if not
        /// </returns>
        public static bool QueryIsString(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.QueryIsPrimitiveType())
            {
                return property.Type.Name.Equals("string", StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.Type?.Name == null)
            {
                return false;
            }

            var typeName = property.Type.Name.ToLowerInvariant();

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
        /// Queries whether the type of the <see cref="IProperty"/> is of type integer
        /// (contains the string "int" in its type name)
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true if the type is an integer (contains the string "int" in its type name)
        /// </returns>
        public static bool QueryIsInteger(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.Type?.Name == null)
            {
                return false;
            }

            var typeName = property.Type?.Name?.ToLowerInvariant();
            return typeName is not null && typeName.Contains("int");
        }

        /// <summary>
        /// Queries whether the type of the <see cref="IProperty"/> is of type float
        /// (contains the string "single" or "float" in its type name)
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true if the type is a float (contains the string "single" or "float" in its type name)
        /// </returns>
        public static bool QueryIsFloat(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.Type?.Name == null)
            {
                return false;
            }

            var typeName = property.Type?.Name?.ToLowerInvariant();
            return typeName is not null && (typeName.Contains("single") || typeName.Contains("float"));
        }

        /// <summary>
        /// Queries whether the type of the <see cref="IProperty"/> is of type double
        /// (contains the string "double" or "real" in its type name)
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true if the type is a double (contains the string "double" or "real" in its type name)
        /// </returns>
        public static bool QueryIsDouble(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.Type?.Name == null)
            {
                return false;
            }

            var typeName = property.Type?.Name?.ToLowerInvariant();
            return typeName is not null && (typeName.Contains("double") || typeName.Contains("real"));
        }

        /// <summary>
        /// Queries whether the type of the <see cref="IProperty"/> is of type <see cref="DateTime"/>
        /// (contains the string "date" in its type name)
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true if the type is a DateTime (contains the string "date" in its type name)
        /// </returns>
        public static bool QueryIsDateTime(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.Type?.Name == null)
            {
                return false;
            }

            var typeName = property.Type?.Name?.ToLowerInvariant();
            return typeName is not null && typeName.Contains("date");
        }

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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.Type.QueryCSharpTypeName();
        }

        /// <summary>
        /// Queries whether the <see cref="IProperty"/> is Enumerable
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IStructuralFeature"/>
        /// </param>
        /// <returns>
        /// true if IStructuralFeature.Upper = -1 or > 1, false if not
        /// </returns>
        public static bool QueryIsEnumerable(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            int value;

            switch (property.UpperValue.SingleOrDefault())
            {
                case ILiteralUnlimitedNatural literalUnlimitedNatural:
                    value = literalUnlimitedNatural.Value == "*" ? int.MaxValue : int.Parse(literalUnlimitedNatural.Value, CultureInfo.InvariantCulture);
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
        /// Queries whether the specified IStructuralFeature.Name is equal to the name of the containing <see cref="IClass"/>
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
            if (structuralFeature == null)
            {
                throw new ArgumentNullException(nameof(structuralFeature));
            }

            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.Type is IDataType && property.QueryIsEnumerable() && !property.IsComposite)
            {
                return $"List<{property.QueryCSharpTypeName() }> ";
            }

            if (property.QueryIsEnumerable() && !property.IsComposite)
            {
                return $"List<I{property.QueryTypeName()}> ";
            }

            if (property.IsComposite)
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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.Type is not IDataType;
        }

        /// <summary>
        /// Queries whether the <see cref="ITypedElement.Type"/> is abstract or not
        /// </summary>
        /// <param name="property">
        ///The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true when the type is abstract, false if not
        /// </returns>
        public static bool QueryIsTypeAbstract(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.Type is IClass classifier)
            {
                return classifier.IsAbstract;
            }

            return false;
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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.Type is IDataType;
        }

        /// <summary>
        /// Queries whether the <see cref="IProperty"/> is nullable
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true if IProperty.Lower = 0, false if not
        /// </returns>
        public static bool QueryIsNullable(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.Lower == 0 && !property.QueryIsEnumerable();
        }

        /// <summary>
        /// Asserts that the current <see cref="IProperty" /> is C# nullable and not a string primitive 
        /// </summary>
        /// <param name="property">
        /// The <see cref="IProperty"/> to assert
        /// </param>
        /// <returns>
        /// True is the <see cref="IProperty"/> is C# nullable and not a string
        /// </returns>
        public static bool QueryIsNullableAndNotString(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.QueryIsNullable() && property.QueryCSharpTypeName() != "string";
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
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            redefinedByProperty = context.QueryAllProperties()
                .FirstOrDefault(prop => prop.RedefinedProperty.Any(x => x.XmiId == property.XmiId));

            return redefinedByProperty != null;
        }

        /// <summary>
        /// Queries whether the property is a redefined property. A redefined property redefines another property
        /// </summary>
        /// <param name="property">
        /// the subject <see cref="IProperty"/>
        /// </param>
        /// <param name="allClasses">
        /// a readonly list of <see cref="IClass"/> that may contain a <see cref="IClass"/>
        /// that may redefine the subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true when the <see cref="IProperty"/> is redefined, false if not
        /// </returns>
        public static bool QueryHasBeenRedefined(this IProperty property, IReadOnlyList<IClass> allClasses)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (allClasses == null)
            {
                throw new ArgumentNullException(nameof(allClasses));
            }

            foreach (var @class in allClasses)
            {
                if (property.Owner != @class)
                {
                    var redefinedByProperty = @class.QueryAllProperties()
                        .FirstOrDefault(prop => prop.RedefinedProperty.Any(x => x.XmiId == property.XmiId));

                    if (redefinedByProperty != null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Queries whether the property has been redefined by other properties
        /// </summary>
        /// <param name="property">
        /// the subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true when the <see cref="IProperty"/> is redefined, false if not
        /// </returns>
        public static bool QueryIsRedefined(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.RedefinedProperty.Any();
        }

        /// <summary>
        /// Queries whether the <see cref="Property"/> is a scalar
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="Property"/>
        /// </param>
        /// <returns>
        /// true if <see cref="IProperty.Lower"/> and <see cref="IProperty.Upper"/> = 1, false if not
        /// </returns>
        public static bool QueryIsScalar(this IProperty property)
        {
            return property.Lower == 1 && property.Upper == "1";
        }

        /// <summary>
        /// Queries whether the property is subsetted
        /// </summary>
        /// <param name="property">
        /// the subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true when the <see cref="IProperty"/> is subsetted, false if not
        /// </returns>
        public static bool QueryIsSubsetted(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.SubsettedProperty.Any();
        }

        /// <summary>
        /// Queries whether the property is a contained property, meaning
        /// that it is on the opposite of a property where <see cref="AggregationKind"/>
        /// is equal to <see cref="AggregationKind.Composite"/>
        /// </summary>
        /// <param name="property">
        ///  the subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true when the property is contained, false if not
        /// </returns>
        public static bool QueryIsContained(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.Opposite != null && property.Opposite.IsComposite)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifies that the current defined Default Value set is not the default C# one
        /// </summary>
        /// <param name="property">The <see cref="IProperty"/> to check the default value</param>
        /// <returns>True if the defined defaultValue within the model is different the default C# one</returns>
        public static bool QueryIsDefaultValueDifferentThanDefault(this IProperty property)
        {
            var defaultValue = property.QueryDefaultValueAsString();

            if (defaultValue == "null")
            {
                return false;
            }
            
            var valueSpecification = property.DefaultValue.FirstOrDefault();

            return valueSpecification switch
            {
                ILiteralInteger or ILiteralReal => defaultValue != "0",
                ILiteralBoolean => defaultValue != "false",
                ILiteralString or ILiteralUnlimitedNatural => !string.IsNullOrEmpty(defaultValue),
                _ => false
            };
        }

        /// <summary>
        /// Queries whether the property is a part of a Many-to-Many association
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/> that is to be queried
        /// </param>
        /// <returns>
        /// True when part of a Many-to-Many, false if not
        /// </returns>
        /// <remarks>
        /// NOTE 1: In case a reference property is defined on a class as an owned attribute not
        /// using an association AND it has a multiplicity upper-value larger than 1 we assume it
        /// takes part in a many-to-many relationship
        /// NOTE 2: When the property is part of an association (binary relationship) and in case the
        /// upper value is larger than 1 on both ends, this property takes part in a many-to-many
        /// relationship
        /// </remarks>
        public static bool QueryIsMemberOfManyToMany(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            // only reference types can be part of a many-to-many relationship
            if (property.QueryIsDataType())
            {
                return false;
            }

            var thisUpperValue = property.QueryUpperValue();

            // in case a reference property is defined on a class as an owned attribute not
            // using an association AND it has a multiplicity upper-value larger than 1 we assume it
            // takes part in a many-to-many relationship
            if (thisUpperValue > 1 && property.Opposite == null)
            {
                return true;
            }

            // When the property is part of an association (binary relationship) and in case the
            // upper value is larger than 1 on both ends, this property takes part in a many-to-many
            // relationship
            var oppositeUpperValue = property.Opposite?.QueryUpperValue();

            if (thisUpperValue > 1 && oppositeUpperValue.HasValue && oppositeUpperValue.Value > 1)
            {
                return true;
            }

            return false;
        }
    }
}
