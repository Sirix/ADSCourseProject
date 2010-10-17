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
        /// Maximum data size(in packets) in network
        /// </summary>
        public int MaxDataSize { get; set; }

        /// <summary>
        /// Maximum count of data files created in network per one tick
        /// </summary>
        public int MaxDataCountPerTick { get; set; }

        /// <summary>
        /// List of allowed channel maxload(simultaneously, in packets) values
        /// </summary>
        public IEnumerable<int> ChannelSizes { get; set; }

        public ObserverParameters()
        {
            MaxDataSize = 10;
            MaxDataCountPerTick = 2;
            ChannelSizes = new int[] {1, 5, 7, 10};
        }
    }
}
