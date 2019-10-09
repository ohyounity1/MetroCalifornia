using System;
using System.Globalization;
using System.Windows.Data;

namespace Framework.WPF.Converters.Operations
{
    public class MultiValueOperationConverter<T, OP, NG> : OperationConverterBase<T, OP, NG>, IMultiValueConverter where OP : IOperation<T>, new() where NG : INegative<T>, new()
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            T leftOperand = default(T);
            if (!_alreadySet)
            {
                var first = true;
                
                foreach (var value in values)
                {
                    if (first)
                    {
                        leftOperand = (T)value;
                        first = false;
                    }
                    else
                    {
                        if (value is T)
                        {
                            var rightOperand = (T)value;
                            if (Invert)
                                rightOperand = InvertRight(rightOperand);
                            leftOperand = _op.Op(leftOperand, rightOperand);
                            if (AllowNegative || !_ng.Op(leftOperand, Low))
                            {
                                _alreadySet = SetOnce;
                                return leftOperand;
                            }
                        }
                    }
                }
            }
            return leftOperand;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new[] { Binding.DoNothing };
        }
    }
}
