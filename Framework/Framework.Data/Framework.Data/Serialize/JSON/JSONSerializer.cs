using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Framework.Data.Serialize.JSON
{
    /// <summary>
    /// Implementation of <see cref="IInOutSerializer"/> which serializes into JSON format
    /// </summary>
    /// <typeparam name="T">Type to be serialized</typeparam>
    public abstract class JSONSerializer<T> : IInOutSerializer
    {
        /// <summary>
        /// Source of serialization
        /// </summary>
        public T Source { get; set; }

        /// <summary>
        /// Provided by very specific type to load the Jobject into type T
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        protected abstract bool LoadJObject(JObject jObject);
        /// <summary>
        /// Provided by very specific type to save type T into a Jobject
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        protected abstract bool Serialize(JObject jObject);

        /// <summary>
        /// <see cref="IInOutSerializer.Load"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public bool Load(TextReader reader)
        {
            // Read from the text into a jobject
            using (var json = new JsonTextReader(reader))
            {
                var jObject = JToken.ReadFrom(json) as JObject;
                if (jObject != null)
                    return LoadJObject(jObject);
            }
            return false;
        }

        /// <summary>
        /// <see cref="IInOutSerializer.Save"/>
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public bool Save(TextWriter writer)
        {
            var jObject = new JObject();
            if (Serialize(jObject))
            {
                using (var json = new JsonTextWriter(writer))
                {
                    json.Formatting = Formatting.Indented;
                    jObject.WriteTo(json);
                    return true;
                }
            }
            return false;
        }
    }
}
