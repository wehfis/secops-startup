using MessengerApp.ClientSocketLogic.EventModel;
using MessengerApp.ClientSocketLogic.Models;
using MessengerApp.ClientSocketLogic.DTO;
using MessengerApp.MVVM;
using MessengerApp.MVVM.View;
using MessengerApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MessengerApp.ClientSocketLogic.ClientEventsHandlers
{
    public static class ResponseHandlers
    {
        public static void SucсessReponseHandler(Event eventObj)
        {
            string? email = eventObj.Parameters["email"]?.ToString();
            string? nickname = eventObj.Parameters["nickname"]?.ToString();
            string? password = eventObj.Parameters["password"]?.ToString();
            UserStore.currentUser = new User { Email = email, Nickname = nickname, Password = password };
            WindowManager.RedirectToAnotherwindow<MainView>();
        }

        public static void LoginErrorReponseHandler(Event eventObj)
        {
            WindowManager.SetLoginViewError(eventObj.Parameters["message"].ToString());
        }
        public static void SignUpErrorReponseHandler(Event eventObj)
        {
            WindowManager.SetSignUpViewViewError(eventObj.Parameters["message"].ToString());
        }

        public static void UsersExceptCurrentResponse(Event eventObj)
        {
            if (eventObj.Parameters["users"].ToString() != null)
            {
                List<User>? users = JsonSerializer.Deserialize<List<User>>(eventObj.Parameters["users"].ToString());
                WindowManager.SetMainViewUsers(users);
            }
        }

        public static void MessagesFromDialogResponse(Event eventObj)
        {
            if (eventObj.Parameters["dialogMessages"].ToString() != null)
            {
                List<MessageDTO>? messages = JsonSerializer.Deserialize<List<MessageDTO>>(eventObj.Parameters["dialogMessages"].ToString());
                WindowManager.SetMainViewChatMessages(messages);
            }
        }
    }
}
