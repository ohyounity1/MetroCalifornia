using Framework.WPF.Converters.Conversion;

namespace Modules.Metro.MetroLines.ViewModel
{
    /// <summary>
    /// Type of <see cref="IsEqualToBooleanConverter{S, D}"/> that converts from a string to another string if equal to something
    /// </summary>
    public class StationNameConverter : IsEqualToBooleanConverter<string, string>
    {
        /// <summary>
        /// <see cref="IsEqualToBooleanConverter{S, SEP, D, DEP}.FalseBackValue"/>
        /// </summary>
        protected override string FalseBackValue => string.Empty;

        /// <summary>
        /// <see cref="IsEqualToBooleanConverter{S, SEP, D, DEP}.Convert"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string Convert(bool value)
        {
            return base.Convert(value);
        }
    }
}
