using MessangerServer.SocketLogic;

namespace MessangerServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SocketInitializer.InitializeSocket();
            SocketInitializer.serverSocketManager.StartServer();
        }
    }
}