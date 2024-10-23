// -------------------------------------------------------------------------------------------------
// <copyright file="IReferenceable.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Classification
{ using System.Collections.Generic;
    /// <summary>
    /// Represents an object that contains a reference to another object of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the referenced object.</typeparam>
    public interface IReferenceable<T>
    {
        /// <summary>
        /// Gets or sets the reference to an object of type <typeparamref name="T"/>.
        /// </summary>
        T Reference { get; set; }
    }
}
