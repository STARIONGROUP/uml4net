// -------------------------------------------------------------------------------------------------
// <copyright file="ClassAttributeTestFixture.cs" company="Starion Group S.A.">
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
    /// Suite of tests for the <see cref="ClassAttribute"/> type.
    /// </summary>
    [TestFixture]
    public class ClassAttributeTestFixture
    {
        [Test]
        public void Verify_that_constructor_sets_all_properties()
        {
            var attribute = new ClassAttribute("id", true, true, true);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(attribute.XmiId, Is.EqualTo("id"));
                Assert.That(attribute.IsAbstract, Is.True);
                Assert.That(attribute.IsFinalSpecialization, Is.True);
                Assert.That(attribute.IsActive, Is.True);
            }
        }

        [Test]
        public void Verify_default_values()
        {
            var attribute = new ClassAttribute();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(attribute.XmiId, Is.EqualTo(string.Empty));
                Assert.That(attribute.IsAbstract, Is.False);
                Assert.That(attribute.IsFinalSpecialization, Is.False);
                Assert.That(attribute.IsActive, Is.False);
            }
        }
    }
}
