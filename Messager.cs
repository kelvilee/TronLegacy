﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace Pong
{
    class Messager
    {
        Thread receiver;

        public Messager()
        {
            receiver = new Thread(receiveMessage);
            receiver.Start();
        }

        public void sendMessage(Player p)
        {
            UdpClient sock = new UdpClient();
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("239.69.69.69"), 9050);
            //IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            string json = JsonConvert.SerializeObject(p);
            byte[] data = Encoding.ASCII.GetBytes(json);
            sock.Send(data, data.Length, iep);
            sock.Close();
        }

        public void receiveMessage()
        {
            IPEndPoint multiep = new IPEndPoint(IPAddress.Parse("239.69.69.69"), 9050);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
            sock.ExclusiveAddressUse = false;
            sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(IPAddress.Parse("239.69.69.69")));
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            EndPoint ep = (EndPoint)multiep;
            sock.Bind(iep);
            byte[] data = new byte[1024];
            string stringData;
            int recv;
            while (true)
            {
                recv = sock.ReceiveFrom(data, ref ep);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine("received: {0}  from: {1}", stringData, ep.ToString());
            }
        }
    }
}
