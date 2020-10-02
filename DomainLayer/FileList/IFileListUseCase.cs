using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogViewer.DomainLayer.FileList
{
    public interface IFileListUseCase
    {
#nullable enable
        List<string> FetchFileList(string? dictionaryPath);
#nullable disable
    }
}
