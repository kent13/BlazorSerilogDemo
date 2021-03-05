using BlazorSerilogDemo.Tools;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSerilogDemo.Services
{
    public class LoggerService
    {
        private List<LogItem> _log = new List<LogItem>();
        public LoggingLevelSwitch LevelSwitch = new LoggingLevelSwitch();

        public LoggerService()
        {
            LevelSwitch.MinimumLevel = LogEventLevel.Verbose;
        }

        public void Add(LogItem logItem)
        {
            _log.Add(logItem);
        }

        public IEnumerable<LogItem> GetLastLogitems(int numberToGet = 5)
        {
            return _log.TakeLastReverse(numberToGet);
        }

        public string GetMinimumLogLevel()
        {
            string result = "I don't Know";
            if (Log.IsEnabled(LogEventLevel.Verbose)) { result = "Verbose"; }
            else if (Log.IsEnabled(LogEventLevel.Debug)) { result = "Debug"; }
            else if (Log.IsEnabled(LogEventLevel.Warning)) { result = "Warning"; }
            else if (Log.IsEnabled(LogEventLevel.Information)) { result = "Information"; }
            else if (Log.IsEnabled(LogEventLevel.Error)) { result = "Error"; }
            else if (Log.IsEnabled(LogEventLevel.Fatal)) { result = "Fatal"; }



            return result;
        }
    }


}
