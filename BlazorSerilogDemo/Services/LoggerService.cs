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
        private int _logEntriesMax = 500;


        public LoggerService()
        {
            LevelSwitch.MinimumLevel = LogEventLevel.Warning;
        }

        public void Add(LogItem logItem)
        {
            _log.Add(logItem);
            TrimRecords();
        }
        public int LogEntriesMax
        {
            get { return _logEntriesMax; }
            set
            {
                _logEntriesMax = value;
                TrimRecords();
            }
        }
        private void TrimRecords()
        {
            // Remove Beginning of list
            int remove = Math.Max(0, _log.Count - _logEntriesMax);
            if (remove > 0)
            {
                _log.RemoveRange(0, remove);
            }
        }

        public IEnumerable<LogItem> GetLastLogitems(int numberToGet = 5)
        {
            return _log.TakeLastReverse(numberToGet);
        }

        public async Task<LogItem> GetLogItemAsync(int id)
        {
            // Following statement will prevent a compiler warning
            await Task.FromResult(0);
            try
            {
                var logItem = _log.FirstOrDefault(x => x.Id == id);
                return logItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public LogItem GetLogItem(int id)
        {
            // Following statement will prevent a compiler warning
            try
            {
                var logItem = _log.FirstOrDefault(x => x.Id == id);
                return logItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
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
        public void SetMinimumLogLevel(LogEventLevel newLevel)
        {
            LevelSwitch.MinimumLevel = newLevel;
        }

        public void SetMinimumLogLevel(string newLevel)
        {
            switch (newLevel.ToLowerInvariant())
            {
                case "verbose":
                    LevelSwitch.MinimumLevel = LogEventLevel.Verbose;
                    break;
                case "vebug":
                    LevelSwitch.MinimumLevel = LogEventLevel.Debug;
                    break;
                case "warning":
                    LevelSwitch.MinimumLevel = LogEventLevel.Warning;
                    break;
                case "information":
                    LevelSwitch.MinimumLevel = LogEventLevel.Information;
                    break;
                case "error":
                    LevelSwitch.MinimumLevel = LogEventLevel.Error;
                    break;
                case "fatal":
                    LevelSwitch.MinimumLevel = LogEventLevel.Fatal;
                    break;
                default:
                    LevelSwitch.MinimumLevel = LogEventLevel.Warning;
                    break;
            }         
        }
    }
}
