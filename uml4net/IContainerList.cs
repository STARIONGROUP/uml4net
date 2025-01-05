// -------------------------------------------------------------------------------------------------
//  <copyright file="IContainerList.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using uml4net.CommonStructure;

    /// <summary>
    /// The <see cref="IContainerList{T}"/> interface defines public members for a container list implementation.
    /// </summary>
    public interface IContainerList<T> : IList<T> where T : class, IElement
    {
        /// <summary>
        /// Adds a new <see cref="IElement"/> in the <see cref="List{T}"/> and sets its <see cref="Container"/> property
        /// </summary>
        /// <param name="element">the new <see cref="IElement"/> to add</param>
        new void Add(T element);

        /// <summary>
        /// Adds a <see cref="IEnumerable{T}"/> of <see cref="IElement"/> in the <see cref="List{T}"/> and sets their <see cref="Container"/> property
        /// </summary>
        /// <param name="elements">the new <see cref="IElement"/>s to add</param>
        void AddRange(IEnumerable<T> elements);

        /// <summary>
        /// Gets or sets the value of the <see cref="IElement"/> associated with the specified index.
        /// </summary>
        /// <param name="index">the index</param>
        /// <returns>The <see cref="IElement"/> with the specified index (only for get).</returns>
        new T this[int index] { get; set; }
    }
}
