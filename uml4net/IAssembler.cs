// -------------------------------------------------------------------------------------------------
//  <copyright file="IAssembler.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net
{
    /// <summary>
    /// The <see cref="IAssembler"/> is the interface definition for the <see cref="Assembler"/>
    /// </summary>
    public interface IAssembler
    {
        /// <summary>
        /// Synchronizes the <see cref="IXmiElement"/>s in the <see cref="IXmiElementCache"/> by assigning
        /// the reference properties that are encoded by <see cref="IXmiElement.SingleValueReferencePropertyIdentifiers"/>
        /// and by <see cref="IXmiElement.MultiValueReferencePropertyIdentifiers>"/>
        /// </summary>
        void Synchronize();
    }
}
