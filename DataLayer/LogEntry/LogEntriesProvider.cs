using LogViewer.DataLayer.File;
using LogViewer.DomainLayer.LogEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
