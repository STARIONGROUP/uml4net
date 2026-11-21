// -------------------------------------------------------------------------------------------------
// <copyright file="EncapsulatedClassifierExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using System.Linq;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class EncapsulatedClassifierExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_encapsulatedClassifier_is_null_argument_null_exception_is_thrown()
        {
            Class encapsulatedClassifier = null;

            Assert.That(() => EncapsulatedClassifierExtensions.QueryOwnedPort(encapsulatedClassifier), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryOwnedPort_returns_an_empty_list_when_no_port_is_owned()
        {
            var @class = new Class();

            var property = new Property { Name = "regularProperty" };
            @class.OwnedAttribute.Add(property);

            Assert.That(@class.OwnedPort, Is.Empty);
        }

        [Test]
        public void Verify_that_QueryOwnedPort_returns_only_the_owned_ports()
        {
            var @class = new Class();

            var property = new Property { Name = "regularProperty" };
            var port_1 = new Port { Name = "port_1" };
            var port_2 = new Port { Name = "port_2" };

            @class.OwnedAttribute.Add(property);
            @class.OwnedAttribute.Add(port_1);
            @class.OwnedAttribute.Add(port_2);

            Assert.That(@class.OwnedPort.ToList(), Is.EquivalentTo(new[] { port_1, port_2 }));
        }
    }
}
