// -------------------------------------------------------------------------------------------------
// <copyright file="ClassExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions.Tests
{
    using System.IO;
    using System.Linq;
    
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;
    
    using Serilog;

    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
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
        public void Verify_that_QueryAllPropertiesInCanonicalOrder_follows_Annex_B52()
        {
            // Bottom specializes Right and Left (declared in that order), both specialize Top; Bottom::r2 redefines Right::r
            var top = new Class { Name = "Top" };
            top.OwnedAttribute.Add(new Property { Name = "t" });
            var right = new Class { Name = "Right" };
            var redefinedR = new Property { Name = "r" };
            right.OwnedAttribute.Add(redefinedR);
            right.OwnedAttribute.Add(new Property { Name = "r1" });
            right.Generalization.Add(new Generalization { General = top });
            var left = new Class { Name = "Left" };
            left.OwnedAttribute.Add(new Property { Name = "l" });
            left.Generalization.Add(new Generalization { General = top });
            var bottom = new Class { Name = "Bottom" };
            bottom.OwnedAttribute.Add(new Property { Name = "b" });
            var redefiningR = new Property { Name = "r2" };
            redefiningR.RedefinedProperty.Add(redefinedR);
            bottom.OwnedAttribute.Add(redefiningR);
            bottom.Generalization.Add(new Generalization { General = right });
            bottom.Generalization.Add(new Generalization { General = left });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(bottom.QueryAllPropertiesInCanonicalOrder().Select(x => x.Name), Is.EqualTo(new[] { "t", "l", "r", "r2", "r1", "b" }),
                    "superclass first, the alphabetically earlier superclass (Left) first, a redefining property at the position of the property that it redefines");
                Assert.That(() => ClassExtensions.QueryAllPropertiesInCanonicalOrder(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryAllPropertiesInCanonicalOrder_returns_the_properties_of_QueryAllProperties()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");
            var dependency = root.NestedPackage.Single(x => x.Name == "CommonStructure").PackagedElement.OfType<IClass>().Single(x => x.Name == "Dependency");

            var properties = dependency.QueryAllPropertiesInCanonicalOrder();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(properties, Is.EquivalentTo(dependency.QueryAllProperties()));
                Assert.That(((INamedElement)properties.First().Owner).Name, Is.EqualTo("Element"));
                Assert.That(properties.Where(x => ((INamedElement)x.Owner).Name == "Dependency").Select(x => x.Name), Is.EqualTo(new[] { "client", "supplier" }));
            }
        }

        [Test]
        public void Verify_that_QueryAllOperations_returns_expected_result()
        {
            Assert.That(() => ClassExtensions.QueryAllOperations(null), Throws.ArgumentNullException);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonStructuresPackage = root.NestedPackage.Single(x => x.Name == "CommonStructure");

            var dependency = commonStructuresPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Dependency");

            Assert.That(dependency.QueryAllOperations(), Is.Not.Empty);
        }

        [Test]
        public void Verify_that_QueryAllProperties_and_QueryAllOperations_both_include_the_realized_interfaces()
        {
            // package
            //   IShape (area, Draw), IColored (color, Paint)
            //   Shape (interfaceRealization: IShape, owned by Shape)
            //   Circle : Shape (radius, Resize)
            //   Realization Circle -> IColored, a packaged element as some tools export it
            var package = new Package { XmiId = "package" };

            var shapeInterface = new Interface { XmiId = "IShape", Name = "IShape" };
            var area = new Property { XmiId = "area", Name = "area" };
            var draw = new Operation { XmiId = "Draw", Name = "Draw" };
            shapeInterface.OwnedAttribute.Add(area);
            shapeInterface.OwnedOperation.Add(draw);

            var coloredInterface = new Interface { XmiId = "IColored", Name = "IColored" };
            var color = new Property { XmiId = "color", Name = "color" };
            var paint = new Operation { XmiId = "Paint", Name = "Paint" };
            coloredInterface.OwnedAttribute.Add(color);
            coloredInterface.OwnedOperation.Add(paint);

            var shape = new Class { XmiId = "Shape", Name = "Shape" };
            var interfaceRealization = new InterfaceRealization { XmiId = "shapeRealization", Contract = shapeInterface };
            interfaceRealization.Supplier.Add(shapeInterface);
            shape.InterfaceRealization.Add(interfaceRealization);

            var circle = new Class { XmiId = "Circle", Name = "Circle" };
            circle.Generalization.Add(new Generalization { XmiId = "generalization", General = shape });
            var radius = new Property { XmiId = "radius", Name = "radius" };
            var resize = new Operation { XmiId = "Resize", Name = "Resize" };
            circle.OwnedAttribute.Add(radius);
            circle.OwnedOperation.Add(resize);

            var realization = new Realization { XmiId = "colorRealization" };
            realization.Client.Add(circle);
            realization.Supplier.Add(coloredInterface);

            foreach (var packagedElement in new IPackageableElement[] { shapeInterface, coloredInterface, shape, circle, realization })
            {
                package.PackagedElement.Add(packagedElement);
            }

            using (Assert.EnterMultipleScope())
            {
                Assert.That(shape.QueryInterfaces(), Is.EqualTo(new[] { shapeInterface }), "the contract and the supplier of the InterfaceRealization count once");
                Assert.That(circle.QueryInterfaces(), Is.EqualTo(new[] { coloredInterface }));

                Assert.That(circle.QueryAllProperties(), Is.EquivalentTo(new[] { radius, color, area }));
                Assert.That(circle.QueryAllOperations(), Is.EqualTo(new[] { draw, paint, resize }), "ordered by name");
                Assert.That(shape.QueryAllOperations(), Is.EqualTo(new[] { draw }));
            }
        }

        [Test]
        public void Verify_that_QueryAllConstraints_returns_expected_result()
        {
            Assert.That(() => ClassExtensions.QueryAllConstraints(null), Throws.ArgumentNullException);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonStructuresPackage = root.NestedPackage.Single(x => x.Name == "CommonStructure");

            var dependency = commonStructuresPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Dependency");

            Assert.That(dependency.QueryAllConstraints(), Is.Not.Empty);
        }

        [Test]
        public void Verify_that_QueryAllConstraints_includes_the_preconditions_and_postconditions_of_a_Behavior()
        {
            // Behavior::precondition and Behavior::postcondition subset Namespace::ownedRule and are stored in their own lists
            var baseActivity = new Activity { Name = "BaseActivity" };
            var inheritedRule = new Constraint { Name = "a inherited rule" };
            baseActivity.OwnedRule.Add(inheritedRule);

            var activity = new Activity { Name = "Activity" };
            activity.Generalization.Add(new Generalization { General = baseActivity });

            var rule = new Constraint { Name = "b rule" };
            var precondition = new Constraint { Name = "c precondition" };
            var postcondition = new Constraint { Name = "d postcondition" };
            activity.OwnedRule.Add(rule);
            activity.Precondition.Add(precondition);
            activity.Postcondition.Add(postcondition);

            Assert.That(activity.QueryAllConstraints(), Is.EqualTo(new[] { inheritedRule, rule, precondition, postcondition }), "ordered by name");
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
            mammal.Generalization.Add(animal_is_generalization_of_mammal);

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
            mammal.Generalization.Add(animal_is_generalization_of_mammal);

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
        public void Verify_that_QueryAllSpecializations_and_QueryContainers_find_classifiers_that_are_not_packaged_elements_of_a_package()
        {
            // package
            //   Base, Part
            //   Outer (nestedClassifier: NestedSpecialization : Base, NestedWhole with a composite part : Part)
            //   IOuter (nestedClassifier: InterfaceNestedSpecialization : Base)
            //   Component (packagedElement: ComponentSpecialization : Base, ComponentWhole with a composite part : Part)
            //   WithBehavior (ownedBehavior: BehaviorSpecialization : Base)
            var package = new Package { Name = "package" };

            var @base = new Class { Name = "Base" };
            var part = new Class { Name = "Part" };
            package.PackagedElement.Add(@base);
            package.PackagedElement.Add(part);

            Class CreateSpecialization(string name)
            {
                var specialization = new Class { Name = name };
                specialization.Generalization.Add(new Generalization { General = @base });
                return specialization;
            }

            Class CreateWhole(string name)
            {
                var whole = new Class { Name = name };
                whole.OwnedAttribute.Add(new Property { Name = "part", Type = part, Aggregation = AggregationKind.Composite });
                return whole;
            }

            var outer = new Class { Name = "Outer" };
            var nestedSpecialization = CreateSpecialization("NestedSpecialization");
            var nestedWhole = CreateWhole("NestedWhole");
            outer.NestedClassifier.Add(nestedSpecialization);
            outer.NestedClassifier.Add(nestedWhole);
            package.PackagedElement.Add(outer);

            var outerInterface = new Interface { Name = "IOuter" };
            var interfaceNestedSpecialization = CreateSpecialization("InterfaceNestedSpecialization");
            outerInterface.NestedClassifier.Add(interfaceNestedSpecialization);
            package.PackagedElement.Add(outerInterface);

            var component = new Component { Name = "Component" };
            var componentSpecialization = CreateSpecialization("ComponentSpecialization");
            var componentWhole = CreateWhole("ComponentWhole");
            component.PackagedElement.Add(componentSpecialization);
            component.PackagedElement.Add(componentWhole);
            package.PackagedElement.Add(component);

            var withBehavior = new Class { Name = "WithBehavior" };
            var behaviorSpecialization = new Activity { Name = "BehaviorSpecialization" };
            behaviorSpecialization.Generalization.Add(new Generalization { General = @base });
            withBehavior.OwnedBehavior.Add(behaviorSpecialization);
            package.PackagedElement.Add(withBehavior);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@base.Cache, Is.Null, "the path without cache is verified");
                Assert.That(@base.QueryAllSpecializations(), Is.EquivalentTo(new IClass[] { nestedSpecialization, interfaceNestedSpecialization, componentSpecialization, behaviorSpecialization }));
                Assert.That(part.QueryContainers(), Is.EqualTo(new IClassifier[] { componentWhole, nestedWhole }), "ordered by name");
            }
        }

        [Test]
        public void Verify_that_QueryAllSpecializations_throws_when_class_is_null()
        {
            Assert.That(() => ClassExtensions.QueryAllSpecializations(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryAllDescendantSpecializations_throws_when_class_is_null()
        {
            Assert.That(() => ClassExtensions.QueryAllDescendantSpecializations(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryAllDescendantSpecializations_returns_expected_result_with_cache()
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
            mammal.Generalization.Add(animal_is_generalization_of_mammal);

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
                Assert.That(animal.QueryAllDescendantSpecializations(), Is.EquivalentTo(new[] { mammal, cat_1, cat_2 }));
                Assert.That(mammal.QueryAllDescendantSpecializations(), Is.EquivalentTo(new[] { cat_1, cat_2 }));
                Assert.That(cat_1.QueryAllDescendantSpecializations(), Is.Empty);
                Assert.That(cat_2.QueryAllDescendantSpecializations(), Is.Empty);
            }
        }

        [Test]
        public void Verify_that_QueryAllDescendantSpecializations_returns_expected_result_without_cache()
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
            mammal.Generalization.Add(animal_is_generalization_of_mammal);

            rootPackage.PackagedElement.Add(animal);
            rootPackage.PackagedElement.Add(mammal);

            otherPackage.PackagedElement.Add(cat_1);
            otherPackage.PackagedElement.Add(cat_2);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(animal.QueryAllDescendantSpecializations(), Is.EquivalentTo(new[] { mammal, cat_1, cat_2 }));
                Assert.That(mammal.QueryAllDescendantSpecializations(), Is.EquivalentTo(new[] { cat_1, cat_2 }));
                Assert.That(cat_1.QueryAllDescendantSpecializations(), Is.Empty);
            }
        }

        [Test]
        public void Verify_that_QueryAllDescendantSpecializations_returns_expected_result_for_real_uml_model()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonBehaviorPackage = root.NestedPackage.Single(x => x.Name == "CommonBehavior");
            var behavior = commonBehaviorPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Behavior");

            var descendants = behavior.QueryAllDescendantSpecializations();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(descendants, Is.Not.Empty);
                Assert.That(descendants.Count, Is.GreaterThan(behavior.QueryAllSpecializations().Count));
                Assert.That(descendants.Any(x => x.Name == "Activity"), Is.True);
            }
        }
    }
}
