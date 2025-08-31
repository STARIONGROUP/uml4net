namespace uml4net.Extensions.Tests
{
    using NUnit.Framework;
    using uml4net.Extensions;
    using uml4net.Values;
    using uml4net.Classification;

    [TestFixture]
    public class ValueSpecificationExtensionsTestFixture
    {
        [Test]
        public void QueryDefaultValueAsString_HandlesDifferentLiteralTypes()
        {
            var literalBool = new LiteralBoolean { Value = true };
            var literalInt = new LiteralInteger { Value = 42 };
            var literalNull = new LiteralNull();
            var literalString = new LiteralString { Value = "star" };
            var literalUnlimited = new LiteralUnlimitedNatural { Value = "*" };
            var instance = new InstanceSpecification { Name = "myInstance" };
            var instanceValue = new InstanceValue { Instance = instance };

            Assert.That(literalBool.QueryDefaultValueAsString(), Is.EqualTo("true"));
            Assert.That(literalInt.QueryDefaultValueAsString(), Is.EqualTo("42"));
            Assert.That(literalNull.QueryDefaultValueAsString(), Is.EqualTo("null"));
            Assert.That(literalString.QueryDefaultValueAsString(), Is.EqualTo("star"));
            Assert.That(literalUnlimited.QueryDefaultValueAsString(), Is.EqualTo("int.MaxValue"));
            Assert.That(instanceValue.QueryDefaultValueAsString(), Is.EqualTo("myInstance"));
        }

        private class UnsupportedValueSpecification : XmiElement, IValueSpecification { }

        [Test]
        public void QueryDefaultValueAsString_ThrowsOnUnsupportedType()
        {
            var unsupported = new UnsupportedValueSpecification();
            Assert.That(() => unsupported.QueryDefaultValueAsString(), Throws.TypeOf<System.NotSupportedException>());
        }
    }
}
