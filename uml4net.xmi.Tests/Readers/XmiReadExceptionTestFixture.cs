// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReadExceptionTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Tests.Readers
{
    using NUnit.Framework;

    using uml4net.xmi.Readers;

    /// <summary>
    /// Suite of tests for the <see cref="XmiReadException"/> class
    /// </summary>
    [TestFixture]
    public class XmiReadExceptionTestFixture
    {
        [Test]
        public void Verify_that_the_message_names_the_element_property_and_position()
        {
            var exception = new XmiReadException("[7] is not the name of a literal of VisibilityKind", "uml:Class", "c", "visibility", 5, 5);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(exception.Message, Is.EqualTo("[7] is not the name of a literal of VisibilityKind: uml:Class [c] property [visibility] at line:position 5:5"));
                Assert.That(exception.ElementType, Is.EqualTo("uml:Class"));
                Assert.That(exception.XmiId, Is.EqualTo("c"));
                Assert.That(exception.PropertyName, Is.EqualTo("visibility"));
                Assert.That(exception.LineNumber, Is.EqualTo(5));
                Assert.That(exception.LinePosition, Is.EqualTo(5));
            }
        }
    }
}
