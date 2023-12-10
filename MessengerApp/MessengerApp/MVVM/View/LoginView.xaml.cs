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
            validateTextBoxes();

            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;

            Event generatedEvent = AuthEventGenerator.GenerateLoginEvent(email, password);
            SocketInitializer.clientSocketManager.SendEvent(generatedEvent);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.RedirectToAnotherwindow<WelcomeView>();
        }
        public void validateTextBoxes()
        {
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                emailErrorLabel.Text = "Email cannot be empty.";
            }
            else
            {
                emailErrorLabel.Text = "";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                passwordErrorLabel.Text = "Password cannot be empty.";
            }
            else
            {
                passwordErrorLabel.Text = "";
            }

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return;
            }
        }
        public void setCustomError(string errorMessage)
        {
            anotherErrorLabel.Text = errorMessage;
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
