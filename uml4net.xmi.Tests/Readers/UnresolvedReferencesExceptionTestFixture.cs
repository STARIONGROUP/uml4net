// -------------------------------------------------------------------------------------------------
// <copyright file="UnresolvedReferencesExceptionTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Tests.Readers
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using uml4net.xmi.Readers;

    [TestFixture]
    public class UnresolvedReferencesExceptionTestFixture
    {
        private static List<XmiReferenceResolutionFailure> CreateFailures(int count)
        {
            return Enumerable.Range(1, count)
                .Select(x => new XmiReferenceResolutionFailure
                {
                    DocumentName = "doc1.xml",
                    ElementXmiId = "idO1",
                    ElementXmiType = "uml:Operation",
                    PropertyName = "ownedRule",
                    Identifier = $"doc2.xml#idC{x}",
                    Kind = XmiReferenceResolutionFailureKind.NotFound
                })
                .ToList();
        }

        [Test]
        public void Verify_that_the_constructor_throws_when_failures_is_null()
        {
            Assert.That(() => new UnresolvedReferencesException(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_all_failures_are_listed_when_within_the_maximum()
        {
            var failures = CreateFailures(2);

            var exception = new UnresolvedReferencesException(failures);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(exception.Failures, Is.SameAs(failures));
                Assert.That(exception.Message, Does.StartWith("2 reference(s) could not be resolved:"));
                Assert.That(exception.Message, Does.Contain("doc1.xml#idO1 (uml:Operation).ownedRule -> doc2.xml#idC2 [NotFound]"));
                Assert.That(exception.Message, Does.Not.Contain("more"));
            }
        }

        [Test]
        public void Verify_that_the_message_is_truncated_beyond_the_maximum()
        {
            var failures = CreateFailures(UnresolvedReferencesException.MaximumListedFailures + 2);

            var exception = new UnresolvedReferencesException(failures);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(exception.Message, Does.Contain($"doc2.xml#idC{UnresolvedReferencesException.MaximumListedFailures} "));
                Assert.That(exception.Message, Does.Not.Contain($"doc2.xml#idC{UnresolvedReferencesException.MaximumListedFailures + 1} "));
                Assert.That(exception.Message, Does.EndWith("... and 2 more"));
            }
        }
    }
}
