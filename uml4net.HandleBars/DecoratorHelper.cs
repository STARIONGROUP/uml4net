// -------------------------------------------------------------------------------------------------
//  <copyright file="DecoratorHelper.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
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
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using HandlebarsDotNet;

    using uml4net.Extensions;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.StructuredClassifiers;
    
    /// <summary>
    /// A block helper that supports operations on class and property decorators (C# attributes)
    /// </summary>
    public static class DecoratorHelper
    {
        /// <summary>
        /// Registers the <see cref="DecoratorHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterDecoratorHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Decorator.WriteClassAttribute", (writer, context, parameters) =>
            {
                if (!(context.Value is IClass @class))
                    throw new ArgumentException("context is supposed to be an IClass");

                var classAttribute = $"[Class(xmiId: \"{@class.XmiId}\", " +
                                     $"isAbstract: {@class.IsAbstract.ToString(CultureInfo.InvariantCulture).ToLower(CultureInfo.InvariantCulture)}, " +
                                     $"isFinalSpecialization: {@class.IsFinalSpecialization.ToString(CultureInfo.InvariantCulture).ToLower(CultureInfo.InvariantCulture)}," +
                                     $"isActive: {@class.IsActive.ToString(CultureInfo.InvariantCulture).ToLower(CultureInfo.InvariantCulture)})]";

                writer.WriteSafeString(classAttribute);
            });

            handlebars.RegisterHelper("Decorator.WriteImplementsAttribute", (writer, context, parameters) =>
            {
                if (!(context.Value is IProperty property))
                    throw new ArgumentException("context is supposed to be an IProperty");

                var owner = property.Owner;

                var ownerName = (owner as INamedElement)?.Name ?? string.Empty;

                var implementsAttribute = $"[Implements(implementation: \"I{ownerName}.{property.Name.CapitalizeFirstLetter()}\")]";

                writer.WriteSafeString(implementsAttribute);
            });

            handlebars.RegisterHelper("Decorator.WritePropertyAttribute", (writer, context, parameters) =>
            {
                if (!(context.Value is IProperty property))
                    throw new ArgumentException("context is supposed to be an IProperty");

                var upperValue = property.Upper == int.MaxValue ? "int.MaxValue" : property.Upper.ToString(CultureInfo.InvariantCulture);

                var defaultValue = property.QueryDefaultValueAsString();
                if (defaultValue != "null")
                {
                    defaultValue = $"\"{defaultValue}\"";
                }
                
                var propertyAttribute = $"[Property(xmiId: \"{property.XmiId}\", " +
                                        $"aggregation: AggregationKind.{property.Aggregation.ToString()}, " +
                                        $"lowerValue: {property.Lower}, " +
                                        $"upperValue: {upperValue}, " +
                                        $"isOrdered: {property.IsOrdered.ToString(CultureInfo.InvariantCulture).ToLowerInvariant()}, " +
                                        $"isReadOnly: {property.IsReadOnly.ToString(CultureInfo.InvariantCulture).ToLowerInvariant()}, " +
                                        $"isDerived: {property.IsDerived.ToString(CultureInfo.InvariantCulture).ToLowerInvariant()}, " +
                                        $"isDerivedUnion: {property.IsDerivedUnion.ToString(CultureInfo.InvariantCulture).ToLowerInvariant()}, " +
                                        $"isUnique: {property.IsUnique.ToString(CultureInfo.InvariantCulture).ToLowerInvariant()}, " +
                                        $"defaultValue: {defaultValue})]";

                writer.WriteSafeString($"{propertyAttribute}" + Environment.NewLine);
            });

            handlebars.RegisterHelper("Decorator.WriteRedefinedPropertyAttribute", (writer, context, parameters) =>
            {
                if (!(context.Value is IProperty property))
                    throw new ArgumentException("context is supposed to be an IProperty");

                var attributes = new List<string>();

                foreach (var redefinedProperty in property.RedefinedProperty)
                {
                    attributes.Add($"[RedefinedProperty(propertyName: \"{redefinedProperty.XmiId}\")]");
                }

                if (attributes.Any())
                {
                    writer.WriteSafeString(string.Join(Environment.NewLine, attributes) + Environment.NewLine);
                }
            });

            handlebars.RegisterHelper("Decorator.WriteRedefinedByPropertyAttribute", (writer, context, parameters) =>
            {
                if (parameters.Length != 2)
                {
                    throw new HandlebarsException("{{#Decorator.WriteRedefinedByPropertyAttribute}} helper must have exactly two arguments");
                }

                var property = parameters[0] as IProperty;
                var @class = parameters[1] as IClass;
                
                if (property.TryQueryRedefinedByProperty(@class, out var redefinedByProperty))
                {
                    var owner = redefinedByProperty.Owner as IClass;
                    writer.WriteSafeString($"[RedefinedByProperty(\"I{owner.Name}.{redefinedByProperty.Name.CapitalizeFirstLetter() }\")]");
                }
            });

            handlebars.RegisterHelper("Decorator.WriteSubsettedPropertyAttribute", (writer, context, parameters) =>
            {
                if (!(context.Value is IProperty property))
                    throw new ArgumentException("context is supposed to be an IProperty");

                var attributes = new List<string>();

                foreach (var redefinedProperty in property.SubsettedProperty)
                {
                    attributes.Add($"[SubsettedProperty(propertyName: \"{redefinedProperty.XmiId}\")]");
                }

                if (attributes.Any())
                {
                    writer.WriteSafeString(string.Join(Environment.NewLine, attributes) + Environment.NewLine);
                }
            });

            handlebars.RegisterHelper("Decorator.WriteImplementsAttribute", (writer, context, parameters) =>
            {
                if (!(context.Value is IProperty property))
                    throw new ArgumentException("context is supposed to be an IProperty");

                var @class = property.Owner as IClass;

                writer.WriteSafeString($"[Implements(implementation: \"I{@class.Name}.{property.Name.CapitalizeFirstLetter()}\")]" + Environment.NewLine);
            });
        }
    }
}
