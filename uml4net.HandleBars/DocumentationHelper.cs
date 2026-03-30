// -------------------------------------------------------------------------------------------------
//  <copyright file="DocumentationHelper.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
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
    using System.Text;

    using HandlebarsDotNet;

    using uml4net.Classification;
    using uml4net.Extensions;
    using uml4net.CommonStructure;

    /// <summary>
    /// a block helper 
    /// </summary>
    public static class DocumentationHelper
    {
        /// <summary>
        /// Registers the <see cref="DocumentationHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterDocumentationHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Documentation", (writer, context, _) =>
            {
                if (!(context.Value is IElement eModelElement))
                {
                    throw new ArgumentException("supposed to be IElement");
                }

                writer.WriteSafeString($"/// <summary>{Environment.NewLine}");
                foreach (var line in eModelElement.QueryDocumentation())
                {
                    writer.WriteSafeString($"/// {line}{Environment.NewLine}");
                }
                writer.WriteSafeString($"/// </summary>{Environment.NewLine}");
            });

            handlebars.RegisterHelper("RawDocumentation", (writer, context, _) =>
            {
                if (!(context.Value is IElement element))
                {
                    throw new ArgumentException("supposed to be IElement");
                }

                var rawDocumentation = element.QueryRawDocumentation();

                if (string.IsNullOrEmpty(rawDocumentation))
                {
                    rawDocumentation = "No Documentation Provided";
                }

                writer.WriteSafeString(rawDocumentation);
            });
            
            handlebars.RegisterHelper("ParameterDocumentation", (writer, _, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new ArgumentException("ParameterDocumentation requires exactly one argument");
                }

                if (arguments[0] is not IOperation operation)
                {
                    throw new ArgumentException("ParameterDocumentation argument must be an IOperation");
                }
                
                var inputParameters = operation.OwnedParameter.Where(x => x.Direction != ParameterDirectionKind.Return).ToList();

                foreach (var inputParameter in inputParameters)
                {
                    writer.WriteSafeString(ComputeInputParameterDocumentation(inputParameter));
                }
                
                var returnParameter = operation.OwnedParameter.SingleOrDefault(x => x.Direction == ParameterDirectionKind.Return);

                if (returnParameter?.Type != null)
                {
                    writer.WriteSafeString(ComputeReturnParameterDocumentation(returnParameter));
                }
            });
        }
        
         /// <summary>
        /// Compute the documentation for an input <see cref="IParameter"/>
        /// </summary>
        /// <param name="parameter">The <see cref="IParameter"/> that needs to have the documentation built</param>
        /// <returns>The built documentation</returns>
        private static string ComputeInputParameterDocumentation(IParameter parameter)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"/// <param name=\"{parameter.Name.LowerCaseFirstLetter()}\">");

            var documentation = parameter.QueryDocumentation().ToList();

            if (documentation.Count != 0)
            {
                stringBuilder.Append(string.Join("/// ", documentation.Select(x => $"{x} {Environment.NewLine}")));
            }
            else
            {
                stringBuilder.AppendLine("/// No documentation provided");
            }

            stringBuilder.AppendLine("/// </param>");
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Compute the documentation for a return <see cref="IParameter"/>
        /// </summary>
        /// <param name="parameter">The <see cref="IParameter"/> that needs to have the documentation built</param>
        /// <returns>The built documentation</returns>
        private static string ComputeReturnParameterDocumentation(IParameter parameter)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("/// <returns>");
            var documentation = parameter.QueryDocumentation().ToList();

            if (documentation.Count != 0)
            {
                stringBuilder.Append(string.Join("/// ", documentation.Select(x => $"{x} {Environment.NewLine}")));
            }
            else
            {
                stringBuilder.AppendLine($"/// The expected {parameter.QueryCSharpFullTypeName()}");
            }

            stringBuilder.AppendLine("/// </returns>");
            return stringBuilder.ToString();
        }
    }
}
