// -------------------------------------------------------------------------------------------------
// <copyright file="IPackageImport.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.CommonStructure
{
    /// <summary>
    /// A PackageImport is a Relationship that imports all the non-private members of a Package into the
    /// Namespace owning the PackageImport, so that those Elements may be referred to by their unqualified 
    /// names in the importingNamespace.
    /// </summary>
    public interface IPackageImport : IDirectedRelationship
    {
    }
}
