// -------------------------------------------------------------------------------------------------
// <copyright file="ActionExtensions.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
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

namespace uml4net.Extend
{
    using System;

    using uml4net.POCO.Actions;
    using uml4net.POCO.Classification;
    using uml4net.Utils;

    /// <summary>
    /// The <see cref="ActionExtensions"/> class provides extensions methods for the <see cref="IAction"/>
    /// </summary>
    public static class ActionExtensions
    {
        public static IClassifier QueryContext(this IAction action)
        {
            throw new NotImplementedException();
        }

        public static IContainerList<IInputPin> QueryInput(this IAction action)
        {
            throw new NotImplementedException();
        }

        public static IContainerList<IOutputPin> QueryOutput(this IAction action)
        {
            throw new NotImplementedException();
        }
    }
}