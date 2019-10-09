namespace Framework.Patterns.Type
{
    /// <summary>
    /// Wrapper around a type <see cref="T"/> to make it a strong type
    /// This class is meant to be inherited from and not used directly
    /// </summary>
    /// <typeparam name="T">Type being wrapped</typeparam>
    public abstract class StrongType<T>
    {
        /// <summary>
        /// Resource being wrapped
        /// </summary>
        private readonly T _wrapped;

        /// <summary>
        /// Initializes a new instance of <see cref="StrongType{T}"/>
        /// </summary>
        /// <param name="value">Value to wrap</param>
        protected StrongType(T value)
        {
            _wrapped = value;
        }

        /// <summary>
        /// Implicit conversion back to <see cref="T"/>
        /// </summary>
        /// <param name="source">Wrapper</param>
        public static implicit operator T(StrongType<T> source)
        {
            return source._wrapped;
        }
    }
}
