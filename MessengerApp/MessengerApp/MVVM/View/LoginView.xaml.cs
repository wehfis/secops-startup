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
