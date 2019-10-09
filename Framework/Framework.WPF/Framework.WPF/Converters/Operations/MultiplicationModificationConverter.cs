namespace Framework.WPF.Converters.Operations
{
    public class MultiplyDouble : IOperation<double>
    {
        public double Op(double left, double right)
        {
            return left * right;
        }
    }

    public class MultiplicationModificationConverter : OperationConverter<double, MultiplyDouble, DoubleNegativeCheck>
    {
    }
}
