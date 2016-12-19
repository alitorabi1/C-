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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IcecreamSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lvAvailable.Items.Add("Vanilla");
            lvAvailable.Items.Add("Chocolate");
            lvAvailable.Items.Add("Strawberry");
            lvAvailable.Items.Add("Blueberry");
            lvAvailable.Items.Add("Pistaccio");
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lvAvailable.SelectedItem == null) return;
            var selectedItem = (dynamic)lvAvailable.SelectedItems[0];
            lvAvailable.Items.Remove(selectedItem);
            lvMyIcecream.Items.Add(selectedItem);
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lvMyIcecream.SelectedItem == null) return;
            var selectedItem = (dynamic)lvMyIcecream.SelectedItems[0];
            lvMyIcecream.Items.Remove(selectedItem);
            lvAvailable.Items.Add(selectedItem);
        }

        private void lvAvailable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvAvailable.SelectedItem == null) return;
            var selectedItem = (dynamic)lvAvailable.SelectedItems[0];
            lvAvailable.Items.Remove(selectedItem);
            lvMyIcecream.Items.Add(selectedItem);
        }

        private void lvMyIcecream_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvMyIcecream.SelectedItem == null) return;
            var selectedItem = (dynamic)lvMyIcecream.SelectedItems[0];
            lvMyIcecream.Items.Remove(selectedItem);
            lvAvailable.Items.Add(selectedItem);
        }
    }
}
