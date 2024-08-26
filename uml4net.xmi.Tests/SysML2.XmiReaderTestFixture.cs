// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SysML2.XmiReaderTestFixture.cs" company="RHEA System S.A.">
//     Copyright (c) 2023-2024 RHEA System S.A.
// 
//     Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Jaime Bernar, Théate Antoine
// 
//     This file is part of CDP4-COMET WEB Community Edition
//     The CDP4-COMET WEB Community Edition is the RHEA Web Application implementation of ECSS-E-TM-10-25 Annex A and Annex C.
// 
//     The CDP4-COMET WEB Community Edition is free software; you can redistribute it and/or
//     modify it under the terms of the GNU Affero General Public
//     License as published by the Free Software Foundation; either
//     version 3 of the License, or (at your option) any later version.
// 
//     The CDP4-COMET WEB Community Edition is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Affero General Public License for more details.
// 
//    You should have received a copy of the GNU Affero General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using uml4net.POCO.Packages;

    public class SysML2_XmiReaderTestFixture
    {
        private ILoggerFactory loggerFactory;

        [SetUp]
        public void SetUp()
        {
            this.loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        }

        [Test]
        public void Verify_that_SysML_XMI_can_be_read()
        {
            var reader = new XmiReader(this.loggerFactory);

            var packages = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));

            Assert.That(packages.Count(), Is.EqualTo(1));

            var model = packages.First() as IModel;

            Assert.That(model.XmiId, Is.EqualTo("_kUROkM9FEe6Zc_le1peNgQ"));
            Assert.That(model.Name, Is.EqualTo("sysml"));
        }
    }
}