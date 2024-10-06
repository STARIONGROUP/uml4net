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

    using uml4net.POCO.Classification;
    using uml4net.POCO.SimpleClassifiers;
    using uml4net.POCO.StructuredClassifiers;

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
            return property.DataType is IEnumeration;
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
            //return property.Upper is -1 or > 1;

            throw new NotImplementedException();
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
            if (property.Aggregation == AggregationKind.Composite)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Queries whether the <see cref="Name"/> is equal to the name of the containing <see cref="IClass"/>
        /// </summary>
        /// <param name="structuralFeature">
        /// The subject <see cref="IStructuralFeature"/>
        /// </param>
        /// <param name="class">
        /// The containing <see cref="EClass"/>
        /// </param>
        /// <returns>
        /// true when the <paramref name="structuralFeature"/> name equals the name of the containing <see cref="IClass"/>, false if not.
        /// </returns>
        public static bool QueryStructuralFeatureNameEqualsEnclosingType(this IStructuralFeature structuralFeature, IClass @class)
        {
            if (structuralFeature.Name.ToLower() == @class.Name.ToLower())
            {
                return true;
            }

            return false;
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
            throw new NotImplementedException();
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
            return property.Type.Name;
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
            return property.Lower == 0 && !property.QueryIsEnumerable();
        }
    }
}