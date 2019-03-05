// -------------------------------------------------------------------------------------------------
// <copyright file="OwnerListTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2018-2019 RHEA System S.A.
//
//   This file is part of uml-sharp
//
//   uml-sharp is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   uml-sharp is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with uml-sharp. If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.Tests.OwnerList
{
    using Uml.Assembler;
    using Implementation.CommonStructure;
    using NUnit.Framework;

    [TestFixture]
    public class OwnerListTestFixture
    {
        private TestElement ownerTestElement;

        [SetUp]
        public void SetUp()
        {
            this.ownerTestElement = new TestElement("owner");
        }

        [Test]
        public void Verify_that_owner_is_set_when_item_is_added()
        {
            var ownerList = new OwnerList<TestElement>(this.ownerTestElement);

            var contained = new TestElement("contained");

            ownerList.Add(contained);

            Assert.That(contained.Owner, Is.EqualTo(this.ownerTestElement));
        }

        
        private class TestElement : Element
        {
            public TestElement(string id) : base(id)
            {
            }
        }
    }
}