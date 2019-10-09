using System.Collections.ObjectModel;

namespace Framework.WPF.ViewModel
{
    /// <summary>
    /// Used by view models that represent a list of data
    /// </summary>
    /// <typeparam name="T">Type of data that is shown</typeparam>
    public abstract class ViewModelCollectionBase<T>
    {
        // Collection of lines
        private readonly ObservableCollection<T> _metroLines = new ObservableCollection<T>();

        /// <summary>
        /// Access the collection
        /// </summary>
        public ObservableCollection<T> Collection
        {
            get { return _metroLines; }
        }

        /// <summary>
        /// Load the collection
        /// </summary>
        public abstract void LoadCollection();
    }
}
