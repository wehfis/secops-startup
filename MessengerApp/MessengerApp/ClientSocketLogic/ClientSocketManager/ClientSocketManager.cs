using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MessengerApp.ClientSocketLogic.EventModel;
using MessengerApp.ClientSocketLogic.ClientEventsGenerators;
using System.Text.Json;
using System.Configuration;

namespace MessengerApp.ClientSocketLogic.ClientSocketManager
{
    internal class ClientSocketManager
    {
        private readonly IPAddress serverIp;
        private readonly int serverPort = 80;
        private readonly StreamReader? STR;
        private readonly StreamWriter? STW;
        private readonly TcpClient? client;
        public string? recieve;
        public Event? eventToSend = LoginGenerator.GenerateLoginEvent("andrii", "mysecretpassword");

        internal ClientSocketManager()
        {
            string? serverIPString = ConfigurationManager.AppSettings["ServerIP"];
            string? serverPortString = ConfigurationManager.AppSettings["ServerPort"];

            if (serverIPString != null && serverPortString != null)
            {
                serverIp = IPAddress.Parse(serverIPString);
                serverPort = int.Parse(serverPortString);
            }
            try
            {
                Console.WriteLine("Try connect to Server");
                client = new TcpClient();
                IPEndPoint ipEnd = new IPEndPoint(serverIp, serverPort);
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
                    if (eventToSend != null)
                    {
                        string? serializedEvent = JsonSerializer.Serialize(eventToSend);
                        await STW.WriteLineAsync(serializedEvent);
                        Console.WriteLine($"You send {serializedEvent}");
                    }
                    eventToSend = null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
