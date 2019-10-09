using Framework.Data.Storage;
using Framework.Patterns.Container;
using Framework.WPF.ViewModel;
using Modules.Metro.MetroLines.Model;

namespace Modules.Metro.MetroLines.ViewModel
{
    /// <summary>
    /// Implements <see cref="ViewModelCollectionBase{T}"/>
    /// </summary>
    public class MetroLinesViewModel : ViewModelCollectionBase<MetroLineDetailsBindable>
    {
        /// <summary>
        /// <see cref="ViewModelCollectionBase{T}.LoadCollection"/>
        /// </summary>
        public override void LoadCollection()
        {
            // Load the data out of CSV storage initially
            var storage = new Storable<MetroLineDetailsReader>(new FileStorageMedium("Resources/MetroLines.csv"));
            storage.Load().Serializer.Data.ForEach((v) => Collection.Add((MetroLineDetailsBindable)v));
        }
    }
}
