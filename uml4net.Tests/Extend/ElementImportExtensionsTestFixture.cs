// -------------------------------------------------------------------------------------------------
// <copyright file="ElementImportExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.CommonStructure;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ElementImportExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryGetName_throws_when_elementImport_is_null()
        {
            ElementImport elementImport = null;

            Assert.That(() => ElementImportExtensions.QueryGetName(elementImport), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryGetName_returns_the_alias_when_set()
        {
            var importedElement = new Class { Name = "Original" };
            var elementImport = new ElementImport { Alias = "Aliased", ImportedElement = importedElement };

            Assert.That(elementImport.QueryGetName(), Is.EqualTo("Aliased"));
        }

        [Test]
        public void Verify_that_QueryGetName_returns_the_imported_element_name_when_no_alias_is_set()
        {
            var importedElement = new Class { Name = "Original" };
            var elementImport = new ElementImport { ImportedElement = importedElement };

            Assert.That(elementImport.QueryGetName(), Is.EqualTo("Original"));
        }
    }
}
