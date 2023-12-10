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
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : Window
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            SignUpView newWindow = new SignUpView();
            newWindow.Show();
            this.Close();
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginView newWindow = new LoginView();
            newWindow.Show();
            this.Close();
        }
    }
}
