// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWriteContextTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests.Writers
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Writers;

    [TestFixture]
    public class XmiWriteContextTestFixture
    {
        [Test]
        public void Verify_that_constructor_throws_when_arguments_are_null()
        {
            Assert.That(() => new XmiWriteContext(null, []), Throws.ArgumentNullException);
            Assert.That(() => new XmiWriteContext("UML.xmi", null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_DocumentName_is_set()
        {
            var context = new XmiWriteContext("UML.xmi", []);

            Assert.That(context.DocumentName, Is.EqualTo("UML.xmi"));
        }

        [Test]
        public void Verify_that_IsLocal_returns_expected_result()
        {
            var localClass = new Class { XmiId = "Class-1", DocumentName = "UML.xmi" };
            var externalClass = new Class { XmiId = "Class-2", DocumentName = "PrimitiveTypes.xmi" };

            var context = new XmiWriteContext("UML.xmi", [localClass.FullyQualifiedIdentifier]);

            Assert.That(context.IsLocal(localClass), Is.True);
            Assert.That(context.IsLocal(externalClass), Is.False);
        }

        [Test]
        public void Verify_that_IsLocal_supports_empty_document_name()
        {
            var localClass = new Class { XmiId = "Class-1" };

            var context = new XmiWriteContext("UML.xmi", [localClass.FullyQualifiedIdentifier]);

            Assert.That(context.IsLocal(localClass), Is.True);
        }

        [Test]
        public void Verify_that_IsLocal_throws_when_element_is_null()
        {
            var context = new XmiWriteContext("UML.xmi", []);

            Assert.That(() => context.IsLocal(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryHref_returns_expected_result()
        {
            var externalClass = new Class { XmiId = "Boolean", DocumentName = "PrimitiveTypes.xmi" };

            var context = new XmiWriteContext("UML.xmi", []);

            Assert.That(context.QueryHref(externalClass), Is.EqualTo("PrimitiveTypes.xmi#Boolean"));
        }

        [Test]
        public void Verify_that_QueryHref_throws_when_element_is_null()
        {
            var context = new XmiWriteContext("UML.xmi", []);

            Assert.That(() => context.QueryHref(null), Throws.ArgumentNullException);
        }
    }
}
