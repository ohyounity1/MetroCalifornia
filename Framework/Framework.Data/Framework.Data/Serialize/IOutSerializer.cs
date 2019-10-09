using System.IO;

namespace Framework.Data.Serialize
{
    /// <summary>
    /// Interface for writing a type out into a stream
    /// </summary>
    public interface IOutSerializer
    {
        /// <summary>
        /// Save to the stream
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        bool Save(TextWriter writer);
    }
}
