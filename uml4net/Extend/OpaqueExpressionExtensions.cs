// -------------------------------------------------------------------------------------------------
//  <copyright file="OpaqueExpressionExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Values
{
    using System;
    using uml4net.Classification;

    /// <summary>
    /// The <see cref="OpaqueExpressionExtensions"/> class provides extensions methods for <see cref="IOpaqueExpression"/>
    /// </summary>
    public static class OpaqueExpressionExtensions
    {
        /// <summary>
        /// Queries If an OpaqueExpression is specified using a UML Behavior, then this refers to the single required
        /// return Parameter of that Behavior. When the Behavior completes execution, the values on this
        /// Parameter give the result of evaluating the OpaqueExpression.
        /// </summary>
        /// <param name="opaqueExpression">
        /// The subject <see cref="IOpaqueExpression"/>
        /// </param>
        /// <returns>
        /// If an OpaqueExpression is specified using a UML Behavior, then this refers to the single required
        /// return Parameter of that Behavior. When the Behavior completes execution, the values on this
        /// Parameter give the result of evaluating the OpaqueExpression.
        /// </returns>
        public static IParameter QueryResult(this IOpaqueExpression opaqueExpression)
        {
            throw new NotSupportedException();
        }
    }
}
