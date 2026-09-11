// -------------------------------------------------------------------------------------------------
// <copyright file="PortExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class PortExtensionsTestFixture
    {
        [Test]
        public void Verify_that_new_Port_query_methods_throw_when_argument_is_null()
        {
            Port port = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => PortExtensions.QueryProvided(port), Throws.ArgumentNullException);
                Assert.That(() => PortExtensions.QueryRequired(port), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryProvided_returns_the_type_itself_when_it_is_an_interface_and_the_port_is_not_conjugated()
        {
            var @interface = new Interface { Name = "MyInterface" };
            var port = new Port { Name = "MyPort", Type = @interface, IsConjugated = false };

            Assert.That(port.QueryProvided(), Is.EquivalentTo(new[] { @interface }));
        }

        [Test]
        public void Verify_that_QueryRequired_returns_the_type_itself_when_it_is_an_interface_and_the_port_is_conjugated()
        {
            var @interface = new Interface { Name = "MyInterface" };
            var port = new Port { Name = "MyPort", Type = @interface, IsConjugated = true };

            Assert.That(port.QueryRequired(), Is.EquivalentTo(new[] { @interface }));
        }

        [Test]
        public void Verify_that_QueryProvided_returns_the_realized_interfaces_of_the_type_when_the_port_is_not_conjugated()
        {
            var package = new Package { Name = "root" };
            var type = new Class { Name = "PortType" };
            var providedInterface = new Interface { Name = "ProvidedInterface" };
            package.PackagedElement.Add(type);
            package.PackagedElement.Add(providedInterface);

            var realization = new Realization { Name = "Realization" };
            realization.Client.Add(type);
            realization.Supplier.Add(providedInterface);
            package.PackagedElement.Add(realization);

            var port = new Port { Name = "MyPort", Type = type, IsConjugated = false };

            Assert.That(port.QueryProvided(), Is.EquivalentTo(new[] { providedInterface }));
        }

        [Test]
        public void Verify_that_QueryRequired_returns_the_used_interfaces_of_the_type_when_the_port_is_not_conjugated()
        {
            var package = new Package { Name = "root" };
            var type = new Class { Name = "PortType" };
            var requiredInterface = new Interface { Name = "RequiredInterface" };
            package.PackagedElement.Add(type);
            package.PackagedElement.Add(requiredInterface);

            var usage = new Usage { Name = "Usage" };
            usage.Client.Add(requiredInterface);
            usage.Supplier.Add(type);
            package.PackagedElement.Add(usage);

            var port = new Port { Name = "MyPort", Type = type, IsConjugated = false };

            Assert.That(port.QueryRequired(), Is.EquivalentTo(new[] { requiredInterface }));
        }

        [Test]
        public void Verify_that_conjugation_swaps_provided_and_required()
        {
            var package = new Package { Name = "root" };
            var type = new Class { Name = "PortType" };
            var realizedInterface = new Interface { Name = "RealizedInterface" };
            var usedInterface = new Interface { Name = "UsedInterface" };
            package.PackagedElement.Add(type);
            package.PackagedElement.Add(realizedInterface);
            package.PackagedElement.Add(usedInterface);

            var realization = new Realization { Name = "Realization" };
            realization.Client.Add(type);
            realization.Supplier.Add(realizedInterface);
            package.PackagedElement.Add(realization);

            var usage = new Usage { Name = "Usage" };
            usage.Client.Add(usedInterface);
            usage.Supplier.Add(type);
            package.PackagedElement.Add(usage);

            var conjugatedPort = new Port { Name = "ConjugatedPort", Type = type, IsConjugated = true };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(conjugatedPort.QueryProvided(), Is.EquivalentTo(new[] { usedInterface }));
                Assert.That(conjugatedPort.QueryRequired(), Is.EquivalentTo(new[] { realizedInterface }));
            }
        }

        [Test]
        public void Verify_that_QueryProvided_and_QueryRequired_return_an_empty_list_when_the_type_is_null()
        {
            var port = new Port { Name = "MyPort" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(port.QueryProvided(), Is.Empty);
                Assert.That(port.QueryRequired(), Is.Empty);
            }
        }
    }
}
