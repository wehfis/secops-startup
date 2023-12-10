using MessengerApp.ClientSocketLogic.EventModel;
using MessengerApp.MVVM;
using MessengerApp.MVVM.View;
using MessengerApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ClientSocketLogic.ClientEventsHandlers
{
    public static class ResponseHandlers
    {
        public static void SucessReponseHandler(Event eventObj)
        {
            UserStore.currentUserEmailState = eventObj.Parameters["email"].ToString();
            UserStore.currentUserPasswordlState = eventObj.Parameters["password"].ToString();
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
    }
}
