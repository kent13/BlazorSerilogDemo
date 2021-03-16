﻿using System;

namespace BlazorSerilogDemo.Services
{
    public class LogItem
    {
        public int Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}
