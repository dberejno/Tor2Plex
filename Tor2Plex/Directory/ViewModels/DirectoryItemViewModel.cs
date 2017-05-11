using System.Collections.ObjectModel;
using Tor2Plex.Directory.Data;
using System.Linq;
using System.Windows.Input;

namespace Tor2Plex.Directory.ViewModels
{
    /// <summary>
    /// View model for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region public properties

        public DirectoryItemType Type { get; set; }

        public string FullPath { get; set; }

        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        /// <summary>
        /// List of all children
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }
        
        /// <summary>
        /// Indicates if the current item is expanded or not
        /// </summary>
        public bool IsExpanded {
            get {
                return this.Children?.Count(f => f != null) > 0;
            }
            set {
                if (value == true)
                    Expand();
                else
                    this.ClearChildren();
            }
        }

        #endregion


        #region Public Commands
        /// <summary>
        /// Command to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }
        #endregion


        #region Constructor
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.ExpandCommand = new RelayCommand(Expand);
            this.FullPath = fullPath;
            this.Type = type;
            this.Children = new ObservableCollection<DirectoryItemViewModel>();
            this.ClearChildren();
        }
        #endregion


        #region Helper Methods

        private void ClearChildren()
        {
            this.Children.Clear();

            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);  // Allow empty drives or folders to be expanded
        }


        private void Expand()
        {
            if (!this.CanExpand)
                return;

            this.Children = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetDirectoryContents(this.FullPath)
                .Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }

        #endregion
    }
}
