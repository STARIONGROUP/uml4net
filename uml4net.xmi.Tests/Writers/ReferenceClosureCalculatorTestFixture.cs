// -------------------------------------------------------------------------------------------------
// <copyright file="ReferenceClosureCalculatorTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests.Writers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;
    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;

    [TestFixture]
    public class ReferenceClosureCalculatorTestFixture
    {
        private ReferenceClosureCalculator referenceClosureCalculator;

        private Package packageA;

        private Class classA;

        private Property property;

        private Package packageB;

        private PrimitiveType primitiveType;

        [SetUp]
        public void SetUp()
        {
            this.referenceClosureCalculator = new ReferenceClosureCalculator(NullLogger<ReferenceClosureCalculator>.Instance);

            this.packageB = new Package { XmiId = "PackageB", DocumentName = "b.xmi", Name = "PackageB" };
            this.primitiveType = new PrimitiveType { XmiId = "String", DocumentName = "b.xmi", Name = "String" };
            this.packageB.PackagedElement.Add(this.primitiveType);

            this.packageA = new Package { XmiId = "PackageA", DocumentName = "a.xmi", Name = "PackageA" };
            this.classA = new Class { XmiId = "ClassA", DocumentName = "a.xmi", Name = "ClassA" };
            this.property = new Property { XmiId = "Property1", DocumentName = "a.xmi", Name = "property1" };
            this.property.Type = this.primitiveType;
            this.classA.OwnedAttribute.Add(this.property);
            this.packageA.PackagedElement.Add(this.classA);
        }

        [Test]
        public void Verify_that_CalculateWritePlan_throws_when_arguments_are_null()
        {
            Assert.That(() => this.referenceClosureCalculator.CalculateWritePlan((IPackage)null, ExternalReferenceResolutionKind.Href, "a.xmi"),
                Throws.ArgumentNullException);

            Assert.That(() => this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Href, null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_Href_plan_contains_selected_package_only()
        {
            var plan = this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Href, "a.xmi");

            Assert.That(plan.RootPackages, Is.EqualTo(new[] { this.packageA }));

            Assert.That(plan.LocalIdentifiers, Does.Contain(this.packageA.FullyQualifiedIdentifier));
            Assert.That(plan.LocalIdentifiers, Does.Contain(this.classA.FullyQualifiedIdentifier));
            Assert.That(plan.LocalIdentifiers, Does.Contain(this.property.FullyQualifiedIdentifier));

            Assert.That(plan.LocalIdentifiers, Does.Not.Contain(this.primitiveType.FullyQualifiedIdentifier));
            Assert.That(plan.LocalIdentifiers, Does.Not.Contain(this.packageB.FullyQualifiedIdentifier));

            Assert.That(plan.ElementsMissingXmiId, Is.Empty);
        }

        [Test]
        public void Verify_that_Include_plan_pulls_in_referenced_root_package()
        {
            var plan = this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Include, "a.xmi");

            Assert.That(plan.RootPackages, Is.EqualTo(new IPackage[] { this.packageA, this.packageB }));

            Assert.That(plan.LocalIdentifiers, Does.Contain(this.primitiveType.FullyQualifiedIdentifier));
            Assert.That(plan.LocalIdentifiers, Does.Contain(this.packageB.FullyQualifiedIdentifier));

            Assert.That(plan.ElementsMissingXmiId, Is.Empty);
        }

        [Test]
        public void Verify_that_Include_plan_pulls_in_transitively_referenced_root_packages()
        {
            var packageC = new Package { XmiId = "PackageC", DocumentName = "c.xmi", Name = "PackageC" };
            var dataType = new DataType { XmiId = "DataType1", DocumentName = "c.xmi", Name = "DataType1" };
            packageC.PackagedElement.Add(dataType);

            var propertyB = new Property { XmiId = "PropertyB", DocumentName = "b.xmi", Name = "propertyB" };
            propertyB.Type = dataType;
            var classB = new Class { XmiId = "ClassB", DocumentName = "b.xmi", Name = "ClassB" };
            classB.OwnedAttribute.Add(propertyB);
            this.packageB.PackagedElement.Add(classB);

            var plan = this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Include, "a.xmi");

            Assert.That(plan.RootPackages, Is.EqualTo(new IPackage[] { this.packageA, this.packageB, packageC }));

            Assert.That(plan.LocalIdentifiers, Does.Contain(dataType.FullyQualifiedIdentifier));
        }

        [Test]
        public void Verify_that_Include_plan_orders_included_packages_by_name()
        {
            var packageC = new Package { XmiId = "PackageC", DocumentName = "c.xmi", Name = "APackageC" };
            var dataType = new DataType { XmiId = "DataType1", DocumentName = "c.xmi", Name = "DataType1" };
            packageC.PackagedElement.Add(dataType);

            var otherProperty = new Property { XmiId = "Property2", DocumentName = "a.xmi", Name = "property2" };
            otherProperty.Type = dataType;
            this.classA.OwnedAttribute.Add(otherProperty);

            var plan = this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Include, "a.xmi");

            Assert.That(plan.RootPackages.First(), Is.EqualTo(this.packageA));
            Assert.That(plan.RootPackages.Skip(1).Select(x => x.Name), Is.EqualTo(new[] { "APackageC", "PackageB" }));
        }

        [Test]
        public void Verify_that_Include_plan_skips_referenced_elements_that_are_not_contained_by_a_root_package()
        {
            var freeFloatingType = new Class { XmiId = "FreeFloating", DocumentName = "free.xmi", Name = "FreeFloating" };
            this.property.Type = freeFloatingType;

            var plan = this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Include, "a.xmi");

            Assert.That(plan.RootPackages, Is.EqualTo(new[] { this.packageA }));
            Assert.That(plan.LocalIdentifiers, Does.Not.Contain(freeFloatingType.FullyQualifiedIdentifier));
        }

        [Test]
        public void Verify_that_Href_plan_excludes_owned_elements_defined_in_another_document()
        {
            var constraint = new Constraint { XmiId = "Constraint1", DocumentName = "b.xmi", Name = "constraint1" };
            var specification = new OpaqueExpression { XmiId = "Specification1", DocumentName = "b.xmi" };
            constraint.Specification.Add(specification);
            this.classA.OwnedRule.Add(constraint);

            var programmaticConstraint = new Constraint { XmiId = "Constraint2", Name = "constraint2" };
            this.classA.OwnedRule.Add(programmaticConstraint);

            var plan = this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Href, "renamed.xmi");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(plan.LocalIdentifiers, Does.Contain(this.classA.FullyQualifiedIdentifier));
                Assert.That(plan.LocalIdentifiers, Does.Contain(programmaticConstraint.FullyQualifiedIdentifier));
                Assert.That(plan.LocalIdentifiers, Does.Not.Contain(constraint.FullyQualifiedIdentifier));
                Assert.That(plan.LocalIdentifiers, Does.Not.Contain(specification.FullyQualifiedIdentifier));
                Assert.That(plan.ElementsMissingXmiId, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_Href_plan_reports_owned_elements_defined_in_another_document_without_XmiId()
        {
            var constraint = new Constraint { DocumentName = "b.xmi", Name = "constraint1" };
            this.classA.OwnedRule.Add(constraint);

            var plan = this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Href, "a.xmi");

            Assert.That(plan.ElementsMissingXmiId, Is.EqualTo(new[] { constraint }));
        }

        [Test]
        public void Verify_that_Href_plan_collects_all_owned_elements_when_the_package_has_no_document_name()
        {
            this.packageA.DocumentName = null;

            var constraint = new Constraint { XmiId = "Constraint1", DocumentName = "b.xmi", Name = "constraint1" };
            this.classA.OwnedRule.Add(constraint);

            var plan = this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Href, "a.xmi");

            Assert.That(plan.LocalIdentifiers, Does.Contain(constraint.FullyQualifiedIdentifier));
        }

        [Test]
        public void Verify_that_Include_plan_keeps_owned_elements_defined_in_another_document()
        {
            var constraint = new Constraint { XmiId = "Constraint1", DocumentName = "b.xmi", Name = "constraint1" };
            this.classA.OwnedRule.Add(constraint);

            var plan = this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Include, "a.xmi");

            Assert.That(plan.LocalIdentifiers, Does.Contain(constraint.FullyQualifiedIdentifier));
        }

        [Test]
        public void Verify_that_CalculateWritePlan_for_root_elements_throws_when_arguments_are_invalid()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => this.referenceClosureCalculator.CalculateWritePlan((IEnumerable<IXmiElement>)null, ExternalReferenceResolutionKind.Href, "a.xmi"),
                    Throws.ArgumentNullException);

                Assert.That(() => this.referenceClosureCalculator.CalculateWritePlan(new IXmiElement[] { this.packageA }, ExternalReferenceResolutionKind.Href, null),
                    Throws.ArgumentNullException);

                Assert.That(() => this.referenceClosureCalculator.CalculateWritePlan(new IXmiElement[0], ExternalReferenceResolutionKind.Href, "a.xmi"),
                    Throws.ArgumentException);

                Assert.That(() => this.referenceClosureCalculator.CalculateWritePlan(new IXmiElement[] { this.packageA, null }, ExternalReferenceResolutionKind.Href, "a.xmi"),
                    Throws.ArgumentException);

                Assert.That(() => this.referenceClosureCalculator.CalculateWritePlan(new IXmiElement[] { this.packageA, this.packageA }, ExternalReferenceResolutionKind.Href, "a.xmi"),
                    Throws.ArgumentException);

                Assert.That(() => this.referenceClosureCalculator.CalculateWritePlan(new IXmiElement[] { this.property, this.packageA }, ExternalReferenceResolutionKind.Href, "a.xmi"),
                    Throws.ArgumentException.With.Message.Contains("Property1").And.Message.Contains("PackageA"));
            }
        }

        [Test]
        public void Verify_that_Href_plan_for_root_elements_contains_all_root_elements_in_order()
        {
            var standaloneClass = new Class { XmiId = "Standalone", DocumentName = "a.xmi", Name = "Standalone" };
            var standaloneProperty = new Property { XmiId = "StandaloneProperty", DocumentName = "a.xmi", Name = "standaloneProperty" };
            standaloneProperty.Type = this.primitiveType;
            standaloneClass.OwnedAttribute.Add(standaloneProperty);

            var plan = this.referenceClosureCalculator.CalculateWritePlan(new IXmiElement[] { standaloneClass, this.packageA }, ExternalReferenceResolutionKind.Href, "a.xmi");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(plan.RootElements, Is.EqualTo(new IXmiElement[] { standaloneClass, this.packageA }));
                Assert.That(plan.RootPackages, Is.EqualTo(new[] { this.packageA }));
                Assert.That(plan.LocalIdentifiers, Does.Contain(standaloneProperty.FullyQualifiedIdentifier));
                Assert.That(plan.LocalIdentifiers, Does.Contain(this.classA.FullyQualifiedIdentifier));
                Assert.That(plan.LocalIdentifiers, Does.Not.Contain(this.primitiveType.FullyQualifiedIdentifier));
                Assert.That(plan.ElementsMissingXmiId, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_Include_plan_for_a_root_element_that_is_not_a_package_pulls_in_referenced_root_package()
        {
            var standaloneClass = new Class { XmiId = "Standalone", DocumentName = "a.xmi", Name = "Standalone" };
            var standaloneProperty = new Property { XmiId = "StandaloneProperty", DocumentName = "a.xmi", Name = "standaloneProperty" };
            standaloneProperty.Type = this.primitiveType;
            standaloneClass.OwnedAttribute.Add(standaloneProperty);

            var plan = this.referenceClosureCalculator.CalculateWritePlan(new IXmiElement[] { standaloneClass }, ExternalReferenceResolutionKind.Include, "a.xmi");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(plan.RootElements, Is.EqualTo(new IXmiElement[] { standaloneClass, this.packageB }));
                Assert.That(plan.RootPackages, Is.EqualTo(new[] { this.packageB }));
                Assert.That(plan.LocalIdentifiers, Does.Contain(this.primitiveType.FullyQualifiedIdentifier));
            }
        }

        [Test]
        public void Verify_that_a_root_element_that_is_not_a_package_without_XmiId_is_reported()
        {
            var standaloneClass = new Class { DocumentName = "a.xmi", Name = "Standalone" };

            var plan = this.referenceClosureCalculator.CalculateWritePlan(new IXmiElement[] { standaloneClass }, ExternalReferenceResolutionKind.Href, "a.xmi");

            Assert.That(plan.ElementsMissingXmiId, Is.EqualTo(new[] { standaloneClass }));
        }

        [Test]
        public void Verify_that_a_referenced_root_package_without_XmiId_is_reported()
        {
            // a reference to it would be written as href="document#", which points at the document (XMI 2.5.1 clause 7.10.2)
            var unidentified = new Package { DocumentName = "w2.xmi", Name = "Unidentified" };
            var importing = new Package { XmiId = "importing", DocumentName = "w2.xmi", Name = "Importing" };
            importing.PackageImport.Add(new PackageImport { XmiId = "pi", DocumentName = "w2.xmi", ImportedPackage = unidentified });

            var plan = this.referenceClosureCalculator.CalculateWritePlan(new IXmiElement[] { unidentified, importing }, ExternalReferenceResolutionKind.Href, "w2.xmi");

            Assert.That(plan.ElementsMissingXmiId, Is.EqualTo(new[] { unidentified }));
        }

        [Test]
        public void Verify_that_a_referenced_element_of_another_document_without_XmiId_is_reported()
        {
            // the root package of ea.xmi has no xmi:id, as Enterprise Architect exports it: an href to it would be
            // href="ea.xmi#", which points at the document instead of the package
            var model = new Model { DocumentName = "ea.xmi", Name = "EA_Model" };
            var identifiedClass = new Class { XmiId = "identified", DocumentName = "ea.xmi", Name = "Identified" };
            model.PackagedElement.Add(identifiedClass);

            var importing = new Package { XmiId = "importing", DocumentName = "b.xmi", Name = "Importing" };
            importing.PackageImport.Add(new PackageImport { XmiId = "pi", DocumentName = "b.xmi", ImportedPackage = model });
            importing.ElementImport.Add(new ElementImport { XmiId = "ei", DocumentName = "b.xmi", ImportedElement = identifiedClass });

            using (Assert.EnterMultipleScope())
            {
                var hrefPlan = this.referenceClosureCalculator.CalculateWritePlan(importing, ExternalReferenceResolutionKind.Href, "b.xmi");
                Assert.That(hrefPlan.ElementsMissingXmiId, Is.EqualTo(new[] { model }), "the class of ea.xmi has an XmiId and can be referenced by href");

                var includePlan = this.referenceClosureCalculator.CalculateWritePlan(importing, ExternalReferenceResolutionKind.Include, "b.xmi");
                Assert.That(includePlan.RootElements, Is.EqualTo(new IXmiElement[] { importing, model }), "the referenced root package is included");
                Assert.That(includePlan.ElementsMissingXmiId, Is.EqualTo(new[] { model }), "an included root package that is referenced needs an XmiId as well");
            }
        }

        [Test]
        public void Verify_that_an_unreferenced_root_package_without_XmiId_is_not_reported_although_its_owner_ends_refer_to_it()
        {
            // how Enterprise Architect exports its uml:Model; the owner ends of the contained elements (Type::package,
            // Package::nestingPackage, Generalization::specific, ...) refer to their owner but are not written
            var model = new Model { DocumentName = "ea.xmi", Name = "EA_Model" };
            var nestedPackage = new Package { XmiId = "nested", DocumentName = "ea.xmi", Name = "Nested" };
            var @class = new Class { XmiId = "class", DocumentName = "ea.xmi", Name = "Class" };
            model.PackagedElement.Add(nestedPackage);
            model.PackagedElement.Add(@class);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(nestedPackage.NestingPackage, Is.SameAs(model), "the owner end is set");
                Assert.That(@class.Package, Is.SameAs(model), "the owner end is set");

                var plan = this.referenceClosureCalculator.CalculateWritePlan(model, ExternalReferenceResolutionKind.Href, "ea.xmi");

                Assert.That(plan.ElementsMissingXmiId, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_elements_without_XmiId_are_reported()
        {
            var invalidClass = new Class { DocumentName = "a.xmi", Name = "Invalid" };
            this.packageA.PackagedElement.Add(invalidClass);

            var plan = this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Href, "a.xmi");

            Assert.That(plan.ElementsMissingXmiId, Is.EqualTo(new[] { invalidClass }));
        }
    }
}
