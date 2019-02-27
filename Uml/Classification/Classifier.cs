// -------------------------------------------------------------------------------------------------
// <copyright file="Classifier.cs" company="RHEA System S.A.">
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
    using Uml.UseCases;
    using Uml.Assembler;
    using Uml.CommonStructure;
    using Uml.StructuredClassifiers;

    /// <summary>
    /// A <see cref="Classifier"/> represents a classification of instances according to their <see cref="Feature"/>s.
    /// </summary>
    public interface Classifier : Namespace, Type, TemplateableElement, RedefinableElement
    {
        /// <summary>
        /// All of the Properties that are direct (i.e., not inherited or imported) attributes of the <see cref="Classifier"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<Property> Attribute { get; }

        /// <summary>
        /// The <see cref="CollaborationUse"/>s owned by the <see cref="Classifier"/>.
        /// </summary>
        OwnerList<CollaborationUse> CollaborationUse { get; set; }

        /// <summary>
        /// Specifies each Feature directly defined in the classifier. Note that there may be members of the <see cref="Classifier"/> that are of the type <see cref="Feature"/> but are not included, e.g., inherited features.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<Feature> Feature { get; }

        /// <summary>
        /// The generalizing <see cref="Classifier"/>s for this <see cref="Classifier"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<Classifier> General { get; }

        /// <summary>
        /// The Generalization relationships for this <see cref="Classifier"/>. These Generalizations navigate to more general <see cref="Classifier"/>s in the generalization hierarchy.
        /// </summary>
        OwnerList<Generalization> Generalization { get; set; }

        /// <summary>
        /// All elements inherited by this <see cref="Classifier"/> from its general <see cref="Classifier"/>s.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<NamedElement> InheritedMember { get; }

        /// <summary>
        /// If true, the <see cref="Classifier"/> can only be instantiated by instantiating one of its specializations. An abstract <see cref="Classifier"/> is intended to be used by other <see cref="Classifier"/>s e.g., as the target of <see cref="Association"/>s or <see cref="Generalization"/>s.
        /// </summary>
        bool IsAbstract { get; set; }

        /// <summary>
        /// If true, the <see cref="Classifier"/> cannot be specialized.
        /// </summary>
        bool IsFinalSpecialization { get; set; }

        /// <summary>
        /// The optional <see cref="RedefinableTemplateSignature"/> specifying the formal template parameters.
        /// </summary>
        OwnerList<RedefinableTemplateSignature> OwnedTemplateSignature { get;  set; }

        /// <summary>
        /// The <see cref="UseCase"/>s owned by this <see cref="Classifier"/>.
        /// </summary>
        OwnerList<UseCase> OwnedUseCase { get;  set; }

        /// <summary>
        /// The <see cref="GeneralizationSet"/> of which this <see cref="Classifier"/> is a power type.
        /// </summary>
        List<GeneralizationSet> PowertypeExtent { get; set; }

        /// <summary>
        /// The <see cref="Classifier"/>s redefined by this <see cref="Classifier"/>.
        /// </summary>
        List<Classifier> RedefinedClassifier { get; set; }

        /// <summary>
        /// A <see cref="CollaborationUse"/> which indicates the <see cref="Collaboration"/> that represents this <see cref="Classifier"/>.
        /// </summary>
        CollaborationUse Representation { get; set; }

        /// <summary>
        /// The <see cref="Substitution"/>s owned by this <see cref="Classifier"/>.
        /// </summary>
        OwnerList<Substitution> Substitution { get;  set; }

        /// <summary>
        /// The <see cref="ClassifierTemplateParameter"/> that exposes this element as a formal parameter.
        /// </summary>
        ClassifierTemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// The set of <see cref="UseCase"/>s for which this <see cref="Classifier"/> is the subject.
        /// </summary>
        List<UseCase> UseCase { get; set; }
    }
}