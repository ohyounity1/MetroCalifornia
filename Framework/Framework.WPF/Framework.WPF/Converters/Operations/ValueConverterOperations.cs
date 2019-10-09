namespace Framework.WPF.Converters.Operations
{
    public interface IValueConverterOperation<T>
    {
        T Op(T leftOperand, T rightOperand);
    }

    public abstract class ValueConverterOperation<T, OP> where OP: IValueConverterOperation<T>, new()
    {
        private readonly OP _op = new OP();
        private readonly T _right;

        public ValueConverterOperation(T rightOperand)
        {
            _right = rightOperand;
        }

        public T Operand => _right;

        public T Operation(T leftOperand)
        {
            return _op.Op(leftOperand, _right);
        }
    }
}
