// -------------------------------------------------------------------------------------------------
// <copyright file="RedefinedByPropertyAttributeTestFixture.cs" company="Starion Group S.A.">
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
    /// Tests for the <see cref="RedefinedByPropertyAttribute"/> type.
    /// </summary>
    [TestFixture]
    public class RedefinedByPropertyAttributeTestFixture
    {
        [Test]
        public void Verify_that_constructor_sets_property()
        {
            var attribute = new RedefinedByPropertyAttribute("PropertyName");

            Assert.That(attribute.PropertyName, Is.EqualTo("PropertyName"));
        }

        [Test]
        public void Verify_that_property_is_settable()
        {
            var attribute = new RedefinedByPropertyAttribute("Initial");
            attribute.PropertyName = "Updated";

            Assert.That(attribute.PropertyName, Is.EqualTo("Updated"));
        }
    }
}
