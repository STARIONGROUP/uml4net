// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtendedPropertyExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Tests.Extensions
{
    using NUnit.Framework;

    using uml4net.Classification;

    using uml4net.xmi.Extensions.EnterpriseArchitect.Extensions;
    using uml4net.xmi.Extensions.EntrepriseArchitect.Structure;

    [TestFixture]
    public class ExtendedPropertyExtensionsTestFixture
    {
        private const string IsIdPattern = "$TYP=attribute property$TYP;$VIS=Public$VIS;$PAR=0$PAR;$DES=@PROP=@NAME=isID@ENDNAME;@TYPE=Boolean@ENDTYPE;@VALU=1@ENDVALU;@PRMT=@ENDPRMT;@ENDPROP;";

        [Test]
        public void QueryIsId_ReturnsTrue_WhenPropertyHasIsID()
        {
            var property = new Property { IsID = true };
            Assert.That(property.QueryIsId(), Is.True);
        }

        [Test]
        public void QueryIsId_ReturnsTrue_WhenXrefContainsPattern()
        {
            var attribute = new Attribute();
            attribute.Xrefs.Add(new Xrefs { Value = IsIdPattern });
            var property = new Property();
            property.Extensions.Add(attribute);

            Assert.That(property.QueryIsId(), Is.True);
        }

        [Test]
        public void QueryIsId_ReturnsFalse_WhenNoIsIDOrPattern()
        {
            var property = new Property();
            Assert.That(property.QueryIsId(), Is.False);
        }

        [Test]
        public void QueryIsId_ReturnsFalse_WhenXrefDoesNotContainPattern()
        {
            var attribute = new Attribute();
            attribute.Xrefs.Add(new Xrefs { Value = "something else" });
            var property = new Property();
            property.Extensions.Add(attribute);

            Assert.That(property.QueryIsId(), Is.False);
        }
    }
}
