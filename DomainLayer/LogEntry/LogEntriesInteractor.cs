using System.Collections.Generic;

namespace LogViewer.DomainLayer.LogEntry
{
    class LogEntriesInteractor : ILogEntriesUseCase
    {
        private readonly ILogEntriesProvider logEntriesProvider;

        public LogEntriesInteractor(ILogEntriesProvider logEntriesProvider)
        {
            this.logEntriesProvider = logEntriesProvider;
        }

        public List<LogEntry> FetchLogEntries(string logFileName)
        {
            return BussinessLogic(logFileName);
        }

        public List<LogEntry> BussinessLogic(string logFileName)
        {
            var parsedEntries = new List<LogEntry>();

            foreach (var line in logEntriesProvider.FetchLogEntries(logFileName))
            {
                if (!line.Contains("DEBUG"))
                {
                    string[] splitLine = line.Split('|');
                    parsedEntries.Add(new LogEntry
                    {
                        DateTime = splitLine[0],
                        Class = splitLine[2],
                        ErrorMessage = splitLine[3]
                    });
                }
            }

            return parsedEntries;
        }
    }
}
