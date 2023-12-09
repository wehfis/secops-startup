using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerServer.SocketLogic
{
    public static class SocketInitializer
    {
        public static SocketManager serverSocketManager;

        public static void InitializeSocket()
        {
            serverSocketManager = new SocketManager();
            serverSocketManager.StartServer();
        }
    }
}
