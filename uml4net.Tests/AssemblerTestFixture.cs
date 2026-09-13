// -------------------------------------------------------------------------------------------------
// <copyright file="AssemblerTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;
    
    [TestFixture]
    public class AssemblerTestFixture
    {
        private Assembler assembler;
        private XmiElementCache cache;
        private string documentName;

        [SetUp]
        public void Setup()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            this.cache = new XmiElementCache();

            this.assembler = new Assembler(loggerFactory.CreateLogger<Assembler>(), this.cache);

            this.documentName = "test";
        }

        [TearDown]
        public void Teardown()
        {
            this.cache.Clear();
        }

        private Constraint CreateConstraint(string xmiId, string documentName = null) => new()
        {
            XmiId = xmiId,
            DocumentName = documentName ?? this.documentName
        };

        private void AddCompositeReference(IXmiElement element, string propertyName, string identifier, int position)
        {
            if (!element.CompositeReferencePropertyIdentifiers.TryGetValue(propertyName, out var references))
            {
                references = [];
                element.CompositeReferencePropertyIdentifiers.Add(propertyName, references);
            }

            references.Add(new XmiCompositeReference { Identifier = identifier, Position = position });
        }

        [Test]
        public void Synchronize_ShouldInsertCompositeReferencesAtTheirPositionAndSetThePossessor()
        {
            var operation = new Operation { XmiId = "op", DocumentName = this.documentName };
            var contained = this.CreateConstraint("c1");
            operation.OwnedRule.Add(contained);

            var first = this.CreateConstraint("c0");
            var last = this.CreateConstraint("c2");

            this.AddCompositeReference(operation, "ownedRule", "c2", 2);
            this.AddCompositeReference(operation, "ownedRule", "c0", 0);

            foreach (var element in new IXmiElement[] { operation, contained, first, last })
            {
                Assert.That(this.cache.TryAdd(element), Is.True);
            }

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation.OwnedRule, Is.EqualTo(new[] { first, contained, last }));
                Assert.That(operation.OwnedRule.Select(x => x.Possessor), Is.All.SameAs(operation));
                Assert.That(operation.CompositeReferencePropertyIdentifiers["ownedRule"], Is.Empty);
            }
        }

        [Test]
        public void Synchronize_ShouldAddCompositeReferenceToAnElementOwnedByTheSameOwnerThroughAnotherProperty()
        {
            var operation = new Operation { XmiId = "op", DocumentName = this.documentName };
            var bodyCondition = this.CreateConstraint("c1");
            operation.BodyCondition.Add(bodyCondition);

            this.AddCompositeReference(operation, "ownedRule", "c1", 0);

            Assert.That(this.cache.TryAdd(operation), Is.True);
            Assert.That(this.cache.TryAdd(bodyCondition), Is.True);

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation.OwnedRule.Single(), Is.SameAs(bodyCondition));
                Assert.That(bodyCondition.Possessor, Is.SameAs(operation));
            }
        }

        [Test]
        public void Synchronize_ShouldNotTakeACompositeReferenceAwayFromAnotherOwner()
        {
            var owner = new Operation { XmiId = "owner", DocumentName = this.documentName };
            var other = new Operation { XmiId = "other", DocumentName = this.documentName };
            var constraint = this.CreateConstraint("c1");
            owner.OwnedRule.Add(constraint);

            this.AddCompositeReference(other, "ownedRule", "c1", 0);

            foreach (var element in new IXmiElement[] { owner, other, constraint })
            {
                Assert.That(this.cache.TryAdd(element), Is.True);
            }

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(other.OwnedRule, Is.Empty);
                Assert.That(owner.OwnedRule.Single(), Is.SameAs(constraint));
                Assert.That(constraint.Possessor, Is.SameAs(owner));
                Assert.That(other.CompositeReferencePropertyIdentifiers["ownedRule"].Single().Identifier, Is.EqualTo("c1"));
            }
        }

        [Test]
        public void Synchronize_ShouldSkipUnresolvableCompositeReferencesAndKeepTheOrder()
        {
            var operation = new Operation { XmiId = "op", DocumentName = this.documentName };
            var comment = new Comment { XmiId = "comment", DocumentName = this.documentName };
            var constraint = this.CreateConstraint("c1");

            this.AddCompositeReference(operation, "ownedRule", "comment", 0);
            this.AddCompositeReference(operation, "ownedRule", "missing", 1);
            this.AddCompositeReference(operation, "ownedRule", "c1", 2);

            foreach (var element in new IXmiElement[] { operation, comment, constraint })
            {
                Assert.That(this.cache.TryAdd(element), Is.True);
            }

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation.OwnedRule.Single(), Is.SameAs(constraint));
                Assert.That(operation.CompositeReferencePropertyIdentifiers["ownedRule"].Select(x => x.Identifier), Is.EqualTo(new[] { "comment", "missing" }));
            }
        }

        [Test]
        public void Synchronize_ShouldRemoveAResolvedCompositeHrefFromTheUnresolvedReferencesAndBeIdempotent()
        {
            var operation = new Operation { XmiId = "op", DocumentName = this.documentName };
            var constraint = this.CreateConstraint("c4", "other.xml");

            this.AddCompositeReference(operation, "ownedRule", "other.xml#c4", 0);
            operation.UnresolvedReferences.Add(new XmiUnresolvedReference { PropertyName = "ownedRule", Identifier = "other.xml#c4" });

            Assert.That(this.cache.TryAdd(operation), Is.True);
            Assert.That(this.cache.TryAdd(constraint), Is.True);

            this.assembler.Synchronize();
            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation.OwnedRule.Single(), Is.SameAs(constraint));
                Assert.That(operation.UnresolvedReferences, Is.Empty);
            }
        }

        [Test]
        public void Synchronize_ShouldThrowWhenTheCompositePropertyDoesNotExist()
        {
            var operation = new Operation { XmiId = "op", DocumentName = this.documentName };
            this.AddCompositeReference(operation, "doesNotExist", "c1", 0);

            Assert.That(this.cache.TryAdd(operation), Is.True);

            Assert.That(() => this.assembler.Synchronize(), Throws.InstanceOf<System.Collections.Generic.KeyNotFoundException>());
        }

        [Test]
        public void Synchronize_ShouldSetSingleValueReference()
        {
            var classElement = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass",
                DocumentName = this.documentName
            };

            var stringExpression = new StringExpression
            {
                XmiId = Guid.NewGuid().ToString(), 
                Name = "StringExpression1",
                DocumentName = this.documentName
            };

            classElement.MultiValueReferencePropertyIdentifiers.Add("NameExpression", [stringExpression.XmiId]);
            Assert.That(this.cache.TryAdd(classElement), Is.True);
            Assert.That(this.cache.TryAdd(stringExpression), Is.True);

            Assert.That(classElement.NameExpression, Is.Empty);

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classElement.NameExpression, Is.Not.Empty);
                Assert.That(classElement.NameExpression.First(), Is.SameAs(stringExpression));
                Assert.That(classElement.NameExpression.First().Name, Is.EqualTo(stringExpression.Name));
            }
        }

        [Test]
        public void Synchronize_ShouldSetMultiValueReference()
        {
            var classElement = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass",
                DocumentName = this.documentName
            };

            var comment1 = new Comment
            {
                XmiId = Guid.NewGuid().ToString(), 
                Body = "Comment 1",
                DocumentName = this.documentName
            };

            var comment2 = new Comment
            {
                XmiId = Guid.NewGuid().ToString(),
                Body = "Comment 2",
                DocumentName = this.documentName
            };

            classElement.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment1.XmiId, comment2.XmiId]);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.cache.TryAdd(classElement), Is.True);
                Assert.That(this.cache.TryAdd(comment1), Is.True);
                Assert.That(this.cache.TryAdd(comment2), Is.True);
            }

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classElement.OwnedComment.Count, Is.EqualTo(2));
                Assert.That(classElement.OwnedComment.Contains(comment1));
                Assert.That(classElement.OwnedComment.Contains(comment2));
            }
        }

        [Test]
        public void Synchronize_ShouldSetMultiValueReferenceFromExternalXmi()
        {
            const string externalXmi0 = "otherxmi";
            const string externalXmi1 = "anotherone";

            var classElement0 = new Class 
            { 
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass0",
                DocumentName = this.documentName
            };

            var classElement1 = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass1",
                DocumentName = externalXmi1
            };
            
            var stringType = new PrimitiveType
            {
                XmiId = Guid.NewGuid().ToString(), 
                Name = "string",
                DocumentName = externalXmi1
            };

            var attribute0 = new Property 
            { 
                XmiId = Guid.NewGuid().ToString(),
                DocumentName = externalXmi0, 
                SingleValueReferencePropertyIdentifiers = { { nameof(Property.Type), $"{externalXmi1}#{stringType.XmiId}" } }
            };

            var attribute1 = new Property
            { 
                XmiId = Guid.NewGuid().ToString(),
                DocumentName = externalXmi1, 
                SingleValueReferencePropertyIdentifiers = { { nameof(Property.Type), $"{externalXmi1}#{classElement1.XmiId}" } }
            };
            
            var comment1 = new Comment 
            {
                XmiId = Guid.NewGuid().ToString(), 
                Body = "Comment 1",
                DocumentName = this.documentName
            };

            var comment2 = new Comment 
            { 
                XmiId = Guid.NewGuid().ToString(),
                Body = "Comment 2",
                DocumentName = this.documentName
            };

            classElement0.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment1.XmiId, comment2.XmiId]);
            classElement0.MultiValueReferencePropertyIdentifiers.Add("OwnedAttribute", [$"{externalXmi0}#{attribute0.XmiId}", $"{externalXmi1}#{attribute1.XmiId}"]);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.cache.TryAdd(classElement0), Is.True);
                Assert.That(this.cache.TryAdd(comment1), Is.True);
                Assert.That(this.cache.TryAdd(comment2), Is.True);
                Assert.That(this.cache.TryAdd(attribute0), Is.True);
                Assert.That(this.cache.TryAdd(attribute1), Is.True);
                Assert.That(this.cache.TryAdd(classElement1), Is.True);
                Assert.That(this.cache.TryAdd(stringType), Is.True);
            }

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classElement0.OwnedComment.Count, Is.EqualTo(2));
                Assert.That(classElement0.OwnedComment.Contains(comment1));
                Assert.That(classElement0.OwnedComment.Contains(comment2));
                Assert.That(classElement0.OwnedAttribute.Contains(attribute0));
                Assert.That(classElement0.OwnedAttribute.Contains(attribute1));
                Assert.That(classElement0.OwnedAttribute.Single(x => x.XmiId == attribute1.XmiId).Type, Is.SameAs(classElement1));
                Assert.That(classElement0.OwnedAttribute.Single(x => x.XmiId == attribute0.XmiId).Type, Is.SameAs(stringType));
            }
        }

        [Test]
        public void Synchronize_ShouldSetSingleValueReferenceAndMultipleValuesReference()
        {
            var classElement = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass",
                DocumentName = this.documentName
            };

            var stringExpression = new StringExpression { XmiId = Guid.NewGuid().ToString(), Name = "StringExpression1",
                DocumentName = this.documentName
            };

            var comment1 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 1",
                DocumentName = this.documentName
            };
            var comment2 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 2",
                DocumentName = this.documentName
            };

            classElement.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment1.XmiId, comment2.XmiId]);
            Assert.That(this.cache.TryAdd(classElement), Is.True);
            Assert.That(this.cache.TryAdd(comment1), Is.True);
            Assert.That(this.cache.TryAdd(comment2), Is.True);

            classElement.MultiValueReferencePropertyIdentifiers.Add("NameExpression", [stringExpression.XmiId]);
            Assert.That(this.cache.TryAdd(stringExpression), Is.True);

            Assert.That(classElement.NameExpression, Is.Empty);
            Assert.That(classElement.OwnedComment.Count, Is.Zero);

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classElement.OwnedComment.Count, Is.EqualTo(2));
                Assert.That(classElement.OwnedComment.Contains(comment1));
                Assert.That(classElement.OwnedComment.Contains(comment2));
                Assert.That(classElement.NameExpression, Is.Not.Empty);
                Assert.That(classElement.NameExpression.First(), Is.SameAs(stringExpression));
                Assert.That(classElement.NameExpression.First().Name, Is.EqualTo(stringExpression.Name));
            }
        }

        [Test]
        public void Synchronize_ShouldSetExpectedReferenceToExpectedReference()
        {
            var classElement0 = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass",
                DocumentName = this.documentName
            };

            var classElement1 = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass",
                DocumentName = this.documentName
            };

            var stringExpression = new StringExpression { XmiId = Guid.NewGuid().ToString(), Name = "StringExpression1",
                DocumentName = this.documentName
            };

            var comment0 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 1",
                DocumentName = this.documentName
            };
            var comment1 = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Comment 2",
                DocumentName = this.documentName
            };

            classElement0.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment0.XmiId ]);
            Assert.That(this.cache.TryAdd(classElement0), Is.True);
            classElement1.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", [comment1.XmiId]);
            Assert.That(this.cache.TryAdd(classElement1), Is.True);
            Assert.That(this.cache.TryAdd(comment1), Is.True);
            Assert.That(this.cache.TryAdd(comment0), Is.True);

            classElement0.MultiValueReferencePropertyIdentifiers.Add("NameExpression", [stringExpression.XmiId]);
            Assert.That(this.cache.TryAdd(stringExpression), Is.True);

            Assert.That(classElement0.NameExpression, Is.Empty);
            Assert.That(classElement1.NameExpression, Is.Empty);
            Assert.That(classElement0.OwnedComment.Count, Is.Zero);
            Assert.That(classElement1.OwnedComment.Count, Is.Zero);

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classElement1.NameExpression, Is.Empty);
                Assert.That(classElement0.OwnedComment.Count, Is.EqualTo(1));
                Assert.That(classElement1.OwnedComment.Count, Is.EqualTo(1));
                Assert.That(classElement0.OwnedComment.Contains(comment0));
                Assert.That(classElement1.OwnedComment.Contains(comment1));
                Assert.That(classElement0.NameExpression, Is.Not.Empty);
                Assert.That(classElement0.NameExpression.First().Name, Is.EqualTo(stringExpression.Name));
            }
        }

        [Test]
        public void Synchronize_ShouldThrow_WhenReferenceNotFound()
        {
            var classElement = new Class
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "TestClass",
                DocumentName = this.documentName
            };

            classElement.SingleValueReferencePropertyIdentifiers.Add("NameExpression", "NonExistentReference");
            Assert.That(this.cache.TryAdd(classElement), Is.True);
            
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
                DocumentName = this.documentName,
                NameExpression = null
            };

            var invalidElement = new Comment { XmiId = Guid.NewGuid().ToString(), Body = "Not a comment",
                DocumentName = this.documentName
            };

            classElement.SingleValueReferencePropertyIdentifiers.Add("NameExpression", invalidElement.XmiId);
            Assert.That(this.cache.TryAdd(classElement), Is.True);
            Assert.That(this.cache.TryAdd(invalidElement), Is.True);

            using (Assert.EnterMultipleScope())
            {
                Assert.Throws<InvalidOperationException>(() => this.assembler.Synchronize());
                Assert.That(classElement.OwnedComment, Is.Empty);
                Assert.That(classElement.NameExpression, Is.Empty);
            }
        }

        [Test]
        public void Synchronize_ShouldResolveBareSameDocumentFragmentAndCrossDocumentMultiValueReference()
        {
            const string externalXmi = "otherdoc";

            var sameDocumentTarget = new Property
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "sameDocumentTarget",
                DocumentName = this.documentName
            };

            var crossDocumentTarget = new Property
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "crossDocumentTarget",
                DocumentName = externalXmi
            };

            var property = new Property
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "directedUsage",
                DocumentName = this.documentName
            };

            // "#id" is a bare same-document fragment, "otherdoc#id" is a cross-document reference
            property.MultiValueReferencePropertyIdentifiers.Add("subsettedProperty",
                [$"#{sameDocumentTarget.XmiId}", $"{externalXmi}#{crossDocumentTarget.XmiId}"]);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.cache.TryAdd(property), Is.True);
                Assert.That(this.cache.TryAdd(sameDocumentTarget), Is.True);
                Assert.That(this.cache.TryAdd(crossDocumentTarget), Is.True);
            }

            Assert.That(property.SubsettedProperty, Is.Empty);

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(property.SubsettedProperty, Has.Count.EqualTo(2));
                Assert.That(property.SubsettedProperty, Does.Contain(sameDocumentTarget));
                Assert.That(property.SubsettedProperty, Does.Contain(crossDocumentTarget));
            }
        }

        [Test]
        public void Synchronize_ShouldResolveBareSameDocumentFragmentSingleValueReference()
        {
            var property = new Property
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "property",
                DocumentName = this.documentName
            };

            var primitiveType = new PrimitiveType
            {
                XmiId = Guid.NewGuid().ToString(),
                Name = "string",
                DocumentName = this.documentName
            };

            // "#id" is a bare same-document fragment
            property.SingleValueReferencePropertyIdentifiers.Add("type", $"#{primitiveType.XmiId}");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.cache.TryAdd(property), Is.True);
                Assert.That(this.cache.TryAdd(primitiveType), Is.True);
            }

            Assert.That(property.Type, Is.Null);

            this.assembler.Synchronize();

            Assert.That(property.Type, Is.SameAs(primitiveType));
        }

        [Test]
        public void Synchronize_verify_that_type_is_set()
        {
            var property = new Property
            {
                XmiId = "Property-aggregation",
                Name = "aggregation",
                DocumentName = this.documentName
            };

            property.SingleValueReferencePropertyIdentifiers.Add("type", "AggregationKind");

            var enumeration = new Enumeration
            {
                XmiId = "AggregationKind",
                Name = "AggregationKind",
                DocumentName = this.documentName
            };

            Assert.That(this.cache.TryAdd(property), Is.True);
            Assert.That(this.cache.TryAdd(enumeration), Is.True);

            this.assembler.Synchronize();

            Assert.That(property.Type, Is.EqualTo(enumeration));
        }

        [Test]
        public void Synchronize_ShouldRemoveThePreservedReferenceElement_WhenTheSingleValueReferenceIsResolved()
        {
            var property = new Property
            {
                XmiId = "Property-1",
                Name = "property",
                DocumentName = this.documentName
            };

            var primitiveType = new PrimitiveType
            {
                XmiId = "Boolean",
                Name = "Boolean",
                DocumentName = "PrimitiveTypes.xmi"
            };

            property.SingleValueReferencePropertyIdentifiers.Add("type", "PrimitiveTypes.xmi#Boolean");
            property.UnresolvedReferences.Add(new XmiUnresolvedReference
            {
                PropertyName = "type",
                Identifier = "PrimitiveTypes.xmi#Boolean",
                ContentRawXmi = "<type href=\"PrimitiveTypes.xmi#Boolean\" />"
            });

            Assert.That(this.cache.TryAdd(property), Is.True);
            Assert.That(this.cache.TryAdd(primitiveType), Is.True);

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(property.Type, Is.SameAs(primitiveType));
                Assert.That(property.UnresolvedReferences, Is.Empty,
                    "a resolved reference is written from the reference property and must not be written a second time from its preserved XMI");
            }
        }

        [Test]
        public void Synchronize_ShouldKeepThePreservedReferenceElement_WhenTheSingleValueReferenceIsNotResolved()
        {
            var profileApplication = new ProfileApplication
            {
                XmiId = "profileap_8C9E6706-8",
                DocumentName = this.documentName
            };

            const string href = "http://www.sparxsystems.com/profiles/EAUML/1.0#8C9E6706-8";

            profileApplication.SingleValueReferencePropertyIdentifiers.Add("appliedProfile", href);
            profileApplication.UnresolvedReferences.Add(new XmiUnresolvedReference
            {
                PropertyName = "appliedProfile",
                Identifier = href,
                ContentRawXmi = $"<appliedProfile href=\"{href}\" />"
            });

            Assert.That(this.cache.TryAdd(profileApplication), Is.True);

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(profileApplication.AppliedProfile, Is.Null);
                Assert.That(profileApplication.UnresolvedReferences.Single().Identifier, Is.EqualTo(href),
                    "a reference that cannot be resolved is preserved so that it is written back verbatim");
            }
        }

        [Test]
        public void Synchronize_ShouldRemoveOnlyThePreservedReferenceElementsThatAreResolved_ForAMultiValueReference()
        {
            var classElement = new Class
            {
                XmiId = "Class-1",
                Name = "TestClass",
                DocumentName = this.documentName
            };

            var comment = new Comment
            {
                XmiId = "Comment-1",
                Body = "Comment 1",
                DocumentName = "other.xmi"
            };

            classElement.MultiValueReferencePropertyIdentifiers.Add("OwnedComment", ["other.xmi#Comment-1", "missing.xmi#Comment-2"]);

            classElement.UnresolvedReferences.Add(new XmiUnresolvedReference
            {
                PropertyName = "OwnedComment",
                Identifier = "other.xmi#Comment-1",
                ContentRawXmi = "<ownedComment href=\"other.xmi#Comment-1\" />"
            });

            classElement.UnresolvedReferences.Add(new XmiUnresolvedReference
            {
                PropertyName = "OwnedComment",
                Identifier = "missing.xmi#Comment-2",
                ContentRawXmi = "<ownedComment href=\"missing.xmi#Comment-2\" />"
            });

            Assert.That(this.cache.TryAdd(classElement), Is.True);
            Assert.That(this.cache.TryAdd(comment), Is.True);

            this.assembler.Synchronize();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classElement.OwnedComment, Has.Count.EqualTo(1));
                Assert.That(classElement.UnresolvedReferences.Single().Identifier, Is.EqualTo("missing.xmi#Comment-2"));
            }
        }
    }
}
