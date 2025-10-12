// -------------------------------------------------------------------------------------------------
//  <copyright file="KnowNamespacePrefixes.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers
{
    /// <summary>
    /// know namespace prefixes
    /// </summary>
    public static class KnowNamespacePrefixes
    {
        /// <summary>
        /// The xmi prefix
        /// </summary>
        public const string Xmi = "xmi";

        /// <summary>
        /// The uml prefix
        /// </summary>
        public const string Uml = "uml";

        /// <summary>
        /// The uml diagram prefix
        /// </summary>
        public const string UmlDi = "umldi";

        /// <summary>
        /// The mofext prefix
        /// </summary>
        public const string MofExt = "mofext";

        /// <summary>
        /// The PrimitiveTypes prefix
        /// </summary>
        public const string PrimitiveTypes = "PrimitiveTypes";

        /// <summary>
        /// The StandardProfile prefix
        /// </summary>
        public const string StandardProfile = "StandardProfile";

        /// <summary>
        /// The other prefix, used when it is unknown
        /// </summary>
        public const string Other = "other";
    }
}