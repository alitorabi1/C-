using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace ZooFull
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string currentFilePath = "";

        List<Animal> animalList = new List<Animal>();

        public MainWindow()
        {
            InitializeComponent();
            dgAnimals.ItemsSource = animalList;
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            // FIXME: handle IO and parsing exceptions!
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Zoo files (*.zoo)|*.zoo|All files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                currentFilePath = ofd.FileName;
                string[] lineArray = File.ReadAllLines(currentFilePath);
                foreach (string line in lineArray)
                {
                    string[] data = line.Split(';');
                    Animal a = new Animal()
                    {
                        Species = data[0],
                        Age = int.Parse(data[1]),
                        Name = data[2],
                        Weight = double.Parse(data[3])
                    };
                    animalList.Add(a);
                }
                refreshingGUI();
                //
                dgAnimals.Items.Refresh();
            }
        }

        private void MenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Zoo Files (*.zoo, *.zoos)|*.zoo;*.zoos|All Files (*.*)|*.*";
            sfd.AddExtension = true;
            sfd.DefaultExt = ".zoo";
            if (sfd.ShowDialog() == true)
            {
                currentFilePath = sfd.FileName;
                try
                {
                    //TextWriter sw = new StreamWriter(currentFilePath);
                    int rowcount = dgAnimals.Items.Count;
                    for (int i = 0; i < rowcount; i++)
                    {
                        Animal newAnimal = (Animal)dgAnimals.Items[i];
                        string newAnimalStr = newAnimal.Species + ";" + newAnimal.Age + ";"
                        + newAnimal.Name + ";" + newAnimal.Weight + "\r\n";
                        File.AppendAllText(currentFilePath, newAnimalStr);
                    }
                }
                catch (IOException ex)
                {
                    // FIXME: show a dialog box here
                    throw ex;
                }
            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = sender as DataGrid;
            var selected = grid.SelectedItems;

            // ... Add all Names to a List.
            foreach (var item in selected)
            {
                var animal = item as Animal;
                this.cbSpecies.Text = animal.Species;
                this.tbName.Text = animal.Name;
                this.tbAge.Text = animal.Age.ToString();
                this.tbWeight.Text = animal.Weight.ToString();
            }
        }


        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!errorMessagesHandler()) {
                return;
            }
            try
            {
                Animal newAnimal = new Animal() { Species = cbSpecies.Text, Age = int.Parse(tbAge.Text), Name = tbName.Text, Weight = double.Parse(tbWeight.Text) };
//                string newAnimalStr = newAnimal.Species + ";" + newAnimal.Age + ";"
//                    + newAnimal.Name + ";" + newAnimal.Weight;
//                File.AppendAllText(currentFilePath, newAnimalStr + Environment.NewLine);
                animalList.Add(newAnimal);
            }
            catch (IOException ex)
            {
                // FIXME: show a dialog box here
                throw ex;
            }
            MessageBox.Show("New animal was added successfuly.", "Add Animal", 
                MessageBoxButton.OK, MessageBoxImage.Information);
            refreshingGUI();
        }

        private void refreshingGUI()
        {
            dgAnimals.ItemsSource = null;
            dgAnimals.ItemsSource = animalList;
            cbSpecies.Text = "";
            tbName.Text = "";
            tbAge.Text = "";
            tbWeight.Text = "";
        }

        private bool errorMessagesHandler()
        {
            if (cbSpecies.SelectedItem == null)
            {
                MessageBox.Show("Please select a specie from species.",
                    "Selection missing",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (tbAge.Text == "" || ( int.Parse(tbAge.Text) < 1 && int.Parse(tbAge.Text) > 500) )
            {
                MessageBox.Show("Age must be between 0 and 500 years.",
                    "Entering the Age of animal Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (tbName.Text.Length < 2)
            {
                MessageBox.Show("Name must be atleast two characters.",
                    "Entering the Name of animal Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (tbWeight.Text == "" || ( double.Parse(tbWeight.Text) < 1 && double.Parse(tbWeight.Text) > 100000) )
            {
                MessageBox.Show("Weight must be between 0 and 100000 kg.",
                    "Entering Weight Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgAnimals.SelectedItem == null)
            {
                MessageBox.Show("Please select an animal from list.",
                    "No animal is selected Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            errorMessagesHandler();
            MessageBoxResult mbResult = MessageBox.Show("Are you sure to update the current record?",
                "Updating confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.No) return;
            try
            {
                Animal animalToUpdate = (Animal)dgAnimals.SelectedItem;
                animalList.Remove(animalToUpdate);

                Animal newAnimal = new Animal() { Species = cbSpecies.Text, Age = int.Parse(tbAge.Text), Name = tbName.Text, Weight = double.Parse(tbWeight.Text) };
                animalList.Add(newAnimal);

                File.Delete(currentFilePath);
                TextWriter tw = new StreamWriter(currentFilePath);
                foreach (Animal a in animalList)
                {
                    tw.WriteLine(a.Species + ";" + a.Age + ";" + a.Name + ";" + a.Weight);
                }
                tw.Close();
            }
            catch (IOException ex)
            {
                // FIXME: show a dialog box here
                throw ex;
            }
            MessageBox.Show("Selected animal was updated successfuly.", "Update Animal",
                MessageBoxButton.OK, MessageBoxImage.Information);
            refreshingGUI();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgAnimals.SelectedItem == null)
            {
                MessageBox.Show("Please select an animal from list.",
                    "No animal is selected Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!errorMessagesHandler())
            {
                return;
            }
            MessageBoxResult mbResult = MessageBox.Show("Are you sure to delete the current record?",
                "Deleting confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.No) return;
            try
            {
                Animal animalToRemove = (Animal)dgAnimals.SelectedItem;
                animalList.Remove(animalToRemove);

                File.Delete(currentFilePath);
                TextWriter tw = new StreamWriter(currentFilePath);
                foreach (Animal a in animalList)
                {
                    tw.WriteLine(a.Species + ";" + a.Age + ";" + a.Name + ";" + a.Weight);
                }
                tw.Close();
            }
            catch (IOException ex)
            {
                // FIXME: show a dialog box here
                throw ex;
            }
            MessageBox.Show("Selected animal was deleted successfuly.", "Add Animal",
                MessageBoxButton.OK, MessageBoxImage.Information);
            refreshingGUI();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnDataGridItemPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Preview MouseRightButtonDown");

            e.Handled = true;
        }
    }
}