using LogViewer.DataLayer.FileList;
using LogViewer.DataLayer.LogEntry;
using LogViewer.DomainLayer.FileList;
using LogViewer.DomainLayer.LogEntry;
using LogViewer.UILayer;

namespace LogViewer
{
    public class DependencyContainer: ILogEntriesDependencies
    {
        public ILogEntriesUseCase LogEntriesUseCase { get; } = new LogEntriesInteractor(new LogEntriesProvider());
        public IFileListUseCase FileListUseCase { get; } = new FileListInteractor(new FileListProvider());
    }
}
