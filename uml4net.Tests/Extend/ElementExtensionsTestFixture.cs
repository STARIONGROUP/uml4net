namespace uml4net.Tests.Extend
{
    using NUnit.Framework;
    using uml4net.CommonStructure;
    using uml4net.Classification;

    [TestFixture]
    public class ElementExtensionsTestFixture
    {
        [Test]
        public void QueryOwner_ReturnsPossessor()
        {
            var owner = new Class();
            var property = new Property { Possessor = owner };

            var result = property.QueryOwner();

            Assert.That(result, Is.EqualTo(owner));
        }
    }
}
