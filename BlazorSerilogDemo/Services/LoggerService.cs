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
        public LogData logData = new LogData();

        public LoggerService()
        {
            logData.LevelSwitch.MinimumLevel = LogEventLevel.Information;
        }

        public void Add(LogItem logItem)
        {
            logData.Log.Add(logItem);
            TrimRecords();
        }
        public int LogEntriesMax
        {
            get { return logData.LogEntriesMax; }
            set
            {
                logData.LogEntriesMax = value;
                TrimRecords();
            }
        }
        private void TrimRecords()
        {
            // Remove Beginning of list
            int remove = Math.Max(0, logData.Log.Count - logData.LogEntriesMax);
            if (remove > 0)
            {
                logData.Log.RemoveRange(0, remove);
            }
        }

        public IEnumerable<LogItem> GetLastLogitems(int numberToGet = 5)
        {
            return logData.Log.TakeLastReverse(numberToGet);
        }

        public async Task<LogItem> GetLogItemAsync(int id)
        {
            // Following statement will prevent a compiler warning
            await Task.FromResult(0);
            try
            {
                var logItem = logData.Log.FirstOrDefault(x => x.Id == id);
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
                var logItem = logData.Log.FirstOrDefault(x => x.Id == id);
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
            else if (Log.IsEnabled(LogEventLevel.Information)) { result = "Information"; }
            else if (Log.IsEnabled(LogEventLevel.Warning)) { result = "Warning"; }
            else if (Log.IsEnabled(LogEventLevel.Error)) { result = "Error"; }
            else if (Log.IsEnabled(LogEventLevel.Fatal)) { result = "Fatal"; }

            return result;
        }
        public void SetMinimumLogLevel(LogEventLevel newLevel)
        {
            logData.LevelSwitch.MinimumLevel = newLevel;
        }
        public LoggingLevelSwitch GetLevelSwitch()
        {
            return logData.LevelSwitch;
        }

        public void SetMinimumLogLevel(string newLevel)
        {
            switch (newLevel.ToLowerInvariant())
            {
                case "verbose":
                    logData.LevelSwitch.MinimumLevel = LogEventLevel.Verbose;
                    break;
                case "debug":
                    logData.LevelSwitch.MinimumLevel = LogEventLevel.Debug;
                    break;
                case "warning":
                    logData.LevelSwitch.MinimumLevel = LogEventLevel.Warning;
                    break;
                case "information":
                    logData.LevelSwitch.MinimumLevel = LogEventLevel.Information;
                    break;
                case "error":
                    logData.LevelSwitch.MinimumLevel = LogEventLevel.Error;
                    break;
                case "fatal":
                    logData.LevelSwitch.MinimumLevel = LogEventLevel.Fatal;
                    break;
                default:
                    logData.LevelSwitch.MinimumLevel = LogEventLevel.Information;
                    Log.Warning("Log level defaulted to Info - Spelling error?");
                    break;
            }
        }
    }
}
