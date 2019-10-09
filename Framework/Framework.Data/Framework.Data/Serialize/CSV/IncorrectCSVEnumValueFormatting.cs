using System;

namespace Framework.Data.Serialize.CSV
{
    /// <summary>
    /// Specific type of <see cref="IncorrectCSVValueFormatting"/> for an <see cref="enum"/>
    /// </summary>
    public class IncorrectCSVEnumValueFormatting : IncorrectCSVValueFormatting
    {
        /// <summary>
        /// The enum type information
        /// </summary>
        private readonly Type _enumType;

        /// <summary>
        /// Initializes a new instance of <see cref="IncorrectCSVEnumValueFormatting"/>
        /// </summary>
        /// <param name="enumType">Type info for the enum</param>
        /// <param name="propertyName">Name of the property</param>
        /// <param name="value">Bad value</param>
        public IncorrectCSVEnumValueFormatting(Type enumType, string propertyName, string value) : base(propertyName, value)
        {
            _enumType = enumType;
        }
        /// <summary>
        /// <see cref="object.ToString"/>
        /// </summary>
        /// <returns>Error string</returns>
        public override string ToString()
        {
            return $"{base.ToString()}, expected enum of type {_enumType.Name}";
        }
    }
}
