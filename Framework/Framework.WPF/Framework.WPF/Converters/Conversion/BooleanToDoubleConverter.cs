using Framework.Patterns.Equality;

namespace Framework.WPF.Converters.Conversion
{ 
    /// <summary>
    /// Implementation of <see cref="BooleanConverter{D, EP}"/> that checks for a <see cref="double"/>
    /// </summary>
    public class BooleanToDoubleConverter : BooleanConverter<double, AlmostEqualsPolicy>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BooleanToDoubleConverter"/>
        /// </summary>
        public BooleanToDoubleConverter() : base(1.0)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="BooleanToDoubleConverter"/>
        /// </summary>
        /// <param name="true">The true value</param>
        public BooleanToDoubleConverter(double @true) : base(@true)
        {
        }
    }
}
