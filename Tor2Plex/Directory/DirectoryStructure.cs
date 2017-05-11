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
            items.AddRange(GetDirectoryContents(DirectoryItemType.Folder, fullPath));
            items.AddRange(GetDirectoryContents(DirectoryItemType.File, fullPath));
            return items;
        }


        /// <summary>
        /// Retrieves contents of directory of specific type 
        /// </summary>
        /// <param name="type">DirectoryItemType</param>
        /// <param name="fullPath">Full path of directory</param>
        /// <returns></returns>
        private static IEnumerable<DirectoryItem> GetDirectoryContents(DirectoryItemType type, string fullPath)
        {
            var contents = new List<DirectoryItem>();

            try
            {
                var items = new List<string>();

                if (type == DirectoryItemType.Folder)
                {
                    items = System.IO.Directory.GetDirectories(fullPath).ToList();
                }
                else if(type == DirectoryItemType.File)
                {
                    items = System.IO.Directory.GetFiles(fullPath).ToList(); ;
                }
                
                contents.AddRange(items.Select(item => new DirectoryItem {
                    FullPath = item,
                    Type = type
                }));
            } 
            catch { }

            return contents;
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
