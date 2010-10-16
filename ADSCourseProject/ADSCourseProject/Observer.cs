using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ADSCourseProject
{
    public class Observer
    {
        /// <summary>
        /// Indicates when Observer object must stop emulate network.
        /// </summary>
        public bool Cancelling { get; set; }

        /// <summary>
        /// List of packets in network. This property is read-only.
        /// </summary>
        public List<Packet> Packets { get; private set; }

        /// <summary>
        /// Retrieves Observer object parameters. This property is read-only.
        /// </summary>
        public ObserverParameters Parameters { get; private set; }

        /// <summary>
        /// Retrieves list of network connections. This property is read-only.
        /// </summary>
        public List<ChannelInformation> Channels { get; private set; }


        private Random _rnd = new Random();

        /// <summary>
        /// Initializes new instance of Observer with parameters
        /// </summary>
        /// <param name="parameters">Observer Parameters</param>
        public Observer(ObserverParameters parameters)
        {
            Cancelling = false;

            Parameters = parameters;

            Packets = new List<Packet>();

            this.CreateNetwork(Parameters.ComputersCount);
        }
     
        public void Tick(object o)
        {
            int packetsCount = _rnd.Next(0, Parameters.ComputersCount);

            packetsCount = 2;
            for (int i = 0; i < packetsCount; i++)
            {
                int sender, receiver;
                //preventing from self packet sending
                do
                {
                    sender = _rnd.Next(0, Parameters.ComputersCount);
                    receiver = _rnd.Next(0, Parameters.ComputersCount);
                } while (sender == receiver /*|| (Parameters.Graph[sender, receiver] == -1)*/);

                Packets.Add(new Packet
                                {
                                    PacketId = Packets.Count + 1,
                                    Sender = sender,
                                    Receiver = receiver,
                                    Size = _rnd.Next(1, Parameters.MaxPacketSize),
                                    Timestamp = DateTime.Now
                                });
            }

            //Packet updating 


            //
            //TODO: Update sleep interval to (WaitingTimeInterval - RealTime)
            Thread.Sleep(Parameters.TimeInterval);
            //this.Cancelling = true;
        }        

        public void CreatePackets()
        {
            throw new NotImplementedException();
        }

        public void UpdatePackets()
        {
            throw new NotImplementedException();
        }

        public void CreateNetwork(int computersCount)
        {
            Channels = new List<ChannelInformation>();

            int leftConnections = computersCount * 2;

            while (leftConnections > 0)
            {
                int sender = _rnd.Next(0, computersCount);
                int target = _rnd.Next(0, computersCount);

                //select random broadband capacity
                int capacity = this.Parameters.ChannelSizes[_rnd.Next(0, this.Parameters.ChannelSizes.Length)];

                //no self-to-self connections
                if (sender == target) continue;

                if (Channels.Find(ci => (ci.A == sender && ci.B == target) || (ci.A == target && ci.B == sender)) == null)
                {
                    Channels.Add(new ChannelInformation { A = sender, B = target, Load = 0, MaxLoad = capacity });
                    leftConnections--;
                }
            }
        }
    }
}
