using System;
using Markup = System.Windows.Markup;

namespace Framework.WPF.MarkupExtension
{
    /// <summary>
    /// <see cref="Markup.MarkupExtension"/> for being able to write out a double in XAML
    /// </summary>
    public sealed class DoubleExtension : Markup.MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DoubleExtension"/>
        /// </summary>
        /// <param name="value"></param>
        public DoubleExtension(double value) { Value = value; }
        /// <summary>
        /// Access the double value
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        ///<see cref="Markup.MarkupExtension.ProvideValue(IServiceProvider)"/>
        /// </summary>
        /// <param name="sp">Service Provider</param>
        /// <returns>Double value</returns>
        public override object ProvideValue(IServiceProvider sp) { return Value; }
    };
}
