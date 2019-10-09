using System;
using System.Globalization;
using System.Windows.Data;
using Framework.Patterns.Equality;

namespace Framework.WPF.Converters.Conversion
{
    public enum ConvertPolicy
    {
        FilterOnTrue, // Return original value with no conversion if compare is true
        FilterOnFalse, // Return original value with no conversion if compare is false
        Convert // Convert compare true/false to value
    }

    /// <summary>
    /// Converter that, when two things are equal of type <see cref="S"/>, then conversion is done from the boolean result to <see cref="D"/>
    /// </summary>
    /// <typeparam name="S">Type of source binding</typeparam>
    /// <typeparam name="SEP">Equals policy for the source type, must be of type <see cref="IEqualsPolicy{S}"/></typeparam>
    /// <typeparam name="D">Destination type of the binding</typeparam>
    /// <typeparam name="DEP">Destination type equals policy, must be of type <see cref="IEqualsPolicy{D}"/></typeparam>
    public abstract class IsEqualToBooleanConverter<S, SEP, D, DEP> : BooleanConverter<D, DEP> where SEP: IEqualsPolicy<S>, new() where DEP : IEqualsPolicy<D>, new()
    {
        /// <summary>
        /// The source equals policy
        /// </summary>
        private readonly SEP _sourceEqualsPolicy = new SEP();

        /// <summary>
        /// Initializes a new instance of <see cref="IsEqualToBooleanConverter{S, SEP, D, DEP}"/>
        /// </summary>
        public IsEqualToBooleanConverter()
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="IsEqualToBooleanConverter{S, SEP, D, DEP}"/> which a specific true type
        /// </summary>
        /// <param name="true">True value</param>
        public IsEqualToBooleanConverter(D @true) : base(@true)
        {

        }

        public ConvertPolicy ConvertPolicy
        {
            get;
            set;
        } = ConvertPolicy.Convert;

        /// <summary>
        /// <see cref="IValueConverter.Convert(object, Type, object, CultureInfo)"/>
        /// </summary>
        /// <param name="value">Original value</param>
        /// <param name="targetType">Type of target binding</param>
        /// <param name="parameter">Parameter in the binding</param>
        /// <param name="culture">Culture Info</param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Source and parameter must be same type
            if (value is S && parameter is S)
            {
                // Convert the types
                var actualValue = (S)value;
                var actualParameter = (S)parameter;
                // Test values using policy
                var result = _sourceEqualsPolicy.EqualsTo(actualValue, actualParameter);
                switch(ConvertPolicy)
                {
                    case ConvertPolicy.Convert:
                        // Convert boolean to destination type
                        return Convert(result);
                    case ConvertPolicy.FilterOnTrue:
                        // If filter out on true, return convert value on true
                        if (result)
                            return Convert(result);
                        else
                            return value;
                    case ConvertPolicy.FilterOnFalse:
                        // If filter out on true, return convert value on false
                        if (!result)
                            return Convert(result);
                        else
                            return value;
                }
            }
            return False;
        }

        /// <summary>
        /// Fallback value for convert back if type is wrong
        /// </summary>
        protected abstract S FalseBackValue { get; }

        /// <summary>
        /// <see cref="IValueConverter.ConvertBack(object, Type, object, CultureInfo)"/>
        /// </summary>
        /// <param name="value">Value from binding destination</param>
        /// <param name="targetType">Type of the binding</param>
        /// <param name="parameter">Parameter in the binding</param>
        /// <param name="culture">Culture info</param>
        /// <returns></returns>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // If we are actually converting back
            if (ConvertBackPolicy == ConvertBackPolicy.Convert)
            {
                // Value from binding destination must be a type D
                if (value is D)
                {
                    // Convert type
                    var asD = (D)value;
                    // Convert from this back to boolean value
                    var result = ConvertBack(asD);
                    // If true, return parameter (which would have been the source value)
                    if (result) return parameter;
                    // Return back something else
                    return FalseBackValue;
                }
                // Return back something else
                return FalseBackValue;
            }
            return Binding.DoNothing;
        }
    }

    /// <summary>
    /// Type of <see cref="IsEqualToBooleanConverter{S, SEP, D, DEP}"/> that uses the <see cref="BasicEqualsPolicy{D}"/> for comparison
    /// </summary>
    /// <typeparam name="S">Type of source</typeparam>
    /// <typeparam name="SEP">Source type equals policy, must be of type <see cref="IEqualsPolicy{S}"/></typeparam>
    /// <typeparam name="D">Type of destination</typeparam>
    public abstract class IsEqualToBooleanConverter<S, SEP, D> : IsEqualToBooleanConverter<S, SEP, D, BasicEqualsPolicy<D>> where SEP : IEqualsPolicy<S>, new()
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IsEqualToBooleanConverter{S, SEP, D}"/>
        /// </summary>
        /// <param name="true">True value</param>
        public IsEqualToBooleanConverter(D @true) : base(@true)
        {
        }
    }

    /// <summary>
    /// Type of <see cref="IsEqualToBooleanConverter{S, SEP, D, DEP}"/> that uses the <see cref="BasicEqualsPolicy{D}"/> for both conversions
    /// </summary>
    /// <typeparam name="S">Type of source</typeparam>
    /// <typeparam name="D">Type of destination</typeparam>
    public abstract class IsEqualToBooleanConverter<S, D> : IsEqualToBooleanConverter<S, BasicEqualsPolicy<S>, D, BasicEqualsPolicy<D>>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IsEqualToBooleanConverter{S, D}"/>
        /// </summary>
        public IsEqualToBooleanConverter()
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="IsEqualToBooleanConverter{S, D}"/>
        /// </summary>
        /// <param name="true">True value</param>
        public IsEqualToBooleanConverter(D @true) : base(@true)
        {

        }
    }

    /// <summary>
    /// Type of <see cref="IsEqualToBooleanConverter{S, SEP, D, DEP}"/> that uses the <see cref="BasicEqualsPolicy{D}"/> for both conversions 
    /// and the destination type of simply being <see cref="bool"/>
    /// </summary>
    /// <typeparam name="S">Type of source</typeparam>
    public abstract class IsEqualToBooleanConverter<S> : IsEqualToBooleanConverter<S, BasicEqualsPolicy<S>, bool, BasicEqualsPolicy<bool>>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IsEqualToBooleanConverter{S}"/>
        /// </summary>
        public IsEqualToBooleanConverter()
        {
            True = true;
            False = false;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IsEqualToBooleanConverter{S}"/>
        /// </summary>
        /// <param name="true">True value</param>
        public IsEqualToBooleanConverter(bool @true) : base(@true)
        {
            True = @true;
            False = !@true;
        }
    }
}
