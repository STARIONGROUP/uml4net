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
    using System.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
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
            Assert.That(() => this.referenceClosureCalculator.CalculateWritePlan(null, ExternalReferenceResolutionKind.Href, "a.xmi"),
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
        public void Verify_that_elements_without_XmiId_are_reported()
        {
            var invalidClass = new Class { DocumentName = "a.xmi", Name = "Invalid" };
            this.packageA.PackagedElement.Add(invalidClass);

            var plan = this.referenceClosureCalculator.CalculateWritePlan(this.packageA, ExternalReferenceResolutionKind.Href, "a.xmi");

            Assert.That(plan.ElementsMissingXmiId, Is.EqualTo(new[] { invalidClass }));
        }
    }
}
