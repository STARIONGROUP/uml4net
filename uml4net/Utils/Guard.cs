// -------------------------------------------------------------------------------------------------
//  <copyright file="Guard.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
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

namespace uml4net.Utils
{
    using System;
    
    /// <summary>
    /// Utility static class that provides guard conditions
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws an exception when the value is null
        /// </summary>.
        /// <param name="argument">The value to check</param>
        public static void ThrowIfNull(object argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(nameof(argument));
            }
        }

        /// <summary>Throws an exception if <paramref name="argument"/> is null or empty.</summary>
        /// <param name="argument">The string argument to validate as non-null and non-empty.</param>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> is empty.</exception>
        public static void ThrowIfNullOrEmpty(string argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(nameof(argument));
            }

            if (argument.Length == 0)
            {
                throw new ArgumentException(nameof(argument));
            }
        }
    }
}
