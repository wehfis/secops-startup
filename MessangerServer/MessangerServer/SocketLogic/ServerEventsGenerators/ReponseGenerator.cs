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
        public static Event GenerateSuccessResponse(EventType eventType, User user)
        {
            return new Event
            {
                EventType = eventType,
                Parameters = new Dictionary<string, object> {
                { "email", user.Email },
                { "nickname", user.Nickname },
                { "password", user.Password }
            }
            };
        }

        public static Event GetAllUsersExceptCurrentResponse(IEnumerable<User> users)
        {
            return new Event
            {
                EventType = EventType.GetAllUsersExceptCurrent,
                Parameters = new Dictionary<string, object> {
                        { "users", users.ToList() }
                }
            };
        }

        public static Event GetAllMessagesFromDialogResponse(IEnumerable<Message> messages)
        {
            return new Event
            {
                EventType = EventType.GetAllUsersExceptCurrent,
                Parameters = new Dictionary<string, object> {
                        { "dialogMessages", messages.ToList() }
                }
            };
        }
    }
}
