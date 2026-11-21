// -------------------------------------------------------------------------------------------------
// <copyright file="ResourceLoaderTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Reporting.Tests.Resources
{
    using System.Resources;

    using NUnit.Framework;

    using uml4net.Reporting.Resources;

    [TestFixture]
    public class ResourceLoaderTestFixture
    {
        [Test]
        public void LoadEmbeddedResource_ReturnsContent()
        {
            var content = ResourceLoader.LoadEmbeddedResource("uml4net.Reporting.Templates.uml-to-html-docs.hbs");
            Assert.That(content, Does.Contain("uml4net.Reporting library"));
        }

        [Test]
        public void LoadEmbeddedResource_InvalidPath_Throws()
        {
            Assert.That(() => ResourceLoader.LoadEmbeddedResource("unknown.resource"),
                Throws.TypeOf<MissingManifestResourceException>());
        }
    }
}
