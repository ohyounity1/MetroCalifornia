namespace Framework.Data.Serialize.CSV
{
    /// <summary>
    /// Specific <see cref="IncorrectCSVValueFormatting/> for a <see cref="bool"/>
    /// </summary>
    public class IncorrectCSVBoolValueFormatting : IncorrectCSVValueFormatting
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IncorrectCSVBoolValueFormatting"/>
        /// </summary>
        /// <param name="propertyName">Bad property name</param>
        /// <param name="value">Bad value</param>
        public IncorrectCSVBoolValueFormatting(string propertyName, string value) : base(propertyName, value)
        {
        }

        /// <summary>
        /// <see cref="object.ToString"/>
        /// </summary>
        /// <returns>Specific error string</returns>
        public override string ToString()
        {
            return $"{base.ToString()}, expecting true/false";
        }
    }
}
