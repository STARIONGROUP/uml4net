﻿// -------------------------------------------------------------------------------------------------
// <copyright file="RedefinableElementExtensions.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Classification
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="RedefinableElementExtensions"/> class provides extensions methods for <see cref="IRedefinableElement"/>
    /// </summary>
    public static class RedefinableElementExtensions
    {
        public static List<IRedefinableElement> QueryRedefinedElement(this IRedefinableElement redefinableElement)
        {
            throw new NotImplementedException();
        }


        public static List<IClassifier> QueryRedefinitionContext(this IRedefinableElement redefinableElement)
        {
            throw new NotImplementedException();
        }
    }
}