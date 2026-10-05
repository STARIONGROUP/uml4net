// -------------------------------------------------------------------------------------------------
// <copyright file="ContainerList.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using uml4net.CommonStructure;

    /// <summary>
    /// List Type used for the 10-25 model for classes which are part of a composition relationship
    /// </summary>
    /// <typeparam name="T">the type of <see cref="IElement"/> that this List contains</typeparam>
    /// <remarks>
    /// An element is owned by one container: adding an element that is held by the composite list of another container
    /// moves it, it is removed from the lists of that other container. An element can be held by several composite lists
    /// of the same container, when a composite property subsets another one (for example <c>Operation::precondition</c>
    /// subsets <c>Namespace::ownedRule</c>); removing it from one of them keeps it owned by the container.
    /// Every way of changing the list, including the non-generic <see cref="IList"/> members, maintains the containment.
    /// </remarks>
    public class ContainerList<T> : List<T>, IContainerList<T>, IList, IContainerListMembership where T : class, IElement
    {
        /// <summary>
        /// Backing field for the container of this <see cref="ContainerList{T}"/>
        /// </summary>
        private readonly IElement container;

        /// <summary>
        /// Initializes a new <see cref="ContainerList{T}"/>
        /// </summary>
        /// <param name="container">
        /// the type of <see cref="IElement"/> that this List contains
        /// </param>
        public ContainerList(IElement container)
        {
            this.container = container;
        }

        /// <summary>
        /// The action that sets the owner end of the contained element, the opposite of the composite property this
        /// <see cref="ContainerList{T}"/> is the value of, to the container; null when there is no such end
        /// </summary>
        private readonly Action<T> attachOwnerEnd;

        /// <summary>
        /// The action that clears the owner end of an element that is no longer contained; null when there is no such end
        /// </summary>
        private readonly Action<T> detachOwnerEnd;

        /// <summary>
        /// Initializes a new <see cref="ContainerList{T}"/> that keeps the owner end of the contained elements in
        /// sync with the containment, for example <c>Generalization::specific</c> for the elements of
        /// <c>Classifier::generalization</c>. An XMI document does not serialize the owner end of a composite
        /// association, it is implied by the nesting of the XML elements.
        /// </summary>
        /// <param name="container">
        /// The <see cref="IElement"/> that owns this <see cref="ContainerList{T}"/>
        /// </param>
        /// <param name="attachOwnerEnd">
        /// The action that sets the owner end of an element that is added to the <paramref name="container"/>
        /// </param>
        /// <param name="detachOwnerEnd">
        /// The action that clears the owner end of an element that is removed from the <paramref name="container"/>
        /// </param>
        public ContainerList(IElement container, Action<T> attachOwnerEnd, Action<T> detachOwnerEnd)
        {
            this.container = container;
            this.attachOwnerEnd = attachOwnerEnd;
            this.detachOwnerEnd = detachOwnerEnd;
        }

        /// <summary>
        /// Initializes a new <see cref="ContainerList{T}"/> that holds the value of a composite property whose
        /// multiplicity has a bounded upper value, for example <c>Constraint::specification [1..1]</c>: adding a value
        /// beyond <paramref name="upperBound"/> throws an <see cref="InvalidOperationException"/>
        /// </summary>
        /// <param name="container">
        /// The <see cref="IElement"/> that owns this <see cref="ContainerList{T}"/>
        /// </param>
        /// <param name="propertyName">
        /// The qualified name of the composite property, for example <c>Constraint::specification</c>, used in the
        /// message of the exception
        /// </param>
        /// <param name="upperBound">
        /// The upper value of the multiplicity of the composite property
        /// </param>
        /// <param name="attachOwnerEnd">
        /// The action that sets the owner end of an element that is added to the <paramref name="container"/>, if any
        /// </param>
        /// <param name="detachOwnerEnd">
        /// The action that clears the owner end of an element that is removed from the <paramref name="container"/>, if any
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="upperBound"/> is less than 1
        /// </exception>
        public ContainerList(IElement container, string propertyName, int upperBound, Action<T> attachOwnerEnd = null, Action<T> detachOwnerEnd = null)
        {
            if (upperBound < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(upperBound), $"the upper bound is {upperBound}, it shall be at least 1");
            }

            this.container = container;
            this.propertyName = propertyName;
            this.UpperBound = upperBound;
            this.attachOwnerEnd = attachOwnerEnd;
            this.detachOwnerEnd = detachOwnerEnd;
        }

        /// <summary>
        /// The qualified name of the composite property that this <see cref="ContainerList{T}"/> is the value of, if known
        /// </summary>
        private readonly string propertyName;

        /// <summary>
        /// Gets the maximum number of elements that this <see cref="ContainerList{T}"/> holds, the upper value of the
        /// multiplicity of its composite property; <see cref="int.MaxValue"/> when it is unbounded
        /// </summary>
        public int UpperBound { get; } = int.MaxValue;

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
            if (containerList == null)
            {
                throw new ArgumentNullException(nameof(containerList));
            }

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            this.container = container;

            if (!updateContaineeContainer)
            {
                return;
            }
            
            foreach (var item in containerList)
            {
                item.Possessor = this.container;
                ContainerListMembership.Register(item, this);
            }
        }

        /// <summary>
        /// Gets the <see cref="IElement"/> that owns this list
        /// </summary>
        IElement IContainerListMembership.Container => this.container;

        /// <summary>
        /// Adds a new <see cref="IElement"/> to the <see cref="List{T}"/> and assigns its <see cref="Container"/> property
        /// to this list's owner. 
        /// </summary>
        /// <remarks>
        /// The <paramref name="element"/> cannot be <c>null</c> because the <see cref="Container"/> property
        /// requires a non-null owner to be set. Attempting to add <c>null</c> will result in an <see cref="ArgumentNullException"/>.
        /// Additionally, if the <paramref name="element"/> already exists in the list, an <see cref="InvalidOperationException"/> is thrown.
        /// An <paramref name="element"/> held by the composite list of another container is moved: it is removed from
        /// the lists of that other container.
        /// </remarks>
        /// <param name="element">The new <see cref="IElement"/> to add to the list.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="element"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if <paramref name="element"/> already exists in the list, or if the list already holds
        /// <see cref="UpperBound"/> elements.
        /// </exception>
        public new void Add(T element)
        {
            this.VerifyAddition(element);

            this.Contain(element);
            base.Add(element);
            this.Attach(element);
        }

        /// <summary>
        /// Inserts an <see cref="IElement"/> into the <see cref="List{T}"/> at the specified index and assigns its
        /// <see cref="IElement.Possessor"/> property to this list's owner.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="element"/> is inserted.</param>
        /// <param name="element">The <see cref="IElement"/> to insert.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="element"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="index"/> is less than 0 or greater than <see cref="List{T}.Count"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if <paramref name="element"/> already exists in the list, or if the list already holds
        /// <see cref="UpperBound"/> elements.
        /// </exception>
        public new void Insert(int index, T element)
        {
            if (index < 0 || index > base.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"index is {index}, valid range is 0 to {this.Count}");
            }

            this.VerifyAddition(element);

            this.Contain(element);
            base.Insert(index, element);
            this.Attach(element);
        }

        /// <summary>
        /// Makes the container of this list the <see cref="IElement.Possessor"/> of the <paramref name="element"/>, and
        /// removes the <paramref name="element"/> from the composite lists of any other container
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> that is added to this list</param>
        private void Contain(T element)
        {
            foreach (var list in ContainerListMembership.QueryLists(element).Where(x => !ReferenceEquals(x.Container, this.container)))
            {
                list.DetachMovingElement(element);
            }

            element.Possessor = this.container;
        }

        /// <summary>
        /// Records that this list holds the <paramref name="element"/> and sets its owner end
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> that was added to this list</param>
        private void Attach(T element)
        {
            ContainerListMembership.Register(element, this);
            this.attachOwnerEnd?.Invoke(element);
        }

        /// <summary>
        /// Releases an <paramref name="element"/> that was removed from this list: when no other composite list of the
        /// container holds it, its <see cref="IElement.Possessor"/> and owner end are cleared, otherwise the owner ends
        /// of the lists that still hold it are set again
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> that was removed from this list</param>
        private void Release(T element)
        {
            ContainerListMembership.Unregister(element, this);
            this.detachOwnerEnd?.Invoke(element);

            var remainingLists = ContainerListMembership.QueryLists(element).Where(x => ReferenceEquals(x.Container, this.container)).ToList();

            if (remainingLists.Count > 0)
            {
                foreach (var list in remainingLists)
                {
                    list.ReattachOwnerEnd(element);
                }

                return;
            }

            if (ReferenceEquals(element.Possessor, this.container))
            {
                element.Possessor = null;
            }
        }

        /// <summary>
        /// Removes an element that moves to another container from this list and clears its owner end, without
        /// changing its <see cref="IElement.Possessor"/>
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> that moves to another container</param>
        void IContainerListMembership.DetachMovingElement(IElement element)
        {
            var item = (T)element;

            base.Remove(item);
            ContainerListMembership.Unregister(item, this);
            this.detachOwnerEnd?.Invoke(item);
        }

        /// <summary>
        /// Sets the owner end of an element that this list still holds to the container
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> held by this list</param>
        void IContainerListMembership.ReattachOwnerEnd(IElement element)
        {
            this.attachOwnerEnd?.Invoke((T)element);
        }

        /// <summary>
        /// Verifies that the <paramref name="element"/> can be added to this <see cref="ContainerList{T}"/>
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="element"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if <paramref name="element"/> is the container, already exists in the list, or if the list already
        /// holds <see cref="UpperBound"/> elements.
        /// </exception>
        private void VerifyAddition(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (this.container == element)
            {
                throw new InvalidOperationException("The container shall not be added as contained item to itself");
            }

            if (this.Contains(element))
            {
                throw new InvalidOperationException($"The added item already exists {element.XmiId}.");
            }

            if (base.Count >= this.UpperBound)
            {
                throw new InvalidOperationException($"{this.propertyName} holds at most {this.UpperBound} value(s); [{element.XmiId}] cannot be added");
            }
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
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

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

                var replaced = base[index];

                if (ReferenceEquals(replaced, value))
                {
                    this.attachOwnerEnd?.Invoke(value);
                    return;
                }

                this.Contain(value);
                base[index] = value;
                this.Release(replaced);
                this.Attach(value);
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific <typeparamref name="T"/> from the list and
        /// resets its <see cref="IElement.Possessor"/> to <c>null</c> when removal succeeds.
        /// </summary>
        /// <param name="item">The object to remove from the list.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="item"/> was successfully removed from the list;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is <c>null</c>.</exception>
        public new bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (!base.Remove(item))
            {
                return false;
            }

            this.Release(item);

            return true;
        }

        /// <summary>
        /// Removes the element at the specified index and resets its <see cref="IElement.Possessor"/> to <c>null</c>.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="index"/> is less than 0 or is equal to or greater than <see cref="List{T}.Count"/>.
        /// </exception>
        public new void RemoveAt(int index)
        {
            if (index < 0 || index >= base.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"index is {index}, valid range is 0 to {this.Count - 1}");
            }

            var element = base[index];
            base.RemoveAt(index);
            this.Release(element);
        }

        /// <summary>
        /// Removes all items from the list and sets their <see cref="IElement.Possessor"/> to <c>null</c>.
        /// </summary>
        public new void Clear()
        {
            var elements = this.ToList();

            base.Clear();

            foreach (var element in elements)
            {
                this.Release(element);
            }
        }

        /// <summary>
        /// Adds an item to the list through the non-generic <see cref="IList"/> interface, maintaining the containment
        /// as <see cref="Add(T)"/> does
        /// </summary>
        /// <param name="value">The item to add, a <typeparamref name="T"/></param>
        /// <returns>The index at which the item was added</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not a <typeparamref name="T"/></exception>
        int IList.Add(object value)
        {
            this.Add(CastToElement(value));

            return this.Count - 1;
        }

        /// <summary>
        /// Inserts an item through the non-generic <see cref="IList"/> interface, maintaining the containment as
        /// <see cref="Insert(int, T)"/> does
        /// </summary>
        /// <param name="index">The zero-based index at which the item is inserted</param>
        /// <param name="value">The item to insert, a <typeparamref name="T"/></param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not a <typeparamref name="T"/></exception>
        void IList.Insert(int index, object value)
        {
            this.Insert(index, CastToElement(value));
        }

        /// <summary>
        /// Removes an item through the non-generic <see cref="IList"/> interface, maintaining the containment as
        /// <see cref="Remove(T)"/> does; an item that is not a <typeparamref name="T"/> is ignored
        /// </summary>
        /// <param name="value">The item to remove</param>
        void IList.Remove(object value)
        {
            if (value is T element)
            {
                this.Remove(element);
            }
        }

        /// <summary>
        /// Removes the item at the specified index through the non-generic <see cref="IList"/> interface, maintaining
        /// the containment as <see cref="RemoveAt(int)"/> does
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove</param>
        void IList.RemoveAt(int index)
        {
            this.RemoveAt(index);
        }

        /// <summary>
        /// Removes all items through the non-generic <see cref="IList"/> interface, maintaining the containment as
        /// <see cref="Clear()"/> does
        /// </summary>
        void IList.Clear()
        {
            this.Clear();
        }

        /// <summary>
        /// Gets or sets the item at the specified index through the non-generic <see cref="IList"/> interface,
        /// maintaining the containment as the typed indexer does
        /// </summary>
        /// <param name="index">The zero-based index of the item</param>
        /// <exception cref="ArgumentException">Thrown when the value set is not a <typeparamref name="T"/></exception>
        object IList.this[int index]
        {
            get => this[index];
            set => this[index] = CastToElement(value);
        }

        /// <summary>
        /// Casts an item passed through the non-generic <see cref="IList"/> interface to a <typeparamref name="T"/>
        /// </summary>
        /// <param name="value">The item</param>
        /// <returns>The item as a <typeparamref name="T"/>, or null when it is null</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not a <typeparamref name="T"/></exception>
        private static T CastToElement(object value)
        {
            if (value == null || value is T)
            {
                return (T)value;
            }

            throw new ArgumentException($"The value is a {value.GetType().Name}, it shall be a {typeof(T).Name}", nameof(value));
        }
    }
}
