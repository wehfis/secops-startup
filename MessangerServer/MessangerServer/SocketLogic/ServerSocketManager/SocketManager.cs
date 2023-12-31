﻿using MessangerServer.SocketLogic.ServerEventsHandlers;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace MessangerServer.SocketLogic
{
    public class SocketManager
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public Event? eventToSend;
        const int LISTENING_PORT = 80;
        IPAddress LISTENING_ADDRESS;

        public SocketManager()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine($"Server is running ip: {address.ToString()} on port: {LISTENING_PORT}.");
                    LISTENING_ADDRESS = address;
                    break;
                }
            }

            TcpListener listener = new TcpListener(LISTENING_ADDRESS, LISTENING_PORT);
            listener.Start();
            Console.WriteLine($"Waiting client to connect...");
            client = listener.AcceptTcpClient();
            Console.WriteLine($"Client connected: {client.Connected}");
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;
        }

        public void StartServer()
        {
            var receiveTask = Task.Run(() => BackgroundRecieveListening());
            var sendTask = Task.Run(() => BackgroundSendListening());
            Task.WhenAll(receiveTask, sendTask).GetAwaiter().GetResult();
        }
        public async Task BackgroundRecieveListening()
        {
            Console.WriteLine($"BackgroundRecieveListening. Client is connected: {client.Connected}");
            while (client.Connected)
            {
                try
                {
                    string? recieve = await STR.ReadLineAsync();
                    if (!string.IsNullOrEmpty(recieve))
                    {
                        Console.WriteLine($"Server received {recieve}");
                        Event? receivedEvent = JsonSerializer.Deserialize<Event>(recieve);
                        switch (receivedEvent?.EventType)
                        {
                            case EventType.Login:
                                AuthenticationHandler.HandleLogin(receivedEvent);
                                break;
                            case EventType.Register:
                                AuthenticationHandler.HandleRegister(receivedEvent);
                                break;
                            case EventType.GetAllUsersExceptCurrent:
                                DataRequestHandler.HandleGetAllUsersExceptCurrent(receivedEvent);
                                break;
                            case EventType.GetAllMessagesFromDialog:
                                DataRequestHandler.HandleGetAllMessagesFromDialog(receivedEvent);
                                break;
                            case EventType.SendMessage:
                                DataRequestHandler.HandleSendMessageToDialog(receivedEvent);
                                break;
                        }
                    }
                    await Task.Delay(100);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public void SendEvent(Event eventObj)
        {
            this.eventToSend = eventObj;
        }

        public async Task BackgroundSendListening()
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
                        Console.WriteLine($"Server send {serializedEvent}");
                        eventToSend = null;
                    }
                    await Task.Delay(100);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
