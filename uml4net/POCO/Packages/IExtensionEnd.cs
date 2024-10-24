﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IExtensionEnd.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.POCO.Packages
{
    using uml4net.Decorators;
    using uml4net.POCO.Classification;

    /// <summary>
    /// An extension end is used to tie an extension to a stereotype when extending a metaclass.
    /// The default multiplicity of an extension end is 0..1.
    /// </summary>
    public interface IExtensionEnd : IProperty
    {
        /// <summary>
        /// This redefinition changes the default multiplicity of association ends, since model
        /// elements are usually extended by 0 or 1 instance of the extension stereotype.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isDerived: true)]
        [RedefinedProperty(propertyName: "MultiplicityElement-lower")]
        public new int Lower { get; }

        /// <summary>
        /// References the type of the ExtensionEnd. Note that this association restricts the possible
        /// types of an ExtensionEnd to only be Stereotypes.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [RedefinedProperty(propertyName: "ExtensionEnd-type")]
        public new IStereotype Type { get; set; }
    }
}
