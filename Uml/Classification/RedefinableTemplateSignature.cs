// -------------------------------------------------------------------------------------------------
// <copyright file="RedefinableTemplateSignature.cs" company="RHEA System S.A.">
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

namespace Uml.Classification
{
    using System.Collections.Generic;
    using Uml.CommonStructure;

    /// <summary>
    /// A RedefinableTemplateSignature supports the addition of formal template parameters in a specialization of a template classifier.
    /// </summary>
    public interface RedefinableTemplateSignature : RedefinableElement, TemplateSignature
    {
        /// <summary>
        /// The Classifier that owns this <see cref="RedefinableTemplateSignature"/>.
        /// </summary>
        Classifier Classifier { get; set; }

        /// <summary>
        /// The signatures extended by this <see cref="RedefinableTemplateSignature"/>.
        /// </summary>
        List<RedefinableTemplateSignature> ExtendedSignature { get; set; }

        /// <summary>
        /// The formal template parameters of the extended signatures.
        /// </summary>
        IEnumerable<TemplateParameter> InheritedParameter { get; }
    }
}