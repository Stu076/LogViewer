using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogViewer.DomainLayer.FileList
{
    class FileListInteractor : IFileListUseCase
    {
        private readonly IFileListProvider fileListProvider;

        public FileListInteractor(IFileListProvider fileListProvider)
        {
            this.fileListProvider = fileListProvider;
        }

#nullable enable
        public List<string> FetchFileList(string? dictionaryPath)
        {
            return fileListProvider.FetchFileList(dictionaryPath)
                                   .Where(file => file.Contains("log"))
                                   .ToList();
        }
#nullable disable
    }
}
