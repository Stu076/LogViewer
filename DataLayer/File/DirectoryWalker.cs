using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LogViewer.DataLayer.File
{
    interface IDirectoryWalker
    {
#nullable enable
        List<string> WalkDirectory(string? directoryPath);
#nullable disable
    }
    class DirectoryWalker : IDirectoryWalker
    {
#nullable enable
        public List<string> WalkDirectory(string? directoryPath)
        {
            List<string> fileList;
            if (directoryPath is string unwrapedDirectoryPath)
            {
                fileList = Directory.GetFiles(unwrapedDirectoryPath).ToList();
            }
            else
            {
                fileList = Directory.GetFiles(Directory.GetCurrentDirectory()).ToList();
            }

            return fileList;
        }
#nullable disable
    }
}
