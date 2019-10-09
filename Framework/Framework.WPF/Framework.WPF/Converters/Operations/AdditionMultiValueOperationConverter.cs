namespace Framework.WPF.Converters.Operations
{
    public class AdditionDoubleMultiValueOperationConverter : MultiValueOperationConverter<double, AdditionDouble, DoubleNegativeCheck>
    {
        protected override double InvertRight(double right)
        {
            return right * -1.0d;
        }
    }
}
