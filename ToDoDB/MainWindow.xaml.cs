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

namespace ToDoDB
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
                List<ToDoItem> list = db.GetAllItems();
                dgToDoItem.ItemsSource = list;
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
            string description = tbDescription.Text;
            DateTime? date = dpDueDate.SelectedDate;
            if (date == null || tbDescription.Text == "")
            {
                // ... A null object.
                MessageBox.Show("Please make sure you entered all items", "Error in Data Entry", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            DateTime dueDate = dpDueDate.SelectedDate.Value;
            int isDone = 0;
            if ((bool)cbIsDone.IsChecked)
            {
                isDone = 1;
            }
            ToDoItem t = new ToDoItem() { Description = description, DueDate = dueDate, IsDone = isDone };
            db.AddItem(t);
            tbDescription.Text = "";
            dpDueDate.Text = "";
            List<ToDoItem> list = db.GetAllItems();
            dgToDoItem.ItemsSource = list;
        }

        int currentPersonId = 0;

        private void dgItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToDoItem t = (ToDoItem)dgToDoItem.SelectedItem;
            if (t == null)
            {
                currentPersonId = 0;
                lbId.Content = "";
                return;
            }
            currentPersonId = t.Id;
            lbId.Content = t.Id;
            tbDescription.Text = t.Description;
            dpDueDate.SelectedDate = t.DueDate;
            cbIsDone.IsChecked = false;
            if (t.IsDone == 1)
            {
                cbIsDone.IsChecked = true;
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem t = (ToDoItem)dgToDoItem.SelectedItem;
            if (t == null)
            {
                MessageBox.Show("Please select an item for deletion",
                    "Invalid action", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            db.DeleteItemsById(t.Id);
            List<ToDoItem> list = db.GetAllItems();
            dgToDoItem.ItemsSource = list;
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
            string description = tbDescription.Text;
            DateTime dueDate = dpDueDate.SelectedDate.Value;
            int isDone = 0;
            if ((bool)cbIsDone.IsChecked)
            {
                isDone = 1;
            }
            ToDoItem t = new ToDoItem() { Description = description, DueDate = dueDate, IsDone = isDone };
            db.UpdateItems(t);
            List<ToDoItem> list = db.GetAllItems();
            dgToDoItem.ItemsSource = list;
        }

    }
}
