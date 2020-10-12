using System.Collections.Generic;

namespace LogViewer.DomainLayer.LogEntry
{
    public interface ILogEntriesUseCase
    {
        List<LogEntry> FetchLogEntries(string logFileName);
    }
}
