using BLL.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerServer.SocketLogic.SocketEventsGenerators
{
    public static class ResponseGenerator
    {
        public static Event GenerateErrorResponse(EventType eventType, string message)
        {
            return new Event
            {
                EventType = eventType,
                Parameters = new Dictionary<string, object> {
                { "message", message }
            }
            };
        }

        // is used for Login/Register sucess responses
        public static Event GenerateSucessResponse(EventType eventType, User user)
        {
            return new Event
            {
                EventType = eventType,
                Parameters = new Dictionary<string, object> {
                { "email", user.Email },
                { "password", user.Password },
            }
            };
        }
    }
}
