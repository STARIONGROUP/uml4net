// -------------------------------------------------------------------------------------------------
//  <copyright file="IXmiInspector.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
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

namespace uml4net.Reporting.Generators
{
    using System.IO;

    /// <summary>
    /// The purpose of the <see cref="IXmiInspector"/> is to inspect the XMI and return a text based
    /// report
    /// </summary>
    public interface IXmiInspector
    {
        /// <summary>
        /// inspects the provided XMI document
        /// </summary>
        /// <param name="modelFileInfo">
        /// the path to the XMI document
        /// </param>
        /// <returns>
        /// a text based report
        /// </returns>
        public string Inspect(FileInfo modelFileInfo);
    }
}