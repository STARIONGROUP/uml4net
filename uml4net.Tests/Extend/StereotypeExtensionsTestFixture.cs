// -------------------------------------------------------------------------------------------------
//  <copyright file="StereotypeExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using System.Data;

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
        public void Verify_that_when_stereotype_not_contained_by_profile_an_exception_is_thrown()
        {
            var package_1 = new Package();
            var package_1_1 = new Package();
            var stereoType = new Stereotype();

            package_1_1.PackagedElement.Add(stereoType);
            package_1.PackagedElement.Add(package_1_1);

            Assert.That(() => stereoType.Profile, Throws.TypeOf<DataException>());
        }
    }
}
