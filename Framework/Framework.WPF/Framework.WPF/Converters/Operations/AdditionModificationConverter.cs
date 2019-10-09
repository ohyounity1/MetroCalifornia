namespace Framework.WPF.Converters.Operations
{
    public class AdditionDouble : IOperation<double>
    {
        public double Op(double left, double right)
        {
            return left + right;
        }
    }

    public class AdditionDoubleModificationConverter : OperationConverter<double, AdditionDouble, DoubleNegativeCheck>
    {
        protected override double InvertRight(double right)
        {
            return right * -1.0d;
        }
    }
}
