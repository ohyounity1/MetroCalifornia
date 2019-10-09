using System.Windows.Media;
using Newtonsoft.Json.Linq;

namespace Framework.Data.Serialize.JSON
{
    /// <summary>
    /// Helper for converting between <see cref="Color"/> and <see cref="JObject"/>
    /// </summary>
    public static class ColorJSONSerializer
    {
        /// <summary>
        /// Convert <see cref="Color"/> to a <see cref="JObject"/>
        /// </summary>
        /// <param name="color">Source color</param>
        /// <returns><see cref="Color"/> serialized to <see cref="JObject"/></returns>
        public static JObject ToJObject(this Color color)
        {
            // Store all the information about the color
            var jObject = new JObject();
            jObject.Add(nameof(Color.R), color.R);
            jObject.Add(nameof(Color.G), color.G);
            jObject.Add(nameof(Color.B), color.B);
            jObject.Add(nameof(Color.A), color.A);

            return jObject;
        }

        /// <summary>
        /// Convert <see cref="JObject"/> to a <see cref="Color"/>
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns><see cref="JObject"/> unserialized to <see cref="Color"/></returns>
        public static Color ToColor(this JObject jObject)
        {
            var alpha = jObject.Read(nameof(Color.A), (v) => (byte)v);
            var red = jObject.Read(nameof(Color.R), (v) => (byte)v);
            var green = jObject.Read(nameof(Color.G), (v) => (byte)v);
            var blue = jObject.Read(nameof(Color.B), (v) => (byte)v);

            return Color.FromArgb(alpha, red, green, blue);
        }
    }
}
