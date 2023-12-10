using MessengerApp.ClientSocketLogic.ClientEventsGenerators;
using MessengerApp.ClientSocketLogic.ClientSocketManager;
using MessengerApp.ClientSocketLogic.EventModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MessengerApp.MVVM.View
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : Window
    {
        public SignUpView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            validateTextBoxes();

            string email = emailTextBox.Text;
            string nickname = nicknameTextBox.Text;
            string password = passwordTextBox.Text;

            Event generatedEvent = AuthEventGenerator.GenerateRegisterEvent(email, nickname, password);
            SocketInitializer.clientSocketManager.SendEvent(generatedEvent);
        }

        public void validateTextBoxes()
        {
            string email = emailTextBox.Text;
            string nickname = nicknameTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                emailErrorLabel.Text = "Email cannot be empty.";
            }
            else
            {
                emailErrorLabel.Text = "";
            }

            if (string.IsNullOrWhiteSpace(nickname))
            {
                nicknameErrorLabel.Text = "Email cannot be empty.";
            }
            else
            {
                nicknameErrorLabel.Text = "";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                passwordErrorLabel.Text = "Password cannot be empty.";
            }
            else
            {
                passwordErrorLabel.Text = "";
            }
            setCustomError("Andrii LOX");

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(nickname))
            {
                return;
            }
        }

        public void setCustomError(string errorMessage)
        {
            anotherErrorLabel.Text = errorMessage;
        }
    }
}
