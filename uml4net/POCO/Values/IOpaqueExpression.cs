﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IOpaqueExpression.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.POCO.Values
{
    /// <summary>
    /// An OpaqueExpression is a ValueSpecification that specifies the computation of a collection of values either in
    /// terms of a UML Behavior or based on a textual statement in a language other than UML
    /// </summary>
    public interface IOpaqueExpression : IValueSpecification
    {
    }
}