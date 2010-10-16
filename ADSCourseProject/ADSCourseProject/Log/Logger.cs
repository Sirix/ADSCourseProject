using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADSCourseProject.Log
{
    public class Logger
    {
        private static Logger _inst;
        public static Logger instance
        {
            // ReSharper disable ConvertConditionalTernaryToNullCoalescing
            get { return _inst == null ? (_inst = new Logger()) : _inst; }
            // ReSharper restore ConvertConditionalTernaryToNullCoalescing
        }

        /// <summary>
        /// Collection of log records, associated with their Log.Type
        /// </summary>
        public Dictionary<Type, string> Records { get; private set; }
        protected Logger()
        {
            Records = new Dictionary<Type, string>();
        }

        

    }
}
