using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tor2Plex.Directory.Data;

namespace Tor2Plex
{
    /// <summary>
    /// Helper class to query information about directories
    /// </summary>
    public static class DirectoryStructure
    {

        /// <summary>
        /// Finds all logical drives as DirectoryItems
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DirectoryItem> GetLogicalDrives()
        {
            // Find logical drives
            return System.IO.Directory.GetLogicalDrives().Select(drive => new DirectoryItem {
                FullPath = drive,
                Type = DirectoryItemType.Drive
            });
        }


        /// <summary>
        /// Gets the directories top-level content
        /// </summary>
        /// <param name="fullPath">Full path of directory</param>
        /// <returns></returns>
        public static IEnumerable<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();

            // Look for directories
            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);

                items.AddRange(dirs.Select(dir => new DirectoryItem {
                    FullPath = dir,
                    Type = DirectoryItemType.Folder
                }));
            } 
            catch { }

            // Look for files
            try
            {
                var files = System.IO.Directory.GetFiles(fullPath);

                items.AddRange(files.Select(file => new DirectoryItem {
                    FullPath = file,
                    Type = DirectoryItemType.File
                }));
            } 
            catch { }


            return items;
        }

        private static IEnumerable<DirectoryItem> GetDirectoryContents(DirectoryItemType type, string fullPath)
        {
            var lstItems = new List<DirectoryItem>();

            try
            {
                var items = new List;

                if (type == DirectoryItemType.Folder)
                {
                    items = System.IO.Directory.GetDirectories(fullPath);
                }
                else if(type == DirectoryItemType.File)
                {
                    items = System.IO.Directory.GetFiles(fullPath);
                }
                           

                lstItems.AddRange(items.Select(item => new DirectoryItem {
                    FullPath = item,
                    Type = type
                }));
            } 
            catch { }

            return lstItems;
        }

        /// <summary>
        /// Find the file or folder name from a given path
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Convert all slashes to back-slashes
            var normalizedPath = path.Replace('/', '\\');

            var parentDirIndex = normalizedPath.LastIndexOf('\\');
            
            // Not a directory
            if (parentDirIndex < 0)
                return normalizedPath;

            return normalizedPath.Substring(parentDirIndex  + 1);
        }
    }

}
