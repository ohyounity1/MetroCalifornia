namespace Framework.Patterns.Enum
{
    /// <summary>
    /// Extensions for an <see cref="Enum"/>
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the string for the enum of type <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="enum">enum value</param>
        /// <returns>String representation of <see cref="T"/></returns>
        public static string GetName<T>(T @enum)
        {
            // Convert to string display
            return System.Enum.GetName(typeof(T), @enum);
        }
    }
}
