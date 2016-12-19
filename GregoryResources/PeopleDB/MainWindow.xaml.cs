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
            try
            {
                db = new Database();
            }
            catch (Exception e)
            {
                // TODO: show a message box
                MessageBox.Show("Fatal error: unable to connect to database",
                    "Fatal error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
                //throw e;
            }            
            InitializeComponent();
            try
            {
                List<Person> list = db.GetAllPersons();
                dgPersonList.ItemsSource = list;
            }
            catch (Exception e)
            {
                // TODO: show a message box
                MessageBox.Show("Unable to fetch records from database",
                    "Database error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            // FIXME: verify user data is correct
            string name = tbName.Text;
            int age = int.Parse(tbAge.Text);
            Person p = new Person() { Name = name, Age = age };
            db.AddPerson(p);
            tbName.Text = "";
            tbAge.Text = "";
            List<Person> list = db.GetAllPersons();
            dgPersonList.ItemsSource = list;
        }

        int currentPersonId = 0;

        private void dgPersonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person p = (Person) dgPersonList.SelectedItem;
            if (p == null) {
                currentPersonId = 0;
                lblId.Content = "";
                return;
            }
            currentPersonId = p.Id;
            lblId.Content = p.Id;
            tbName.Text = p.Name;
            tbAge.Text = p.Age + "";
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            Person p = (Person)dgPersonList.SelectedItem;
            if (p == null)
            {
                MessageBox.Show("Please select an item for deletion",
                    "Invalid action", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            db.DeletePersonById(p.Id);
            List<Person> list = db.GetAllPersons();
            dgPersonList.ItemsSource = list;
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (currentPersonId == 0)
            {
                MessageBox.Show("Please select an item for update",
                    "Invalid action", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            // FIXME: verify user data is correct
            string name = tbName.Text;
            int age = int.Parse(tbAge.Text);
            Person p = new Person() { Id = currentPersonId, Name = name, Age = age };
            db.UpdatePerson(p);
            List<Person> list = db.GetAllPersons();
            dgPersonList.ItemsSource = list;
        }
    }
}
