// -------------------------------------------------------------------------------------------------
// <copyright file="ElementImportExtensionsTestFixture.cs" company="Starion Group S.A.">
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
