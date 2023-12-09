using MessangerServer.SocketLogic.SocketManager.EventModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerServer.SocketLogic.SocketManager.ServerEventsHandlers
{
    public static class AuthenticationHandler
    {
        public static void HandleLogin(Event eventParam)
        {
            // get email + password from eventParam dictionary
            // handle login with checking data base for this user
        }
    }
}
