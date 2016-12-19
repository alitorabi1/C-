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

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool hasUnsavedChanges;

        string currentFilePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            string filename = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text File (*.txt, *.text)|*.txt;*.text|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                filename = ofd.FileName;
                try
                {
                    string text = File.ReadAllText(filename);
                    tbDocument.Text = text;
                }
                catch (IOException ex)
                {
                    // FIXME: show a dialog box here
                    throw ex;
                }
            }
        }
        private void MenuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File (*.txt, *.text)|*.txt;*.text|All Files (*.*)|*.*";
            sfd.AddExtension = true;
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == true)
            {
                string filename = sfd.FileName;
                try
                {
                    string text = tbDocument.Text;
                    File.WriteAllText(filename, text);
                    
                }
                catch (IOException ex)
                {
                    // FIXME: show a dialog box here
                    throw ex;
                }
            }

        }
        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
