// -------------------------------------------------------------------------------------------------
//  <copyright file="HandlebarsPayload.cs" company="Starion Group S.A.">
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

namespace uml4net.Reporting.Payload
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using POCO.Packages;
    using POCO.SimpleClassifiers;
    using POCO.StructuredClassifiers;

    /// <summary>
    /// represents the payload for the generators that require all <see cref="IClass"/>,
    /// <see cref="IDataType"/> and <see cref="IClass"/>
    /// </summary>
    public class HandlebarsPayload
    {
        /// <summary>
        /// initializes an instance of the <see cref="HandlebarsPayload"/> class.
        /// </summary>
        /// <param name="rootPackage">
        /// The root <see cref="IPackage"/> of the ECore model
        /// </param>
        /// <param name="enums">
        /// the <see cref="IEnumeration"/>s in the ECore model
        /// </param>
        /// <param name="dataTypes">
        /// the <see cref="IDataType"/>s in the ECore model
        /// </param>
        /// <param name="classes">
        /// the <see cref="IClass"/>es in the ECore model
        /// </param>
        public HandlebarsPayload(IPackage rootPackage, IEnumerable<IEnumeration> enums, IEnumerable<IDataType> dataTypes, IEnumerable<IClass> classes)
        {
            this.RootPackage = rootPackage;
            this.Enums = enums.ToArray();
            this.DataTypes = dataTypes.ToArray();
            this.Classes = classes.ToArray();
        }

        /// <summary>
        /// Gets the root <see cref="IPackage"/>
        /// </summary>
        public IPackage RootPackage { get; private set; }

        /// <summary>
        /// Gets the array of <see cref="IEnumeration"/>
        /// </summary>
        public IEnumeration[] Enums { get; private set; }

        /// <summary>
        /// Gets the array of <see cref="IDataType"/>
        /// </summary>
        public IDataType[] DataTypes { get; private set; }

        /// <summary>
        /// Gets the array of <see cref="IClass"/>
        /// </summary>
        public IClass[] Classes { get; private set; }

        /// <summary>
        /// Gets the version of the reporting library
        /// </summary>
        public string Version => Assembly.GetExecutingAssembly().GetName().Version?.ToString();
    }
}