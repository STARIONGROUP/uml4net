// -------------------------------------------------------------------------------------------------
// <copyright file="ElementExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ElementExtensionsTestFixture
    {
        private Package outerPackage;

        private Package innerPackage;

        private Class outerClass;

        private Class nestedClass;

        private Class specializationOfNestedClass;

        private Component component;

        private Class classPackagedInComponent;

        private Interface realizedInterface;

        [SetUp]
        public void SetUp()
        {
            // outerPackage
            //   innerPackage
            //     outerClass (nestedClassifier: nestedClass, a composite attribute typed by nestedClass)
            //     specializationOfNestedClass
            //     component (packagedElement: classPackagedInComponent)
            //   realizedInterface
            //   a Realization from classPackagedInComponent to realizedInterface
            this.outerPackage = new Package { XmiId = "outerPackage", Name = "outerPackage" };
            this.innerPackage = new Package { XmiId = "innerPackage", Name = "innerPackage" };
            this.outerPackage.PackagedElement.Add(this.innerPackage);

            this.outerClass = new Class { XmiId = "outerClass", Name = "OuterClass" };
            this.nestedClass = new Class { XmiId = "nestedClass", Name = "NestedClass" };
            this.outerClass.NestedClassifier.Add(this.nestedClass);
            this.outerClass.OwnedAttribute.Add(new Property { XmiId = "part", Name = "part", Type = this.nestedClass, Aggregation = AggregationKind.Composite });
            this.innerPackage.PackagedElement.Add(this.outerClass);

            this.specializationOfNestedClass = new Class { XmiId = "specializationOfNestedClass", Name = "SpecializationOfNestedClass" };
            this.specializationOfNestedClass.Generalization.Add(new Generalization { XmiId = "generalization", General = this.nestedClass, Specific = this.specializationOfNestedClass });
            this.innerPackage.PackagedElement.Add(this.specializationOfNestedClass);

            this.component = new Component { XmiId = "component", Name = "Component" };
            this.classPackagedInComponent = new Class { XmiId = "classPackagedInComponent", Name = "ClassPackagedInComponent" };
            this.component.PackagedElement.Add(this.classPackagedInComponent);
            this.innerPackage.PackagedElement.Add(this.component);

            this.realizedInterface = new Interface { XmiId = "realizedInterface", Name = "RealizedInterface" };
            this.outerPackage.PackagedElement.Add(this.realizedInterface);

            var realization = new Realization { XmiId = "realization" };
            realization.Client.Add(this.classPackagedInComponent);
            realization.Supplier.Add(this.realizedInterface);
            this.outerPackage.PackagedElement.Add(realization);
        }

        [Test]
        public void Verify_that_QueryRootPackage_returns_the_outermost_package_whatever_the_kinds_of_the_owners_in_between()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.outerPackage.QueryRootPackage(), Is.SameAs(this.outerPackage), "the element itself");
                Assert.That(this.innerPackage.QueryRootPackage(), Is.SameAs(this.outerPackage));
                Assert.That(this.outerClass.QueryRootPackage(), Is.SameAs(this.outerPackage));
                Assert.That(this.nestedClass.QueryRootPackage(), Is.SameAs(this.outerPackage), "owned by a Class");
                Assert.That(this.outerClass.OwnedAttribute.Single().QueryRootPackage(), Is.SameAs(this.outerPackage), "owned by a Class");
                Assert.That(this.classPackagedInComponent.QueryRootPackage(), Is.SameAs(this.outerPackage), "owned by a Component");

                var classWithoutPackage = new Class();
                var nestedClassWithoutPackage = new Class();
                classWithoutPackage.NestedClassifier.Add(nestedClassWithoutPackage);

                Assert.That(classWithoutPackage.QueryRootPackage(), Is.Null);
                Assert.That(nestedClassWithoutPackage.QueryRootPackage(), Is.Null);

                Assert.That(() => ElementExtensions.QueryRootPackage(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_the_helpers_that_start_at_the_root_package_work_for_elements_not_owned_by_a_package()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.nestedClass.QueryContainers(), Is.EqualTo(new[] { this.outerClass }));
                Assert.That(this.nestedClass.QueryAllSpecializations(), Is.EqualTo(new[] { this.specializationOfNestedClass }));
                Assert.That(this.classPackagedInComponent.QueryInterfaces(), Is.EqualTo(new[] { this.realizedInterface }));
            }
        }

        [Test]
        public void Verify_that_the_helpers_that_start_at_the_root_package_return_nothing_without_a_package()
        {
            var classWithoutPackage = new Class { XmiId = "classWithoutPackage" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classWithoutPackage.QueryContainers(), Is.Empty);
                Assert.That(classWithoutPackage.QueryAllSpecializations(), Is.Empty);
                Assert.That(classWithoutPackage.QueryInterfaces(), Is.Empty);
            }
        }
    }
}
