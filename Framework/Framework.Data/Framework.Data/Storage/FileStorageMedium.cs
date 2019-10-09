using System.IO;
using Framework.Data.Serialize;

namespace Framework.Data.Storage
{
    /// <summary>
    /// Implementation of <see cref="IStorageMedium"/> which stores into a file
    /// </summary>
    public class FileStorageMedium : IStorageMedium
    {
        /// <summary>
        /// Name of the file to store data into
        /// </summary>
        private readonly string _fileName;

        /// <summary>
        /// Initializes a new instance of <see cref="FileStorageMedium"/>
        /// </summary>
        /// <param name="fileName">Name of the file being used for storage</param>
        public FileStorageMedium(string fileName)
        {
            _fileName = fileName;
        }

        /// <summary>
        /// <see cref="IStorageMedium.Save(IOutSerializer)"/>
        /// </summary>
        /// <param name="serializer">Where to save data into</param>
        public void Save(IOutSerializer serializer)
        {
            // Prepare the file for writing out to
            using (var stream = new FileStream(_fileName, FileMode.Truncate))
            {
                // Writer
                using (var writer = new StreamWriter(stream))
                {
                    serializer.Save(writer);
                }
            }
        }

        /// <summary>
        /// <see cref="IStorageMedium.Load(IInSerializer)"/>
        /// </summary>
        /// <param name="serializer">Where to load data from</param>
        public void Load(IInSerializer serializer)
        {
            // Prepare file to be read from
            using (var stream = new FileStream(_fileName, FileMode.Open))
            {
                // Reader
                using (var reader = new StreamReader(stream))
                {
                    serializer.Load(reader);
                }
            }
        }
    }
}
