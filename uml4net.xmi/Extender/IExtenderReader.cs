// -------------------------------------------------------------------------------------------------
//  <copyright file="IExtenderReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extender
{
    using System.Collections.Generic;

    /// <summary>
    /// The purpose of the <see cref="IExtenderReader"/> interface is to implement readers for tool-vendor specific
    /// <see cref="XmiExtension"/>s.
    /// </summary>
    public interface IExtenderReader
    {
        /// <summary>
        /// Reads
        /// </summary>
        /// <param name="extensionXmi"></param>
        /// <returns></returns>
        List<object> ReadContent(string extensionXmi);

        /// <summary>
        /// Performs post-processing of a UMl model using content of the extension
        /// </summary>
        void PostProcess();
    }
}
