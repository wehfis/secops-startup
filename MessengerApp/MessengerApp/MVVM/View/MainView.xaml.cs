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
        public ObservableCollection<User> Users { get; set; }
        public class CustomItem
        {
            public string Name { get; set; }
            public string Description { get; set; }
            // Add more properties based on your data
        }

        private void RequestUsers()
        {
            if (UserStore.currentUserEmailState != null)
            {
                var request = RequestEventGenerator.UsersExceptCurrentRequest(UserStore.currentUserEmailState);
                SocketInitializer.clientSocketManager.eventToSend = request ;
            }
        }

        public MainView()
        {
            InitializeComponent();
            RequestUsers();
            userEmailProfileTextBox.Text = UserStore.currentUserEmailState;
            //Items = new ObservableCollection<CustomItem>();
            //dynamicListBox.ItemsSource = Items;

            // Add some sample data (you can replace this with your dynamic data)
            //Items.Add(new CustomItem { Name = "Item 1", Description = "Description for Item 1" });
            //Items.Add(new CustomItem { Name = "Item 2", Description = "Description for Item 2" });
            //Items.Add(new CustomItem { Name = "Item 1", Description = "Description for Item 1" });
            //Items.Add(new CustomItem { Name = "Item 2", Description = "Description for Item 2" });
            //Items.Add(new CustomItem { Name = "Item 1", Description = "Description for Item 1" });
            //Items.Add(new CustomItem { Name = "Item 2", Description = "Description for Item 2" });
            //Items.Add(new CustomItem { Name = "Item 1", Description = "Description for Item 1" });
            //Items.Add(new CustomItem { Name = "Item 2", Description = "Description for Item 2" });
            //Items.Add(new CustomItem { Name = "Item 1", Description = "Description for Item 1" });
            //Items.Add(new CustomItem { Name = "Item 2", Description = "Description for Item 2" });
        }

        public void SetAviableUsers(List<User> users)
        {
            Users = new ObservableCollection<User>(users);
            dynamicListBox.ItemsSource = Users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.RedirectToAnotherwindow<WelcomeView>();
        }
    }
}
