using System.ComponentModel;
using System.Windows;
using Metro.ViewModel;

namespace Metro.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(!DesignerProperties.GetIsInDesignMode(this))
            {
                var container = DataContext as ViewModelContainer;
                container?.LoadViewModels();
            }
        }
    }
}
