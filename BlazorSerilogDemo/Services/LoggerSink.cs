using BlazorSerilogDemo.Tools;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Text;

namespace BlazorSerilogDemo.Services
{
    public class LoggerSink : ILogEventSink, IDisposable
    {
        private readonly IFormatProvider _formatProvider;
        private readonly LoggerService _loggerService;
        private int itemNumber = 0;

        public LoggerSink(IFormatProvider formatProvider, LoggerService loggerService)
        {
            _formatProvider = formatProvider;
            _loggerService = loggerService;
        }

        public void Emit(LogEvent logEvent)
        {
            var message = logEvent.RenderMessage(_formatProvider);

            var newLogItem = new LogItem();
            newLogItem.Id = itemNumber++;
            newLogItem.Message = message;
            newLogItem.TimeStamp = logEvent.Timestamp;
            newLogItem.Level = logEvent.Level.ToString();
            newLogItem.Exception = logEvent.Exception.ToLogString("");
            if (logEvent.Properties.Count > 0)
            {
                StringBuilder sbProps = new StringBuilder();
                foreach (var item in logEvent.Properties)
                {
                    sbProps.AppendLine($"{item.Key} = {item.Value}");
                }
                newLogItem.Properties = sbProps.ToString();
            }
            _loggerService.Add(newLogItem);
        }

        public void Dispose()
        {
            /// TODO: Clear in memory storage 
        }
    }
}
