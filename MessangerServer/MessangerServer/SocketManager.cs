using System.Net;
using System.Net.Sockets;

namespace MessangerServer
{
    internal class SocketManager
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string? recieve;
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
