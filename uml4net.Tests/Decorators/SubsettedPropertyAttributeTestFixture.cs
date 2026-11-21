// -------------------------------------------------------------------------------------------------
// <copyright file="SubsettedPropertyAttributeTestFixture.cs" company="Starion Group S.A.">
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
    /// Tests for the <see cref="SubsettedPropertyAttribute"/> type.
    /// </summary>
    [TestFixture]
    public class SubsettedPropertyAttributeTestFixture
    {
        [Test]
        public void Verify_that_constructor_sets_property()
        {
            var attribute = new SubsettedPropertyAttribute("Class.Property");

            Assert.That(attribute.PropertyName, Is.EqualTo("Class.Property"));
        }

        [Test]
        public void Verify_that_property_is_settable()
        {
            var attribute = new SubsettedPropertyAttribute("Initial");
            attribute.PropertyName = "Updated";

            Assert.That(attribute.PropertyName, Is.EqualTo("Updated"));
        }
    }
}
