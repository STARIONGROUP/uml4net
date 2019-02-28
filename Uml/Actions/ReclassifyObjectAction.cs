// -------------------------------------------------------------------------------------------------
// <copyright file="ReclassifyObjectAction.cs" company="RHEA System S.A.">
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

namespace Uml.Actions
{
    using Uml.Assembler;
    using Uml.Classification;

    /// <summary>
    /// A <see cref="ReclassifyObjectAction"/> is an <see cref="Action"/> that changes the <see cref="Classifiers"/> that classify an object.
    /// </summary>
    public interface ReclassifyObjectAction : Action
    {
        /// <summary>
        /// Specifies whether existing <see cref="Classifier"/>s should be removed before adding the new <see cref="Classifier"/>s.
        /// </summary>
        bool IsReplaceAll { get; set; }

        /// <summary>
        /// A set of <see cref="Classifier"/>s to be added to the <see cref="Classifier"/>s of the given object.
        /// </summary>
        Classifier NewClassifier { get; set; }

        /// <summary>
        /// The <see cref="InputPin"/> that holds the object to be reclassified.
        /// </summary>
        OwnerList<InputPin> Object { get; set; }

        /// <summary>
        /// A set of <see cref="Classifier"/>s to be removed from the <see cref="Classifier"/>s of the given object.
        /// </summary>
        Classifier OldClassifier { get; set; }
    }
}