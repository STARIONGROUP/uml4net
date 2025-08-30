// -------------------------------------------------------------------------------------------------
//  <copyright file="TypeExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
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
    using System.Linq;

    using uml4net.CommonStructure;
    using uml4net.SimpleClassifiers;

    /// <summary>
    /// Extension methods for <see cref="IType"/> interface
    /// </summary>
    public static class TypeExtensions
    {
                /// <summary>
        /// A mapping of the known SysML value types to C# types
        /// </summary>
        private static readonly Dictionary<string, string> DefaultCSharpTypeMapping = new ()
        {
            {"Boolean", "bool"},
            {"Integer", "int"},
            {"Real", "double"},
            {"String", "string"},
            {"UnlimitedNatural", "string"},
        };

        /// <summary>
        /// A mapping of the custom SysML value types to C# types
        /// </summary>
        private static readonly Dictionary<string, string> CustomCSharpTypeMapping = new();

        /// <summary>
        /// A mapping of the known and custom SysML value types to C# types
        /// </summary>
        /// <remarks>
        /// By default, contains all items from DefaultCSharpTypeMapping
        /// </remarks>
        private static readonly Dictionary<string, string> CSharpTypeMapping =
            DefaultCSharpTypeMapping.ToDictionary(x => x.Key, x => x.Value);

        /// <summary>
        /// Adds or overwrites the C# type mappings
        /// </summary>
        /// <param name="mappings">Collection of tuples with Key and Value data to add to custom mappings, or overwrite default mappings</param>
        public static void AddOrOverwriteCSharpTypeMappings(params (string Key, string Value)[] mappings)
        {
            if (mappings == null || mappings.Length == 0 || mappings.Any(x => x.Key == null || x.Value == null))
            {
                throw new ArgumentNullException(nameof(mappings));
            }

            foreach (var kvp in mappings)
            {
                if (CustomCSharpTypeMapping.TryGetValue(kvp.Key, out var curVal))
                {
                    if (curVal != kvp.Value)
                    {
                        CustomCSharpTypeMapping[kvp.Key] = kvp.Value;
                    }
                }
                else
                {
                    CustomCSharpTypeMapping.Add(kvp.Key, kvp.Value);
                }
            }

            RecalculateCSharpTypeMapping();
        }

        /// <summary>
        /// Removes any added custom C# type mapping and resets to the default in <see cref="DefaultCSharpTypeMapping"/>
        /// </summary>
        public static void ResetCSharpTypeMappingsToDefault()
        {
            CustomCSharpTypeMapping.Clear();
            RecalculateCSharpTypeMapping();
        }

        /// <summary>
        /// Concatenates the default and custom type mappings from <see cref="CustomCSharpTypeMapping"/> and <see cref="DefaultCSharpTypeMapping"/> and stores the result in <see cref="CSharpTypeMapping"/>
        /// </summary>
        /// <remarks>
        /// If the same key exist in <see cref="DefaultCSharpTypeMapping"/> and <see cref="CustomCSharpTypeMapping"/>, the value of the <see cref="CustomCSharpTypeMapping"/> mapping will be used.
        /// </remarks>
        private static void RecalculateCSharpTypeMapping()
        {
            CSharpTypeMapping.Clear();

            foreach (var kvp in DefaultCSharpTypeMapping)
            {
                CSharpTypeMapping.Add(kvp.Key, kvp.Value);
            }

            foreach (var kvp in CustomCSharpTypeMapping)
            {
                if (CSharpTypeMapping.TryGetValue(kvp.Key, out var curVal))
                {
                    if (curVal != kvp.Value)
                    {
                        CSharpTypeMapping[kvp.Key] = kvp.Value;
                    }
                }
                else
                {
                    CSharpTypeMapping.Add(kvp.Key, kvp.Value);
                }
            }
        }

        /// <summary>
        /// Queries the C# Type name of the <see cref="IType"/>
        /// </summary>
        /// <param name="type">
        /// The <see cref="IType"/> for which the C# Type name is to be queried
        /// </param>
        /// <returns>
        /// a string representation of the C# Type name
        /// </returns>
        public static string QueryCSharpTypeName(this IType type)
        {
            var typeName = type?.Name ?? string.Empty;
            return !CSharpTypeMapping.TryGetValue(typeName, out var cSharpTypeName) ? typeName : cSharpTypeName;
        }
    }
}
