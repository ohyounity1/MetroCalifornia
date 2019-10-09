namespace Framework.Data.Serialize.CSV
{
    /// <summary>
    /// Error for when the CSV header is not recognized
    /// </summary>
    public class UnrecognizedCSVHeaderProperty
    {
        // Property that was not recognized
        private readonly string _propertyName;

        /// <summary>
        /// Initializes a new instance of <see cref="UnrecognizedCSVHeaderProperty"/>
        /// </summary>
        /// <param name="propertyName">Property that was not recognized</param>
        public UnrecognizedCSVHeaderProperty(string propertyName)
        {
            _propertyName = propertyName;
        }

        /// <summary>
        /// Property name not recognized
        /// </summary>
        public string PropertyName => _propertyName;

        /// <summary>
        /// Format for the error string
        /// </summary>
        /// <returns>Error string</returns>
        public override string ToString()
        {
            return "Unrecognized CSV header property: " + _propertyName;
        }
    }
}
