// -------------------------------------------------------------------------------------------------
// <copyright file="OwnerList.cs" company="RHEA System S.A.">
//   Copyright (c) 2018-2019 RHEA System S.A.
//
//   This file is part of uml-sharp
//
//   uml-sharp is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   uml-sharp is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with Foobar.  If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.Assembler
{
    using System;
    using System.Collections.Generic;
    using Uml.CommonStructure;

    /// <summary>
    /// List Type used for the uml meta-model for <see cref="Element"/>s which are part of a composition relationship
    /// </summary>
    /// <typeparam name="T">the type of <see cref="Element"/> that this List contains</typeparam>
    public class OwnerList<T> : List<T> where T : Element
    {
        /// <summary>
        /// backing field for the container of this <see cref="OwnerList{T}"/>
        /// </summary>
        private readonly Element owner;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerList{T}"/> class
        /// </summary>
        /// <param name="owner">the <see cref="Element"/> that contains this <see cref="OwnerList{T}"/></param>
        public OwnerList(Element owner)
        {
            this.owner = owner;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerList{T}"/> class
        /// </summary>
        /// <param name="ownerList">The <see cref="OwnerList{T}"/> which values are copied</param>
        /// <param name="owner">The owner of this <see cref="OwnerList{T}"/></param>
        public OwnerList(OwnerList<T> ownerList, Element owner)
            : base(ownerList)
        {
            this.owner = owner;
        }

        /// <summary>
        /// Adds a new <see cref="Element"/> in the <see cref="List{T}"/> and sets its <see cref="Element.Owner"/> property
        /// </summary>
        /// <param name="element">the new <see cref="Element"/> to add</param>
        public new void Add(T element)
        {
            element.Owner = this.owner;
            
            if (this.Contains(element))
            {
                throw new InvalidOperationException(string.Format("The added item already exists {0}.", element.Id));
            }

            base.Add(element);
        }

        /// <summary>
        /// Adds a <see cref="IEnumerable{T}"/> of <see cref="Element"/> in the <see cref="List{T}"/> and sets their <see cref="Element.Owner"/> property
        /// </summary>
        /// <param name="elements">the new <see cref="Element"/>s to add</param>
        public new void AddRange(IEnumerable<T> elements)
        {
            foreach (var element in elements)
            {
                element.Owner = this.owner;
                base.Add(element);
            }
        }

        /// <summary>
        /// Gets or sets the value of the <see cref="Element"/> associated with the specified index.
        /// </summary>
        /// <param name="index">the index</param>
        /// <returns>The <see cref="Element"/> with the specified index (only for get).</returns>
        public new T this[int index]
        {
            get
            {
                if (index < 0 || index >= base.Count)
                {
                    throw new ArgumentOutOfRangeException(
                        "index", string.Format("index is {0}, valid range is 0 to {1}", index, this.Count - 1));
                }

                return base[index];
            }

            set
            {
                if (index < 0 || index >= base.Count)
                {
                    throw new ArgumentOutOfRangeException(
                        "index", string.Format("index is {0}, valid range is 0 to {1}", index, this.Count - 1));
                }

                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                


                if (this.Contains(value) && !base[index].Equals(value))
                {
                    throw new InvalidOperationException(string.Format("The added item already exists {0}.", value.Id));
                }

                value.Owner = this.owner;
                base[index] = value;
            }
        }
    }
}
