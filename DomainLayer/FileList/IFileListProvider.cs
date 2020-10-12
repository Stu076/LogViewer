using System.Collections.Generic;

namespace LogViewer.DomainLayer.FileList
{
    interface IFileListProvider
    {
#nullable enable
        List<string> FetchFileList(string? dictionaryPath);
#nullable disable
    }
}
