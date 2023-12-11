﻿using MessengerApp.ClientSocketLogic.ClientEventsGenerators;
using MessengerApp.ClientSocketLogic.ClientSocketManager;
using MessengerApp.ClientSocketLogic.DTO;
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
        private List<MessageDTO> Messages { get; set; }

        private void RequestUsers()
        {
            if (UserStore.currentUser.Email != null)
            {
                var request = RequestEventGenerator.UsersExceptCurrentRequest(UserStore.currentUser.Email);
                SocketInitializer.clientSocketManager.eventToSend = request ;
            }
        }

        private void RequestMessagesFromDialog()
        {
            if (UserStore.currentUser.Email != null)
            {
                var request = RequestEventGenerator.MessagesFromDialogRequest(UserStore.currentUser.Email, DialogStore.dialogUser.Email);
                SocketInitializer.clientSocketManager.eventToSend = request;
            }
        }

        private void RequestSendMessage(User sender, User receiver, string message)
        {
            if (UserStore.currentUser.Email != null)
            {
                var request = RequestEventGenerator.SendMessageToDialogRequest(sender.Email, receiver.Email, message);
                SocketInitializer.clientSocketManager.eventToSend = request;
            }
        }

        public MainView()
        {
            InitializeComponent();
            RequestUsers();
            userEmailProfileTextBox.Text = UserStore.currentUser.Email;
            userNicknameProfileTextBox.Text = UserStore.currentUser.Nickname;
        }

        public void SetAviableUsers(List<User> users)
        {
            Users = users;
            dynamicListBox.ItemsSource = Users;
        }

        public void SetChatMessages(List<MessageDTO> messages)
        {
            Messages = messages;
            dynamicListBox.ItemsSource = Users;
            messageListBox.ItemsSource = Messages;
            chatPanel.Visibility = Visibility.Visible;
            noChatLabel.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.RedirectToAnotherwindow<WelcomeView>();
        }

        private void dynamicListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedUser = dynamicListBox.SelectedItem as User;
            if (selectedUser != null)
            {
                DialogStore.dialogUser = new User { Email= selectedUser.Email, Nickname = selectedUser.Nickname };
                RequestMessagesFromDialog();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var currentUser = UserStore.currentUser;
            var dialogUser = DialogStore.dialogUser;
            var messageToSend = messageTextBox.Text;
            if (currentUser != null && dialogUser != null && messageToSend != string.Empty)
            {
                RequestSendMessage(currentUser, dialogUser, messageToSend);
            }
        }
    }
}
