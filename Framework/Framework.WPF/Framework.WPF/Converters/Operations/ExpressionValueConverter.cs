using System;
using System.Globalization;
using System.Windows.Data;
using Framework.WPF.Converters.Conversion;
using Framework.WPF.MarkupExtension;

namespace Framework.WPF.Converters.Operations
{
    /// <summary>
    /// Type of <see cref="IValueConverter"/> which can be used inline in a binding as a simple binary expression
    /// </summary>
    public class ExpressionValueConverter : ExpressionExtension, IValueConverter
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ExpressionValueConverter"/>
        /// </summary>
        /// <param name="expression">Original expression</param>
        public ExpressionValueConverter(string expression) : base(expression)
        {
        }

        /// <summary>
        /// <see cref="IValueConverter.Convert(object, Type, object, CultureInfo)"/>
        /// </summary>
        /// <param name="value">Source value</param>
        /// <param name="targetType">Type going to the binding</param>
        /// <param name="parameter">Parameter in the binding</param>
        /// <param name="culture">Culture information</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ComputeExpression(value, parameter);
        }

        /// <summary>
        /// <see cref="IValueConverter.ConvertBack(object, Type, object, CultureInfo)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This will do nothing, it will be too complicated to do the inverse expression at this point
            // Can implement later if we want to
            return Binding.DoNothing;
        }

        /// <summary>
        /// <see cref="System.Windows.Markup.MarkupExtension.ProvideValue(IServiceProvider)"/>
        /// </summary>
        /// <param name="serviceProvider">Stuff</param>
        /// <returns>Reference to ourselves</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

    /// <summary>
    /// Type of <see cref="IValueConverter"/> which can use an inline expression in XAML to be calculated
    /// This particular instance allows the resulting <see cref="bool"/> result to be converted to a specific value
    /// </summary>
    /// <typeparam name="D">Destination type in binding</typeparam>
    /// <typeparam name="EP">Equals policy</typeparam>
    public class ExpressionValueConverter<D> : ExpressionExtension, IValueConverter
    {
        /// <summary>
        /// Converter
        /// </summary>
        private readonly BooleanConverter<D> _converter = new BooleanConverter<D>();

        /// <summary>
        /// Value to use when binding source is true
        /// </summary>
        public D True
        {
            get { return _converter.True; }
            set { _converter.True = value; }
        }
        /// <summary>
        /// Value to use when the binding source if false
        /// </summary>
        public D False
        {
            get { return _converter.False; }
            set { _converter.False = value; }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ExpressionValueConverter"/>
        /// </summary>
        /// <param name="expression">Original expression</param>
        public ExpressionValueConverter(string expression) : base(expression)
        {
        }

        /// <summary>
        /// <see cref="IValueConverter.Convert(object, Type, object, CultureInfo)"/>
        /// </summary>
        /// <param name="value">Source value</param>
        /// <param name="targetType">Type going to the binding</param>
        /// <param name="parameter">Parameter in the binding</param>
        /// <param name="culture">Culture information</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = ComputeExpression(value, parameter);
            if(result is bool)
            {
                var @bool = (bool)result;
                return _converter.Convert(@bool);
            }
            return False;
        }

        /// <summary>
        /// <see cref="IValueConverter.ConvertBack(object, Type, object, CultureInfo)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This will do nothing, it will be too complicated to do the inverse expression at this point
            // Can implement later if we want to
            return Binding.DoNothing;
        }

        /// <summary>
        /// <see cref="System.Windows.Markup.MarkupExtension.ProvideValue(IServiceProvider)"/>
        /// </summary>
        /// <param name="serviceProvider">Stuff</param>
        /// <returns>Reference to ourselves</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
