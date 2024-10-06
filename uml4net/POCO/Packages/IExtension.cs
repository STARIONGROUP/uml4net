// -------------------------------------------------------------------------------------------------
// <copyright file="IExtension.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// An extension is used to indicate that the properties of a metaclass are extended through
    /// a stereotype, and gives the ability to flexibly add (and later remove) stereotypes to classes.
    /// </summary>
    public interface IExtension : IAssociation
    {
        /// <summary>
        /// Indicates whether an instance of the extending stereotype must be created when an instance
        /// of the extended class is created. The attribute value is derived from the value of the lower
        /// property of the ExtensionEnd referenced by Extension::ownedEnd; a lower value of 1 means
        /// that isRequired is true, but otherwise it is false. Since the default value of
        /// ExtensionEnd::lower is 0, the default value of isRequired is false.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isReadOnly: true, isDerived:true)]
        public bool IsRequired { get; }

        /// <summary>
        /// References the Class that is extended through an Extension. The property is derived from the type of the
        /// memberEnd that is not the ownedEnd.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isReadOnly: true, isDerived: true)]
        public IClass Metaclass { get; }

        /// <summary>
        /// References the end of the extension that is typed by a Stereotype.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1)]
        [RedefinedProperty(propertyName: "Association-ownedEnd")]
        public IExtensionEnd OwnedEnd { get; set; }
    }
}
