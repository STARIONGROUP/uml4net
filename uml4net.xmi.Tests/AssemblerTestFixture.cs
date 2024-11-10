// -------------------------------------------------------------------------------------------------
// <copyright file="AssemblerTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
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

namespace uml4net.xmi.Tests
{
    using Cache;
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;
    using System;
    using POCO.Classification;
    using POCO.SimpleClassifiers;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.Values;

    [TestFixture]
    public class AssemblerTestFixture
    {
        private Assembler assembler;
        private IXmiReaderCache cache;

        [SetUp]
        public void Setup()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            this.cache = new XmiReaderCache(loggerFactory.CreateLogger<XmiReaderCache>());

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
                Name = "TestClass",
                NameExpression = null
            };

            var stringExpression = new StringExpression { XmiId = Guid.NewGuid().ToString(), Name = "StringExpression1" };

            classElement.SingleValueReferencePropertyIdentifiers.Add("NameExpression", stringExpression.XmiId);
            this.cache.Add(classElement.XmiId, classElement);
            this.cache.Add(stringExpression.XmiId, stringExpression);

            Assert.That(classElement.NameExpression, Is.Null);
            
            this.assembler.Synchronize();
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(classElement.NameExpression, Is.Not.Null);
                Assert.That(classElement.NameExpression, Is.SameAs(stringExpression));
                Assert.That(classElement.NameExpression.Name, Is.EqualTo(stringExpression.Name));
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
            this.cache.Add(classElement.XmiId, classElement);
            this.cache.Add(comment1.XmiId, comment1);
            this.cache.Add(comment2.XmiId, comment2);

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
        public void Synchronize_ShouldSetSingleValueReferenceAndMultipleValuesReference()
        {
            // Arrange
            var classElement = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass",
                NameExpression = null
            };

            var stringExpression = new StringExpression { XmiId = Guid.NewGuid().ToString(), Name = "StringExpression1" };

            var comment1 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 1" };
            var comment2 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 2" };

            classElement.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment1.XmiId, comment2.XmiId]);
            this.cache.Add(classElement.XmiId, classElement);
            this.cache.Add(comment1.XmiId, comment1);
            this.cache.Add(comment2.XmiId, comment2);

            classElement.SingleValueReferencePropertyIdentifiers.Add("NameExpression", stringExpression.XmiId);
            this.cache.Add(stringExpression.XmiId, stringExpression);

            Assert.That(classElement.NameExpression, Is.Null);
            Assert.That(classElement.OwnedComment.Count, Is.Zero);

            this.assembler.Synchronize();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(classElement.OwnedComment.Count, Is.EqualTo(2));
                Assert.That(classElement.OwnedComment.Contains(comment1));
                Assert.That(classElement.OwnedComment.Contains(comment2));
                Assert.That(classElement.NameExpression, Is.Not.Null);
                Assert.That(classElement.NameExpression, Is.SameAs(stringExpression));
                Assert.That(classElement.NameExpression.Name, Is.EqualTo(stringExpression.Name));
            });
        }

        [Test]
        public void Synchronize_ShouldSetExpectedReferenceToExpectedReference()
        {
            // Arrange
            var classElement0 = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass",
                NameExpression = null
            };

            var classElement1 = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass",
                NameExpression = null
            };

            var stringExpression = new StringExpression { XmiId = Guid.NewGuid().ToString(), Name = "StringExpression1" };

            var comment0 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 1" };
            var comment1 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 2" };

            classElement0.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment0.XmiId ]);
            this.cache.Add(classElement0.XmiId, classElement0);
            classElement1.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment1.XmiId]);
            this.cache.Add(classElement1.XmiId, classElement1);
            this.cache.Add(comment1.XmiId, comment1);
            this.cache.Add(comment0.XmiId, comment0);

            classElement0.SingleValueReferencePropertyIdentifiers.Add("NameExpression", stringExpression.XmiId);
            this.cache.Add(stringExpression.XmiId, stringExpression);

            Assert.That(classElement0.NameExpression, Is.Null);
            Assert.That(classElement1.NameExpression, Is.Null);
            Assert.That(classElement0.OwnedComment.Count, Is.Zero);
            Assert.That(classElement1.OwnedComment.Count, Is.Zero);

            this.assembler.Synchronize();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(classElement0.NameExpression, Is.SameAs(stringExpression));
                Assert.That(classElement1.NameExpression, Is.Null);
                Assert.That(classElement0.OwnedComment.Count, Is.EqualTo(1));
                Assert.That(classElement1.OwnedComment.Count, Is.EqualTo(1));
                Assert.That(classElement0.OwnedComment.Contains(comment0));
                Assert.That(classElement1.OwnedComment.Contains(comment1));
                Assert.That(classElement0.NameExpression, Is.Not.Null);
                Assert.That(classElement0.NameExpression.Name, Is.EqualTo(stringExpression.Name));
            });
        }

        [Test]
        public void Synchronize_ShouldThrow_WhenReferenceNotFound()
        {
            var classElement = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass",
                NameExpression = new StringExpression()
            };

            classElement.SingleValueReferencePropertyIdentifiers.Add("NameExpression", "NonExistentReference");
            this.cache.Add(classElement.XmiId, classElement);
            
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
            this.cache.Add(classElement.XmiId, classElement);
            this.cache.Add(invalidElement.XmiId, invalidElement);

            Assert.Multiple(() =>
            {
                Assert.Throws<InvalidOperationException>(() => this.assembler.Synchronize());
                Assert.That(classElement.OwnedComment, Is.Empty);
                Assert.That(classElement.NameExpression, Is.Null);
            });
        }

        [Test]
        public void Synchronize_verify_that_type_is_set()
        {
            var property = new Property()
            {
                XmiId = "Property-aggregation",
                Name = "aggregation"
            };

            property.SingleValueReferencePropertyIdentifiers.Add("type", "AggregationKind");

            var enumeration = new Enumeration()
            {
                XmiId = "AggregationKind",
                Name = "AggregationKind",
            };

            this.cache.Add(property.XmiId, property);
            this.cache.Add(enumeration.XmiId, enumeration);

            this.assembler.Synchronize();

            Assert.That(property.Type, Is.EqualTo(enumeration));
        }
    }
}
