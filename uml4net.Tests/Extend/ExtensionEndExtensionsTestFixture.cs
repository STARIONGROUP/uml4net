// -------------------------------------------------------------------------------------------------
// <copyright file="ExtensionEndExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using System;

    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.Values;

    [TestFixture]
    public class ExtensionEndExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_extensionEnd_is_null_argument_null_exception_is_thrown()
        {
            ExtensionEnd extensionEnd = null;

            Assert.That(() => ExtensionEndExtensions.QueryLower(extensionEnd), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_Lower_defaults_to_0_when_no_lowerValue_is_set()
        {
            // ExtensionEnd redefines the default MultiplicityElement lower bound (which is 1 when
            // empty) to 0 - see OMG UML 2.5.1 clause 12.4.2.6
            var extensionEnd = new ExtensionEnd();

            Assert.That(extensionEnd.Lower, Is.EqualTo(0));
        }

        [Test]
        public void Verify_that_Lower_returns_the_explicit_lowerValue_when_set()
        {
            var extensionEnd = new ExtensionEnd();
            extensionEnd.LowerValue.Add(new LiteralInteger { Value = 1 });

            Assert.That(extensionEnd.Lower, Is.EqualTo(1));
        }

        [Test]
        public void Verify_that_when_lowerValue_is_not_a_LiteralInteger_not_supported_exception_is_thrown()
        {
            var extensionEnd = new ExtensionEnd();
            extensionEnd.LowerValue.Add(new LiteralString { Value = "not-an-integer" });

            Assert.That(() => extensionEnd.Lower, Throws.TypeOf<NotSupportedException>());
        }
    }
}
