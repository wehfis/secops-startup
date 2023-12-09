﻿using MessengerApp.ClientSocketLogic.ClientEventsGenerators;
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
            Event generatedEvent = AuthEventGenerator.GenerateRegisterEvent("andrii", "andrulik", "psaaword");
            SocketInitializer.clientSocketManager.SendEvent(generatedEvent);
        }
    }
}
