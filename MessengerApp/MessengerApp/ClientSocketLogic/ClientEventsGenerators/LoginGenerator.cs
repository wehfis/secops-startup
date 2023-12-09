using MessengerApp.ClientSocketLogic.EventModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ClientSocketLogic.ClientEventsGenerators
{
    internal static class LoginGenerator
    {
        public static Event GenerateLoginEvent(string email, string password)
        {
            return new Event
            {
                EventType = EventType.Login,
                Parameters = new Dictionary<string, object> {
                { "email", email },
                { "password", password }
            }
            };
        }
    }
}
