using System;
using System.Globalization;
using System.Windows.Data;
using Framework.Patterns.Equality;
using Framework.WPF.Converters.Conversion;
using Framework.WPF.MarkupExtension;

namespace Framework.WPF.Converters.Operations
{
    public class CompoundExpressionValueConverter : ExpressionExtension, IMultiValueConverter
    {
        public CompoundExpressionValueConverter(string expression) : base(expression)
        {
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return ComputeExpression(values);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new[] { Binding.DoNothing };
        }
    }

    public class CompoundExpressionValueConverter<D, EP> : ExpressionExtension, IMultiValueConverter where EP: IEqualsPolicy<D>, new()
    {
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

        public CompoundExpressionValueConverter(string expression) : base(expression)
        {
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var result = ComputeExpression(values);
            if (result is bool)
            {
                var @bool = (bool)result;
                return _converter.Convert(@bool);
            }
            return False;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new[] { Binding.DoNothing };
        }
    }

    public class CompoundExpressionValueConverter<D> : CompoundExpressionValueConverter<D, BasicEqualsPolicy<D>>
    {
        public CompoundExpressionValueConverter(string expression) : base(expression)
        {
        }
    }
}
