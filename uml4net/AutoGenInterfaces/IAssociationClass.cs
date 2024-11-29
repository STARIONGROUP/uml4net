// -------------------------------------------------------------------------------------------------
// <copyright file="IAssociationClass.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// A model element that has both Association and Class properties. An AssociationClass can be seen as an
    /// Association that also has Class properties, or as a Class that also has Association properties.
    /// It not only connects a set of Classifiers but also defines a set of Features that belong to the Association
    /// itself and not to any of the associated Classifiers.
    /// </summary>
    public interface IAssociationClass : IClass, IAssociation
    {
    }
}
