using System;
using System.Windows.Data;
using Markup = System.Windows.Markup;

namespace Framework.WPF.MarkupExtension
{
    public class AncestorType : Markup.MarkupExtension
    {

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new RelativeSource(RelativeSourceMode.FindAncestor);
        }
    }
}
