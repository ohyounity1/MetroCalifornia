using System;
using System.Globalization;
using System.Windows.Data;

namespace Framework.WPF.Converters.Operations
{
    /// <summary>
    /// Interface for an operation
    /// </summary>
    /// <typeparam name="T">Type of the operation</typeparam>
    public interface IOperation<T>
    {
        /// <summary>
        /// Implement the operation
        /// </summary>
        /// <param name="left">Left side of operation</param>
        /// <param name="right">Right side of the operation</param>
        /// <returns></returns>
        T Op(T left, T right);
    }

    public interface INegative<T>
    {
        bool Op(T left, T right);
    }

    public class DoubleNegativeCheck : INegative<double>
    {
        public bool Op(double left, double right)
        {
            return left < right;
        }
    }

    public abstract class OperationConverterBase<T, OP, NG> where OP : IOperation<T>, new() where NG : INegative<T>, new()
    {
        protected readonly OP _op = new OP();
        protected readonly NG _ng = new NG();

        protected bool _alreadySet = false;

        public bool AllowNegative { get; set; }

        public bool SetOnce { get; set; }

        public bool Invert { get; set; }

        public T Low { get; set; }

        protected virtual T InvertRight(T right) => right;
    }

    public abstract class OperationConverter<T, OP, NG> : OperationConverterBase<T, OP, NG>, IValueConverter where OP : IOperation<T>, new() where NG: INegative<T>, new()
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!_alreadySet)
            {
                if (value is T && parameter is T)
                {
                    var actualValue = (T)value;
                    var actualParameter = (T)parameter;
                    if (Invert)
                        actualParameter = InvertRight(actualParameter);
                    var result = _op.Op(actualValue, actualParameter);
                    if (AllowNegative || !_ng.Op(result, Low))
                    {
                        _alreadySet = SetOnce;
                        return result;
                    }
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
