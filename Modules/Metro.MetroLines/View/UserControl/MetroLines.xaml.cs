using System.Windows;
using Framework.WPF.UserControl;
using Modules.Metro.MetroLines.ViewModel;

namespace Modules.Metro.MetroLines.View.UserControl
{
    /// <summary>
    /// Interaction logic for MetroLines.xaml
    /// </summary>
    public partial class MetroLines : MetroUserControl
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MetroLines"/>
        /// </summary>
        public MetroLines()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dependency property for the view model
        /// </summary>
        public static readonly DependencyProperty MainViewModelProperty = DependencyProperty.Register(nameof(MainViewModel),
            typeof(MetroLinesViewModel),
            typeof(MetroLines),
            new PropertyMetadata(null, MainViewModelPropertyChangedEventHandler));
        /// <summary>
        /// View model updated event
        /// </summary>
        /// <param name="old">Old vm</param>
        /// <param name="new">New vm</param>
        private void MainViewModelPropertyChangedEventHandler(MetroLinesViewModel old, MetroLinesViewModel @new)
        {
            
        }
        /// <summary>
        /// View model updated event
        /// </summary>
        /// <param name="d">Source object</param>
        /// <param name="e">event args</param>
        private static void MainViewModelPropertyChangedEventHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MetroLines;
            if (control != null)
            {
                control.MainViewModelPropertyChangedEventHandler(e.OldValue as MetroLinesViewModel, e.NewValue as MetroLinesViewModel);
            }
        }
        /// <summary>
        /// The view model for this control
        /// </summary>
        public MetroLinesViewModel MainViewModel
        {
            get { return (MetroLinesViewModel)GetValue(MainViewModelProperty); }
            set { SetValue(MainViewModelProperty, value); }
        }

        /// <summary>
        /// <see cref="MetroUserControl.ControlLoadedFirstTime"/>
        /// </summary>
        protected override void ControlLoadedFirstTime()
        {
        }
    }
}
