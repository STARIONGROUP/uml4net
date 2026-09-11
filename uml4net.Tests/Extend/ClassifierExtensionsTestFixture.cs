// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests.Extend
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ClassifierExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryAttribute_returns_expected_result()
        {
            var @interface = new Interface();

            var property = new Property
            {
                XmiId = "test_id",
                Name = "test",
            };

            @interface.OwnedAttribute.Add(property);

            var properties = Classification.ClassifierExtensions.QueryAttribute(@interface);

            Assert.That(properties.Single(), Is.EqualTo(property));
        }

        [Test]
        public void Verify_that_when_Class_is_null_argument_exception_is_thrown()
        {
            Class @class = null;

            Assert.That(() => ClassifierExtensions.QueryGeneral(@class), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryAttribute_returns_throws_exception_when_argument_is_Null()
        {
            IInterface @interface = null;

            Assert.That(() => Classification.ClassifierExtensions.QueryAttribute(@interface),
                Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_new_Classifier_query_methods_throw_when_argument_is_null()
        {
            Class @class = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => ClassifierExtensions.QueryAllParents(@class), Throws.ArgumentNullException);
                Assert.That(() => ClassifierExtensions.QueryDirectlyRealizedInterfaces(@class), Throws.ArgumentNullException);
                Assert.That(() => ClassifierExtensions.QueryDirectlyUsedInterfaces(@class), Throws.ArgumentNullException);
                Assert.That(() => ClassifierExtensions.QueryAllRealizedInterfaces(@class), Throws.ArgumentNullException);
                Assert.That(() => ClassifierExtensions.QueryAllUsedInterfaces(@class), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryAllParents_returns_the_transitive_closure_of_general_classifiers()
        {
            var grandParent = new Class { Name = "GrandParent" };
            var parent = new Class { Name = "Parent" };
            var child = new Class { Name = "Child" };

            parent.Generalization.Add(new Generalization { General = grandParent });
            child.Generalization.Add(new Generalization { General = parent });

            Assert.That(child.QueryAllParents(), Is.EquivalentTo(new IClassifier[] { parent, grandParent }));
        }

        [Test]
        public void Verify_that_QueryAllParents_returns_an_empty_list_when_there_are_no_generalizations()
        {
            var @class = new Class { Name = "Standalone" };

            Assert.That(@class.QueryAllParents(), Is.Empty);
        }

        [Test]
        public void Verify_that_QueryDirectlyRealizedInterfaces_returns_the_interfaces_realized_via_client_dependency()
        {
            var package = new Package { Name = "root" };
            var @class = new Class { Name = "MyClass" };
            var @interface = new Interface { Name = "MyInterface" };
            package.PackagedElement.Add(@class);
            package.PackagedElement.Add(@interface);

            var realization = new Realization { Name = "Realization" };
            realization.Client.Add(@class);
            realization.Supplier.Add(@interface);
            package.PackagedElement.Add(realization);

            Assert.That(@class.QueryDirectlyRealizedInterfaces(), Is.EquivalentTo(new[] { @interface }));
        }

        [Test]
        public void Verify_that_QueryDirectlyRealizedInterfaces_excludes_realizations_with_a_non_interface_supplier()
        {
            var package = new Package { Name = "root" };
            var @class = new Class { Name = "MyClass" };
            var nonInterfaceSupplier = new Class { Name = "NotAnInterface" };
            package.PackagedElement.Add(@class);
            package.PackagedElement.Add(nonInterfaceSupplier);

            var realization = new Realization { Name = "Realization" };
            realization.Client.Add(@class);
            realization.Supplier.Add(nonInterfaceSupplier);
            package.PackagedElement.Add(realization);

            Assert.That(@class.QueryDirectlyRealizedInterfaces(), Is.Empty);
        }

        [Test]
        public void Verify_that_QueryDirectlyUsedInterfaces_returns_the_interfaces_used_via_supplier_dependency()
        {
            var package = new Package { Name = "root" };
            var @class = new Class { Name = "MyClass" };
            var @interface = new Interface { Name = "MyInterface" };
            package.PackagedElement.Add(@class);
            package.PackagedElement.Add(@interface);

            var usage = new Usage { Name = "Usage" };
            usage.Client.Add(@interface);
            usage.Supplier.Add(@class);
            package.PackagedElement.Add(usage);

            Assert.That(@class.QueryDirectlyUsedInterfaces(), Is.EquivalentTo(new[] { @interface }));
        }

        [Test]
        public void Verify_that_QueryAllRealizedInterfaces_includes_interfaces_realized_by_a_general_classifier()
        {
            var package = new Package { Name = "root" };
            var parent = new Class { Name = "Parent" };
            var child = new Class { Name = "Child" };
            var @interface = new Interface { Name = "MyInterface" };
            package.PackagedElement.Add(parent);
            package.PackagedElement.Add(child);
            package.PackagedElement.Add(@interface);

            child.Generalization.Add(new Generalization { General = parent });

            var realization = new Realization { Name = "Realization" };
            realization.Client.Add(parent);
            realization.Supplier.Add(@interface);
            package.PackagedElement.Add(realization);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(parent.QueryDirectlyRealizedInterfaces(), Is.EquivalentTo(new[] { @interface }));
                Assert.That(child.QueryDirectlyRealizedInterfaces(), Is.Empty);
                Assert.That(child.QueryAllRealizedInterfaces(), Is.EquivalentTo(new[] { @interface }));
            }
        }

        [Test]
        public void Verify_that_QueryAllUsedInterfaces_includes_interfaces_used_by_a_general_classifier()
        {
            var package = new Package { Name = "root" };
            var parent = new Class { Name = "Parent" };
            var child = new Class { Name = "Child" };
            var @interface = new Interface { Name = "MyInterface" };
            package.PackagedElement.Add(parent);
            package.PackagedElement.Add(child);
            package.PackagedElement.Add(@interface);

            child.Generalization.Add(new Generalization { General = parent });

            var usage = new Usage { Name = "Usage" };
            usage.Client.Add(@interface);
            usage.Supplier.Add(parent);
            package.PackagedElement.Add(usage);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(parent.QueryDirectlyUsedInterfaces(), Is.EquivalentTo(new[] { @interface }));
                Assert.That(child.QueryDirectlyUsedInterfaces(), Is.Empty);
                Assert.That(child.QueryAllUsedInterfaces(), Is.EquivalentTo(new[] { @interface }));
            }
        }
    }
}