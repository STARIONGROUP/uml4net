// -------------------------------------------------------------------------------------------------
// <copyright file="ComponentExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ComponentExtensionsTestFixture
    {
        [Test]
        public void Verify_that_new_Component_query_methods_throw_when_argument_is_null()
        {
            Component component = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => ComponentExtensions.QueryProvided(component), Throws.ArgumentNullException);
                Assert.That(() => ComponentExtensions.QueryRequired(component), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryProvided_includes_interfaces_directly_realized_by_the_component()
        {
            var package = new Package { Name = "root" };
            var component = new Component { Name = "MyComponent" };
            var providedInterface = new Interface { Name = "ProvidedInterface" };
            package.PackagedElement.Add(component);
            package.PackagedElement.Add(providedInterface);

            var realization = new Realization { Name = "Realization" };
            realization.Client.Add(component);
            realization.Supplier.Add(providedInterface);
            package.PackagedElement.Add(realization);

            Assert.That(component.QueryProvided(), Is.EquivalentTo(new[] { providedInterface }));
        }

        [Test]
        public void Verify_that_QueryRequired_includes_interfaces_directly_used_by_the_component()
        {
            var package = new Package { Name = "root" };
            var component = new Component { Name = "MyComponent" };
            var requiredInterface = new Interface { Name = "RequiredInterface" };
            package.PackagedElement.Add(component);
            package.PackagedElement.Add(requiredInterface);

            var usage = new Usage { Name = "Usage" };
            usage.Client.Add(requiredInterface);
            usage.Supplier.Add(component);
            package.PackagedElement.Add(usage);

            Assert.That(component.QueryRequired(), Is.EquivalentTo(new[] { requiredInterface }));
        }

        [Test]
        public void Verify_that_QueryProvided_includes_interfaces_realized_by_a_realizing_classifier()
        {
            var package = new Package { Name = "root" };
            var component = new Component { Name = "MyComponent" };
            var realizingClassifier = new Class { Name = "RealizingClass" };
            var providedInterface = new Interface { Name = "ProvidedInterface" };
            package.PackagedElement.Add(component);
            package.PackagedElement.Add(realizingClassifier);
            package.PackagedElement.Add(providedInterface);

            var componentRealization = new ComponentRealization { Name = "ComponentRealization" };
            componentRealization.RealizingClassifier.Add(realizingClassifier);
            component.Realization.Add(componentRealization);

            var realization = new Realization { Name = "Realization" };
            realization.Client.Add(realizingClassifier);
            realization.Supplier.Add(providedInterface);
            package.PackagedElement.Add(realization);

            Assert.That(component.QueryProvided(), Is.EquivalentTo(new[] { providedInterface }));
        }

        [Test]
        public void Verify_that_QueryRequired_includes_interfaces_used_by_a_realizing_classifier()
        {
            var package = new Package { Name = "root" };
            var component = new Component { Name = "MyComponent" };
            var realizingClassifier = new Class { Name = "RealizingClass" };
            var requiredInterface = new Interface { Name = "RequiredInterface" };
            package.PackagedElement.Add(component);
            package.PackagedElement.Add(realizingClassifier);
            package.PackagedElement.Add(requiredInterface);

            var componentRealization = new ComponentRealization { Name = "ComponentRealization" };
            componentRealization.RealizingClassifier.Add(realizingClassifier);
            component.Realization.Add(componentRealization);

            var usage = new Usage { Name = "Usage" };
            usage.Client.Add(requiredInterface);
            usage.Supplier.Add(realizingClassifier);
            package.PackagedElement.Add(usage);

            Assert.That(component.QueryRequired(), Is.EquivalentTo(new[] { requiredInterface }));
        }

        [Test]
        public void Verify_that_QueryProvided_includes_interfaces_provided_by_owned_ports()
        {
            var component = new Component { Name = "MyComponent" };
            var portInterface = new Interface { Name = "PortInterface" };
            var port = new Port { Name = "MyPort", Type = portInterface, IsConjugated = false };
            component.OwnedAttribute.Add(port);

            Assert.That(component.QueryProvided(), Is.EquivalentTo(new[] { portInterface }));
        }

        [Test]
        public void Verify_that_QueryRequired_includes_interfaces_required_by_owned_ports()
        {
            var component = new Component { Name = "MyComponent" };
            var portInterface = new Interface { Name = "PortInterface" };
            var port = new Port { Name = "MyPort", Type = portInterface, IsConjugated = true };
            component.OwnedAttribute.Add(port);

            Assert.That(component.QueryRequired(), Is.EquivalentTo(new[] { portInterface }));
        }

        [Test]
        public void Verify_that_QueryProvided_includes_interfaces_realized_and_provided_by_a_general_component()
        {
            var package = new Package { Name = "root" };
            var generalComponent = new Component { Name = "GeneralComponent" };
            var component = new Component { Name = "MyComponent" };
            var realizingClassifier = new Class { Name = "RealizingClass" };
            var realizedInterface = new Interface { Name = "RealizedInterface" };
            var portInterface = new Interface { Name = "PortInterface" };
            package.PackagedElement.Add(generalComponent);
            package.PackagedElement.Add(component);
            package.PackagedElement.Add(realizingClassifier);
            package.PackagedElement.Add(realizedInterface);
            package.PackagedElement.Add(portInterface);

            component.Generalization.Add(new Generalization { General = generalComponent });

            var componentRealization = new ComponentRealization { Name = "ComponentRealization" };
            componentRealization.RealizingClassifier.Add(realizingClassifier);
            generalComponent.Realization.Add(componentRealization);

            var realization = new Realization { Name = "Realization" };
            realization.Client.Add(realizingClassifier);
            realization.Supplier.Add(realizedInterface);
            package.PackagedElement.Add(realization);

            var port = new Port { Name = "GeneralPort", Type = portInterface, IsConjugated = false };
            generalComponent.OwnedAttribute.Add(port);

            Assert.That(component.QueryProvided(), Is.EquivalentTo(new[] { realizedInterface, portInterface }));
        }
    }
}
