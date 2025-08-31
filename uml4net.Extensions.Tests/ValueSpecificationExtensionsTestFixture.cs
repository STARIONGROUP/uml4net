// -------------------------------------------------------------------------------------------------
//  <copyright file="ValueSpecificationExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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
    using System.Collections.Generic;
    using CommonStructure;
    using NUnit.Framework;
    using uml4net.Extensions;
    using uml4net.Values;
    using uml4net.Classification;

    [TestFixture]
    public class ValueSpecificationExtensionsTestFixture
    {
        [Test]
        public void QueryDefaultValueAsString_HandlesDifferentLiteralTypes()
        {
            var literalBool = new LiteralBoolean { Value = true };
            var literalInt = new LiteralInteger { Value = 42 };
            var literalNull = new LiteralNull();
            var literalString = new LiteralString { Value = "star" };
            var literalUnlimited = new LiteralUnlimitedNatural { Value = "*" };
            var instance = new InstanceSpecification { Name = "myInstance" };
            var instanceValue = new InstanceValue { Instance = instance };

            Assert.That(literalBool.QueryDefaultValueAsString(), Is.EqualTo("true"));
            Assert.That(literalInt.QueryDefaultValueAsString(), Is.EqualTo("42"));
            Assert.That(literalNull.QueryDefaultValueAsString(), Is.EqualTo("null"));
            Assert.That(literalString.QueryDefaultValueAsString(), Is.EqualTo("star"));
            Assert.That(literalUnlimited.QueryDefaultValueAsString(), Is.EqualTo("int.MaxValue"));
            Assert.That(instanceValue.QueryDefaultValueAsString(), Is.EqualTo("myInstance"));
        }

        private class UnsupportedValueSpecification : XmiElement, IValueSpecification
        {
            public IElement Possessor { get; set; }
            public IContainerList<IComment> OwnedComment { get; set; }
            public IContainerList<IElement> OwnedElement { get; }
            public IElement Owner { get; }
            public List<IDependency> ClientDependency { get; }
            public string Name { get; set; }
            public IContainerList<IStringExpression> NameExpression { get; set; }
            public INamespace Namespace { get; }
            public string QualifiedName { get; }
            public VisibilityKind Visibility { get; set; }
            public IType Type { get; set; }
            public ITemplateParameter OwningTemplateParameter { get; set; }
            public ITemplateParameter TemplateParameter { get; set; }
        }

        [Test]
        public void QueryDefaultValueAsString_ThrowsOnUnsupportedType()
        {
            var unsupported = new UnsupportedValueSpecification();
            Assert.That(() => unsupported.QueryDefaultValueAsString(), Throws.TypeOf<System.NotSupportedException>());
        }
    }
}
