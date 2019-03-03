// -------------------------------------------------------------------------------------------------
// <copyright file="UseCase.cs" company="RHEA System S.A.">
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

namespace Uml.UseCases
{
    using Uml.Assembler;
    using Uml.Classification;
    using Uml.SimpleClassifiers;

    /// <summary>
    /// A <see cref="UseCase"/> specifies a set of actions performed by its subjects, which yields an observable result that is of value for one or more Actors or other stakeholders of each subject.
    /// </summary>
    public interface UseCase : BehavioredClassifier
    {
        /// <summary>
        /// The <see cref="Extend"/> relationships owned by this <see cref="UseCase"/>.
        /// </summary>
        OwnerList<Extend> Extend { get; set; }

        /// <summary>
        /// The <see cref="ExtensionPoint"/>s owned by this <see cref="UseCase"/>.
        /// </summary>
        OwnerList<ExtensionPoint> ExtensionPoint { get; set; }

        /// <summary>
        /// The <see cref="Include"/> relationships owned by this <see cref="UseCase"/>.
        /// </summary>
        OwnerList<Include> Include { get; set; }

        /// <summary>
        /// The subjects to which this <see cref="UseCase"/> applies. Each subject or its parts realize all the <see cref="UseCase"/>s that apply to it.
        /// </summary>
        Classifier Subject { get; set; }
    }
}