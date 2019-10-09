using Framework.Data.Serialize;

namespace Framework.Data.Storage
{
    /// <summary>
    /// Interface for the storage medium
    /// </summary>
    public interface IStorageMedium
    {
        /// <summary>
        /// Save the information in the serializer
        /// </summary>
        /// <param name="serializer"></param>
        void Save(IOutSerializer serializer);
        /// <summary>
        /// Load the information to the serializer
        /// </summary>
        /// <param name="serializer"></param>
        void Load(IInSerializer serializer);
    }
}
