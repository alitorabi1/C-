using Microsoft.Win32;
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

namespace ZooGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Animal> animalList = new List<Animal>();

        public MainWindow()
        {
            InitializeComponent();
            dgAnimals.ItemsSource = animalList;
            // dgAnimals.Columns = 

        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            // FIXME: handle IO and parsing exceptions!
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Zoo files (*.zoo)|*.zoo|All files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                string filename = ofd.FileName;
                string[] lineArray = File.ReadAllLines(filename);
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
                //
                dgAnimals.Items.Refresh();
            }
        }
    }
}
