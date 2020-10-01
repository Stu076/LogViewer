using LogViewer.DataLayer.FileList;
using LogViewer.DataLayer.LogEntry;
using LogViewer.DomainLayer.FileList;
using LogViewer.DomainLayer.LogEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogViewer
{
    class DependencyContainer
    {
        public ILogEntriesUseCase LogEntriesUseCase { get; } = new LogEntriesInteractor(new LogEntriesProvider());
        public IFileListUseCase FileListUseCase { get; } = new FileListInteractor(new FileListProvider());
    }
}
