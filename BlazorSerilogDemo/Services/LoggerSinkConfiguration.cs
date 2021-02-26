using Serilog;
using Serilog.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
