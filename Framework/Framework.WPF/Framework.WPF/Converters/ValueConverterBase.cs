using System;
using System.Globalization;
using System.Windows.Data;

namespace Framework.WPF.Converters
{
    /// <summary>
    /// The converter policy
    /// </summary>
    public enum ConvertBackPolicy
    {
        DoNothing, // Do nothing on the convert back call
        Convert // Convert back
    }

    /// <summary>
    /// A base value converter implementing <see cref="IValueConverter"/>
    /// </summary>
    /// <typeparam name="S"> Source Type </typeparam>
    /// <typeparam name="D"> Destination Type </typeparam>
    public abstract class ValueConverterBase<S, D> : IValueConverter
    {
        /// <summary>
        /// A fallback value for the destination type <see cref="D"/>
        /// </summary>
        public D FallbackValueD { get; set; }
        /// <summary>
        /// A fallback value for the source type <see cref="S"/>
        /// </summary>
        public S FallbackValueS { get; set; }

        /// <summary>
        /// Policy for converting back
        /// </summary>
        public ConvertBackPolicy ConvertBackPolicy { get; set; }

        /// <summary>
        /// <see cref="IValueConverter.Convert(object, Type, object, CultureInfo)"/>
        /// </summary>
        /// <param name="value">Original value</param>
        /// <param name="targetType">Type of the binding destination</param>
        /// <param name="parameter">Parameter given to the binding</param>
        /// <param name="culture">Culture information</param>
        /// <returns></returns>
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // If the type is S...
            if (value is S)
            {
                // Cast to S
                var source = (S)value;
                // Call converter
                return Convert(source);
            }
            // Return a fallback value
            return FallbackValueD;
        }

        /// <summary>
        /// <see cref="IValueConverter.ConvertBack(object, Type, object, CultureInfo)"/>
        /// </summary>
        /// <param name="value">Value from the binding destination</param>
        /// <param name="targetType">Type going back to binding source</param>
        /// <param name="parameter">Parameter given to the binding</param>
        /// <param name="culture">Culture information</param>
        /// <returns></returns>
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // If the policy is to convert...
            if(ConvertBackPolicy == ConvertBackPolicy.Convert)
            {
                // Cast to D if it is a D
                if(value is D)
                {
                    var destination = (D)value;
                    // Call method to convert back
                    return ConvertBack(destination);
                }
                // Otherwise, return failback value
                return FallbackValueS;
            }
            return Binding.DoNothing;
        }

        /// <summary>
        /// Override to do the actual conversion
        /// </summary>
        /// <param name="source">Source value</param>
        /// <returns></returns>
        public abstract D Convert(S source);

        /// <summary>
        /// Override to do the actual conversion
        /// </summary>
        /// <param name="destination">Destination value</param>
        /// <returns></returns>
        public abstract S ConvertBack(D destination);
    }
}
