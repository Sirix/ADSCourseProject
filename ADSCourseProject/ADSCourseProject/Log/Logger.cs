using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADSCourseProject.Log
{
    internal class Logger
    {
        /// <summary>
        /// Singleton field
        /// </summary>
        private static Logger _inst;
        public static Logger Instance
        {
            // ReSharper disable ConvertConditionalTernaryToNullCoalescing
            get { return _inst == null ? (_inst = new Logger()) : _inst; }
            // ReSharper restore ConvertConditionalTernaryToNullCoalescing
        }

        /// <summary>
        /// Specifies tick, on which events are recorded.
        /// </summary>
        public int Tick { get; set; }
        /// <summary>
        /// Collection of log records, associated with their Log.Type
        /// </summary>
        public IList<LogEntry> Records { get; set; }
        protected Logger()
        {
            Records = new List<LogEntry>();
        }
        public void Add(string message, LogType type)
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
                LogType = LogType.DataSended,
                Message =
                    string.Format("[{0}]: New data file(ID:{1}) with size ({4}) task created: {2}->{3}",
                                  DateTime.Now.ToLongTimeString(), dataId, A, B, size),
                Tick = Tick
            });
        }
        // ReSharper disable InconsistentNaming
        /// <summary>
        /// Log DataReceived event, occured when data file has been successfully received
        /// </summary>
        /// <param name="dataId">Data file id</param>
        /// <param name="A">A-host(source)</param>
        /// <param name="B">B-host(target)</param>
        public void DataReceived(int dataId, int A, int B)
        // ReSharper restore InconsistentNaming
        {
            Records.Add(new LogEntry
            {
                LogType = LogType.DataReceived,
                Message =
                    string.Format("[{0}]: Data file(ID:{1}) has been successfully transmiited via {2}->{3}",
                                  DateTime.Now.ToLongTimeString(), dataId, A, B),
                Tick = Tick
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
                                LogType = LogType.PacketSended,
                                Message = string.Format("[{0}]: New packet([DS:{1}/{2}]) task created: {3}->{4}",
                                                        DateTime.Now.ToLongTimeString(), dataId, packetId, A, B),
                                Tick = Tick
                            });
        }
        /// <summary>
        /// Log Tick completed event, at the end of every Observer iteration
        /// </summary>
        public void TickCompleted()
        {
            Records.Add(new LogEntry
                            {
                                LogType = LogType.TickCompleted,
                                Message = string.Format("[{0}] Tick has been completed", DateTime.Now.ToLongTimeString()),
                                Tick = Tick
                            });
        }
    }
}
