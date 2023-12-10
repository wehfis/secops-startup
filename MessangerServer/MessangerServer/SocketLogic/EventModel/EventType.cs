using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerServer.SocketLogic
{
    public enum EventType
    {
        Login,
        LoginResponse,
        LoginRedirect,
        Register,
        RegisterResponse,
        RegisterRedirect
    }
}
