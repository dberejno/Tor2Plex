using PropertyChanged;
using System.ComponentModel;

namespace Tor2Plex.Directory.ViewModels
{
    /// <summary>
    /// Base view model that fires Property Changed events as needed
    /// </summary>
    [ImplementPropertyChanged]  //Fody.PropertyChanged nuget package
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}