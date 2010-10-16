using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADSCourseProject
{
    public class ObserverParameters
    {
        /// <summary>
        /// Count of computers in emulated network.
        /// </summary>
        public int ComputersCount { get; set; }

        /// <summary>
        /// Time for updating Observer information in milliseconds.
        /// </summary>
        public int TimeInterval { get; set; }

        /// <summary>
        /// Maximal packet size in network
        /// </summary>
        public int MaxPacketSize { get; set; }

        /// <summary>
        /// List of channel maxload values
        /// </summary>
        public int[] ChannelSizes = new int[] { 1, 5, 7, 10 };

        public ObserverParameters()
        {
            MaxPacketSize = 1024;
        }
    }
}
