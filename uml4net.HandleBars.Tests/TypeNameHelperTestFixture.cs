namespace uml4net.HandleBars.Tests
{
    using System.Globalization;
    using HandlebarsDotNet;
    using NUnit.Framework;
    using uml4net.HandleBars;
    using uml4net.Classification;
    using uml4net.SimpleClassifiers;
    using uml4net.Values;

    [TestFixture]
    public class TypeNameHelperTestFixture
    {
        private IHandlebars handlebars;

        [SetUp]
        public void SetUp()
        {
            this.handlebars = Handlebars.Create();
            this.handlebars.Configuration.FormatProvider = CultureInfo.InvariantCulture;
            TypeNameHelper.RegisterTypeNameHelper(this.handlebars);
        }

        private string Render(IProperty property)
        {
            var template = "{{#POCO.TypeName this}}";
            var action = this.handlebars.Compile(template);
            return action(property);
        }

        [Test]
        public void Value_property_nullable_renders_nullable_type()
        {
            var property = CreateValueProperty("Integer", 0, 1);
            var result = Render(property);
            Assert.That(result, Is.EqualTo("int?"));
        }

        [Test]
        public void Value_property_enumerable_renders_list()
        {
            var property = CreateValueProperty("Integer", 0, int.MaxValue);
            var result = Render(property);
            Assert.That(result, Is.EqualTo("List<int>"));
        }

        [Test]
        public void Reference_property_in_abstract_owner_uses_interface_prefix()
        {
            var owner = new Class { IsAbstract = true };
            var property = new Property
            {
                Type = new Class { Name = "Foo" },
                Possessor = owner,
            };
            property.LowerValue.Add(new LiteralInteger { Value = 1 });
            property.UpperValue.Add(new LiteralInteger { Value = 1 });

            var result = Render(property);
            Assert.That(result, Is.EqualTo("IFoo"));
        }

        [Test]
        public void Reference_property_enumerable_renders_list()
        {
            var owner = new Class();
            var property = new Property
            {
                Type = new Class { Name = "Bar" },
                Possessor = owner,
            };
            property.LowerValue.Add(new LiteralInteger { Value = 0 });
            property.UpperValue.Add(new LiteralUnlimitedNatural { Value = "*" });

            var result = Render(property);
            Assert.That(result, Is.EqualTo("List<Bar>"));
        }

        private static Property CreateValueProperty(string typeName, int lower, int upper)
        {
            var property = new Property
            {
                Type = new PrimitiveType { Name = typeName }
            };
            property.LowerValue.Add(new LiteralInteger { Value = lower });
            if (upper == int.MaxValue)
            {
                property.UpperValue.Add(new LiteralUnlimitedNatural { Value = "*" });
            }
            else
            {
                property.UpperValue.Add(new LiteralInteger { Value = upper });
            }
            return property;
        }
    }
}
