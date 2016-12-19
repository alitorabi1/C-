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

namespace CustomDialogNames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonEnterFirst_Click(object sender, RoutedEventArgs e)
        {
            EnterStringDialog dialog = new EnterStringDialog("Please enter your first name");
            if (dialog.ShowDialog() == true)
            { // if user pressed "Save"
                string valueEntered = dialog.ValueEntered;
                lblFirstName.Content = valueEntered;
            }
        }

        private void ButtonEnterLast_Click(object sender, RoutedEventArgs e)
        {
            EnterStringDialog dialog = new EnterStringDialog("Please enter your last name");
            if (dialog.ShowDialog() == true)
            { // if user pressed "Save"
                string valueEntered = dialog.ValueEntered;
                lblLastName.Content = valueEntered;
            }
        }
    }
}
