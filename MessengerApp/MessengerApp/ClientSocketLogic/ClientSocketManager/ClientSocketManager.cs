﻿using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using MessengerApp.ClientSocketLogic.EventModel;
using MessengerApp.ClientSocketLogic.ClientEventsGenerators;
using System.Text.Json;
using System.Configuration;
using MessengerApp.ClientSocketLogic.ClientEventsHandlers;

namespace MessengerApp.ClientSocketLogic.ClientSocketManager
{
    public class ClientSocketManager
    {
        private readonly IPAddress serverIp;
        private readonly int serverPort = 80;
        private readonly StreamReader? STR;
        private readonly StreamWriter? STW;
        private readonly TcpClient client;
        public Event? eventToSend;

        public ClientSocketManager()
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

        public void Connect()
        {
            var receiveTask = Task.Run(() => BackgroundRecieveListening());
            var sendTask = Task.Run(() => BackgroundSendListening());
        }

        public void SendEvent(Event eventObj)
        {
            this.eventToSend = eventObj;
        }

        public async Task BackgroundRecieveListening()
        {
            while (client.Connected)
            {
                try
                {
                    string? recieve = await STR.ReadLineAsync();
                    if (!string.IsNullOrEmpty(recieve))
                    {
                        Event? receivedEvent = JsonSerializer.Deserialize<Event>(recieve);
                        switch (receivedEvent?.EventType)
                        {
                            case EventType.Login:
                                break;
                            case EventType.LoginSuccessResponse:
                                ResponseHandlers.SucсessReponseHandler(receivedEvent);
                                break;
                            case EventType.RegisterSuccessResponse:
                                ResponseHandlers.SucсessReponseHandler(receivedEvent);
                                break;
                            case EventType.LoginErrorResponse:
                                ResponseHandlers.LoginErrorReponseHandler(receivedEvent);
                                break;
                            case EventType.RegisterErrorResponse:
                                ResponseHandlers.SignUpErrorReponseHandler(receivedEvent);
                                break;
                            case EventType.GetAllUsersExceptCurrent:
                                ResponseHandlers.UsersExceptCurrentResponse(receivedEvent);
                                break;
                            case EventType.GetAllMessagesFromDialogResponse:
                                ResponseHandlers.MessagesFromDialogResponse(receivedEvent);
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
        public async Task BackgroundSendListening()
        {
            while (client.Connected)
            {
                try
                {
                    if (eventToSend != null)
                    {
                        string? serializedEvent = JsonSerializer.Serialize(eventToSend);
                        await STW.WriteLineAsync(serializedEvent);
                    }
                    eventToSend = null;
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
