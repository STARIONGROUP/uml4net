// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyHelper.cs" company="Starion Group S.A.">
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
    using System.Linq;
    using System.Text;

    using HandlebarsDotNet;

    using uml4net.SimpleClassifiers;
    using uml4net.Extensions;
    using uml4net.Classification;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// A handlebars block helper for the <see cref="IProperty"/> interface
    /// </summary>
    public static class PropertyHelper
    {
        /// <summary>
        /// Registers the <see cref="PropertyHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterPropertyHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Property.QueryIsEnumerable", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsEnumerable}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsEnumerable();
            });
            
            handlebars.RegisterHelper("Property.IsEnumerable", (output, options, context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.IsEnumerable}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                var isEnumerable = property.QueryIsEnumerable();

                if (isEnumerable)
                {
                    options.Template(output, context);
                }
            });

            handlebars.RegisterHelper("Property.QueryStructuralFeatureNameEqualsEnclosingType", (context, arguments) =>
            {
                if (arguments.Length != 2)
                {
                    throw new HandlebarsException("{{#Property.QueryStructuralFeatureNameEqualsEnclosingType}} helper must have exactly two arguments");
                }

                var property = arguments.Single() as IProperty;
                var @class = arguments[1] as IClass;

                return property.QueryStructuralFeatureNameEqualsEnclosingType(@class);
            });

            handlebars.RegisterHelper("Property.NameEqualsEnclosingType", (output, options, context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.NameEqualsEnclosingType}} helper must have exactly two arguments");
                }

                var property = arguments.Single() as IProperty;
                var @class = arguments[1] as IClass;

                var nameEqualsEnclosingType = property.QueryStructuralFeatureNameEqualsEnclosingType(@class);

                if (nameEqualsEnclosingType)
                {
                    options.Template(output, context);
                }
            });

            handlebars.RegisterHelper("Property.QueryIsEnum", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsEnum}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsEnum();
            });

            handlebars.RegisterHelper("Property.IsEnum", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.IsEnum}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsEnum();
            });

            handlebars.RegisterHelper("Property.QueryIsBool", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsBool}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsBool();
            });

            handlebars.RegisterHelper("Property.QueryIsNumeric", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsNumeric}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsNumeric();
            });

            handlebars.RegisterHelper("Property.QueryIsInteger", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsInteger}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property?.Type?.Name.ToLowerInvariant().Contains("int");
            });

            handlebars.RegisterHelper("Property.QueryIsFloat", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsFloat}} helper must have exactly one argument");
                }

                var typeName = (arguments.Single() as IProperty)?.Type?.Name?.ToLowerInvariant();
                return typeName is not null && (typeName.Contains("single") || typeName.Contains("float"));
            });
            
            handlebars.RegisterHelper("Property.QueryIsDouble", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsDouble}} helper must have exactly one argument");
                }

                var typeName = (arguments.Single() as IProperty)?.Type?.Name?.ToLowerInvariant();
                return typeName?.Contains("double");
            });

            handlebars.RegisterHelper("Property.QueryIsDateTime", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsDouble}} helper must have exactly one argument");
                }

                var typeName = (arguments.Single() as IProperty)?.Type?.Name?.ToLowerInvariant();
                return typeName?.Contains("date");
            });

            handlebars.RegisterHelper("Property.QueryHasDefaultValue", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryHasDefaultValue}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryHasDefaultValue();
            });

            handlebars.RegisterHelper("Property.QueryIsContainment", (context, arguments) =>
            {
                if (!(context.Value is IProperty property))
                    throw new ArgumentException("supposed to be IProperty");

                return property.QueryIsContainment();
            });

            handlebars.RegisterHelper("Property.WriteTypeName", (writer, context, parameters) =>
            {
                if (!(context.Value is IProperty property))
                    throw new ArgumentException("supposed to be IProperty");

                var typeName = property.QueryTypeName();

                writer.WriteSafeString($"{typeName}");
            });

            handlebars.RegisterHelper("Property.WriteUpperValue", (writer, context, arguments) =>
            {
                if (!(context.Value is IProperty property))
                    throw new ArgumentException("supposed to be IProperty");

                var upperValue = property.QueryUpperValue();

                writer.WriteSafeString($"{upperValue}");
            });

            handlebars.RegisterHelper("Property.WriteForInterface", (writer, context, arguments) =>
            {
                if (!(context.Value is IProperty property))
                    throw new ArgumentException("supposed to be IProperty");

                var sb = new StringBuilder();
                sb.Append(property.Visibility.ToString().ToLower());
                sb.Append(" ");

                if (property.RedefinedProperty.Any())
                {
                    sb.Append("new ");
                }

                if (property.Type is IDataType && property.QueryIsEnumerable() && !property.QueryIsContainment())
                {
                    sb.Append($"List<{property.QueryCSharpTypeName()}>");
                    sb.Append(" ");
                }
                else if(property.QueryIsEnumerable() && !property.QueryIsContainment())
                {
                    sb.Append($"List<I{property.QueryTypeName()}>");
                    sb.Append(" ");
                }
                else if(property.QueryIsContainment())
                {
                    sb.Append($"IContainerList<I{ property.QueryTypeName() }>");
                    sb.Append(" ");
                }
                else if (property.Type is IDataType)
                {
                    sb.Append($"{property.QueryCSharpTypeName()}");
                    sb.Append(" ");
                }
                else
                {
                    sb.Append($"I{property.QueryTypeName()}");
                    sb.Append(" ");
                }

                var propertyName = property.Name.CapitalizeFirstLetter();

                var owner = property.Owner as IClass;
                if (owner.Name.ToLowerInvariant() == property.Name.ToLowerInvariant())
                {
                    propertyName = propertyName + "s";
                }

                sb.Append(propertyName);
                sb.Append(" ");
                
                if (property.IsReadOnly || property.IsDerived)
                {
                    sb.Append("{ get; }");
                }
                else
                {
                    sb.Append("{ get; set; }");
                }

                writer.WriteSafeString(sb + Environment.NewLine);
            });

            handlebars.RegisterHelper("Property.WriteForClass", (writer, context, parameters) =>
            {
                if (parameters.Length != 2)
                {
                    throw new HandlebarsException("{{#Decorator.WriteRedefinedByPropertyAttribute}} helper must have exactly two arguments");
                }

                var property = parameters[0] as IProperty;
                var @class = parameters[1] as IClass;

                var sb = new StringBuilder();

                var isRedefinedByProperty = property.TryQueryRedefinedByProperty(@class, out _);

                if (!isRedefinedByProperty)
                {
                    sb.Append(property.Visibility.ToString().ToLower());
                    sb.Append(" ");

                    if (property.RedefinedProperty.Any())
                    {
                        sb.Append("new ");
                    }
                }

                sb.Append(property.QueryCSharpFullTypeName());
                sb.Append(" ");

                var owner = property.Owner as IClass;

                if (isRedefinedByProperty)
                {
                    sb.Append($"I{owner.Name}."); 
                }

                var propertyName = property.Name.CapitalizeFirstLetter();
                
                if (owner.Name.ToLowerInvariant() == property.Name.ToLowerInvariant() || @class.Name.ToLowerInvariant() == property.Name.ToLowerInvariant())
                {
                    propertyName = propertyName + "s";
                }

                sb.Append(propertyName);
                sb.Append(" ");

                if (property.IsReadOnly || property.IsDerived)
                {
                    if (isRedefinedByProperty)
                    {
                        sb.Append($" => {owner.Name}Extensions.Query{property.Name.CapitalizeFirstLetter()}(this);");
                    }
                    else
                    {
                        sb.Append($" => this.Query{property.Name.CapitalizeFirstLetter()}();");
                    }
                }
                else
                {
                    if (!isRedefinedByProperty)
                    {
                        if (property.QueryIsEnumerable() && !property.QueryIsContainment())
                        {
                            sb.Append("{ get; set; } = new();");
                        }
                        else if (property.QueryIsContainment())
                        {
                            propertyName = property.Name;

                            switch (propertyName)
                            {
                                case "class":
                                case "namespace":
                                case "object":
                                case "using":
                                    propertyName = $"@{propertyName}";
                                    break;
                            }

                            sb.AppendLine("{");
                            sb.AppendLine($"get => this.{propertyName} ??= new ContainerList<I{property.QueryTypeName()}>(this);");
                            sb.AppendLine($"set => this.{propertyName} = value;");
                            sb.AppendLine("}");
                            sb.AppendLine();
                            sb.AppendLine("/// <summary>");
                            sb.AppendLine($"/// Backing field for <see cref=\"{property.Name.CapitalizeFirstLetter()}\"/>");
                            sb.AppendLine("/// </summary>");
                            sb.Append($"private IContainerList<I{property.QueryTypeName()}> {propertyName};");
                        }
                        else
                        {
                            sb.Append("{ get; set; }");
                        }
                    }
                    else
                    {
                        sb.Append("{ get; set; }");
                    }
                }

                writer.WriteSafeString(sb + Environment.NewLine);
            });
        }
    }
}
