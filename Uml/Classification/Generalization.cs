// -------------------------------------------------------------------------------------------------
// <copyright file="Generalization.cs" company="RHEA System S.A.">
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

namespace Uml.Classification
{
    using System.Collections.Generic;
    using Uml.CommonStructure;

    /// <summary>
    /// A Generalization is a taxonomic relationship between a more general Classifier and a more specific Classifier. Each instance of the specific Classifier is also an instance of the general Classifier. The specific Classifier inherits the features of the more general Classifier. A Generalization is owned by the specific Classifier.
    /// </summary>
    public interface Generalization : DirectedRelationship
    {
        /// <summary>
        /// The general classifier in the Generalization relationship.
        /// </summary>
        Classifier General { get; set; }

        /// <summary>
        /// Represents a set of instances of <see cref="Generalization"/>. A <see cref="Generalization"/> may appear in many <see cref="GeneralizationSet"/>s.
        /// </summary>
        List<GeneralizationSet> GeneralizationSet { get; set; }

        /// <summary>
        /// Indicates whether the specific <see cref="Classifier"/> can be used wherever the general <see cref="Classifier"/> can be used. If true, the execution traces of the specific <see cref="Classifier"/> shall be a superset of the execution traces of the general <see cref="Classifier"/>. If false, there is no such constraint on execution traces. If unset, the modeler has not stated whether there is such a constraint or not.
        /// </summary>
        bool IsSubstitutable { get; set; }

        /// <summary>
        /// The specializing <see cref="Classifier"/> in the <see cref="Generalization"/> relationship.
        /// </summary>
        Classifier Specific { get; set; }
    }
}