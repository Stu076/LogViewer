using System.Collections.Generic;

namespace LogViewer.DomainLayer.FileList
{
    public interface IFileListUseCase
    {
#nullable enable
        List<FileData> FetchFileList(string? dictionaryPath);
#nullable disable
    }
}
