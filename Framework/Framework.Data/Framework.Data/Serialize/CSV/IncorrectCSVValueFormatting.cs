namespace Framework.Data.Serialize.CSV
{
    /// <summary>
    /// When an error occurs in the CSV formatting
    /// </summary>
    public abstract class IncorrectCSVValueFormatting
    {
        // Improper value
        private readonly string _value;
        // Improper property name
        private readonly string _propertyName;

        /// <summary>
        /// Initializes a new instance of <see cref="IncorrectCSVValueFormatting"/>
        /// </summary>
        /// <param name="propertyName">The bad property</param>
        /// <param name="value">The property's value</param>
        protected IncorrectCSVValueFormatting(string propertyName, string value)
        {
            _propertyName = propertyName;
            _value = value;
        }

        /// <summary>
        /// Format for logging error
        /// </summary>
        /// <returns>Error string</returns>
        public override string ToString()
        {
            return "CSV Value " + _propertyName + " is formatted incorrectly: " + _value;
        }
    }
}
