﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogViewer.DomainLayer.LogEntry
{
    interface ILogEntriesUseCase
    {
        List<LogEntry> FetchLogEntries(string logFileName);
    }
}