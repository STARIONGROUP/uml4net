// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterHelper.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2026 Starion Group S.A.
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

namespace uml4net.HandleBars
{
    using System;

    using HandlebarsDotNet;

    using uml4net.Classification;
    using uml4net.Extensions;

    /// <summary>
    /// A handlebars block helper for the <see cref="IParameter"/> interface
    /// </summary>
    public static class ParameterHelper
    {
        /// <summary>
        /// Registers the <see cref="ParameterHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterParameterHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Parameter.WriteTypeAndName", (writer,_ , arguments) => 
            {
                if (arguments.Length != 1)
                {
                    throw new ArgumentException("#Parameter.WriteTypeAndName expects to have exactly 1 argument");
                }

                if (arguments[0] is not IParameter parameter)
                {
                    throw new ArgumentException("#Parameter.WriteTypeAndName argument should be an IParameter");
                }

                writer.WriteSafeString($"{parameter.Direction} ");

                if (parameter.Type == null)
                {
                    writer.WriteSafeString("void");
                }
                else
                {
                    writer.WriteSafeString($"<a href=#{parameter.Type.XmiId}>{parameter.Type.Name}</a>");
                    
                    if (parameter.Direction != ParameterDirectionKind.Return)
                    {
                        writer.WriteSafeString($" {parameter.Name}");
                    }
                    
                    writer.Write($" {parameter.QueryFormattedMultiplicity()}");
                }
            });
        }
    }
}
