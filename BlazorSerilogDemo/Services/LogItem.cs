using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSerilogDemo.Services
{
    public class LogItem
    {
        public int Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Message { get; set; }
        //public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}
