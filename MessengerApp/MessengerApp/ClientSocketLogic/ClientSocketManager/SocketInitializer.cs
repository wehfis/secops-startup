using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ClientSocketLogic.ClientSocketManager
{
    public static class SocketInitializer
    {
        public static ClientSocketManager clientSocketManager;

        public static void InitializeSocket()
        {
            clientSocketManager = new ClientSocketManager();
            clientSocketManager.Connect();
        }
    }
}
