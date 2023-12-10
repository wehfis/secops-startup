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
                EventType = EventType.GetAllUsersExceptCurrent,
                Parameters = new Dictionary<string, object> {
                { "email", email }
            }
            };
        }
    }
}
