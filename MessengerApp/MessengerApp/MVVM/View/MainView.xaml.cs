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
        public class CustomItem
        {
            public string Name { get; set; }
            public string Description { get; set; }
            // Add more properties based on your data
        }
        public ObservableCollection<CustomItem> Items { get; set; }

        public MainView()
        {
            InitializeComponent();
            Items = new ObservableCollection<CustomItem>();
            dynamicListBox.ItemsSource = Items;

            // Add some sample data (you can replace this with your dynamic data)
            Items.Add(new CustomItem { Name = "Item 1", Description = "Description for Item 1" });
            Items.Add(new CustomItem { Name = "Item 2", Description = "Description for Item 2" });
        }
    }
}
