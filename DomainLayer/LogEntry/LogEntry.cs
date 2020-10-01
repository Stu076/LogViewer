using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogViewer.DomainLayer.LogEntry
{
    class LogEntry
    {
        public string DateTime { get; set; }
        public string Class { get; set; }
        public string ErrorMessage { get; set; }
    }
}
