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
    }
}
