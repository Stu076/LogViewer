using System.Collections.Generic;
using System.Linq;

namespace LogViewer.DataLayer.File
{
    interface IFileReader
    {
        List<string> GetLogFileEntries(string logFileName);
    }
    class FileReader : IFileReader
    {
        public List<string> GetLogFileEntries(string logFileName)
        {
            return System.IO.File.ReadLines(logFileName).ToList();
        }
    }
}
