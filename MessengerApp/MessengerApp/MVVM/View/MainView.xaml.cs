using MessengerApp.ClientSocketLogic.ClientEventsGenerators;
using MessengerApp.ClientSocketLogic.ClientSocketManager;
using MessengerApp.ClientSocketLogic.Models;
using MessengerApp.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private List<User> Users { get; set; }
        private Dialog currentDialog { get; set; }

        private List<Message> Messages { get; set; }

        private void RequestUsers()
        {
            if (UserStore.currentUser.Email != null)
            {
                var request = RequestEventGenerator.UsersExceptCurrentRequest(UserStore.currentUser.Email);
                SocketInitializer.clientSocketManager.eventToSend = request ;
            }
        }

        public MainView()
        {
            InitializeComponent();
            RequestUsers();
            userEmailProfileTextBox.Text = UserStore.currentUser.Email;
            userNicknameProfileTextBox.Text = UserStore.currentUser.Nickname;
            Messages = new List<Message>() { new Message { Content = "hello" }, new Message { Content = "hello" }, new Message { Content = "hello" }, new Message { Content = "hello" }, new Message { Content = "hello" }, new Message { Content = "hello" }, new Message { Content = "hello" }, new Message { Content = "hello" }, new Message { Content = "hello" }, new Message { Content = "hello" } };
            messageListBox.ItemsSource = Messages;
        }

        public void SetAviableUsers(List<User> users)
        {
            Users = users;
            dynamicListBox.ItemsSource = Users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.RedirectToAnotherwindow<WelcomeView>();
        }

        private void dynamicListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // request dialog and set it
        }
    }
}
