﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogViewer.DomainLayer.LogEntry
{
    interface ILogEntriesProvider
    {
        List<string> FetchLogEntries(string logFileName);
    }
}
