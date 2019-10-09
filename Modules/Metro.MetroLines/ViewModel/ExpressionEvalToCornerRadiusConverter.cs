using System.Windows;
using Framework.WPF.Converters.Operations;

namespace Modules.Metro.MetroLines.ViewModel
{
    /// <summary>
    /// <see cref="CompoundExpressionValueConverter{D}"/> that converts from a given XAML expression evaluated to true/false, and then converts that to a <see cref="CornerRadius"/>
    /// </summary>
    public class ExpressionEvalToCornerRadiusConverter : CompoundExpressionValueConverter<CornerRadius>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ExpressionEvalToCornerRadiusConverter"/>
        /// </summary>
        /// <param name="expression">Original expression</param>
        public ExpressionEvalToCornerRadiusConverter(string expression) : base(expression)
        {
        }
    }
}
