// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReadExceptionTestFixture.cs" company="Starion Group S.A.">
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
