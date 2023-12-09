using MessangerServer.SocketLogic.SocketManager.EventModel;
using MessangerServer.SocketLogic.SocketManager.ServerEventsHandlers;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text.Json;

namespace MessangerServer.SocketLogic.SocketManager
{
    internal class SocketManager
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string? TextToSend;
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

        internal void StartServer()
        {
            var receiveTask = Task.Run(() => BackgroundRecieveListening());
            var sendTask = Task.Run(() => BackgroundSendListening());
            Task.WhenAll(receiveTask, sendTask).GetAwaiter().GetResult();
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
                            }
                        }
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
                    if (TextToSend != "" && TextToSend != null)
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
