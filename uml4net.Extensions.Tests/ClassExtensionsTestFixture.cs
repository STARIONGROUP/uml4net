// -------------------------------------------------------------------------------------------------
//  <copyright file="ClassExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions.Tests
{
    using System.IO;
    using System.Linq;
    
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;
    
    using Serilog;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using xmi.Readers;

    [TestFixture]
    public class ClassExtensionsTestFixture
    {
        private ILoggerFactory loggerFactory;

        private XmiReaderResult xmiReaderResult;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        [SetUp]
        public void SetUp()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            this.xmiReaderResult = reader.Read(Path.Combine(rootPath, "UML.xmi"));
        }

        [Test]
        public void Verify_that_QueryAllProperties_returns_expected_result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonStructuresPackage = root.NestedPackage.Single(x => x.Name == "CommonStructure");

            var dependency = commonStructuresPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Dependency");

            var properties = dependency.QueryAllProperties();

            Assert.That(properties.Count, Is.EqualTo(17));
        }

        [Test]
        public void Verify_that_QueryAllProperties_throws_when_class_is_null()
        {
            Assert.That(() => ClassExtensions.QueryAllProperties(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryAllSpecializations_returns_expected_result_with_cache()
        {
            var animal = new Class { XmiId = "Animal", Name = "Animal", DocumentName = "test" };
            var mammal = new Class { XmiId = "Mammal", Name = "Mammal", DocumentName = "test" };
            var cat_1 = new Class { XmiId = "Cat_1", Name = "Cat 1", DocumentName = "test" };
            var cat_2 = new Class { XmiId = "Cat_2", Name = "Cat 2", DocumentName = "test" };

            var animal_is_generalization_of_mammal = new Generalization
            {
                XmiId = "animal_is_generalization_of_mammal",
                DocumentName = "test",
                General = animal,
                Specific = mammal
            };

            var mammal_is_generalization_of_cat_1 = new Generalization
            {
                XmiId = "mammal_is_generalization_of_cat_1",
                DocumentName = "test",
                General = mammal,
                Specific = cat_1
            };

            var mammal_is_generalization_of_cat_2 = new Generalization
            {
                XmiId = "mammal_is_generalization_of_cat_2",
                DocumentName = "test",
                General = mammal,
                Specific = cat_2
            };

            cat_1.Generalization.Add(mammal_is_generalization_of_cat_1);
            cat_2.Generalization.Add(mammal_is_generalization_of_cat_2);
            animal.Generalization.Add(animal_is_generalization_of_mammal);

            var cache = new XmiElementCache();

            cache.TryAdd(animal);
            cache.TryAdd(mammal);
            cache.TryAdd(cat_1);
            cache.TryAdd(cat_2);

            cache.TryAdd(animal_is_generalization_of_mammal);
            cache.TryAdd(mammal_is_generalization_of_cat_1);
            cache.TryAdd(mammal_is_generalization_of_cat_2);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(animal.QueryAllSpecializations(), Is.EquivalentTo([mammal]));
                Assert.That(mammal.QueryAllSpecializations(), Is.EquivalentTo([cat_1, cat_2]));
            }
        }

        [Test]
        public void Verify_that_QueryAllSpecializations_returns_expected_result_without_cache()
        {
            var rootPackage = new Package
            {
                XmiId = "rootPackage",
                DocumentName = "test"
            };

            var otherPackage = new Package
            {
                XmiId = "otherPackage",
                DocumentName = "test"
            };

            var packageImport = new PackageImport
            {
                XmiId = "packageImport",
                DocumentName = "test",
                ImportedPackage = otherPackage
            };

            rootPackage.PackageImport.Add(packageImport);

            var animal = new Class { XmiId = "Animal", Name = "Animal", DocumentName = "test" };
            var mammal = new Class { XmiId = "Mammal", Name = "Mammal", DocumentName = "test" };
            var cat_1 = new Class { XmiId = "Cat_1", Name = "Cat 1", DocumentName = "test" };
            var cat_2 = new Class { XmiId = "Cat_2", Name = "Cat 2", DocumentName = "test" };

            var animal_is_generalization_of_mammal = new Generalization
            {
                XmiId = "animal_is_generalization_of_mammal",
                DocumentName = "test",
                General = animal,
                Specific = mammal
            };

            var mammal_is_generalization_of_cat_1 = new Generalization
            {
                XmiId = "mammal_is_generalization_of_cat_1",
                DocumentName = "test",
                General = mammal,
                Specific = cat_1
            };

            var mammal_is_generalization_of_cat_2 = new Generalization
            {
                XmiId = "mammal_is_generalization_of_cat_2",
                DocumentName = "test",
                General = mammal,
                Specific = cat_2
            };

            cat_1.Generalization.Add(mammal_is_generalization_of_cat_1);
            cat_2.Generalization.Add(mammal_is_generalization_of_cat_2);
            animal.Generalization.Add(animal_is_generalization_of_mammal);

            rootPackage.PackagedElement.Add(animal);
            rootPackage.PackagedElement.Add(mammal);

            otherPackage.PackagedElement.Add(cat_1);
            otherPackage.PackagedElement.Add(cat_2);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(animal.QueryAllSpecializations(), Is.EquivalentTo([mammal]));
                Assert.That(mammal.QueryAllSpecializations(), Is.EquivalentTo([cat_1, cat_2]));
            }
        }

        [Test]
        public void Verify_that_QueryAllSpecializations_throws_when_class_is_null()
        {
            Assert.That(() => ClassExtensions.QueryAllSpecializations(null), Throws.ArgumentNullException);
        }
    }
}
