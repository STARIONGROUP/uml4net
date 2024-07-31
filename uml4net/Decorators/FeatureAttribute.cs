// -------------------------------------------------------------------------------------------------
// <copyright file="FeatureAttribute.cs" company="Starion Group S.A.">
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

namespace uml4net.Decorators
{
    using System;

    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// Attribute used to decorate properties with using the properties sourced from
    /// the UML meta-model.
    /// </summary>
    public class FeatureAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureAttribute"/> class.
        /// </summary>
        /// <param name="aggregation"></param>
        public FeatureAttribute(AggregationKind aggregation, int lowerValue, int upperValue, 
            bool isOrdered = false,
            bool isReadOnly = false,
            bool isDerived = false,
            bool isDerivedUnion = false,
            string subsets = "")
        {
            this.Aggregation = aggregation;
            this.LowerValue = lowerValue;
            this.UpperValue = upperValue;
            this.IsOrdered = isOrdered;
            this.IsReadOnly = isReadOnly;
            this.IsDerived = isDerived;
            this.IsDerivedUnion = isDerivedUnion;
            this.Subsets = subsets;
        }

        /// <summary>
        /// Gets or sets the <see cref="AggregationKind"/>.
        /// </summary>
        public AggregationKind Aggregation { get; set; } = AggregationKind.None;

        /// <summary>
        /// Gets or sets the lower value (lowerbound) of the property
        /// </summary>
        public int LowerValue { get; set; } = 0;

        /// <summary>
        /// Gets or sets the upper value (upperbound) of the property
        /// </summary>
        public int UpperValue { get; set; } = 1;

        /// <summary>
        /// Gets or sets a value specifiying whether this is an ordered property
        /// </summary>
        public bool IsOrdered { get; set; } = false;

        /// <summary>
        /// Gets or sets a value specifiying whether this is a readonly property
        /// </summary>
        public bool IsReadOnly { get; set; } = false;

        /// <summary>
        /// Gets or sets a value specifiying whether this is a derived property
        /// </summary>
        public bool IsDerived { get; set; } = false;

        /// <summary>
        /// Gets or sets a value specifiying whether this is a derived union property
        /// </summary>
        public bool IsDerivedUnion { get; set; } = false;
        
        /// <summary>
        /// Gets or sets the name of the subsetted property (using the superclass name and 
        /// property name separated by :: e.g. Element::ownedElement)
        /// </summary>
        public string Subsets { get; set; } = string.Empty;
    }
}
