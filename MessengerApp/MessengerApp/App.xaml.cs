using MessengerApp.ClientSocketLogic.ClientSocketManager;
using MessengerApp.MVVM;
using MessengerApp.MVVM.View;
using System.Windows;

namespace MessengerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SocketInitializer.InitializeSocket();
            WelcomeView welcomeView = new WelcomeView();
            welcomeView.Show();
            WindowManager.SetCurrentWindow = welcomeView;
        }
    }
}
