using System.Windows.Media;

namespace Framework.WPF.Converters.Conversion
{
    /// <summary>
    /// Implementation of <see cref="ValueConverterBase{S, D}"/> that converts from <see cref="Color"/> to <see cref="SolidColorBrush"/>
    /// </summary>
    public class ColorToBrushConverter : ValueConverterBase<Color, SolidColorBrush>
    {
        /// <summary>
        /// <see cref="ValueConverterBase{S, D}.Convert(S)"/>
        /// </summary>
        /// <param name="source">Source color</param>
        /// <returns>Wrapper around color</returns>
        public override SolidColorBrush Convert(Color source)
        {
            return new SolidColorBrush(source);
        }

        /// <summary>
        /// <see cref="ValueConverterBase{S, D}.ConvertBack(D)"/>
        /// </summary>
        /// <param name="destination">The solid color brush</param>
        /// <returns>Raw color</returns>
        public override Color ConvertBack(SolidColorBrush destination)
        {
            return destination.Color;
        }
    }
}
