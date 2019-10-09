using System;
using System.Windows.Markup;
using Modules.Metro.MetroLines.ViewModel;

namespace Metro.ViewModel
{
    public class ViewModelContainer : MarkupExtension
    {
        public ViewModelContainer()
        {

        }

        private readonly MetroLinesViewModel _metroLinesViewModel = new MetroLinesViewModel();

        public MetroLinesViewModel MetroLinesViewModel => _metroLinesViewModel;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public void LoadViewModels()
        {
            MetroLinesViewModel.LoadCollection();
        }
    }
}
