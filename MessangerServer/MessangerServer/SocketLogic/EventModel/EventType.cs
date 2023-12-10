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
        LoginErrorResponse,
        LoginSucessResponse,
        GetAllUsersExceptCurrent,
        Error,
        Register,
        RegisterErrorResponse,
        RegisterSucessResponse
    }
}
