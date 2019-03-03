// -------------------------------------------------------------------------------------------------
// <copyright file="ReadIsClassifiedObjectAction.cs" company="RHEA System S.A.">
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
//   along with uml-sharp. If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.Actions
{
    using Uml.Assembler;
    using Uml.Classification;

    /// <summary>
    /// A <see cref="ReadIsClassifiedObjectAction"/> is an <see cref="Action"/> that determines whether an object is classified by a given <see cref="Classifier"/>.
    /// </summary>
    public interface ReadIsClassifiedObjectAction : Action
    {
        /// <summary>
        /// The Classifier against which the classification of the input object is tested.
        /// </summary>
        Classifier  Classifier { get; set; }

        /// <summary>
        /// Indicates whether the input object must be directly classified by the given <see cref="Classifier"/> or whether it may also be an instance of a specialization of the given <see cref="Classifier"/>.
        /// </summary>
        bool IsDirect { get; set; }

        /// <summary>
        /// The <see cref="InputPin"/> that holds the object whose classification is to be tested.
        /// </summary>
        OwnerList<InputPin> Object { get; set; }

        /// <summary>
        /// The <see cref="OutputPin"/> that holds the Boolean result of the test.
        /// </summary>
        OwnerList<OutputPin> Result { get; set; }
    }
}