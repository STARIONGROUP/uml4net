﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="IXmiElementReader.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
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

namespace uml4net.xmi.Readers
{
    using POCO;
    using System.Xml;

    /// <summary>
    /// Defines a contract for reading <typeparamref name="TXmiElement"/> objects
    /// from their XML representation.
    /// </summary>
    /// <typeparam name="TXmiElement">The type of the XMI element to be read.</typeparam>
    public interface IXmiElementReader<out TXmiElement> where TXmiElement : IXmiElement
    {
        /// <summary>
        /// Reads the <typeparamref name="TXmiElement"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <typeparamref name="TXmiElement"/>
        /// </returns>
        public TXmiElement Read(XmlReader xmlReader);
    }
}