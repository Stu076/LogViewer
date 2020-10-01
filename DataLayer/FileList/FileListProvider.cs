using LogViewer.DataLayer.File;
using LogViewer.DomainLayer.FileList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogViewer.DataLayer.FileList
{
    class FileListProvider : IFileListProvider
    {
        private readonly IDirectoryWalker directoryWalker = new DirectoryWalker();

        public FileListProvider() { }
        
        public FileListProvider(IDirectoryWalker directoryWalker)
        {
            this.directoryWalker = directoryWalker;
        }

#nullable enable
        public List<string> FetchFileList(string? dictionaryPath)
        {
            return directoryWalker.WalkDirectory(dictionaryPath);
        }
#nullable disable
    }
}
