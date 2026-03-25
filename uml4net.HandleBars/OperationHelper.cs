// -------------------------------------------------------------------------------------------------
//  <copyright file="OperationHelper.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2026 Starion Group S.A.
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

namespace uml4net.HandleBars
{
    using System;
    using System.Linq;

    using HandlebarsDotNet;

    using uml4net.Classification;
    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// A handlebars block helper for the <see cref="IOperation"/> interface
    /// </summary>
    public static class OperationHelper
    {
        /// <summary>
        /// Registers the <see cref="OperationHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterOperationHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Operation.WriteForPOCOInterface", (writer, _, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new ArgumentException("Operation.WriteForPOCOInterface requires exactly one argument");
                }

                if (arguments[0] is not IOperation operation)
                {
                    throw new ArgumentException("Operation.WriteForPOCOInterface argument must be an IOperation");
                }

                if (operation.RedefinedOperation.Any(x => x.Name == operation.Name))
                {
                    writer.WriteSafeString("new ");
                }

                var returnParameter = operation.OwnedParameter.SingleOrDefault(x => x.Direction == ParameterDirectionKind.Return);

                writer.WriteSafeString(returnParameter?.Type == null ? "void" : $"{returnParameter.Type.QueryCSharpTypeName(true)}");

                var methodName = operation.RedefinedOperation.Any(x => x.Name == operation.Name) ? $"ComputeRedefined{operation.Name.CapitalizeFirstLetter()}Operation" : $"Compute{operation.Name.CapitalizeFirstLetter()}Operation";
                writer.WriteSafeString($" {operation.Name.CapitalizeFirstLetter()}("); 
                var inputParameters = operation.OwnedParameter.Where(x => x.Direction != ParameterDirectionKind.Return).ToList();

                writer.WriteSafeString(string.Join(", ", inputParameters.Select(x => $"{x.Type.QueryCSharpTypeName(true)} {x.Name.LowerCaseFirstLetter()}")));
                writer.WriteSafeString($") => this.{methodName}(");
                writer.WriteSafeString(string.Join(", ", inputParameters.Select(x => $"{x.Name.LowerCaseFirstLetter()}")));
                writer.WriteSafeString($");{Environment.NewLine}");
            });
            
            handlebars.RegisterHelper("Operation.WriteForPOCOExtend", (writer, _, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new ArgumentException("Operation.WriteForPOCOExtend requires exactly one argument");
                }

                if (arguments[0] is not IOperation operation)
                {
                    throw new ArgumentException("Operation.WriteForPOCOExtend argument must be an IOperation");
                }
                
                writer.WriteSafeString("internal static ");
                
                var returnParameter = operation.OwnedParameter.SingleOrDefault(x => x.Direction == ParameterDirectionKind.Return);

                writer.WriteSafeString(returnParameter?.Type == null ? "void" : $"{returnParameter.Type.QueryCSharpTypeName(true)}");

                var methodName = operation.RedefinedOperation.Any(x => x.Name == operation.Name) ? $"ComputeRedefined{operation.Name.CapitalizeFirstLetter()}Operation" : $"Compute{operation.Name.CapitalizeFirstLetter()}Operation";
                var owner = (IClass)operation.Owner;
                writer.WriteSafeString($" {methodName}(this I{owner.Name.CapitalizeFirstLetter()} {owner.Name.LowerCaseFirstLetter()}Subject");
                
                var inputParameters = operation.OwnedParameter.Where(x => x.Direction != ParameterDirectionKind.Return).ToList();

                if (inputParameters.Count > 0)
                {
                    var parametersDefinition = string.Join(", ", inputParameters.Select(x => $"{x.Type.QueryCSharpTypeName(true)} {x.Name.LowerCaseFirstLetter()}"));
                    writer.WriteSafeString($", {parametersDefinition}");
                }
                
                writer.WriteSafeString($"){Environment.NewLine}");
            });
        }
    }
}
