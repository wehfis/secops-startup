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
        public LoginView()
        {
            InitializeComponent();
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
            string password = passwordTextBox.Password.ToString();

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
            string password = passwordTextBox.Password.ToString();

            emailErrorLabel.Text = "";
            passwordErrorLabel.Text = "";

            if (string.IsNullOrWhiteSpace(email))
            {
                emailErrorLabel.Text = "Email cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                passwordErrorLabel.Text = "Password cannot be empty.";
            }
        }
        public void setCustomError(string errorMessage)
        {
            anotherErrorLabel.Text = errorMessage;
        }
    }
}
