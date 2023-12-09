using MessengerApp.ClientSocketLogic.ClientEventsGenerators;
using MessengerApp.ClientSocketLogic.ClientSocketManager;
using MessengerApp.ClientSocketLogic.EventModel;
using System.Windows;
using System.Windows.Input;

namespace MessengerApp.MVVM.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        Person person = new Person { Name = "ANDRII"};
        public LoginView()
        {
            InitializeComponent();
            this.DataContext = person;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;
            Event generatedEvent = AuthEventGenerator.GenerateLoginEvent(email, password);
            SocketInitializer.clientSocketManager.SendEvent(generatedEvent);
        }
    }
    public class Person
    {

        private string nameValue;

        public string Name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }

    }
}
