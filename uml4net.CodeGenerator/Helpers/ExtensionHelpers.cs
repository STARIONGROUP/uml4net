// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionHelpers.cs" company="Starion Group S.A.">
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

namespace uml4net.CodeGenerator.Helpers
{
    using System;
    using System.Linq;
    using System.Text;

    using HandlebarsDotNet;

    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using uml4net.Classification;
    using uml4net.Extensions;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Provides Handlebars Helper registration for extension generation
    /// </summary>
    internal static class ExtensionHelpers
    {
        /// <summary>
        /// Register handlebars helper that should be use within the extension scope
        /// </summary>
        /// <param name="handlebars">The <see cref="IHandlebars" /></param>
        public static void RegisterExtensionsHelpers(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Generalization.Interfaces", (writer, context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("The context shall be a IClass");
                }

                var superClasses = @class.SuperClass.Select(x => $"I{x.Name}").ToList();

                if (@class.Namespace.Name.Contains("Extension", StringComparison.InvariantCulture) && @class.Name == "Extension")
                {
                    superClasses.Add("uml4net.Packages.IPackage");
                }

                if (superClasses.Count != 0)
                {
                    var result = $": {string.Join(", ", superClasses)}";

                    writer.WriteSafeString(result);
                }
            });

            handlebars.RegisterHelper("ExtensionHelper.IsExtensionClass", (context, _) =>
            {
                if (context.Value is not IClass umlClass)
                {
                    throw new ArgumentException("The context shall be an IClass");
                }

                return umlClass.Name == "Extension";
            });

            handlebars.RegisterHelper("Class.QueryAllNonDerivedNonReadOnlyNonAssociationProperties", (_, arguments) =>
            {
                if (arguments.Count() != 1)
                {
                    throw new ArgumentException("The Class.QueryAllNonDerivedNonReadOnlyNonAssociationProperties requires to have 1 argument");
                }

                if (arguments.Single() is not IClass umlClass)
                {
                    throw new ArgumentException("The Class.QueryAllNonDerivedNonReadOnlyNonAssociationProperties argument should be an IClass");
                }

                var properties = umlClass.QueryAllProperties()
                    .Where(x => !x.IsComposite)
                    .Where(x => !x.IsDerived)
                    .Where(x => x.Association == null)
                    .OrderBy(x => x.Name);

                return properties;
            });

            handlebars.RegisterHelper("Property.WriteXmlAttributeForExtensionReader", (writer, _, arguments) =>
            {
                if (arguments.Count() != 1)
                {
                    throw new ArgumentException("The Property.WriteXmlAttributeForExtensionReader requires to have argument");
                }

                if (arguments.ElementAt(0) is not IProperty property)
                {
                    throw new ArgumentException("The Property.WriteXmlAttributeForExtensionReader argument should be an IProperty");
                }

                var propertyName = property.Name.CapitalizeFirstLetter();
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"var {propertyName.LowerCaseFirstLetter()}Value = xmlReader.GetAttribute(\"{property.Name}\");");

                if (property.QueryCSharpTypeName() == "string")
                {
                    stringBuilder.AppendLine($"poco.{propertyName} = {propertyName.LowerCaseFirstLetter()}Value;");
                }
                else
                {
                    stringBuilder.AppendLine($"if(!string.IsNullOrWhiteSpace({propertyName.LowerCaseFirstLetter()}Value))");
                    stringBuilder.AppendLine("{");

                    if (property.QueryIsEnum())
                    {
                        stringBuilder.AppendLine($"poco.{propertyName} = ({property.QueryCSharpTypeName()})Enum.Parse(typeof({property.QueryCSharpTypeName()}), {propertyName.LowerCaseFirstLetter()}Value);");
                    }
                    else
                    {
                        stringBuilder.AppendLine($"poco.{propertyName} = {property.QueryCSharpTypeName()}.Parse({propertyName.LowerCaseFirstLetter()}Value);");
                    }

                    stringBuilder.AppendLine($"}}{Environment.NewLine}");
                }
                
                writer.WriteSafeString(stringBuilder.ToString());
            });

            handlebars.RegisterHelper("Class.DoesExtensionReferencesXmiElement", (_, arguments) =>
            {
                if (arguments.Count() != 1)
                {
                    throw new ArgumentException("The Class.QueryAllNonDerivedNonReadOnlyNonAssociationProperties requires to have 1 argument");
                }

                if (arguments.Single() is not IClass umlClass)
                {
                    throw new ArgumentException("The Class.QueryAllNonDerivedNonReadOnlyNonAssociationProperties argument should be an IClass");
                }

                var properties = umlClass.QueryAllProperties();

                return properties.Any(x => x.Association != null && x.Type is IInterface && x.Type.Name == "XmiElement");
            });
            
            handlebars.RegisterHelper("Class.QueryAllAssociationPropertiesExceptInterfaces", (_, arguments) =>
            {
                if (arguments.Count() != 1)
                {
                    throw new ArgumentException("The Class.QueryAllAssociationPropertiesExceptInterfaces requires to have 1 argument");
                }

                if (arguments.Single() is not IClass umlClass)
                {
                    throw new ArgumentException("The Class.QueryAllAssociationPropertiesExceptInterfaces argument should be an IClass");
                }

                var properties = umlClass.QueryAllProperties()
                    .Where(x => !x.IsDerived)
                    .Where(x => x.Association != null && x.Type is not IInterface)
                    .OrderBy(x => x.Name);

                return properties;
            });
            
            handlebars.RegisterHelper("Property.WriteXmlReferenceForExtensionReader", (writer, _, arguments) =>
            {
                if (arguments.Count() != 1)
                {
                    throw new ArgumentException("The Property.WriteXmlAttributeForExtensionReader requires to have argument");
                }

                if (arguments.ElementAt(0) is not IProperty property)
                {
                    throw new ArgumentException("The Property.WriteXmlAttributeForExtensionReader argument should be an IProperty");
                }
                
                var propertyName = property.Name.CapitalizeFirstLetter();
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"case \"{property.Name}\":");
                stringBuilder.AppendLine("{");
                var classOwner = (IClass)property.Owner;

                var propertyTypeName = property.Type is IClass { IsAbstract: true } ? $"I{property.QueryCSharpTypeName()}" : property.QueryCSharpTypeName();
                propertyTypeName = propertyTypeName == "Attribute" ? $"{classOwner.Namespace.Name}.{propertyTypeName}" : propertyTypeName;
                
                if (property.QueryIsEnumerable())
                {
                    var reader = $"{property.Name}Reader";

                    stringBuilder.AppendLine($"using var {reader} = xmlReader.ReadSubtree();");

                    stringBuilder.AppendLine($"{Environment.NewLine}while({reader}.Read())");
                    stringBuilder.AppendLine("{");
                    stringBuilder.AppendLine($"if({reader}.NodeType != XmlNodeType.Element || {reader}.LocalName == \"{property.Name}\")");
                    stringBuilder.AppendLine("{");
                    stringBuilder.AppendLine("continue;");
                    stringBuilder.AppendLine($"}}{Environment.NewLine}");

                    stringBuilder.AppendLine($"poco.{propertyName}.Add(this.ExtensionContentReaderFacade.QueryExtensionContent<{propertyTypeName}>({reader}, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory));");
                    stringBuilder.AppendLine($"}}{Environment.NewLine}");
                }
                else
                {
                    stringBuilder.AppendLine($"poco.{propertyName} = this.ExtensionContentReaderFacade.QueryExtensionContent<{propertyTypeName}>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);");
                }
                
                stringBuilder.AppendLine("break;");
                stringBuilder.AppendLine("}");
                
                writer.WriteSafeString(stringBuilder.ToString());
            });
        }
    }
}
