// -------------------------------------------------------------------------------------------------
// <copyright file="BehavioredClassifier.cs" company="RHEA System S.A.">
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

namespace Uml.SimpleClassifiers
{
    using Uml.Assembler;
    using Uml.Classification;
    using Uml.CommonBehavior;

    /// <summary>
    /// A <see cref="BehavioredClassifier"/> may have <see cref="InterfaceRealization"/>s, and owns a set of Behaviors one of which may specify the behavior of the <see cref="BehavioredClassifier"/> itself.
    /// </summary>
    public interface BehavioredClassifier : Classifier
    {
        /// <summary>
        /// A <see cref="Behavior"/> that specifies the behavior of the <see cref="BehavioredClassifier"/> itself.
        /// </summary>
        Behavior ClassifierBehavior { get; set; }

        /// <summary>
        /// The set of <see cref="InterfaceRealization"/>s owned by the <see cref="BehavioredClassifier"/>. Interface realizations reference the <see cref="Interface"/>s of which the <see cref="BehavioredClassifier"/> is an implementation.
        /// </summary>
        InterfaceRealization InterfaceRealization { get; set; }

        /// <summary>
        /// Behaviors owned by a <see cref="BehavioredClassifier"/>.
        /// </summary>
        OwnerList<Behavior> OwnedBehavior { get; set; }
    }
}