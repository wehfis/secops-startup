using MessangerServer.SocketLogic.SocketManager;

namespace MessangerServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SocketManager socketManager = new SocketManager();
            socketManager.StartServer();
        }
    }
}