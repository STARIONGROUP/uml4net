﻿// -------------------------------------------------------------------------------------------------
// <copyright file="Class.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.StructuredClassifiers
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A Class classifies a set of objects and specifies the features that characterize the structure and behavior
    /// of those objects.  A Class may have an internal structure and Ports
    /// </summary>
    public partial class Class
    {
        /// <summary>
        /// Queries the superclasses of a Class, derived from its Generalizations.
        /// </summary>
        private List<IClass> QuerySuperClass() => this.Generalization.Select(x => x.General).OfType<IClass>().ToList();
    }
}