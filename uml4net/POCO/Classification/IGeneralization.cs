// -------------------------------------------------------------------------------------------------
// <copyright file="IGeneralization.cs" company="Starion Group S.A.">
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
{
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// A Generalization is a taxonomic relationship between a more general Classifier and a more specific
    /// Classifier. Each instance of the specific Classifier is also an instance of the general Classifier.
    /// The specific Classifier inherits the features of the more general Classifier. A Generalization
    /// is owned by the specific Classifier.
    /// </summary>
    public interface IGeneralization : IDirectedRelationship
    {
    }
}
