// -------------------------------------------------------------------------------------------------
//  <copyright file="Extension.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Extensions.EntrepriseArchitect.Structure
{
    using uml4net.CommonStructure;
    using uml4net.Packages;

    /// <summary>
    /// hand-coded properties for the <see cref="Extension"/> class.
    /// </summary>
    public partial class Extension
    {
        /// <summary>
        /// Backing field for <see cref="PrimitivesTypes"/>
        /// </summary>
        private IContainerList<IPackageableElement> primitivesTypes;

        /// <summary>
        /// The contained <see cref="IPackageableElement"/>s
        /// </summary>
        public IContainerList<IPackageableElement>  PrimitivesTypes
        {
            get => this.primitivesTypes ??= new ContainerList<IPackageableElement>(this);
            set => this.primitivesTypes = value;
        }

        /// <summary>
        /// Backing field for <see cref="Profiles"/>
        /// </summary>
        private IContainerList<IProfile> profiles;

        /// <summary>
        /// The contained <see cref="IProfile"/>s
        /// </summary>
        public IContainerList<IProfile>  Profiles
        {
            get => this.profiles ??= new ContainerList<IProfile>(this);
            set => this.profiles = value;
        }
    }
}
