// -------------------------------------------------------------------------------------------------
// <copyright file="StereotypeExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.Packages;

    [TestFixture]
    public class StereotypeExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryProfile_returns_expected_result()
        {
            var profile = new Profile();
            var package_1 = new Package();
            var package_1_1 = new Package();
            var stereoType = new Stereotype();

            package_1_1.PackagedElement.Add(stereoType);
            package_1.PackagedElement.Add(package_1_1);
            profile.PackagedElement.Add(package_1);

            Assert.That(stereoType.Profile, Is.EqualTo(profile));

            var otherProfile = new Profile();
            var otherStereoType = new Stereotype();
            otherProfile.PackagedElement.Add(otherStereoType);

            Assert.That(otherStereoType.Profile, Is.EqualTo(otherProfile));
        }

        [Test]
        public void Verify_that_Profile_is_null_when_the_stereotype_is_not_contained_by_a_profile()
        {
            var package_1 = new Package();
            var package_1_1 = new Package();
            var stereoType = new Stereotype();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(stereoType.Profile, Is.Null, "a stereotype that is not owned");

                package_1_1.PackagedElement.Add(stereoType);
                package_1.PackagedElement.Add(package_1_1);

                Assert.That(stereoType.Profile, Is.Null, "a stereotype owned by packages that are not in a profile");
            }
        }

        [Test]
        public void Verify_that_QueryProfile_throws_when_the_stereotype_is_null()
        {
            Assert.That(() => StereotypeExtensions.QueryProfile(null), Throws.ArgumentNullException);
        }
    }
}
