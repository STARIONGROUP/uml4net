// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterHelper.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
