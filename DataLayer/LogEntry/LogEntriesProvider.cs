using System.Collections.Generic;

using LogViewer.DataLayer.File;
using LogViewer.DomainLayer.LogEntry;

namespace LogViewer.DataLayer.LogEntry
{
    class LogEntriesProvider : ILogEntriesProvider
    {
        private readonly IFileReader fileReader = new FileReader();

        public LogEntriesProvider() { }

        public LogEntriesProvider(IFileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public List<string> FetchLogEntries(string logFileName)
        {
            return fileReader.GetLogFileEntries(logFileName);
        }
    }
}
