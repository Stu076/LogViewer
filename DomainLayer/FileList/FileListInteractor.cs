using System.Collections.Generic;

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
        public List<FileData> FetchFileList(string? dictionaryPath)
        {
            var fileList = new List<FileData>();

            foreach (var file in fileListProvider.FetchFileList(dictionaryPath))
            {
                if (file.Contains("log"))
                {
                    fileList.Add(new FileData
                    {
                        FileName = file.Substring(file.LastIndexOf("\\") + 1),
                        FilePath = file
                    });
                }
            }
            return fileList;
        }
#nullable disable
    }
}
