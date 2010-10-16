using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADSCourseProject
{
    public class Packet
    {
        /// <summary>
        /// Specifies id of data - one file, which size is bigger than max packet size. This value is incrementing whih each file sended.
        /// </summary>
        public int DataId { get; set; }

        /// <summary>
        /// Specifies id of packet in files, which size is bigger than max packet size. This value is in range from 1..infinity in each file sended.
        /// </summary>
        public int PacketId { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }

        public DateTime Timestamp { get; set; }
        public int Size { get; set; }

        public override string ToString()
        {
            return string.Format("Packet {4}: [{0} -> {1}]:[{2}], Size: {3}\r\n", Sender, Receiver, Timestamp, Size, PacketId);
        }
    }
}
