using System;
using System.Globalization;
using System.Windows.Data;
using Framework.WPF.Converters.Conversion;

namespace Framework.WPF.Converters.Operations
{
    public class MultiValueAndBooleanConverter<D> : BooleanConverter<D>, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var totalTruth = true;
            foreach (var value in values)
            {
                if (!(value is bool) || !((bool)value))
                {
                    totalTruth = false;
                    break;
                }
            }
            return Convert(totalTruth);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { Binding.DoNothing };
        }
    }
}
