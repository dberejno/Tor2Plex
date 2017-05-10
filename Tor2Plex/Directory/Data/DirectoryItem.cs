

namespace Tor2Plex.Directory.Data
{
    /// <summary>
    /// Information about a directory item such as a drive, file, or folder.
    /// </summary>
    public class DirectoryItem
    {
        public DirectoryItemType Type {get; set;}

        // The absolute path to item
        public string FullPath { get; set; }

        // Name of directory Item
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }
    }
}
