using Framework.Patterns.Equality;

namespace Framework.WPF.Converters.Conversion
{
    /// <summary>
    /// Type of <see cref="BooleanConverter{D, EP}"/> which converts from a <see cref="bool"/> value to another <see cref="bool"/> value
    /// </summary>
    public class BooleanConverter : BooleanConverter<bool, BasicEqualsPolicy<bool>>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BooleanConverter"/>
        /// </summary>
        public BooleanConverter() : base(true)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="BooleanConverter"/>
        /// </summary>
        /// <param name="true">True value</param>
        public BooleanConverter(bool @true) : base(@true)
        {
        }
    }

    /// <summary>
    /// Type of <see cref="BooleanConverter{D, EP}"/> using the <see cref="BasicEqualsPolicy{D}"/>
    /// </summary>
    /// <typeparam name="D"></typeparam>
    public class BooleanConverter<D> : BooleanConverter<D, BasicEqualsPolicy<D>>
    {
    }

    /// <summary>
    /// Implementation of <see cref="ValueConverterBase{S, D}"/> which converts from a source <see cref="bool"/> to the destination type <see cref="D"/>
    /// </summary>
    /// <typeparam name="D">Type of the destination</typeparam>
    /// <typeparam name="EP">Type of equals policy, must be of type <see cref="IEqualsPolicy{T}"/></typeparam>
    public class BooleanConverter<D, EP> : ValueConverterBase<bool, D> where EP : IEqualsPolicy<D>, new()
    {
        /// <summary>
        /// Value to use when binding source is true
        /// </summary>
        public D True { get; set; }
        /// <summary>
        /// Value to use when the binding source if false
        /// </summary>
        public D False { get; set; } = default(D);

        /// <summary>
        /// Policy
        /// </summary>
        private readonly EP _equalsPolicy = new EP();

        /// <summary>
        /// Access policy
        /// </summary>
        protected EP EqualsPolicy => _equalsPolicy;

        /// <summary>
        /// Initializes a new instance of <see cref="BooleanConverter{D, EP}"/>
        /// </summary>
        public BooleanConverter()
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="BooleanConverter{D, EP}"/>
        /// </summary>
        /// <param name="true">The true value</param>
        public BooleanConverter(D @true)
        {
            True = @true;
        }

        /// <summary>
        /// <see cref="ValueConverterBase{S, D}.Convert(S)"/>
        /// </summary>
        /// <param name="value">Source bool value</param>
        /// <returns>The true or false value</returns>
        public override D Convert(bool value)
        {
            return value ? True : False;
        }

        /// <summary>
        /// <see cref="ValueConverterBase{S, D}.ConvertBack(D)"/>
        /// </summary>
        /// <param name="value">Binding destination value</param>
        /// <returns>If the binding destination value equals the true value, true, else false</returns>
        public override bool ConvertBack(D value)
        {
            return _equalsPolicy.EqualsTo(value, True) ? true : false;
        }
    }
}
