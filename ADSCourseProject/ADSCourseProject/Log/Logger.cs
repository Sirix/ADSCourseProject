using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADSCourseProject
{
    internal class Log
    {
        /// <summary>
        /// Singleton field
        /// </summary>
        private static Log _inst;
        public static Log Instance
        {
            // ReSharper disable ConvertConditionalTernaryToNullCoalescing
            get { return _inst == null ? (_inst = new Log()) : _inst; }
            // ReSharper restore ConvertConditionalTernaryToNullCoalescing
        }

        /// <summary>
        /// Collection of log records, associated with their Log.Type
        /// </summary>
        public List<LogEntry> Records { get; set; }
        protected Log()
        {
            Records = new List<LogEntry>();
        }
        public void Add(string message, Type type)
        {
            Records.Add(new LogEntry {LogType = type, Message = message});
        }   

// ReSharper disable InconsistentNaming
        /// <summary>
        /// Log DataSend event, occured when new data file created
        /// </summary>
        /// <param name="dataId">Data file id</param>
        /// <param name="size">Size of data file</param>
        /// <param name="A">A-host(source)</param>
        /// <param name="B">B-host(target)</param>
        public void DataSend(int dataId, int size, int A, int B)
// ReSharper restore InconsistentNaming
        {
            Records.Add(new LogEntry
                            {
                                LogType = Type.DataSended,
                                Message =
                                    string.Format("[{0}]: New data file(ID:{1}) with size ({4}) task created: {2}->{3}",
                                                  DateTime.Now.ToLongTimeString(), dataId, A, B, size)
                            });
        }

        // ReSharper disable InconsistentNaming
        /// <summary>
        /// Log PacketSend event, occured when new data file created
        /// </summary>
        /// <param name="packetId">Packet id</param>
        /// <param name="dataId">Data file id</param>
        /// <param name="A">A-host(source)</param>
        /// <param name="B">B-host(target)</param>
        public void PacketSend(int packetId, int dataId, int A, int B)
        // ReSharper restore InconsistentNaming
        {
            Records.Add(new LogEntry
                            {
                                LogType = Type.PacketSended,
                                Message = string.Format("[{0}]: New packet([DS:{1}/{2}]) task created: {3}->{4}",
                                                        DateTime.Now.ToLongTimeString(), dataId, packetId, A, B)
                            });
        }
    }
}
