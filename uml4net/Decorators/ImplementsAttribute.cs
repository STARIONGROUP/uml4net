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
    using System.Collections.Generic;

    /// <summary>
    /// Attribute used to decorate properties with to indicicate which class.property
    /// is being implemented
    /// </summary>
    public class ImplementsAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImplementsAttribute"/> class.
        /// </summary>
        public ImplementsAttribute(string implementation)
        { 
            this.Implementations = implementation;
        }

        /// <summary>
        /// Gets or sets the names of the propertries that are being implemented
        /// ClassName.AttributeName or ClassName.OperationName
        /// </summary>
        public string Implementations { get; set; }
    }
}
