// -------------------------------------------------------------------------------------------------
// <copyright file="RedefinableTemplateSignatureExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
