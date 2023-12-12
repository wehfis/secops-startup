using MessengerApp.ClientSocketLogic.DTO;
using MessengerApp.ClientSocketLogic.Models;
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

        public static void RedirectToAnotherwindow<TWindow>() where TWindow : Window, new()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                TWindow newWindow = new TWindow();
                newWindow.Show();
                currentWindow.Close();
                currentWindow = newWindow;
            });
        }

        public static void SetLoginViewError(string message) 
        {
            var tryCastWindow = currentWindow as LoginView;
            if(tryCastWindow != null) 
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    tryCastWindow.setCustomError(message);
                });
            }
        }

        public static void SetSignUpViewViewError(string message)
        {
            var tryCastWindow = currentWindow as SignUpView;
            if (tryCastWindow != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    tryCastWindow.setCustomError(message);
                });
            }
        }

        public static void SetMainViewUsers(List<UserContactDTO> users)
        {
            var tryCastWindow = currentWindow as MainView;
            if (tryCastWindow != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    tryCastWindow.SetAviableUsers(users);
                });
            }
        }

        public static void SetMainViewChatMessages(List<MessageDTO> messages)
        {
            var tryCastWindow = currentWindow as MainView;
            if (tryCastWindow != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    tryCastWindow.SetChatMessages(messages);
                });
            }
        }
    }
}
