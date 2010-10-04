﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ADSCourseProject
{
    [Obsolete]
    public delegate void ObserverEventHandler(NetStateArgs e);

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

        private Random _rnd = new Random();
        public Observer(ObserverParameters parameters)
        {
            Cancelling = false;

            Parameters = parameters;

            Packets = new List<Packet>();
        }

        [Obsolete]
        public event ObserverEventHandler ObserverStateChanged;

        [Obsolete]
        private void InvokeObserverStateChanged()
        {
            ObserverEventHandler handler = ObserverStateChanged;
            if (handler != null) handler(new NetStateArgs { Time = DateTime.Now.ToLongTimeString() });
        }
     
        public NetStateArgs Tick(object o)
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

            return new NetStateArgs { Time = DateTime.Now.ToLongTimeString(), O = (int)2 };
        }        

        public void CreatePackets()
        {
            throw new NotImplementedException();
        }

        public void UpdatePackets()
        {
            throw new NotImplementedException();
        }
    }
}
