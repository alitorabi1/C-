using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;



namespace ZooUpdate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declare and initialise list of Animal objects to populate the data grid
        List<Animal> animalList = new List<Animal>();
        //Decalre and initialize list of species strings to populate the combo box
        List<string> speciesList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            dgAnimals.ItemsSource = animalList;
            comboBoxSpecies.ItemsSource = speciesList;

            btnDelete.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            SaveAsMenuITem.IsEnabled = false;
            dgAnimals.IsReadOnly = true;
            dgAnimals.SelectionMode = DataGridSelectionMode.Single;

            //Get a CollectionViewSource wich would implement Interface INotifyCollectionChanged to handle events related to update ItemSource in datagrid
            CollectionView dgAnimalsCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dgAnimals.Items);
            ((INotifyCollectionChanged)dgAnimalsCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(dgAnimals_CollectionChanged);


        }

        private void dgAnimals_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Enable SaveMenuItem and Context menu if there are items in datagrid view and disable if there are not
            SaveAsMenuITem.IsEnabled = (dgAnimals.Items.Count != 0);
            DeleteContextMenu.IsEnabled = (dgAnimals.Items.Count != 0);
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Clear the list every time a new file is opened
            animalList.Clear();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Zoo Files (*.zoo) | *.zoo";
            if (ofd.ShowDialog() == true)
            {
                try
                {
                    string[] linesList = File.ReadAllLines(ofd.FileName);
                    foreach (string line in linesList)
                    {
                        string[] splittedLine = line.Split(';');
                        string species = splittedLine[0];
                        int age = int.Parse(splittedLine[1]);
                        string name = splittedLine[2];
                        double weight = double.Parse(splittedLine[3]);
                        animalList.Add(new Animal() { Species = species, Age = age, Name = name, Weight = weight });
                        speciesList.Add(species);
                    }
                    dgAnimals.Items.Refresh();
                    comboBoxSpecies.Items.Refresh();

                }
                catch (IOException ex)
                {
                    MessageBox.Show("Could not Write to file " + ex.Message);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error parsing doument");
                }

            }

        }
        private void dgAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAnimals.SelectedItem == null)
            {
                //if there is no selection dissable buttons Update and Add
                btnUpdate.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
            else
            {
                //if there is a selectoin enable buttons Update and Add
                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
                //if there is a selection populate text boxes and combo box with the properties of the objetc selected in data grid
                Animal selectedAnimal = (Animal)dgAnimals.SelectedItem;
                comboBoxSpecies.SelectedItem = selectedAnimal.Species;
                tbAge.Text = selectedAnimal.Age + "";
                tbName.Text = selectedAnimal.Name;
                tbWeight.Text = selectedAnimal.Weight + "";

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //if there are invalid inputs return
            if (!ValidateInput())
            {
                return;
            }
            Animal animal = getNewAnimal();
            //Add the new Animal to the grid
            animalList.Add(animal);
            dgAnimals.Items.Refresh();
            //Add the new species to the list of species or change the list of specises declared at the top into a HashSet(but since we didn't learn that yet, I chose this solution)
            if (!speciesList.Contains(animal.Species))
            {
                speciesList.Add(animal.Species);
                comboBoxSpecies.Items.Refresh();
            }

        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            if (!ValidateInput())
            {
                return;
            }

            Animal newAnimal = getNewAnimal();
            Animal selectedAnimal = (Animal) dgAnimals.SelectedItem;
            selectedAnimal.Species = newAnimal.Species;
            selectedAnimal.Age = newAnimal.Age;
            selectedAnimal.Name = newAnimal.Name;
            selectedAnimal.Weight = newAnimal.Weight;
            //refresh the grid
            dgAnimals.Items.Refresh();
            //Add the new species to the list of species
            if (!speciesList.Contains(newAnimal.Species))
            {

                speciesList.Add(newAnimal.Species);
                comboBoxSpecies.Items.Refresh();
            }
        }
        private bool ValidateInput()
        {
            //TODO: Ask teacher if it is a good idea to validate properties in setters of Animal class, and to catch exception at instantiation rather than valiadate input fields
            if (comboBoxSpecies.SelectedItem == null && comboBoxSpecies.Text == "")
            {
                MessageBox.Show("Please choose a species from the drop down menu or write it in the input field", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            string name = tbName.Text;
            if (name.Length < 2)
            {
                MessageBox.Show("Name must be at least two characters long", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            int age;
            if (!int.TryParse(tbAge.Text, out age) || age < 0 || age > 500)
            {
                MessageBox.Show("Age  must be a number betwee 0-500", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            double weight;
            if (!double.TryParse(tbWeight.Text, out weight) || weight < 0 || weight > 100000)
            {
                MessageBox.Show("Weight must between 0-100000", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecord();
        }

        private void DeleteRecord()
        {

            MessageBoxResult answer = MessageBox.Show("Are you sure you want to delete row " + (dgAnimals.SelectedIndex + 1) + "?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (answer == MessageBoxResult.OK)
            {
                IEditableCollectionView items = dgAnimals.Items;
                if (items.CanRemove)
                {
                    items.RemoveAt(dgAnimals.SelectedIndex);
                }
                /* The solution throws an OutOFRange Exception when user uses sorting for columns, because it's messing up the indexes
            animalList.RemoveAt(dgAnimals.SelectedIndex);
            dgAnimals.Items.Refresh();
            */
            }
        }

     

        private void ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecord();
        }
        private Animal getNewAnimal()
        {
            string species = "";
            if (comboBoxSpecies.SelectedItem == null)
            {
                species = comboBoxSpecies.Text.Trim();
            }
            else
            {
                species = comboBoxSpecies.SelectedItem.ToString();
            }

            int age = int.Parse(tbAge.Text);
            string name = tbName.Text;
            double weight = double.Parse(tbWeight.Text);
            Animal animal = new Animal() { Species = species, Age = age, Name = name, Weight = weight };
            return animal;
        }
        private void SaveAsMenuITem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Zoo Files (*.zoo) | *.zoo";
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    using (StreamWriter sW = new StreamWriter(sfd.FileName))
                    {
                        foreach (Animal animal in animalList)
                        {
                            sW.WriteLine(string.Format("{0};{1};{2};{3};", animal.Species, animal.Age, animal.Name, animal.Weight));
                        }
                    }
                }
                catch (IOException)
                {

                    MessageBox.Show("Could not Save File " + sfd.FileName + ".zoo");
                }
            }
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // approximate floating point number: ^[0-9]+(\.[0-9]*)?$
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }

    internal class Animal
    {
        public string Species { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
    }
}
