using System.IO;

namespace Framework.Data.Serialize
{
    /// <summary>
    /// Interface for a serializer which reads from a stream and creates a type
    /// </summary>
    public interface IInSerializer
    {
        /// <summary>
        /// Load type from a stream
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        bool Load(TextReader reader);
    }
}
