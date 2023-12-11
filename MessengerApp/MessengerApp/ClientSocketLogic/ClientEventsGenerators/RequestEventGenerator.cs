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
        public static Event MessagesFromDialogRequest(string currentUserEmail, string dialogUserEmail)
        {
            return new Event
            {
                EventType = EventType.GetAllMessagesFromDialog,
                Parameters = new Dictionary<string, object> {
                { "currentUserEmail", currentUserEmail },
                { "dialogUserEmail", dialogUserEmail } 
            }
            };
        }
        public static Event SendMessageToDialogRequest(string senderUserEmail, string receiverUserEmail, string messageToSend)
        {
            return new Event
            {
                EventType = EventType.SendMessage,
                Parameters = new Dictionary<string, object> {
                { "senderUserEmail", senderUserEmail },
                { "receiverUserEmail", receiverUserEmail },
                { "message", messageToSend }
            }
            };
        }
    }
}
