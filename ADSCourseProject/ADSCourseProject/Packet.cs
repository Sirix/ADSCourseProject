using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADSCourseProject
{
    public class Packet
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }

        public DateTime Timestamp { get; set; }
        public int Size { get; set; }

        public override string ToString()
        {
            return string.Format("[{0} -> {1}]:[{2}], Size: {3}\r\n", Sender, Receiver, Timestamp, Size);
        }
    }
}
