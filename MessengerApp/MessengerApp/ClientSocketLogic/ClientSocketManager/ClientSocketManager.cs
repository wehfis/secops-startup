﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ClientSocketLogic.ClientSocketManager
{
    internal class ClientSocketManager
    {
        const string SERVER_IP = "192.168.0.108";
        const int SERVER_PORT = 80;
        private readonly StreamReader? STR;
        private readonly StreamWriter? STW;
        private readonly TcpClient? client;
        private readonly IPEndPoint? ipEnd;
        public string? recieve;
        public string? TextToSend = "Hello, server";

        internal ClientSocketManager()
        {
            try
            {
                Console.WriteLine("Try connect to Server");
                client = new TcpClient();
                ipEnd = new IPEndPoint(IPAddress.Parse(SERVER_IP), SERVER_PORT);
                client.Connect(ipEnd);
                STW = new StreamWriter(client.GetStream());
                STR = new StreamReader(client.GetStream());
                STW.AutoFlush = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        internal void Connect()
        {
            var receiveTask = Task.Run(() => BackgroundRecieveListening());
            var sendTask = Task.Run(() => BackgroundSendListening());
        }

        internal async Task BackgroundRecieveListening()
        {
            Console.WriteLine($"BackgroundRecieveListening. Client is connected: {client.Connected}");
            while (client.Connected)
            {
                try
                {
                    if (STR.Peek() >= 0)
                    {
                        recieve = await STR.ReadLineAsync();
                        if (recieve != null && recieve != "")
                        {
                            Console.WriteLine($"You received {recieve}");
                        }
                        recieve = "";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        internal async Task BackgroundSendListening()
        {
            Console.WriteLine($"BackgroundSendListening. Client is connected: {client.Connected}");
            while (client.Connected)
            {
                try
                {
                    await STW.WriteLineAsync(TextToSend);
                    if (TextToSend != "")
                    {
                        Console.WriteLine($"You send {TextToSend}");
                    }
                    TextToSend = "";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}