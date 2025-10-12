// -------------------------------------------------------------------------------------------------
//  <copyright file="TypeExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//    Copyright 2019-2025 Starion Group S.A.
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

namespace uml4net.Extensions.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    
    using uml4net;
    using uml4net.CommonStructure;
    using uml4net.Extensions;
    using uml4net.Packages;
    using uml4net.Values;

    [TestFixture]
    public class TypeExtensionsTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            TypeExtensions.ResetCSharpTypeMappingsToDefault();
        }

        private class TestType : IType
        {
            public string Name { get; set; }

            public IPackage Package { get; set; }

            public IContainerList<IComment> OwnedComment { get; set; }

            public IContainerList<IElement> OwnedElement => null;

            public IElement Owner => null;
            public IElement Possessor { get; set; }

            public List<IDependency> ClientDependency => new();

            public IContainerList<IStringExpression> NameExpression { get; set; }

            public INamespace Namespace => null;

            public string QualifiedName => null;

            public VisibilityKind Visibility { get; set; }

            public ITemplateParameter OwningTemplateParameter { get; set; }

            public ITemplateParameter TemplateParameter { get; set; }
            public string XmiId { get; set; }
            public string DocumentName { get; set; }
            public string XmiNamespaceUri { get; set; }
            public string XmiGuid { get; set; }
            public string XmiType { get; set; }
            public string FullyQualifiedIdentifier { get; }
            public Dictionary<string, string> SingleValueReferencePropertyIdentifiers { get; set; }
            public Dictionary<string, List<string>> MultiValueReferencePropertyIdentifiers { get; set; }
            public IXmiElementCache Cache { get; set; }
            public List<IElement> Extensions { get; set; }
        }

        [Test]
        public void Verify_that_QueryCSharpTypeName_returns_mapped_value_for_default_type()
        {
            var type = new TestType { Name = "Boolean" };

            var result = type.QueryCSharpTypeName();

            Assert.That(result, Is.EqualTo("bool"));
        }

        [Test]
        public void Verify_that_QueryCSharpTypeName_returns_original_value_when_mapping_not_found()
        {
            var type = new TestType { Name = "Unknown" };

            var result = type.QueryCSharpTypeName();

            Assert.That(result, Is.EqualTo("Unknown"));
        }

        [Test]
        public void Verify_that_QueryCSharpTypeName_returns_empty_string_when_type_is_null()
        {
            IType type = null;

            var result = type.QueryCSharpTypeName();

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Verify_that_AddOrOverwriteCSharpTypeMappings_handles_add_and_overwrite_scenarios()
        {
            TypeExtensions.AddOrOverwriteCSharpTypeMappings(("Custom", "decimal"));

            var customType = new TestType { Name = "Custom" };
            Assert.That(customType.QueryCSharpTypeName(), Is.EqualTo("decimal"));

            TypeExtensions.AddOrOverwriteCSharpTypeMappings(("Custom", "decimal"));
            Assert.That(customType.QueryCSharpTypeName(), Is.EqualTo("decimal"));

            TypeExtensions.AddOrOverwriteCSharpTypeMappings(("Custom", "long"));
            Assert.That(customType.QueryCSharpTypeName(), Is.EqualTo("long"));
        }

        [Test]
        public void Verify_that_AddOrOverwriteCSharpTypeMappings_overrides_default_mapping()
        {
            TypeExtensions.AddOrOverwriteCSharpTypeMappings(("Boolean", "bool?"));

            var type = new TestType { Name = "Boolean" };

            Assert.That(type.QueryCSharpTypeName(), Is.EqualTo("bool?"));
        }

        [Test]
        public void Verify_that_ResetCSharpTypeMappingsToDefault_resets_custom_mappings()
        {
            TypeExtensions.AddOrOverwriteCSharpTypeMappings(("Boolean", "bool?"));

            TypeExtensions.ResetCSharpTypeMappingsToDefault();

            var type = new TestType { Name = "Boolean" };

            Assert.That(type.QueryCSharpTypeName(), Is.EqualTo("bool"));
        }

        [Test]
        public void Verify_that_AddOrOverwriteCSharpTypeMappings_throws_when_invalid_input()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => TypeExtensions.AddOrOverwriteCSharpTypeMappings(null), Throws.TypeOf<ArgumentNullException>());
                Assert.That(() => TypeExtensions.AddOrOverwriteCSharpTypeMappings(Array.Empty<(string Key, string Value)>()), Throws.TypeOf<ArgumentNullException>());
                Assert.That(() => TypeExtensions.AddOrOverwriteCSharpTypeMappings((null, "int")), Throws.TypeOf<ArgumentNullException>());
                Assert.That(() => TypeExtensions.AddOrOverwriteCSharpTypeMappings(("Foo", null)), Throws.TypeOf<ArgumentNullException>());
            }
        }
    }
}
