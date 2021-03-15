
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;

namespace BlazorSerilogDemo.Services
{
    public class LogData
    {
        public List<LogItem> Log = new List<LogItem>();
        public LoggingLevelSwitch LevelSwitch = new LoggingLevelSwitch();
        public int LogEntriesMax = 500;
        public DateTime DateTimeSaved = DateTime.Now;

        public LogData()
        {
            LevelSwitch.MinimumLevel = LogEventLevel.Warning;
        }
    }
}
