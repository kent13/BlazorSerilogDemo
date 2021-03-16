using Serilog;
using System;

namespace BlazorSerilogDemo.Services
{
    public static class LoggerSinkConfiguration
    {
        public static LoggerConfiguration LoggerSink(
          this Serilog.Configuration.LoggerSinkConfiguration loggerConfiguration,
           LoggerService loggerService,
          IFormatProvider formatProvider = null)
        {
            return loggerConfiguration.Sink(new LoggerSink(formatProvider, loggerService));
        }
    }
}
