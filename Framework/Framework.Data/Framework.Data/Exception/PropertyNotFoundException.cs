namespace Framework.Data.Exception
{
    /// <summary>
    /// Exception related to a property not found
    /// </summary>
    public class PropertyNotFoundException : System.Exception
    {
        /// <summary>
        /// Property name not found
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="PropertyNotFoundException"/>
        /// </summary>
        /// <param name="propertyName">Property not found</param>
        public PropertyNotFoundException(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
