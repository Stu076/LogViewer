using System.Collections.Generic;

namespace LogViewer.DomainLayer.LogEntry
{
    interface ILogEntriesProvider
    {
        List<string> FetchLogEntries(string logFileName);
    }
}
