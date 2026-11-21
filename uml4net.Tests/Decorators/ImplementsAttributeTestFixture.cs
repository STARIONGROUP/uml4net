// -------------------------------------------------------------------------------------------------
// <copyright file="ImplementsAttributeTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Decorators
{
    using NUnit.Framework;

    using uml4net.Decorators;

    /// <summary>
    /// Tests for the <see cref="ImplementsAttribute"/> type.
    /// </summary>
    [TestFixture]
    public class ImplementsAttributeTestFixture
    {
        [Test]
        public void Verify_that_constructor_sets_property()
        {
            var attribute = new ImplementsAttribute("Class.Property");

            Assert.That(attribute.Implementations, Is.EqualTo("Class.Property"));
        }

        [Test]
        public void Verify_that_property_is_settable()
        {
            var attribute = new ImplementsAttribute("Initial");
            attribute.Implementations = "Updated";

            Assert.That(attribute.Implementations, Is.EqualTo("Updated"));
        }
    }
}
