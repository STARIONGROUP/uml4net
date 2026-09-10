// -------------------------------------------------------------------------------------------------
// <copyright file="RedefinableTemplateSignatureExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Classification;
    using uml4net.CommonStructure;

    [TestFixture]
    public class RedefinableTemplateSignatureExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_redefinableTemplateSignature_is_null_argument_exception_is_thrown()
        {
            RedefinableTemplateSignature redefinableTemplateSignature = null;

            Assert.That(() => RedefinableTemplateSignatureExtensions.QueryInheritedParameter(redefinableTemplateSignature), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_InheritedParameter_is_empty_when_there_is_no_extendedSignature()
        {
            var signature = new RedefinableTemplateSignature();

            Assert.That(signature.InheritedParameter, Is.Empty);
        }

        [Test]
        public void Verify_that_InheritedParameter_returns_the_parameters_of_the_extendedSignature()
        {
            var parameter1 = new TemplateParameter();
            var parameter2 = new TemplateParameter();

            var extendedSignature = new RedefinableTemplateSignature();
            extendedSignature.Parameter.Add(parameter1);
            extendedSignature.Parameter.Add(parameter2);

            var signature = new RedefinableTemplateSignature();
            signature.ExtendedSignature.Add(extendedSignature);

            Assert.That(signature.InheritedParameter, Is.EquivalentTo(new[] { parameter1, parameter2 }));
        }

        [Test]
        public void Verify_that_InheritedParameter_combines_and_deduplicates_parameters_across_multiple_extendedSignatures()
        {
            var sharedParameter = new TemplateParameter();
            var ownParameter1 = new TemplateParameter();
            var ownParameter2 = new TemplateParameter();

            var extendedSignature1 = new RedefinableTemplateSignature();
            extendedSignature1.Parameter.Add(sharedParameter);
            extendedSignature1.Parameter.Add(ownParameter1);

            var extendedSignature2 = new RedefinableTemplateSignature();
            extendedSignature2.Parameter.Add(sharedParameter);
            extendedSignature2.Parameter.Add(ownParameter2);

            var signature = new RedefinableTemplateSignature();
            signature.ExtendedSignature.Add(extendedSignature1);
            signature.ExtendedSignature.Add(extendedSignature2);

            Assert.That(signature.InheritedParameter, Is.EquivalentTo(new[] { sharedParameter, ownParameter1, ownParameter2 }));
        }
    }
}
