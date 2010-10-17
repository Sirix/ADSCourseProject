using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADSCourseProject.Log
{
    /// <summary>
    /// Specifies type of log entry
    /// </summary>
    [Flags]
    public enum LogType
    {
        /// <summary>
        /// New data has been sended
        /// </summary>
        DataSended,
        /// <summary>
        /// Data has been received
        /// </summary>
        DataReceived,
        /// <summary>
        /// Data has been splitted
        /// </summary>
        DataSplitted,
        /// <summary>
        /// Data has been combined
        /// </summary>
        DataCombined,
        /// <summary>
        /// New packet has been sended
        /// </summary>
        PacketSended,
        /// <summary>
        /// Packet has been received
        /// </summary>
        PacketReceived,
        /// <summary>
        /// Packet has been moved
        /// </summary>
        PacketMoved,
        /// <summary>
        /// Packet waiting at the host due to some reasons
        /// </summary>
        PacketWaiting,
        /// <summary>
        /// Channel has been overloaded
        /// </summary>
        ChannelOverload,
        /// <summary>
        /// Tick has been completed
        /// </summary>
        TickCompleted
    }
}
