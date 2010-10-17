using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADSCourseProject.Log
{
    /// <summary>
    /// Provides information about log entry, such as its type, message and tick
    /// </summary>
    internal class LogEntry
    {
        /// <summary>
        /// Type of log event
        /// </summary>
        public LogType LogType { get; set; }
        /// <summary>
        /// Log message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Tick on which this entry was writed
        /// </summary>
        public int Tick{ get; set; }
    }
}
