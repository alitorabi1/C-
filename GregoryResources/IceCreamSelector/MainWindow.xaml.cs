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

namespace IceCreamSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] initialFlavoursList = { "Vanilla", "Chocolate", "Stawberry", "Pistachios", "Cookie cream" };
            /* foreach (string item in initialFlavoursList)
            {
                lvAvailable.Items.Add(item);
            } */
        }

        private void doAddFlavour()
        {
            if (lvAvailable.SelectedItem == null)
            {
                MessageBox.Show("Please select a flavour to add it",
                    "Selection missing",
                    MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else if (lvChoosen.Items.Count >= 3)
            {
                MessageBox.Show("You are only allowed to choose up to 3 scoops",
                    "Brain feeze alert",
                    MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                ListViewItem item = (ListViewItem)lvAvailable.SelectedItem;
                lvAvailable.Items.Remove(item);
                lvChoosen.Items.Add(item);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            doAddFlavour();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lvChoosen.SelectedItem == null)
            {
                MessageBox.Show("Please select a flavour to remove it",
                    "Selection missing",
                    MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                ListViewItem item = (ListViewItem)lvChoosen.SelectedItem;
                lvChoosen.Items.Remove(item);
                lvAvailable.Items.Add(item);
            }
        }

        private void lvAvailable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            doAddFlavour();
        }

        private void lvChoosen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btRemove.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }
}
