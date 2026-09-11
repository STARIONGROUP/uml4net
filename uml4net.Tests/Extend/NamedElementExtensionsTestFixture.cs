// -------------------------------------------------------------------------------------------------
// <copyright file="NamedElementExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using CommonStructure;
    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class NamedElementExtensionsTestFixture
    {
        [Test]
        public void Verify_that_the_fully_qualified_name_of_a_class_returns_the_expected_result()
        {
            var rootPackage = new Package { Name = "root" };
            var package = new Package { Name = "sub" };
            var @class = new Class { Name = "class_A" };

            rootPackage.PackagedElement.Add(package);
            package.PackagedElement.Add(@class);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(rootPackage.QualifiedName, Is.EqualTo("root"));
                Assert.That(package.QualifiedName, Is.EqualTo("root::sub"));
                Assert.That(@class.QualifiedName, Is.EqualTo("root::sub::class_A"));
            }
        }

        [Test]
        public void Verify_that_QueryNamespace_returns_the_expected_result()
        {
            var rootPackage = new Package { Name = "root" };
            var package = new Package { Name = "sub" };
            var @class = new Class { Name = "class_A" };

            rootPackage.PackagedElement.Add(package);
            package.PackagedElement.Add(@class);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@class.Namespace, Is.EqualTo(package));
                Assert.That(package.Namespace, Is.EqualTo(rootPackage));
                Assert.That(rootPackage.Namespace, Is.Null);
            }
        }

        [Test]
        public void Verify_that_when_NamedElement_is_null_argument_exception_is_thrown()
        {
            Class @class = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => NamedElementExtensions.QueryQualifiedName(@class), Throws.ArgumentNullException);
                Assert.That(() => NamedElementExtensions.QueryNamespace(@class), Throws.ArgumentNullException);
                Assert.That(() => NamedElementExtensions.QueryClientDependency(@class), Throws.ArgumentNullException);
                Assert.That(() => NamedElementExtensions.QuerySupplierDependency(@class), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryClientDependency_returns_the_dependencies_referencing_the_namedElement_as_client()
        {
            var package = new Package { Name = "root" };
            var client = new Class { Name = "Client" };
            var supplier = new Class { Name = "Supplier" };
            var unrelated = new Class { Name = "Unrelated" };
            package.PackagedElement.Add(client);
            package.PackagedElement.Add(supplier);
            package.PackagedElement.Add(unrelated);

            var dependency = new Dependency { Name = "Dependency" };
            dependency.Client.Add(client);
            dependency.Supplier.Add(supplier);
            package.PackagedElement.Add(dependency);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(client.ClientDependency, Is.EquivalentTo(new[] { dependency }));
                Assert.That(supplier.ClientDependency, Is.Empty);
                Assert.That(unrelated.ClientDependency, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_QuerySupplierDependency_returns_the_dependencies_referencing_the_namedElement_as_supplier()
        {
            var package = new Package { Name = "root" };
            var client = new Class { Name = "Client" };
            var supplier = new Class { Name = "Supplier" };
            var unrelated = new Class { Name = "Unrelated" };
            package.PackagedElement.Add(client);
            package.PackagedElement.Add(supplier);
            package.PackagedElement.Add(unrelated);

            var dependency = new Dependency { Name = "Dependency" };
            dependency.Client.Add(client);
            dependency.Supplier.Add(supplier);
            package.PackagedElement.Add(dependency);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(supplier.QuerySupplierDependency(), Is.EquivalentTo(new[] { dependency }));
                Assert.That(client.QuerySupplierDependency(), Is.Empty);
                Assert.That(unrelated.QuerySupplierDependency(), Is.Empty);
            }
        }
    }
}
