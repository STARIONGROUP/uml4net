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

    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;

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
        public void Verify_that_QueryNamespace_is_null_when_the_owner_is_not_a_Namespace()
        {
            var package = new Package { Name = "P" };
            var @class = new Class { Name = "C" };
            var property = new Property { Name = "p" };
            var lowerValue = new LiteralInteger { Name = "lower", Value = 0 };
            var defaultValue = new LiteralString { Name = "default", Value = "x" };

            package.PackagedElement.Add(@class);
            @class.OwnedAttribute.Add(property);
            property.LowerValue.Add(lowerValue);
            property.DefaultValue.Add(defaultValue);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(property.Namespace, Is.SameAs(@class), "an owned attribute is an owned member of its class");
                Assert.That(lowerValue.Namespace, Is.Null, "a lowerValue is owned by a Property, which is not a Namespace; the class is not returned in its place");
                Assert.That(defaultValue.Namespace, Is.Null, "a defaultValue is owned by a Property, which is not a Namespace");
            }
        }

        [Test]
        public void Verify_that_QueryNamespace_is_null_for_a_pin_owned_by_an_action()
        {
            var activity = new Activity { Name = "A" };
            var action = new OpaqueAction { Name = "act" };
            var pin = new InputPin { Name = "in" };

            activity.Node.Add(action);
            action.InputValue.Add(pin);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(action.Namespace, Is.Null, "Activity::node subsets ownedElement only, not ownedMember, so a node has no namespace");
                Assert.That(pin.Namespace, Is.Null, "an Action is not a Namespace; the activity is not returned in its place");
                Assert.That(activity.OwnedElement, Does.Contain(action), "the node is nevertheless owned by the activity");
            }
        }

        [Test]
        public void Verify_that_QueryNamespace_is_null_and_does_not_throw_when_no_ancestor_is_a_Namespace()
        {
            var property = new Property { Name = "p" };
            var lowerValue = new LiteralInteger { Name = "lower", Value = 0 };

            property.LowerValue.Add(lowerValue);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => lowerValue.Namespace, Throws.Nothing);
                Assert.That(lowerValue.Namespace, Is.Null);
                Assert.That(property.Namespace, Is.Null, "no owner at all");
            }
        }

        [Test]
        public void Verify_that_QueryNamespace_is_the_owner_only_when_the_element_is_one_of_its_owned_members()
        {
            var @class = new Class { Name = "C" };
            var rule = new Constraint { Name = "rule" };
            var operation = new Operation { Name = "op" };
            var parameter = new Parameter { Name = "par" };
            var template = new Class { Name = "T" };
            var signature = new RedefinableTemplateSignature { Name = "sig" };
            var templateParameter = new ClassifierTemplateParameter();
            var parameteredElement = new Class { Name = "P" };

            @class.OwnedRule.Add(rule);
            @class.OwnedOperation.Add(operation);
            operation.OwnedParameter.Add(parameter);
            template.OwnedTemplateSignature.Add(signature);
            signature.OwnedParameter.Add(templateParameter);
            templateParameter.OwnedParameteredElement.Add(parameteredElement);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(rule.Namespace, Is.SameAs(@class), "ownedRule subsets ownedMember");
                Assert.That(parameter.Namespace, Is.SameAs(operation), "an Operation is a Namespace whose ownedParameter subsets ownedMember");
                Assert.That(parameteredElement.Namespace, Is.Null, "a TemplateParameter is not a Namespace; the template class is not returned in its place");
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

        [Test]
        public void Verify_that_QueryIsDistinguishableFrom_throws_when_an_argument_is_null()
        {
            var package = new Package { Name = "root" };
            var @class = new Class { Name = "A" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => NamedElementExtensions.QueryIsDistinguishableFrom(null, @class, package), Throws.ArgumentNullException);
                Assert.That(() => NamedElementExtensions.QueryIsDistinguishableFrom(@class, null, package), Throws.ArgumentNullException);
                Assert.That(() => NamedElementExtensions.QueryIsDistinguishableFrom(@class, @class, null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryIsDistinguishableFrom_returns_true_for_unrelated_kinds_even_with_the_same_name()
        {
            var package = new Package { Name = "root" };
            var @class = new Class { Name = "Same" };
            var signal = new Signal { Name = "Same" };
            package.PackagedElement.Add(@class);
            package.PackagedElement.Add(signal);

            Assert.That(@class.QueryIsDistinguishableFrom(signal, package), Is.True);
        }

        [Test]
        public void Verify_that_QueryIsDistinguishableFrom_returns_false_for_the_same_kind_with_the_same_name()
        {
            var package = new Package { Name = "root" };
            var classA = new Class { Name = "Same" };
            var classB = new Class { Name = "Same" };
            package.PackagedElement.Add(classA);
            package.PackagedElement.Add(classB);

            Assert.That(classA.QueryIsDistinguishableFrom(classB, package), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsDistinguishableFrom_returns_true_for_the_same_kind_with_different_names()
        {
            var package = new Package { Name = "root" };
            var classA = new Class { Name = "A" };
            var classB = new Class { Name = "B" };
            package.PackagedElement.Add(classA);
            package.PackagedElement.Add(classB);

            Assert.That(classA.QueryIsDistinguishableFrom(classB, package), Is.True);
        }

        [Test]
        public void Verify_that_QueryIsDistinguishableFrom_returns_false_when_one_is_a_specialization_of_the_other_with_the_same_name()
        {
            var package = new Package { Name = "root" };
            var @class = new Class { Name = "Same" };
            var component = new Component { Name = "Same" };
            package.PackagedElement.Add(@class);
            package.PackagedElement.Add(component);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@class.QueryIsDistinguishableFrom(component, package), Is.False);
                Assert.That(component.QueryIsDistinguishableFrom(@class, package), Is.False);
            }
        }
    }
}
