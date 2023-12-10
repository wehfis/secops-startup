using MessengerApp.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessengerApp.MVVM
{
    public static class WindowManager
    {
        private static Window currentWindow;

        public static Window SetCurrentWindow
        {
            set { currentWindow = value; }
        }

        public static void RedirectToMain()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MainView newWindow = new MainView();
                newWindow.Show();
                currentWindow.Close();
                currentWindow = newWindow;
            });
        }

        public static void RedirectToLogin()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                LoginView newWindow = new LoginView();
                newWindow.Show();
                currentWindow.Close();
                currentWindow = newWindow;
            });
        }

        public static void RedirectToRegister()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                SignUpView newWindow = new SignUpView();
                newWindow.Show();
                currentWindow.Close();
                currentWindow = newWindow;
            });
        }
    }
}
