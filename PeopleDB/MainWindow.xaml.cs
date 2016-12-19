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

namespace PeopleDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;
        public MainWindow()
        {
            InitializeComponent();
            MakePersonList();
        }

        public void MakePersonList()
        {
            try
            {
                db = new Database();
            }
            catch (Exception ex)
            {
                // TODO: Show a messagebox to user
                MessageBox.Show("Fatal Error: unable to connect to database",
                    "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
                //throw ex;
            }
            try
            {
                List<Person> pList = db.GetAllPersons();
                dgPerson.ItemsSource = pList;
//                return pList;
            }
            catch (Exception ex)
            {
                // TODO: Show a messagebox to user
                MessageBox.Show("Unable to fetch records from database",
                    "Database Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void refreshingGUI()
        {
            lbId.Content = "";
            tbAge.Text = "";
            tbName.Text = "";
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            // FIXME: verify user data is correct
            string name = tbName.Text;
            int age = int.Parse(tbAge.Text);
            Person p = new Person() { Name = name, Age = age };
            db.AddPerson(p);
            MakePersonList();
            refreshingGUI();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgPerson.SelectedItem == null)
            {
                MessageBox.Show("Please select an item from list.",
                    "No item is selected Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult mbResult = MessageBox.Show("Are you sure to delete the current record?",
                "Deleting confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.No) return;

            Person selectedPerson = new Person() { Id = int.Parse(lbId.Content.ToString()), Name = tbName.Text, Age = int.Parse(tbAge.Text) };
            db.UpdatePersons(selectedPerson);
            MakePersonList();
//            refreshingGUI();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgPerson.SelectedItem == null)
            {
                MessageBox.Show("Please select an item from list.",
                    "No item is selected Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult mbResult = MessageBox.Show("Are you sure to delete the current record?",
                "Deleting confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.No) return;
            Person selectedPerson = (Person)dgPerson.SelectedItem;
            db.DeletePersonsById(selectedPerson.Id);
            MakePersonList();
            refreshingGUI();
        }

        private void dgPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgPerson.SelectedItem == null)
            {
                //if there is no selection dissable buttons Update and Add
                btUpdate.IsEnabled = false;
                btDelete.IsEnabled = false;
            }
            else
            {
                //if there is a selectoin enable buttons Update and Add
                btUpdate.IsEnabled = true;
                btDelete.IsEnabled = true;
                //if there is a selection populate text boxes and combo box with the properties of the objetc selected in data grid
                Person selectedPerson = (Person)dgPerson.SelectedItem;
                lbId.Content = selectedPerson.Id + "";
                tbName.Text = selectedPerson.Name;
                tbAge.Text = selectedPerson.Age + "";

            }
        }

    }
}
