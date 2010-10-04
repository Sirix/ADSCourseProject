using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADSCourseProject
{
    /// <summary>
    /// Describes the state of current packet, e.g. it's route
    /// </summary>
    public class PacketState
    {
        /// <summary>
        /// Current packet instance
        /// </summary>
        public Packet Packet { get; private set; }

        /// <summary>
        /// Current host id, on which packet located
        /// </summary>
        public int CurrentHost { get; set; }

        /// <summary>
        /// Proposing route to end point
        /// </summary>
        public List<int> Route { get; set; }
    }
}
