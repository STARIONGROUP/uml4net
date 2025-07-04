﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyHelper.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using HandlebarsDotNet;

    using uml4net.SimpleClassifiers;
    using uml4net.Extensions;
    using uml4net.Classification;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;

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
            // Queries whether the Property is an IEnumerable
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

            handlebars.RegisterHelper("Property.QueryStructuralFeatureNameEqualsEnclosingType", (_, arguments) =>
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

            // Queries whether the Property is an Enum (Enumeration)
            handlebars.RegisterHelper("Property.QueryIsEnum", (_, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsEnum}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsEnum();
            });

            // Queries whether the Property is of type bool (Boolean)
            handlebars.RegisterHelper("Property.QueryIsBool", (_, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsBool}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsBool();
            });

            // Queries whether the Property has a numeric Type (e.g. int, float, double...)
            handlebars.RegisterHelper("Property.QueryIsNumeric", (_, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsNumeric}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsNumeric();
            });

            // Queries whether the property is of type integer (contains the string "int" in its type name)
            handlebars.RegisterHelper("Property.QueryIsInteger", (_, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsInteger}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property?.Type?.Name.ToLowerInvariant().Contains("int");
            });

            // Queries whether the property is of type integer (contains the string "single" or "float" in its type name
            handlebars.RegisterHelper("Property.QueryIsFloat", (_, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsFloat}} helper must have exactly one argument");
                }

                var typeName = (arguments.Single() as IProperty)?.Type?.Name?.ToLowerInvariant();
                return typeName is not null && (typeName.Contains("single") || typeName.Contains("float"));
            });

            // Queries whether the property is of type integer (contains the string "double" or "real" in its type name)
            handlebars.RegisterHelper("Property.QueryIsDouble", (_, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsDouble}} helper must have exactly one argument");
                }

                var typeName = (arguments.Single() as IProperty)?.Type?.Name?.ToLowerInvariant();
                return typeName is not null && (typeName.Contains("double") || typeName.Contains("real"));
            });

            // Queries whether the property is of type DateTime (contains the string "date" in its type name)
            handlebars.RegisterHelper("Property.QueryIsDateTime", (_, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsDateTime}} helper must have exactly one argument");
                }

                var typeName = (arguments.Single() as IProperty)?.Type?.Name?.ToLowerInvariant();
                return typeName?.Contains("date");
            });

            // Queries whether the property is of type string (contains the string "string" in its type name)
            handlebars.RegisterHelper("Property.QueryIsString", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsString}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsString();
            });

            // Queries whether the Property has a default value specified
            handlebars.RegisterHelper("Property.QueryHasDefaultValue", (_, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryHasDefaultValue}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryHasDefaultValue();
            });

            // Queries whether the Property is a Composite property (AggregationKind.Composite)
            handlebars.RegisterHelper("Property.IsComposite", (context, _) =>
            {
                if (!(context.Value is IProperty property))
                {
                    throw new ArgumentException("{{#Property.IsComposite}} - supposed to be IProperty");
                }

                return property.IsComposite;
            });

            // Queries whether the Property is redefined
            handlebars.RegisterHelper("Property.IsRedefined", (context, parameters) =>
            {
                if (parameters.Length != 2)
                {
                    throw new HandlebarsException("{{#Property.IsRedefined}} helper must have exactly two arguments");
                }

                var property = parameters[0] as IProperty;
                var @class = parameters[1] as IClass;

                return property.TryQueryRedefinedByProperty(@class, out _);
            });

            // Queries whether the Property is subsetted
            handlebars.RegisterHelper("Property.QueryIsSubsetted", (context, _) =>
            {
                if (!(context.Value is IProperty property))
                {
                    throw new ArgumentException("{{#Property.QueryIsSubsetted}} - supposed to be IProperty");
                }

                return property.QueryIsSubsetted;
            });

            // Queries whether the Property is Derived, DerivedUnion or ReadOnly
            handlebars.RegisterHelper("Property.QueryIsDerivedOrDerivedUnionOrReadOnly", (_, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsString}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                if (property.IsDerived || property.IsDerivedUnion || property.IsReadOnly)
                {
                    return true;
                }

                return false;
            });

            // Queries whether the Property takes part in a many-to-many relationship
            handlebars.RegisterHelper("Property.QueryIsMemberOfManyToMany", (_, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsMemberOfManyToMany}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsMemberOfManyToMany();
            });

            handlebars.RegisterHelper("Property.WriteManyToManyAndOpposite", (writer, context, _) =>
            {
                if (!(context.Value is IProperty property))
                {
                    throw new HandlebarsException("Property.WriteManyToManyAndOpposite - supposed to be IProperty");
                }

                // only reference types can be part of a many-to-many relationship
                if (property.QueryIsDataType())
                {
                    return;
                }

                var thisUpperValue = property.QueryUpperValue();

                if (thisUpperValue < 2)
                {
                    return;
                }

                var opposite = property.Opposite;

                // in case a reference property is defined on a class as an owned attribute not
                // using an association AND it has a multiplicity upper-value larger than 1 we assume it
                // takes part in a many-to-many relationship
                if (opposite == null)
                {
                    writer.WriteSafeString($"{{many-to-many}}");
                    return;
                }

                // When the property is part of an association(binary relationship) and in case the
                // upper value is larger than 1 on both ends, this property takes part in a many-to-many
                // relationship
                if (opposite.QueryUpperValue() > 1)
                {
                    writer.WriteSafeString($"{{many-to-many:{opposite.QueryTypeName()}.{opposite.Name}}}");
                }
            });

            handlebars.RegisterHelper("Property.WriteTypeName", (writer, context, _) =>
            {
                if (!(context.Value is IProperty property))
                {
                    throw new ArgumentException("supposed to be IProperty");
                }

                var typeName = property.QueryTypeName();

                writer.WriteSafeString($"{typeName}");
            });

            handlebars.RegisterHelper("Property.WriteUpperValue", (writer, context, _) =>
            {
                if (!(context.Value is IProperty property))
                {
                    throw new ArgumentException("supposed to be IProperty");
                }

                var upperValue = property.QueryUpperValue();

                writer.WriteSafeString($"{upperValue}");
            });

            handlebars.RegisterHelper("Property.WriteForInterface", (writer, context, _) =>
            {
                if (!(context.Value is IProperty property))
                {
                    throw new ArgumentException("supposed to be IProperty");
                }

                var sb = new StringBuilder();
                sb.Append(property.Visibility.ToString().ToLower());
                sb.Append(" ");

                if (property.RedefinedProperty.Any())
                {
                    sb.Append("new ");
                }

                if (property.Type is IDataType && property.QueryIsEnumerable() && !property.IsComposite)
                {
                    sb.Append($"List<{property.QueryCSharpTypeName()}>");
                    sb.Append(" ");
                }
                else if(property.QueryIsEnumerable() && !property.IsComposite)
                {
                    sb.Append($"List<I{property.QueryTypeName()}>");
                    sb.Append(" ");
                }
                else if(property.IsComposite)
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

            handlebars.RegisterHelper("Property.WriteForClass", (writer, _, parameters) =>
            {
                if (parameters.Length != 2)
                {
                    throw new HandlebarsException("{{#Property.WriteForClass}} helper must have exactly two arguments");
                }

                var property = parameters[0] as IProperty;
                var @class = parameters[1] as IClass;

                var sb = new StringBuilder();

                var isRedefinedByProperty = property.TryQueryRedefinedByProperty(@class, out var redefiningProperty);

                if (!isRedefinedByProperty)
                {
                    sb.Append(property.Visibility.ToString().ToLower(CultureInfo.InvariantCulture));
                    sb.Append(" ");
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

                if (property.IsReadOnly || property.IsDerived || property.IsDerivedUnion)
                {
                    if (isRedefinedByProperty)
                    {
                        var owningClass = redefiningProperty.Owner as IClass;

                        sb.Append($"=> throw new InvalidOperationException(\"Redefined by property I{owningClass.Name}.{redefiningProperty.Name.CapitalizeFirstLetter()}\");");
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
                        if (property.QueryIsEnumerable() && !property.IsComposite)
                        {
                            sb.Append("{ get; set; } = new();");
                        }
                        else if (property.IsComposite)
                        {
                            propertyName = property.Name;

                            switch (propertyName)
                            {
                                case "class":
                                case "interface":
                                case "namespace":
                                case "object":
                                case "type":
                                case "using":
                                    propertyName = $"@{propertyName}";
                                    break;
                                default:
                                    // nothing to do here
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

                            if (property.QueryIsDefaultValueDifferentThanDefault())
                            {
                                var defaultProperty = property.DefaultValue.FirstOrDefault();
                                sb.Append(defaultProperty is ILiteralUnlimitedNatural or ILiteralString ? $" = \"{property.QueryDefaultValueAsString()}\";" : $" = {property.QueryDefaultValueAsString()};");
                            }
                        }
                    }
                    else
                    {
                        var owningClass = redefiningProperty.Owner as IClass;

                        sb.AppendLine("{");
                        sb.AppendLine($"    get => throw new InvalidOperationException(\"Redefined by property I{owningClass.Name}.{redefiningProperty.Name.CapitalizeFirstLetter()}\");");
                        sb.AppendLine($"    set => throw new InvalidOperationException(\"Redefined by property I{owningClass.Name}.{redefiningProperty.Name.CapitalizeFirstLetter()}\");");
                        sb.Append("}");
                    }
                }

                writer.WriteSafeString(sb + Environment.NewLine);
            });

            handlebars.RegisterHelper("Property.WriteXmlAttributeForXmiReader", (writer, context, parameters) =>
            {
                if (parameters.Length != 2)
                {
                    throw new HandlebarsException("{{#Property.WriteXmlAttributeForXmiReader}} helper must have exactly two arguments");
                }

                var property = parameters[0] as IProperty;
                var @class = parameters[1] as IClass;

                if (property == null || @class == null)
                {
                    throw new ArgumentNullException();
                }

                if (property.IsDerived || property.IsDerivedUnion || property.IsReadOnly)
                {
                    return;
                }

                var isRedefinedByProperty = property.TryQueryRedefinedByProperty(@class, out _);

                if (isRedefinedByProperty)
                {
                    return;
                }

                var sb = new StringBuilder();

                if (!property.IsComposite)
                {
                    if (property.QueryIsReferenceProperty() && !property.QueryIsEnumerable())
                    {
                        sb.AppendLine($"var {property.Name}XmlAttribute = xmlReader.GetAttribute(\"{property.Name}\");");
                        sb.AppendLine($"{Environment.NewLine}if (!string.IsNullOrEmpty({property.Name}XmlAttribute))");
                        sb.AppendLine("{");
                        sb.AppendLine($"poco.SingleValueReferencePropertyIdentifiers.Add(\"{property.Name}\", {property.Name}XmlAttribute);");
                        sb.AppendLine("}");

                        writer.WriteSafeString(sb + Environment.NewLine);
                        return;
                    }

                    if (property.QueryIsReferenceProperty() && property.QueryIsEnumerable())
                    {
                        sb.AppendLine($"var {property.Name}XmlAttribute = xmlReader.GetAttribute(\"{property.Name}\");");
                        sb.AppendLine($"{Environment.NewLine}if (!string.IsNullOrEmpty({property.Name}XmlAttribute))");
                        sb.AppendLine("{");
                        sb.AppendLine($"var {property.Name}XmlAttributeValues = {property.Name}XmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();");
                        sb.AppendLine($"poco.MultiValueReferencePropertyIdentifiers.Add(\"{property.Name}\", {property.Name}XmlAttributeValues);");
                        sb.AppendLine("}");

                        writer.WriteSafeString(sb + Environment.NewLine);
                        return;
                    }

                    if (property.QueryIsPrimitiveType() && property.QueryIsEnumerable())
                    {
                        var cSharpTypeName = property.QueryCSharpTypeName();

                        switch (cSharpTypeName)
                        {
                            case "bool":
                            case "double":
                            case "int":
                                sb.AppendLine($"var {property.Name}XmlAttribute = xmlReader.GetAttribute(\"{property.Name}\");");
                                sb.AppendLine($"{Environment.NewLine}if (!string.IsNullOrEmpty({property.Name}XmlAttribute))");
                                sb.AppendLine("{");
                                sb.AppendLine($"    var {property.Name}XmlAttributeValues = {property.Name}XmlAttribute.Split(this.XmiReaderSettings.ValueSeparator);");
                                sb.AppendLine($"    foreach (var {property.Name}XmlAttributeValue in {property.Name}XmlAttributeValues)");
                                sb.AppendLine("    {");
                                sb.AppendLine($"        poco.{property.Name.CapitalizeFirstLetter()}.Add({cSharpTypeName}.Parse({property.Name}XmlAttributeValue));");
                                sb.AppendLine("    }");
                                sb.AppendLine("}");
                                break;
                            case "string":
                                sb.AppendLine($"var {property.Name}XmlAttribute = xmlReader.GetAttribute(\"{property.Name}\");");
                                sb.AppendLine($"{Environment.NewLine}if (!string.IsNullOrEmpty({property.Name}XmlAttribute))");
                                sb.AppendLine("{");
                                sb.AppendLine($"    var {property.Name}XmlAttributeValues = {property.Name}XmlAttribute.Split(this.XmiReaderSettings.ValueSeparator);");
                                sb.AppendLine($"    foreach (var {property.Name}XmlAttributeValue in {property.Name}XmlAttributeValues)");
                                sb.AppendLine("    {");
                                sb.AppendLine($"        poco.{property.Name.CapitalizeFirstLetter()}.Add({property.Name}XmlAttributeValue);");
                                sb.AppendLine("    }");
                                sb.AppendLine("}");
                                break;
                            default:
                                throw new NotSupportedException($"{property.Name} has a Primitive Type that is not supported: {cSharpTypeName}");
                        }

                        writer.WriteSafeString(sb + Environment.NewLine);
                        return;
                    }

                    if (property.QueryIsDataType() && property.QueryIsEnumerable())
                    {
                        sb.AppendLine($"var {property.Name}XmlAttribute = xmlReader.GetAttribute(\"{property.Name}\");");
                        sb.AppendLine($"{Environment.NewLine}if (!string.IsNullOrEmpty({property.Name}XmlAttribute))");
                        sb.AppendLine("{");
                        sb.AppendLine($"throw new NotSupportedException(\"DataTypes encoded as XML attributes are not (yet) supported: {@class.Name}.{property.Name}\");");
                        sb.AppendLine("}");

                        writer.WriteSafeString(sb + Environment.NewLine);
                        return;
                    }

                    if (property.QueryIsPrimitiveType() && !property.QueryIsEnumerable())
                    {
                        var cSharpTypeName = property.QueryCSharpTypeName();

                        switch (cSharpTypeName)
                        {
                            case "bool":
                            case "double":
                            case "int":
                                sb.AppendLine($"var {property.Name}XmlAttribute = xmlReader.GetAttribute(\"{property.Name}\");");
                                sb.AppendLine($"{Environment.NewLine}if (!string.IsNullOrEmpty({property.Name}XmlAttribute))");
                                sb.AppendLine("{");
                                sb.AppendLine($"poco.{property.Name.CapitalizeFirstLetter()} = {cSharpTypeName}.Parse({property.Name}XmlAttribute);");
                                sb.AppendLine("}");
                                break;
                            case "string":
                                sb.AppendLine($"poco.{property.Name.CapitalizeFirstLetter()} = xmlReader.GetAttribute(\"{property.Name}\");");
                                break;
                            default:
                                throw new NotSupportedException($"{property.Name} has a Primitive Type that is not supported: {cSharpTypeName}");
                        }

                        writer.WriteSafeString(sb + Environment.NewLine);
                        return;
                    }

                    if (property.QueryIsEnum())
                    {
                        var typeName = property.QueryTypeName();

                        sb.AppendLine($"var {property.Name}XmlAttribute = xmlReader.GetAttribute(\"{property.Name}\");");
                        sb.AppendLine($"{Environment.NewLine}if (!string.IsNullOrEmpty({property.Name}XmlAttribute))");
                        sb.AppendLine("{");
                        sb.AppendLine($"poco.{property.Name.CapitalizeFirstLetter()} = ({typeName})Enum.Parse(typeof({typeName}), {property.Name}XmlAttribute, true);");
                        sb.AppendLine("}");

                        writer.WriteSafeString(sb + Environment.NewLine);
                        return;
                    }
                }
                else
                {
                    // contained objects are only handled as contained XML elements
                    return;
                }

                throw new NotSupportedException($"{@class.Name}.{property.Name}");
            });

            handlebars.RegisterHelper("Property.WriteXmlElementForXmiReader", (writer, context, parameters) =>
            {
                if (parameters.Length != 2 && parameters.Length != 3)
                {
                    throw new HandlebarsException("{{#Property.WriteXmlElementForXmiReader}} helper must have two or 3 arguments arguments");
                }

                var property = parameters[0] as IProperty;
                var @class = parameters[1] as IClass;

                if (property == null || @class == null)
                {
                    throw new ArgumentNullException();
                }

                var isForExtension = false;

                if (parameters.Length == 3)
                {
                    isForExtension = (bool)parameters[2];
                }

                if (property.IsDerived || property.IsDerivedUnion || property.IsReadOnly)
                {
                    return;
                }

                var isRedefinedByProperty = property.TryQueryRedefinedByProperty(@class, out _);

                if (isRedefinedByProperty)
                {
                    return;
                }

                var sb = new StringBuilder();

                sb.AppendLine($"case \"{property.Name}\":");

                if (property.IsComposite)
                {
                    if (property.QueryIsPrimitiveType())
                    {
                        sb.AppendLine($"var {property.Name}Value = xmlReader.ReadElementContentAsString();");
                        sb.AppendLine($"poco.{property.Name.CapitalizeFirstLetter()}.Add({property.Name}Value);");
                        sb.AppendLine("break;");
                        
                        writer.WriteSafeString(sb);

                        return;
                    }

                    if (property.QueryIsEnum())
                    {
                        throw new NotImplementedException("contained enumeration is not yet supported");
                    }

                    if (property.QueryIsReferenceProperty() && (property.SubsettedProperty.Count == 0))
                    {
                        sb.AppendLine(property.QueryIsTypeAbstract()
                            ? $"var {property.Name}Value = (I{property.QueryTypeName()})this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory);"
                            : $"var {property.Name}Value = (I{property.QueryTypeName()})this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, \"{(isForExtension? "" : "uml:")}{property.QueryTypeName()}\"{(isForExtension?", true":"")});");

                        sb.AppendLine($"poco.{property.Name.CapitalizeFirstLetter()}.Add({property.Name}Value);");
                        
                        sb.AppendLine("break;");

                        writer.WriteSafeString(sb);

                        return;
                    }

                    if (property.QueryIsReferenceProperty() && property.SubsettedProperty.Count > 0)
                    {
                        if (property.SubsettedProperty.Any(x => x.IsDerived || x.IsDerivedUnion || x.IsReadOnly))
                        {
                            sb.AppendLine(property.QueryIsTypeAbstract()
                                ? $"var {property.Name}Value = (I{property.QueryTypeName()})this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory);"
                                : $"var {property.Name}Value = (I{property.QueryTypeName()})this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, \"{(isForExtension? "" : "uml:")}{property.QueryTypeName()}\"{(isForExtension?", true":"")});");

                            sb.AppendLine($"poco.{property.Name.CapitalizeFirstLetter()}.Add({property.Name}Value);");
                        }
                        else
                        {
                            sb.AppendLine($"if (!this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, \"{property.Name}\"))");
                            sb.AppendLine("{");
                            sb.AppendLine($"    this.Logger.LogWarning(\"The {@class.Name}.{property.Name.CapitalizeFirstLetter()} attribute was not processed at {{DefaultLineInfo}}\", defaultLineInfo);");
                            sb.AppendLine($"}}{Environment.NewLine}");
                        }

                        sb.AppendLine("break;");
                        writer.WriteSafeString(sb);
                        return;
                    }
                }
                else
                {
                    if (property.QueryIsPrimitiveType() && property.QueryIsEnumerable())
                    {
                        var cSharpTypeName = property.QueryCSharpTypeName();

                        switch (cSharpTypeName)
                        {
                            case "bool":
                            case "double":
                            case "int":
                                sb.AppendLine($"var {property.Name}Value = xmlReader.ReadElementContentAsString();");
                                sb.AppendLine($"{Environment.NewLine}if (!string.IsNullOrEmpty({property.Name}Value))");
                                sb.AppendLine("{");
                                sb.AppendLine($"poco.{property.Name.CapitalizeFirstLetter()}.Add({cSharpTypeName}.Parse({property.Name}Value));");
                                sb.AppendLine($"}}{Environment.NewLine}");
                                break;
                            case "string":
                                sb.AppendLine($"var {property.Name}Value = xmlReader.ReadElementContentAsString();");
                                sb.AppendLine($"poco.{property.Name.CapitalizeFirstLetter()}.Add({property.Name}Value);");
                                break;
                            default:
                                throw new NotSupportedException($"{property.Name} has a Primitive Type that is not supported: {cSharpTypeName}");
                        }

                        sb.AppendLine("break;");

                        writer.WriteSafeString(sb);

                        return;
                    }

                    if (property.QueryIsPrimitiveType() && !property.QueryIsEnumerable())
                    {
                        var cSharpTypeName = property.QueryCSharpTypeName();

                        switch (cSharpTypeName)
                        {
                            case "bool":
                            case "double":
                            case "int":
                                sb.AppendLine($"var {property.Name}Value = xmlReader.ReadElementContentAsString();");
                                sb.AppendLine($"{Environment.NewLine}if (!string.IsNullOrEmpty({property.Name}Value))");
                                sb.AppendLine("{");
                                sb.AppendLine($"poco.{property.Name.CapitalizeFirstLetter()} = {cSharpTypeName}.Parse({property.Name}Value);");
                                sb.AppendLine($"}}{Environment.NewLine}");
                                break;
                            case "string":
                                sb.AppendLine($"poco.{property.Name.CapitalizeFirstLetter()} = xmlReader.ReadElementContentAsString();");
                                break;
                            default:
                                throw new NotSupportedException($"{property.Name} has a Primitive Type that is not supported: {cSharpTypeName}");
                        }

                        sb.AppendLine("break;");

                        writer.WriteSafeString(sb);

                        return;
                    }

                    if (property.QueryIsEnum())
                    {
                        var typeName = property.QueryTypeName();

                        sb.AppendLine($"var {property.Name}Value = xmlReader.ReadElementContentAsString();");
                        sb.AppendLine($"{Environment.NewLine}if (!string.IsNullOrEmpty({property.Name}Value))");
                        sb.AppendLine("{");
                        sb.AppendLine($"poco.{property.Name.CapitalizeFirstLetter()} = ({typeName})Enum.Parse(typeof({typeName}), {property.Name}Value, true);");
                        sb.AppendLine("}");

                        sb.AppendLine($"{Environment.NewLine}break;");
                        writer.WriteSafeString(sb);
                        return;
                    }

                    if (property.QueryIsReferenceProperty() && !property.QueryIsEnumerable())
                    {
                        sb.AppendLine($"this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, \"{property.Name}\");");
                        sb.AppendLine("break;");

                        writer.WriteSafeString(sb);
                        return;
                    }

                    if (property.QueryIsReferenceProperty() && property.QueryIsEnumerable())
                    {
                        sb.AppendLine($"this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, \"{property.Name}\");");
                        sb.AppendLine("break;");

                        writer.WriteSafeString(sb);
                        return;
                    }

                    throw new NotSupportedException($"{@class.Name}.{property.Name}");
                }

                throw new NotSupportedException($"{@class.Name}.{property.Name}");
            });
        }
    }
}
