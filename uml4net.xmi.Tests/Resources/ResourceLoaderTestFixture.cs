namespace uml4net.xmi.Tests.Resources
{
    using System.IO;
    using NUnit.Framework;
    using uml4net.xmi.Resources;

    [TestFixture]
    public class ResourceLoaderTestFixture
    {
        [Test]
        public void TryLoadKnownResource_ReturnsEmbeddedStream()
        {
            var loader = new ResourceLoader();
            var result = loader.TryLoadKnownResource("UML", out var stream);
            Assert.That(result, Is.True);
            Assert.That(stream, Is.Not.Null);
            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();
            Assert.That(content, Does.Contain("xmi:XMI"));
        }

        [Test]
        public void TryLoadKnownResource_WithFragment_IsHandled()
        {
            var loader = new ResourceLoader();
            var result = loader.TryLoadKnownResource("http://www.omg.org/spec/UML/20161101/UML.xmi#fragment", out var stream);
            Assert.That(result, Is.True);
            Assert.That(stream, Is.Not.Null);
        }

        [Test]
        public void LoadEmbeddedResource_ReturnsContent()
        {
            var loader = new ResourceLoader();
            var content = loader.LoadEmbeddedResource("uml4net.xmi.Resources.UML.xmi");
            Assert.That(content, Does.Contain("xmi:XMI"));
        }
    }
}
