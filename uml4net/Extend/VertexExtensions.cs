﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="VertexExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.StateMachines
{
    using System;
    using System.Collections.Generic;

    using uml4net.Classification;

    /// <summary>
    /// The <see cref="VertexExtensions"/> class provides extensions methods for <see cref="IVertex"/>
    /// </summary>
    public static class VertexExtensions
    {
        public static List<ITransition> QueryIncoming(this IVertex vertex)
        {
            throw new NotImplementedException();
        }

        public static List<ITransition> QueryOutgoing(this IVertex vertex)
        {
            throw new NotImplementedException();
        }

        public static IClassifier QueryRedefinitionContext(this IVertex vertex)
        {
            throw new NotImplementedException();
        }
    }
}