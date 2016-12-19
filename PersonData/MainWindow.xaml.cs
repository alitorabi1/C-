using System;
using System.Collections.Generic;
using System.IO;
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

namespace PersonData
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

        public string rbContent;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cmbNationality.SelectedItem;
            string value = item.Content.ToString();
            if (item.Content == null)
            {
                return;
            }
            string country = item.Content.ToString();
            if (country == "Canadian")
            {
                // enable tbPassportNo, tbPostalCode
                txPassNo.IsEnabled = true;
                txPostalcode.IsEnabled = true;
            }
            else
            {
                // disable tbPassportNo, tbPostalCode
                // set "" to both text boxes
                txPassNo.IsEnabled = false;
                txPostalcode.IsEnabled = false;
                txPassNo.Text = "";
                txPostalcode.Text = "";
            }
        }

        private void btAddToFile_Click(object sender, RoutedEventArgs e)
        {
            string data;
            data = txFName.Text + "; ";
            data += txLName.Text + "; ";
            data += dpBirthdate.Text + "; ";

            switch(rbContent)
            {
                case "Male":
                    data += "Male; ";
                    break;
                case "Female":
                    data += "Female; ";
                    break;
                case "N/A":
                    data += "N/A; ";
                    break;
                default:
                    data += "; ";
                    break;
            }

            if (chbxCats.IsChecked == true && chbxDogs.IsChecked == true && chbxRabbits.IsChecked == true)
            {
                data += "Cats and Dogs and Rabbits; ";
            }
            else if (chbxCats.IsChecked == true && chbxDogs.IsChecked == true)
            {
                data += "Cats and Dogs; ";
            }
            else if (chbxDogs.IsChecked == true && chbxRabbits.IsChecked == true)
            {
                data += "Dogs and Rabbits; ";
            }
            else if (chbxCats.IsChecked == true && chbxRabbits.IsChecked == true)
            {
                data += "Cats and Rabbits; ";
            }
            else if (chbxCats.IsChecked == true)
            {
                data += "Cats; ";
            }
            else if (chbxDogs.IsChecked == true)
            {
                data += "Dogs; ";
            }
            else if (chbxRabbits.IsChecked == true)
            {
                data += "Rabbits; ";
            }
            else
            {
                data += "; ";
            }
            ComboBoxItem item = (ComboBoxItem)cmbNationality.SelectedItem;
            string value = item.Content.ToString();
            switch (value)
            {
                case "Canadian":
                    data += "Canadian; ";
                    data += txPassNo.Text + "; ";
                    data += txPostalcode.Text + "; ";
                    break;
                case "American":
                    data += "American; ";
                    data += "; ";
                    data += "; ";
                    break;
                case "Citizen of the world":
                    data += "Citizen of the world; ";
                    data += "; ";
                    data += "; ";
                    break;
                default:
                    data += "; ";
                    data += "; ";
                    data += "; ";
                    break;
            }
            File.AppendAllText("PersonData.txt", data + Environment.NewLine);
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // ... Get RadioButton reference.
            var button = sender as RadioButton;

            // ... Display button content as title.
            rbContent = button.Content.ToString();
        }
    }
}
