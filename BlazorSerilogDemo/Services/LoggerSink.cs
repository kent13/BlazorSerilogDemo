using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Configuration;
using BlazorSerilogDemo.Tools;

namespace BlazorSerilogDemo.Services
{
    public class LoggerSink : ILogEventSink, IDisposable
    {
        private readonly IFormatProvider _formatProvider;
        private readonly LoggerService _loggerService;

        public LoggerSink(IFormatProvider formatProvider, LoggerService loggerService)
        {
            _formatProvider = formatProvider;
            _loggerService = loggerService;
        }


        public void Emit(LogEvent logEvent)
        {
            var message = logEvent.RenderMessage(_formatProvider);

            var newLogItem = new LogItem();
            newLogItem.Message = message;
//            newLogItem.MessageTemplate = logEvent.MessageTemplate.ToString();
            newLogItem.TimeStamp = logEvent.Timestamp;
            newLogItem.Level = logEvent.Level.ToString();
            newLogItem.Exception = logEvent.Exception.ToLogString("");
            newLogItem.Properties = logEvent.Properties.ToString();

            _loggerService.Add(newLogItem);
        }




        public void Dispose()
        {
            /// TODO: Kent -> Clear in memory storage 
            /// Save data to local storage
            /// 
        }
    }
}
