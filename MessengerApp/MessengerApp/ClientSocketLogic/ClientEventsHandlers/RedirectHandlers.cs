using MessengerApp.MVVM;
using MessengerApp.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ClientSocketLogic.ClientEventsHandlers
{
    public static class RedirectHandlers
    {
        public static void LoginRedirect()
        {
            WindowManager.RedirectToMain();
        }
        public static void RegisterRedirect()
        {
            WindowManager.RedirectToMain();
        }
    }
}
