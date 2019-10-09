using System;

namespace Framework.Patterns.Equality
{
    /// <summary>
    /// Extensions for the type <see cref="double"/>
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Precision for the double comparison
        /// </summary>
        private const double Precision = 1E-6;

        /// <summary>
        /// Compare two values of type <see cref="double"/>
        /// </summary>
        /// <param name="value">Left compare</param>
        /// <param name="other">Right compare</param>
        /// <param name="precision">Precision to use, has a default</param>
        /// <returns></returns>
        public static bool EqualsWithin(this double value, double other, double precision = Precision)
        {
            // Various double checks
            if (Equals(value, other)) return true;
            if (double.IsNaN(value) && double.IsNaN(other)) return true;
            if (double.IsInfinity(value) && double.IsInfinity(other)) return true;
            if (Math.Abs(value - other) < precision) return true;
            return false;
        }
    }
}
