namespace Framework.Patterns.Equality
{
    /// <summary>
    /// Policy for equals
    /// </summary>
    /// <typeparam name="T">Type for the policy</typeparam>
    public interface IEqualsPolicy<T>
    {
        /// <summary>
        /// Implement this method for equals
        /// </summary>
        /// <param name="_0">Left parameter</param>
        /// <param name="_1">Right parameter</param>
        /// <returns>true if equal, false otherwise</returns>
        bool EqualsTo(T _0, T _1);
    }

    /// <summary>
    /// A simple equals check implementing <see cref="IEqualsPolicy{T}"/>
    /// </summary>
    /// <typeparam name="D">Type of the policy</typeparam>
    public class BasicEqualsPolicy<D> : IEqualsPolicy<D>
    {
        /// <summary>
        /// <see cref="IEqualsPolicy{T}.EqualsTo(T, T)"/>
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <returns></returns>
        public bool EqualsTo(D _0, D _1)
        {
            return Equals(_0, _1);
        }
    }

    /// <summary>
    /// Equals policy for doubles implementing <see cref="IEqualsPolicy{T}"/>, since direct equals is not possible
    /// </summary>
    public class AlmostEqualsPolicy : IEqualsPolicy<double>
    {
        /// <summary>
        /// <see cref="IEqualsPolicy{T}.EqualsTo(T, T)"/>
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <returns></returns>
        public bool EqualsTo(double _0, double _1)
        {
            return _0.EqualsWithin(_1);
        }
    }
}
