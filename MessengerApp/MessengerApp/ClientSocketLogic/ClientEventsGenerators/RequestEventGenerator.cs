using MessengerApp.ClientSocketLogic.EventModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ClientSocketLogic.ClientEventsGenerators
{
    public static class RequestEventGenerator
    {
        public static Event UsersExceptCurrentRequest(string email)
        {
            return new Event
            {
                EventType = EventType.Login,
                Parameters = new Dictionary<string, object> {
                { "currentUserEmail", email }
            }
            };
        }
    }
}
