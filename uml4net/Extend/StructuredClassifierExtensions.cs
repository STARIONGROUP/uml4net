﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="StructuredClassifierExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.StructuredClassifiers
{
    using System;
    using System.Collections.Generic;

    using uml4net.Classification;

    /// <summary>
    /// The <see cref="StructuredClassifierExtensions"/> class provides extensions methods for <see cref="IStructuredClassifier"/>
    /// </summary>
    public static class StructuredClassifierExtensions
    {
        public static List<IProperty> QueryPart(this IStructuredClassifier structuredClassifier)
        {
            throw new NotImplementedException();
        }

        public static List<IConnectableElement> QueryRole(this IStructuredClassifier structuredClassifier)
        {
            throw new NotImplementedException();
        }
    }
}