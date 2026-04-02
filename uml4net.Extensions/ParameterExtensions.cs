// -------------------------------------------------------------------------------------------------
//  <copyright file="ParameterExtensions.cs" company="Starion Group S.A.">
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
                return $"List<I{parameter.QueryTypeName()}> ";
            }

            if (parameter.Type is IDataType)
            {
                if (parameter.QueryIsNullable() && !parameter.Type.QueryCSharpTypeName().Equals("string"))
                {
                    return $"{parameter.QueryCSharpTypeName()}? ";
                }
                
                return $"{parameter.QueryCSharpTypeName()} ";
            }
            
            return $"I{parameter.QueryTypeName()}";
        }
    }
}
