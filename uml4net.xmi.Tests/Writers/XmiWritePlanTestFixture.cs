// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWritePlanTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Writers;

    [TestFixture]
    public class XmiWritePlanTestFixture
    {
        [Test]
        public void Verify_that_the_constructors_throw_when_arguments_are_null()
        {
            var localIdentifiers = new HashSet<string>();
            var elementsMissingXmiId = new List<IXmiElement>();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => new XmiWritePlan((IReadOnlyList<IPackage>)null, localIdentifiers, elementsMissingXmiId), Throws.ArgumentNullException);
                Assert.That(() => new XmiWritePlan((IReadOnlyList<IXmiElement>)null, localIdentifiers, elementsMissingXmiId), Throws.ArgumentNullException);
                Assert.That(() => new XmiWritePlan(new List<IXmiElement>(), null, elementsMissingXmiId), Throws.ArgumentNullException);
                Assert.That(() => new XmiWritePlan(new List<IXmiElement>(), localIdentifiers, null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_RootPackages_are_the_packages_of_the_RootElements()
        {
            var package = new Package { XmiId = "Package-1" };
            var @class = new Class { XmiId = "Class-1" };

            var plan = new XmiWritePlan(new List<IXmiElement> { @class, package }, new HashSet<string>(), new List<IXmiElement>());
            var packagePlan = new XmiWritePlan(new List<IPackage> { package }, new HashSet<string>(), new List<IXmiElement>());

            using (Assert.EnterMultipleScope())
            {
                Assert.That(plan.RootElements, Is.EqualTo(new IXmiElement[] { @class, package }));
                Assert.That(plan.RootPackages, Is.EqualTo(new[] { package }));
                Assert.That(packagePlan.RootElements, Is.EqualTo(new[] { package }));
                Assert.That(packagePlan.RootPackages, Is.EqualTo(new[] { package }));
            }
        }
    }
}
