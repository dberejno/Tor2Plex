using System.Windows;
using Tor2Plex.Directory.ViewModels;


namespace Tor2Plex
{
    /// <summary>
    /// Interaction logic for DirectoryExplorerWindow.xaml
    /// </summary>
    public partial class DirectoryExplorerWindow : Window
    {

        #region Constuctor
        public DirectoryExplorerWindow()
        {
            InitializeComponent();

            this.DataContext = new DirectoryStructureViewModel();                   
        }

        #endregion

    }
}
