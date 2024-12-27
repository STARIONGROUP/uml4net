// -------------------------------------------------------------------------------------------------
//  <copyright file="ContainerList.cs" company="Starion Group S.A.">
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

namespace uml4net.Utils
{
    using System.ComponentModel;
    using System.Collections.Generic;
    using System;

    using uml4net.CommonStructure;

    /// <summary>
    /// List Type used for the 10-25 model for classes which are part of a composition relationship
    /// </summary>
    /// <typeparam name="T">the type of <see cref="IElement"/> that this List contains</typeparam>
    public class ContainerList<T> : List<T>, IContainerList<T> where T : class, IElement
    {
        /// <summary>
        /// Backing field for the container of this <see cref="ContainerList{T}"/>
        /// </summary>
        private readonly IElement container;
        
        /// <summary>
        /// Initializes a new <see cref="ContainerList{T}"/>
        /// </summary>
        /// <typeparam name="T">the type of <see cref="IElement"/> that this List contains</typeparam>
        public ContainerList(IElement container)
        {
            this.container = container;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerList{T}"/> class
        /// </summary>
        /// <param name="containerList">
        /// The <see cref="ContainerList{T}"/> which values are copied.
        /// </param>
        /// <param name="container">
        /// The owner of this <see cref="ContainerList{T}"/>.
        /// </param>
        /// <param name="updateContaineeContainer">
        /// A value indicating whether the container of the contained items, the containees, in the provided <paramref name="containerList"/>
        /// shall be set to the provided <paramref name="container"/>. The default value = false
        /// </param>
        public ContainerList(IContainerList<T> containerList, IElement container, bool updateContaineeContainer = false) : base(containerList)
        {
            this.container = container;

            if (!updateContaineeContainer)
            {
                return;
            }
            
            foreach (var item in containerList)
            {
                item.Possessor = this.container;
            }
        }

        /// <summary>
        /// Adds a new <see cref="IElement"/> to the <see cref="List{T}"/> and assigns its <see cref="Container"/> property
        /// to this list's owner. 
        /// </summary>
        /// <remarks>
        /// The <paramref name="element"/> cannot be <c>null</c> because the <see cref="Container"/> property 
        /// requires a non-null owner to be set. Attempting to add <c>null</c> will result in an <see cref="ArgumentNullException"/>.
        /// Additionally, if the <paramref name="element"/> already exists in the list, an <see cref="InvalidOperationException"/> is thrown.
        /// </remarks>
        /// <param name="element">The new <see cref="IElement"/> to add to the list.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="element"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="element"/> already exists in the list.</exception>
        public new void Add(T element)
        {
            Guard.ThrowIfNull(element);

            element.Possessor = this.container;

            if (this.Contains(element))
            {
                throw new InvalidOperationException($"The added item already exists {element.XmiId}.");
            }

            base.Add(element);
        }

        /// <summary>
        /// Adds a collection of <see cref="IElement"/> instances to the <see cref="List{T}"/> and sets each element's 
        /// <see cref="Container"/> property to this list's owner. 
        /// </summary>
        /// <remarks>
        /// Each element in <paramref name="elements"/> must not be <c>null</c> to allow setting its <see cref="Container"/> property.
        /// Attempting to add <c>null</c> elements will result in an <see cref="ArgumentNullException"/> for each invalid entry.
        /// This method will also prevent duplicate entries by using the <see cref="Add(T)"/> method for each item.
        /// </remarks>
        /// <param name="elements">The collection of <see cref="IElement"/> instances to add to the list.</param>
        /// <exception cref="ArgumentNullException">Thrown if any element in <paramref name="elements"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if any element in <paramref name="elements"/> already exists in the list.</exception>
        public new void AddRange(IEnumerable<T> elements)
        {
            foreach (var element in elements)
            {
                this.Add(element);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IElement"/> at the specified index within the collection, and ensures that 
        /// the <see cref="Container"/> property is appropriately set when a new value is assigned.
        /// </summary>
        /// <param name="index">The zero-based index of the <see cref="IElement"/> to get or set.</param>
        /// <value>
        /// The <see cref="IElement"/> at the specified <paramref name="index"/>. 
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="index"/> is less than 0 or greater than or equal to the number of elements in the collection.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if attempting to set a <c>null</c> value.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if attempting to set a value that already exists within the collection but at a different index.
        /// </exception>
        /// <remarks>
        /// When setting an element at the specified index, the element's <see cref="Container"/> property is set to 
        /// match the container of this collection. This indexer also prevents duplicate entries by verifying that 
        /// the new value does not already exist elsewhere in the collection.
        /// </remarks>
        public new T this[int index]
        {
            get
            {
                if (index < 0 || index >= base.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"index is {index}, valid range is 0 to {this.Count - 1}");
                }

                return base[index];
            }

            set
            {
                if (index < 0 || index >= base.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"index is {index}, valid range is 0 to {this.Count - 1}");
                }

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (this.Contains(value) && base[index] != value)
                {
                    throw new InvalidOperationException($"The added item already exists {value.XmiId}.");
                }

                value.Possessor = this.container;
                base[index] = value;
            }
        }
    }
}
