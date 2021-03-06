﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ADSCourseProject.Log;
using System.Diagnostics;

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
        /// Specifies id of last sended data file
        /// </summary>
        private int _lastdataFileId = 0;


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

        public object Tick()
        {
            this.CreateAndSplitDataFiles();

            this.MovePackets();

            this.CombineDataFile();

            Thread.Sleep(Parameters.TimeInterval);

            Logger.Instance.TickCompleted();
            Logger.Instance.Tick++;

            return new object();
        }

               

        /// <summary>
        /// Creates and split new data files to packets
        /// </summary>
        public void CreateAndSplitDataFiles()
        {
            int dataCount = _rnd.Next(0, Parameters.MaxDataCountPerTick);

            for (int i = 0; i < dataCount; i++)
            {
                int sender, receiver;
                //preventing from self data sending
                do
                {
                    sender = _rnd.Next(0, Parameters.ComputersCount);
                    receiver = _rnd.Next(0, Parameters.ComputersCount);
                } while (sender == receiver);
                //} while (false);

                //create data size
                int dataSize = _rnd.Next(1, Parameters.MaxDataSize);

                _lastdataFileId++;
                int dataId = _lastdataFileId;

                Logger.Instance.DataSend(dataId, dataSize, sender, receiver);

                //split into packets
                for (int j = 1; j <= dataSize; j++)
                {
                    Logger.Instance.PacketSend(j, dataId, sender, receiver);

                    Packets.Add(new Packet
                    {
                        DataId = dataId,
                        PacketId = j,
                        Sender = sender,
                        Receiver = receiver,
                        CurrentHost = sender
                    });
                }
            }
        }

        public void MovePackets()
        {
            Debug.Write("Not yet implemented\n");
        }

        private void CombineDataFile()
        {
            var datasReceived = (from p in Packets
                                 where p.Receiver == p.CurrentHost
                                 orderby p.DataId
                                 select new { p.DataId, p.Sender, p.Receiver }).Distinct().ToList();

            if (datasReceived.Count == 0) return;

            //send notify
            datasReceived.ForEach(d => Logger.Instance.DataReceived(d.DataId, d.Sender, d.Receiver));

            //remove packets
            datasReceived.ForEach(d => Packets.RemoveAll(p => p.DataId == d.DataId));
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
                int capacity = this.Parameters.ChannelSizes.ElementAt(_rnd.Next(0, Parameters.ChannelSizes.Count()));

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
