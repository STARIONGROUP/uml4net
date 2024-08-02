// -------------------------------------------------------------------------------------------------
// <copyright file="Assembler.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net
{
    using System.Collections.Generic;
    
    using POCO.CommonStructure;

    /// <summary>
    /// The purpose of the Assembler is to convert a list of DTO's into an object graph
    /// </summary>
    public class Assembler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Assembler"/> class
        /// </summary>
        public Assembler()
        { 
        }

        /// <summary>
        /// Gets the cache of <see cref="IElement"/>s
        /// </summary>
        public Dictionary<string, IElement> Cache { get; private set; } = new Dictionary<string, IElement>();

        public void Synchronize()
        { 
        }
    }
}
