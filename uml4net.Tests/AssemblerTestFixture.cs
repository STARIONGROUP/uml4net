// -------------------------------------------------------------------------------------------------
// <copyright file="AssemblerTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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

namespace uml4net.Tests
{
    using System;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;
    
    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;
    
    [TestFixture]
    public class AssemblerTestFixture
    {
        private Assembler assembler;
        private XmiElementCache cache;

        [SetUp]
        public void Setup()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            this.cache = new XmiElementCache();

            this.assembler = new Assembler(loggerFactory.CreateLogger<Assembler>(), this.cache);
        }

        [TearDown]
        public void Teardown()
        {
            this.cache.GlobalCache.Clear();
        }

        [Test]
        public void Synchronize_ShouldSetSingleValueReference()
        {
            // Arrange
            var classElement = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass"
            };

            var stringExpression = new StringExpression { XmiId = Guid.NewGuid().ToString(), Name = "StringExpression1" };

            classElement.MultiValueReferencePropertyIdentifiers.Add("NameExpression", [stringExpression.XmiId]);
            Assert.That(this.cache.TryAdd(classElement.XmiId, classElement), Is.True);
            Assert.That(this.cache.TryAdd(stringExpression.XmiId, stringExpression), Is.True);

            Assert.That(classElement.NameExpression, Is.Empty);
            
            this.assembler.Synchronize();
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(classElement.NameExpression, Is.Not.Empty);
                Assert.That(classElement.NameExpression.First(), Is.SameAs(stringExpression));
                Assert.That(classElement.NameExpression.First().Name, Is.EqualTo(stringExpression.Name));
            });
        }

        [Test]
        public void Synchronize_ShouldSetMultiValueReference()
        {
            // Arrange
            var classElement = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass"
            };

            var comment1 = new Comment
            {  XmiId = Guid.NewGuid().ToString(), Body = "Comment 1" };
            var comment2 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 2" };

            classElement.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment1.XmiId, comment2.XmiId]);
            Assert.That(this.cache.TryAdd(classElement.XmiId, classElement), Is.True);
            Assert.That(this.cache.TryAdd(comment1.XmiId, comment1), Is.True);
            Assert.That(this.cache.TryAdd(comment2.XmiId, comment2), Is.True);

            this.assembler.Synchronize();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(classElement.OwnedComment.Count, Is.EqualTo(2));
                Assert.That(classElement.OwnedComment.Contains(comment1));
                Assert.That(classElement.OwnedComment.Contains(comment2));
            });
        }

        [Test]
        public void Synchronize_ShouldSetMultiValueReferenceFromExternalXmi()
        {
            // Arrange
            const string externalXmi0 = "otherxmi";
            const string externalXmi1 = "anotherone";
            
            var classElement0 = new Class { XmiId = Guid.NewGuid().ToString(), Name = "TestClass0"};
            var classElement1 = new Class { XmiId = Guid.NewGuid().ToString(), Name = "TestClass1" };
            var stringType = new PrimitiveType { XmiId = Guid.NewGuid().ToString(), Name = "string" };

            var attribute0 = new Property 
            { 
                XmiId = Guid.NewGuid().ToString(), 
                SingleValueReferencePropertyIdentifiers = { { nameof(Property.Type), $"{externalXmi1}#{stringType.XmiId}" } }
            };

            var attribute1 = new Property
            { 
                XmiId = Guid.NewGuid().ToString(), 
                SingleValueReferencePropertyIdentifiers = { { nameof(Property.Type), $"{externalXmi1}#{classElement1.XmiId}" } }
            };
            
            var comment1 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 1" };
            var comment2 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 2" };

            classElement0.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment1.XmiId, comment2.XmiId]);
            classElement0.MultiValueReferencePropertyIdentifiers.Add("OwnedAttribute", [$"{externalXmi0}#{attribute0.XmiId}", $"{externalXmi1}#{attribute1.XmiId}"]);
            
            Assert.That(this.cache.TryAdd(classElement0.XmiId, classElement0), Is.True);
            Assert.That(this.cache.TryAdd(comment1.XmiId, comment1), Is.True);
            Assert.That(this.cache.TryAdd(comment2.XmiId, comment2), Is.True);

            this.cache.SwitchContext(externalXmi0);
            Assert.That(this.cache.TryAdd(attribute0.XmiId, attribute0), Is.True);

            this.cache.SwitchContext(externalXmi1);
            Assert.That(this.cache.TryAdd(attribute1.XmiId, attribute1), Is.True);
            Assert.That(this.cache.TryAdd(classElement1.XmiId, classElement1), Is.True);
            Assert.That(this.cache.TryAdd(stringType.XmiId, stringType), Is.True);

            // Act
            this.assembler.Synchronize();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(classElement0.OwnedComment.Count, Is.EqualTo(2));
                Assert.That(classElement0.OwnedComment.Contains(comment1));
                Assert.That(classElement0.OwnedComment.Contains(comment2));
                Assert.That(classElement0.OwnedAttribute.Contains(attribute0));
                Assert.That(classElement0.OwnedAttribute.Contains(attribute1));
                Assert.That(classElement0.OwnedAttribute.Single(x => x.XmiId == attribute1.XmiId).Type, Is.SameAs(classElement1));
                Assert.That(classElement0.OwnedAttribute.Single(x => x.XmiId == attribute0.XmiId).Type, Is.SameAs(stringType));
            });
        }

        [Test]
        public void Synchronize_ShouldSetSingleValueReferenceAndMultipleValuesReference()
        {
            // Arrange
            var classElement = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass"
            };

            var stringExpression = new StringExpression { XmiId = Guid.NewGuid().ToString(), Name = "StringExpression1" };

            var comment1 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 1" };
            var comment2 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 2" };

            classElement.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment1.XmiId, comment2.XmiId]);
            Assert.That(this.cache.TryAdd(classElement.XmiId, classElement), Is.True);
            Assert.That(this.cache.TryAdd(comment1.XmiId, comment1), Is.True);
            Assert.That(this.cache.TryAdd(comment2.XmiId, comment2), Is.True);

            classElement.MultiValueReferencePropertyIdentifiers.Add("NameExpression", [stringExpression.XmiId]);
            Assert.That(this.cache.TryAdd(stringExpression.XmiId, stringExpression), Is.True);

            Assert.That(classElement.NameExpression, Is.Empty);
            Assert.That(classElement.OwnedComment.Count, Is.Zero);

            this.assembler.Synchronize();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(classElement.OwnedComment.Count, Is.EqualTo(2));
                Assert.That(classElement.OwnedComment.Contains(comment1));
                Assert.That(classElement.OwnedComment.Contains(comment2));
                Assert.That(classElement.NameExpression, Is.Not.Empty);
                Assert.That(classElement.NameExpression.First(), Is.SameAs(stringExpression));
                Assert.That(classElement.NameExpression.First().Name, Is.EqualTo(stringExpression.Name));
            });
        }

        [Test]
        public void Synchronize_ShouldSetExpectedReferenceToExpectedReference()
        {
            // Arrange
            var classElement0 = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass"
            };

            var classElement1 = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass"
            };

            var stringExpression = new StringExpression { XmiId = Guid.NewGuid().ToString(), Name = "StringExpression1" };

            var comment0 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 1" };
            var comment1 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 2" };

            classElement0.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment0.XmiId ]);
            Assert.That(this.cache.TryAdd(classElement0.XmiId, classElement0), Is.True);
            classElement1.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment1.XmiId]);
            Assert.That(this.cache.TryAdd(classElement1.XmiId, classElement1), Is.True);
            Assert.That(this.cache.TryAdd(comment1.XmiId, comment1), Is.True);
            Assert.That(this.cache.TryAdd(comment0.XmiId, comment0), Is.True);

            classElement0.MultiValueReferencePropertyIdentifiers.Add("NameExpression", [stringExpression.XmiId]);
            Assert.That(this.cache.TryAdd(stringExpression.XmiId, stringExpression), Is.True);

            Assert.That(classElement0.NameExpression, Is.Empty);
            Assert.That(classElement1.NameExpression, Is.Empty);
            Assert.That(classElement0.OwnedComment.Count, Is.Zero);
            Assert.That(classElement1.OwnedComment.Count, Is.Zero);

            this.assembler.Synchronize();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(classElement1.NameExpression, Is.Empty);
                Assert.That(classElement0.OwnedComment.Count, Is.EqualTo(1));
                Assert.That(classElement1.OwnedComment.Count, Is.EqualTo(1));
                Assert.That(classElement0.OwnedComment.Contains(comment0));
                Assert.That(classElement1.OwnedComment.Contains(comment1));
                Assert.That(classElement0.NameExpression, Is.Not.Empty);
                Assert.That(classElement0.NameExpression.First().Name, Is.EqualTo(stringExpression.Name));
            });
        }

        [Test]
        public void Synchronize_ShouldThrow_WhenReferenceNotFound()
        {
            var classElement = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass"
            };

            classElement.SingleValueReferencePropertyIdentifiers.Add("NameExpression", "NonExistentReference");
            Assert.That(this.cache.TryAdd(classElement.XmiId, classElement), Is.True);
            
            this.assembler.Synchronize();

            Assert.That(classElement.NameExpression, Is.Not.Null);
        }

        [Test]
        public void Synchronize_ShouldThrow_WhenElementNotIReferenceable()
        {
            var classElement = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass",
                NameExpression = null
            };

            var invalidElement = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Not a comment" };
            classElement.SingleValueReferencePropertyIdentifiers.Add("NameExpression", invalidElement.XmiId);
            Assert.That(this.cache.TryAdd(classElement.XmiId, classElement), Is.True);
            Assert.That(this.cache.TryAdd(invalidElement.XmiId, invalidElement), Is.True);

            Assert.Multiple(() =>
            {
                Assert.Throws<InvalidOperationException>(() => this.assembler.Synchronize());
                Assert.That(classElement.OwnedComment, Is.Empty);
                Assert.That(classElement.NameExpression, Is.Empty);
            });
        }

        [Test]
        public void Synchronize_verify_that_type_is_set()
        {
            var property = new Property
            {
                XmiId = "Property-aggregation",
                Name = "aggregation"
            };

            property.SingleValueReferencePropertyIdentifiers.Add("type", "AggregationKind");

            var enumeration = new Enumeration
            {
                XmiId = "AggregationKind",
                Name = "AggregationKind",
            };

            Assert.That(this.cache.TryAdd(property.XmiId, property), Is.True);
            Assert.That(this.cache.TryAdd(enumeration.XmiId, enumeration), Is.True);

            this.assembler.Synchronize();

            Assert.That(property.Type, Is.EqualTo(enumeration));
        }
    }
}