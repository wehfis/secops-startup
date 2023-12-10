using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerServer.SocketLogic.SocketEventsGenerators
{
    public static class ResponseGenerator
    {
        public static Event GenerateResponse(EventType eventType, string message)
        {
            return new Event
            {
                EventType = eventType,
                Parameters = new Dictionary<string, object> {
                { "message", message }
            }
            };
        }
        public static Event GenerateRedirect(EventType eventType)
        {
            return new Event
            {
                EventType = eventType
            };
        }
    }
}
