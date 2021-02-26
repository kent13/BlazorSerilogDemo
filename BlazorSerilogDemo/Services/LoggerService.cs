using BlazorSerilogDemo.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSerilogDemo.Services
{
    public class LoggerService
    {
        private List<LogItem> _log = new List<LogItem>();

        public LoggerService()
        {

        }

        public void Add(LogItem logItem)
        {
            _log.Add(logItem);
        }

        public IEnumerable<LogItem> GetLastLogitems(int numberToGet = 5)
        {
            return _log.TakeLastReverse(numberToGet);
        }

    }


}
