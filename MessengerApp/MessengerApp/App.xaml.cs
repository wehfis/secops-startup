using MessengerApp.ClientSocketLogic.ClientSocketManager;
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
        }
    }
}
