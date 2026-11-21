// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions
{
    using System;
    using System.Collections.Generic;

    using uml4net.Classification;
    using uml4net.SimpleClassifiers;

    /// <summary>
    /// Extension methods for the <see cref="IParameter" /> interface 
    /// </summary>
    public static class ParameterExtensions
    {
        /// <summary>
        /// Queries the full type name which includes whether it's a <see cref="List{T}"/>
        /// </summary>
        /// <param name="parameter">
        /// the subject <see cref="IParameter"/>
        /// </param>
        /// <returns>
        /// a string representation of the type
        /// </returns>
        public static string QueryCSharpFullTypeName(this IParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            if (parameter.Type is IDataType && parameter.QueryIsEnumerable())
            {
                return $"List<{parameter.QueryCSharpTypeName() }> ";
            }

            if (parameter.QueryIsEnumerable())
            {
                return $"List<{parameter.QueryInterfaceTypeName()}> ";
            }

            if (parameter.Type is IDataType)
            {
                if (parameter.QueryIsNullable() && !parameter.Type.QueryCSharpTypeName().Equals("string"))
                {
                    return $"{parameter.QueryCSharpTypeName()}? ";
                }
                
                return $"{parameter.QueryCSharpTypeName()} ";
            }
            
            return $"{parameter.QueryInterfaceTypeName()}";
        }
    }
}
