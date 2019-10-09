using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Data.Storage;
using System.IO;
using System.Windows.Media;
using Modules.Metro.MetroLines.Model;
using Modules.Metro.MetroLines.Data;

namespace UnitTests
{
    [TestClass]
    public class MetroLine
    {
        [TestMethod]
        public void TestSerialize()
        {
            var serializer = new MetroLineJSONSerializationStrategy();
            serializer.Source = new MetroLineDetails("Inland Empire Line", Colors.Blue, 'A', "LA Union Station", "San Bernardino", true, true, 1969, LineType.EastWest, false);
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    serializer.Save(writer);
                }
                var bytes = stream.GetBuffer();
                var json = System.Text.Encoding.UTF8.GetString(bytes).Trim('\0');
                Assert.AreEqual('{', json[0]);
                Assert.AreEqual("{\r\n" +
                                "  \"Name\": \"Inland Empire Line\"\r\n" +
                                "}", json);
            }
        }

        [TestMethod]
        public void TestStorable()
        {
            var storage = new Mock<IStorageMedium>(MockBehavior.Strict);

            var storable = new Storable<MetroLineJSONSerializationStrategy>(storage.Object);
            storable.Serializer.Source = new MetroLineDetails("Inland Empire Line", Colors.Blue, 'A', "LA Union Station", "San Bernardino", true, true, 1969, LineType.NorthSouth, true);
            storable.Save();
        }
    }
}
