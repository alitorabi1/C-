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

namespace CustomDialogNames
{
    /// <summary>
    /// Interaction logic for EnterStringDialog.xaml
    /// </summary>
    public partial class EnterStringDialog : Window
    {
        public string ValueEntered;
        
        public EnterStringDialog(string message)
        {
            InitializeComponent();
            lblMessage.Content = message;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            ValueEntered = tbInput.Text;
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            tbInput.SelectAll();
            tbInput.Focus();
        }
    }
}
