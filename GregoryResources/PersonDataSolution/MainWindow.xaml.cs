using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PersonDataSolution
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

        private void listNationality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)listNationality.SelectedItem).Content;
            if (item == null)
            {
                return;
            }
            if (item.ToString() == "Canadian")
            {
                lblCanadianPassport.IsEnabled = true;
                tbCanadianPassport.IsEnabled = true;
                lblCanadianPostalCode.IsEnabled = true;
                tbCanadianPostalCode.IsEnabled = true;
            }
            else
            {
                tbCanadianPassport.Text = "";
                tbCanadianPostalCode.Text = "";
                lblCanadianPassport.IsEnabled = false;
                tbCanadianPassport.IsEnabled = false;
                lblCanadianPostalCode.IsEnabled = false;
                tbCanadianPostalCode.IsEnabled = false;
            }
        }

        private void btnAddToFile_Click(object sender, RoutedEventArgs e)
        {
            string firstName = tbFirstName.Text;
            string lastName = tbLastName.Text;
            if (firstName.Length < 2 || lastName.Length < 2)
            {
                MessageBox.Show("Invalid input. FirstName and lastName must be at least 2 characters long");
                return;
            }
            if (dpDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Invalid input. Please select a valid Date of Birth");
                return;
            }
            string dob = ((DateTime)dpDatePicker.SelectedDate).ToString("yyyy-MM-dd");

            string gender = "";
            // if-else-if... chain
            if (rbMale.IsChecked == true)
            {
                gender = "Male";
            } else if (rbFemale1.IsChecked == true)
            {
                gender = "Female";
            }
            else
            {
                gender = "N/A";
            }

            /*
            RadioButton[] radioButtonsList = { rbMale, rbFemale1, rbNA };
            foreach (RadioButton rb in radioButtonsList)
            {
                if (rb.IsChecked == true)
                {
                    gender = rb.Content.ToString();
                    break;
                }
            }*/

            /*
            List<string> likesList = new List<string>();
            if (cbCats.IsChecked == true)
            {
                likesList.Add(cbCats.Content.ToString());
            }            
            if (cbDogs.IsChecked == true)
                {
                    likesList.Add(cbDogs.Content.ToString());
                }
            if (cbBoats.IsChecked == true)
                {
                    likesList.Add(cbBoats.Content.ToString());
                }
            string likesString = string.Join(",", likesList);
            */

            string choicesToAppend = "";
            {
                List<string> likesList = new List<string>();
                CheckBox[] checkBoxesList = { cbCats, cbDogs, cbBoats };
                foreach (CheckBox cb in checkBoxesList)
                {
                    if (cb.IsChecked == true)
                    {
                        likesList.Add(cb.Content.ToString());
                    }
                }

                choicesToAppend = string.Join(",", likesList);
            }

            string nationality = ((ComboBoxItem)listNationality.SelectedItem).Content.ToString();
            if (nationality == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a nationality");
                return;
            }
            string canadianPassport = "";
            string canadianPostalCode = "";

            if (nationality == "Canadian")
            {
                canadianPassport = tbCanadianPassport.Text;
                Regex regexPassport = new Regex("^[A-Z]{2}[0-9]{6}$");
                if (!regexPassport.IsMatch(canadianPassport))
                {
                    MessageBox.Show("Invalid input. Passport must be in format AA012345");
                    return;
                }
                canadianPostalCode = tbCanadianPostalCode.Text;
                Regex regexPostalCode = new Regex(@"^([A-Z]\d){3}$", RegexOptions.IgnoreCase);
                if (!regexPostalCode.IsMatch(canadianPostalCode))
                {
                    MessageBox.Show("Invalid input. postal code must be in format A0A0A0");
                    return;
                }

            }
            string lineToAppend = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};",
                firstName, lastName, dob, gender, choicesToAppend, nationality, canadianPassport, canadianPostalCode);
            try
            {
                File.AppendAllText("personData.txt", lineToAppend + Environment.NewLine);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Could not Write to File " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error occured. " +
                    "Could not Write to File " + ex.Message);
            }


        }

    }
}
