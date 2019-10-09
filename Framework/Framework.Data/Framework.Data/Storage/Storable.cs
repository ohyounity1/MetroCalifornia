using Framework.Data.Serialize;

namespace Framework.Data.Storage
{
    /// <summary>
    /// Helper proxy to communicate between the storage and the serializer
    /// </summary>
    /// <typeparam name="S">Type of the serializer</typeparam>
    public class Storable<S> where S : IInOutSerializer, new()
    {
        /// <summary>
        /// The storage medium
        /// </summary>
        private readonly IStorageMedium _storageMedium;
        /// <summary>
        /// Serializer, should have no constructor parameters
        /// </summary>
        private readonly S _serializer = new S();

        /// <summary>
        /// Initializes a new instance of <see cref="Storable{S}"/> with a specific medium
        /// </summary>
        /// <param name="storageMedium"></param>
        public Storable(IStorageMedium storageMedium)
        {
            _storageMedium = storageMedium;
        }

        /// <summary>
        /// Access to the serializer, which will have the data loaded into it
        /// </summary>
        public S Serializer
        {
            get { return _serializer; } 
        }

        /// <summary>
        /// Save from the data into the storage medium
        /// </summary>
        public void Save()
        {
            _storageMedium.Save(_serializer);
        }

        /// <summary>
        /// Load from the storage into the data
        /// </summary>
        public Storable<S> Load()
        {
            _storageMedium.Load(_serializer);
            return this;
        }
    }
}
