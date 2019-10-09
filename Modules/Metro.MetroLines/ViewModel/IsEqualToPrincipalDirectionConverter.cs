using Framework.WPF.Converters.Conversion;
using Modules.Metro.MetroLines.Data;

namespace Modules.Metro.MetroLines.ViewModel
{
    /// <summary>
    /// <see cref="IsEqualToBooleanConverter{S}"/> that converts from whether two <see cref="LineType"/> are equal to a <see cref="bool"/>
    /// </summary>
    public class IsEqualToPrincipalDirectionConverter : IsEqualToBooleanConverter<LineType>
    {
        /// <summary>
        /// <see cref="IsEqualToBooleanConverter{S, SEP, D, DEP}.FalseBackValue"/>
        /// </summary>
        protected override LineType FalseBackValue => LineType.Circle;
    }
}
