using System;
using System.Collections.ObjectModel;
using System.Linq;
using Tor2Plex.Directory.Data;

namespace Tor2Plex.Directory.ViewModels
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            this.Items = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetLogicalDrives()
                .Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }
    }
}
